import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { HttpBaseService } from '../../core/services/http-base.service';

import { ISupplier } from '../../core/models/supplier.interface';

@Injectable()
export class SuppliersService extends HttpBaseService {

    constructor(_httpClient: HttpClient) {
        super(_httpClient);
        this.resourceUrl = '/suppliers/';
    }

    save(supplier: ISupplier): Observable<ISupplier> {
        return this.postGetKey<ISupplier>(supplier);
    }

    list(): Observable<ISupplier[]> {
        return this.get<ISupplier[]>();
    }

    read(id: number): Observable<ISupplier> {
        if (id) {
            return this.get<ISupplier>(id);
        } else {
            throw Error('Parameter "id" cannot be null or undefined.')
        }
    }

    remove(id: number): Observable<boolean> {
        return this.delete(id);
    }
}
