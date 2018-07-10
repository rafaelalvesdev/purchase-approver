import { Component, OnInit, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { SummaryService, ISummary, IErrorApi, ISuccessApi, IWarningApi } from './services/summary.services';



@Component({
    selector: 'app-summary',
    templateUrl: './summary.component.html',
    styleUrls: ['./summary.component.scss']
})

export class SummaryComponent implements OnInit {
    subscription: Subscription;
    @Input()
    summary: ISummary = { errors: [], warnings: [], success: [], FormGroup: null };

    ngOnInit() {
    }
    constructor(private service: SummaryService) {
        this.subscription = this.service.getSummary().subscribe(x => {
            this.summary = x;
        });
    }

    keyMapDom(key: string) {
        return '';
    }
}
