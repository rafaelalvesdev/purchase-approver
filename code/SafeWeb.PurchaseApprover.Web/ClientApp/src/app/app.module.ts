// angular modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';


// shell
import { AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';

// shared modules
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';

// services
import { LoggerService } from './core/services/logger.service';

// feature modules
import { UsersModule } from './features/users/users.module';
import { CategoriesModule } from './features/categories/categories.module';
import { SuppliersModule } from './features/suppliers/suppliers.module';

@NgModule({
    imports: [
        // angular modules
        BrowserModule,

        // cross modules
        SharedModule,
        CoreModule.forRoot(),

        // feature modules
        UsersModule,
        CategoriesModule,
        SuppliersModule,

        AppRoutingModule // needs to be the last module
    ],
    declarations: [
        AppComponent
    ],
    providers: [
        { provide: APP_BASE_HREF, useValue: '/v1/' }
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {
    constructor(private logger: LoggerService) {
        this.logger.log('app module constructor');
    }
}
