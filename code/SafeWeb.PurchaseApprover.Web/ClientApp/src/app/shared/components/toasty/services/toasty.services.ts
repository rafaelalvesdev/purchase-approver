import { Injectable, Output, ComponentFactoryResolver, ViewChild } from '@angular/core';
import { Observable, Subject } from 'rxjs';

export const MenssageForType = {
    success: "Salvo com sucesso!",
    danger: "Erro ao salvar!"
}

export interface IAlert {
    type: string;
    message: string;
}
@Injectable()
export class ToastyService {
    // Alerta inject
    private objPush: Array<IAlert> = [];
    private objObservable = new Subject<Array<IAlert>>();

    constructor() { }

    showMessage(alertItem: IAlert): void {
        if (alertItem) {
            this.objObservable.next([alertItem]);
        }
    }

    alert(alerts: Array<IAlert>): void {
        this.objPush = [];
        for (var i = 0; i <= Object.keys(alerts).length; i++) {
            if (typeof alerts[i] !== undefined && alerts[i] != null) {
                this.objPush.push(alerts[i]);
            }
        }
        this.objObservable.next(this.objPush);
    }

    getAlert(): Observable<Array<IAlert>> {
        return this.objObservable.asObservable();
    }
}