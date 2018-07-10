import { Injectable, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
@Injectable()
export class CoreShellService implements OnDestroy {

    private _shell: any;
    private objObservable = new Subject<any>();

    constructor() {
        this._shell = (window.parent['$']) ? window.parent['$'].shell : false;
    }

    setTabTitle(url: string): void {
        if (this._shell && url) {
            this._shell.titleNgChange(url.substr(1, url.length));
        }
    }

    openTab(url: string, title: string, option:any = {}): void {
        var options = {
            behavior: (!option.behavior) ? 'TabSingle' : option.behavior,
            type: 'catalog',
            title: title,
            url: url
        };
        if (this._shell) {
            this._shell.addTab(options);
        }
    }

    createHolder(iframeContainer: string, url: string): void {
        this._shell.createHolder(iframeContainer, url);
    }

    ngOnDestroy(): void {
        this._shell = undefined;
    }


    setEvent(event: any) {
        window.parent.addEventListener('coreEventNg', e => {
            this.objObservable.next(e['detail'].text);
        });
    }

    getEvent(): Observable<any> {
        return this.objObservable.asObservable();
    }
}
