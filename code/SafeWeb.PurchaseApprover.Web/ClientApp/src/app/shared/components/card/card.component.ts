import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'app-card',
    templateUrl: './card.component.html',
    styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

    @Input() title: string;
    @Input() acronym: string;
    @Input() color: string;
    @Input() detailUrl: string;
    @Input() configUrl: string;

    constructor() { }

    ngOnInit() {
    }

}
