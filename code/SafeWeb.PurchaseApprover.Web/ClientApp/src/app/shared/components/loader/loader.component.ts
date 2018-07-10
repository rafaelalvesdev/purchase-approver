import { Component, OnInit, Input } from '@angular/core';
import {NgbProgressbarConfig} from '@ng-bootstrap/ng-bootstrap';
import { LoaderService, LoaderState } from './services/loader.services';
import { Subscription } from 'rxjs';
export interface ILoad {
    type: string;
    color:string;
}

@Component({
    selector: 'app-loader-router',
    templateUrl: './loader-router.component.html',
    styleUrls: ['./loader-router.component.scss'],
    providers: [NgbProgressbarConfig]
})
export class LoaderRouterComponent implements OnInit {
    showRouter = false;
    private subscription: Subscription;
    constructor(
        private loaderService: LoaderService
    ) { }
    ngOnInit() { 
        this.subscription = this.loaderService.loaderState
            .subscribe((state: LoaderState) => {
                this.showRouter = state.show;
        });
    }
    ngOnDestroy() {
        this.subscription.unsubscribe();
    }    
}

@Component({
    selector: 'app-loader',
    templateUrl: './loader.component.html',
    styleUrls: ['./loader.component.scss'],
    providers: [NgbProgressbarConfig]
})
export class LoaderComponent implements OnInit {
    constructor() { }
    ngOnInit() { 
    }
    ngOnDestroy() {
    }    
}
