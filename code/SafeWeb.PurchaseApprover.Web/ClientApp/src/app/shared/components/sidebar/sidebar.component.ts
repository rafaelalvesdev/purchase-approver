import { Component, OnInit, Input } from '@angular/core';
import { CoreShellService } from '../../../core/services/core-shell.service';
import { ISidebarItem } from './sidebar-item.interface';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {

    @Input()
    menus: ISidebarItem[];

}
