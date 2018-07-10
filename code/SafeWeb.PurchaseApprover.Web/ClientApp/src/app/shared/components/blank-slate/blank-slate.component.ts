import { Component, Input } from '@angular/core';
import { CoreShellService } from '../../../core/services/core-shell.service';

@Component({
    selector: 'app-blank-slate',
    templateUrl: './blank-slate.component.html',
    styleUrls: ['./blank-slate.component.scss']
})
export class BlankSlateComponent {

    @Input() message: string;
    @Input() buttonName: string;
    @Input() buttonUrl: string;

    @Input() defaultButtonTabName: string;
    @Input() defaultButtonTabUrl: string;

    constructor(private _coreShellService: CoreShellService) { }

    openTab() {
        this._coreShellService.openTab(this.defaultButtonTabUrl, this.defaultButtonTabName);
    }
}
