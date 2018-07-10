import { Component, OnInit, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { ToastyService, IAlert } from './services/toasty.services';



@Component({
    selector: 'app-toasty',
    templateUrl: './toasty.component.html',
    styleUrls: ['./toasty.component.scss']
})

export class ToastyComponent implements OnInit {
    subscription: Subscription;
    timeout: any;

    @Input()
    alerts: Array<IAlert> = [];
    ngOnInit() {
    }

    constructor(private ToastyService: ToastyService) {
        this.subscription = this.ToastyService.getAlert().subscribe(x => {
            for (var i = 0; i < x.length; i++) {
                this.alerts.push(x[i]);
            }
            this.timeoutClear();
        });
    }
    closeAlert(alert: IAlert) {
        const index: number = this.alerts.indexOf(alert);
        this.alerts.splice(index, 1);
    }
    timeoutClear() {
        clearTimeout(this.timeout);
        this.timeout = setTimeout(x => {
            this.alerts = [];
        }, 4000);
    }

}
