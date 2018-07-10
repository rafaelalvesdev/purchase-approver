// angular modules
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

// Third party modules
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

// pipes
import { SafePipe } from './pipes/safe.pipe';

// services
import { ToastyService } from './components/toasty/services/toasty.services';
import { SummaryService } from './components/summary/services/summary.services';
import { LoaderService } from './components/loader/services/loader.services';

// components
import { CardComponent } from './components/card/card.component';
import { ColorSeletorComponent } from './components/color-selector/color-selector.component';
import { ToastyComponent } from './components/toasty/toasty.component';
import { SummaryComponent } from './components/summary/summary.component';
import { LoaderRouterComponent, LoaderComponent } from './components/loader/loader.component';
import { TabHeaderComponent } from './components/tab-header/tab-header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { BlankSlateComponent } from './components/blank-slate/blank-slate.component';

@NgModule({
    declarations: [
        // app components
        CardComponent,
        ColorSeletorComponent,
        TabHeaderComponent,
        ToastyComponent,
        SummaryComponent,
        LoaderRouterComponent,
        LoaderComponent,
        SidebarComponent,
        BlankSlateComponent,

        // app pipes
        SafePipe
    ],
    imports: [
        // angular modules
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,

        // third party modules
        NgbModule.forRoot()
    ],
    exports: [
        // angular modules
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,

        // third party modules
        NgbModule,

        // app components
        CardComponent,
        ColorSeletorComponent,
        LoaderRouterComponent,
        LoaderComponent,
        TabHeaderComponent,
        ToastyComponent,
        SummaryComponent,
        SidebarComponent,
        BlankSlateComponent,

        // app pipes
        SafePipe
    ],
    providers: [
        ToastyService,
        LoaderService,
        SummaryService
    ],
})
export class SharedModule { }
