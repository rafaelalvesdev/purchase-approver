import { Component, OnInit } from '@angular/core';

import { environment } from '../environments/environment';
import { Router, RouterEvent, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { LoaderService } from './shared/components/loader/services/loader.services';
import { CoreShellService } from './core/services/core-shell.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

    constructor(private _coreShellService: CoreShellService,
        private _router: Router,
        private loading: LoaderService) {
    }
    ngOnInit() {
        this._router.events
            .subscribe((event: RouterEvent) => {
                this._coreShellService.setTabTitle(event.url);
                this.navigationInterceptor(event)
            });
    }

    navigationInterceptor(event: RouterEvent): void {
        if (event instanceof NavigationStart) {
            this.loading.show();
        }
        if (event instanceof NavigationEnd) {
            this.loading.hide();
        }
        if (event instanceof NavigationCancel) {
            this.loading.hide();
        }
        if (event instanceof NavigationError) {
            this.loading.hide();
        }
    }
}
