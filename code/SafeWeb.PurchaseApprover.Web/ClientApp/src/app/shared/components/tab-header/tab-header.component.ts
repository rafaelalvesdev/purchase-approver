import { Component, Input } from '@angular/core';
import { CoreShellService } from '../../../core/services/core-shell.service';

@Component({
    selector: 'app-tab-header',
    templateUrl: './tab-header.component.html'
})
export class TabHeaderComponent {

    @Input() title: string;
    @Input() badgeTitle: string;
    @Input() backUrl: any[] | string;
    @Input() defaultButtonName: string;
    @Input() defaultButtonUrl: any[] | string;
    @Input() defaultButtonSubmit: boolean = false;

    @Input() defaultButtonTabName: string;
    @Input() defaultButtonTabUrl: string;

    constructor(private _coreShellService: CoreShellService) { }

    openTab() {
        this._coreShellService.openTab(this.defaultButtonTabUrl, '');
    }
}
