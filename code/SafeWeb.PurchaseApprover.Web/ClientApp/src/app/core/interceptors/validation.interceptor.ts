import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { ISummary, SummaryService } from '../../shared/components/summary/services/summary.services';
import { ServiceResponse } from '../models/service-response';

@Injectable()
export class ValidationInterceptor implements HttpInterceptor {

    private summary: ISummary;

    constructor(private serviceSummary: SummaryService = new SummaryService()) {
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            tap((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    if (event.body) {
                        let responseBody = <ServiceResponse<any>>event.body;
                        if (!responseBody.isValid) { //response com algum error core

                            this.summary = { errors: [], success: [], warnings: [], FormGroup: null };

                            responseBody.errors.forEach(element => {
                                this.summary.errors.push(element);
                            });

                            this.serviceSummary.summary(this.summary);
                        }
                    }
                }
            })
        );
    }
}