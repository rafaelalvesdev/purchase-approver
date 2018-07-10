// angular modules
import { NgModule, ModuleWithProviders, Optional, SkipSelf } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// guards
import { AuthenticatedGuard } from './guards/authenticated.guard';

// services
import { AuthService } from './services/auth.service';
import { LoggerService } from './services/logger.service';
import { CoreShellService } from './services/core-shell.service';
import { ValidationInterceptor } from './interceptors/validation.interceptor';


@NgModule({
    declarations: [
    ],
    imports: [
        HttpClientModule
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: ValidationInterceptor, multi: true }
    ],
    exports: [
    ],
})
export class CoreModule {

    constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
        if (parentModule) {
            throw new Error('CoreModule is already loaded. Import it in the AppModule only');
        }
    }

    static forRoot(): ModuleWithProviders {
        return {
            ngModule: CoreModule,
            providers: [
                // app services
                AuthService,
                LoggerService,
                CoreShellService,

                // app guards
                AuthenticatedGuard,
            ]
        };
    }
}
