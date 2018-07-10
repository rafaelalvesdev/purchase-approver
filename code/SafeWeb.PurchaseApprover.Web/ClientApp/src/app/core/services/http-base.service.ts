import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs';
import { tap, map, catchError, filter } from 'rxjs/operators';

import { environment } from '../../../environments/environment';

import { ServiceResponse } from '../models/service-response';
import { IModelBase } from '../models/model-base.interface';

@Injectable()
export class HttpBaseService {

    private httpOptions = {
        headers: { 'Accept': 'application/json; style=camel' },
        withCredentials: true
    };
    private apiUrl: string;
    protected resourceUrl: string;

    constructor(protected _httpClient: HttpClient) {
        this.apiUrl = environment.service.host + environment.service.apiPath;
    }

    /**
     * @description 
     * Make a request using GET method mapping the result into a defined type T.
     *
     * @return an `Observable` of the type T.
     */
    protected get<T>(): Observable<T>;

    /**
     * @description Make a request using GET method mapping the result into a defined type T.
     * 
     * @id parameter to concatenate in URL. 
     * 
     * @example URL that will be generated: http://host/route/id
     * 
     * @return an `Observable` of the type T.
     */
    protected get<T>(id: number): Observable<T>;

    /**
     * @description Make a request using GET method mapping the result into a defined type T.
     * 
     * @filters object that describe the filters for concatenate in URL. 
     * 
     * @example With object { filterName: filterValue } will generate the URL: http://host/route/?filterName=filterValue
     * 
     * @return an `Observable` of the type T.
     */
    protected get<T>(filters: object): Observable<T>;

    /**
     * @description Make a request using GET method mapping the result into a defined type T.
     * 
     * @id parameter to concatenate in url.
     * @filters object that describe the filters for concatenate in URL. E.g. { filterName: filterValue }
     * 
     * @example Using this two parameters the generated URL will be http://host/route/id/?filterName=filterValue
     * 
     * @return an `Observable` of the type T.
     */
    protected get<T>(id: number, filters: object): Observable<T>

    protected get<T>(idOrFilter?: number | object, filters?: object): Observable<T> {
        var url = this.createApiUrl();
        var filter: string;
        if (filters) {
            filter = this.createFilterPath(filters);

            if (idOrFilter && typeof idOrFilter === 'number') {
                url += idOrFilter;
            }

            url += filter;
        } else if (idOrFilter) {
            if (typeof idOrFilter === 'number') {
                url += idOrFilter;
            } else {
                filter = this.createFilterPath(idOrFilter);
                url += filter;
            }
        }

        return this._httpClient.get<ServiceResponse<T>>(url, this.httpOptions).pipe(
            tap(response => {
                if (!environment.production) {
                    // tslint:disable-next-line:no-console
                    console.debug(`Service response for ${url}`, response);
                }
            }),
            map(response => response.data),
            catchError(this.handleError)
        );
    }

    /**
     * @description Make a request using POST method mapping the result into a defined type T.
     *
     * @model paramter with data to create model in server.
     * 
     * @return an `Observable` of the type T.
     */
    protected post<T>(model: T): Observable<ServiceResponse<T>> {
        return this._httpClient.post<ServiceResponse<T>>(this.createApiUrl(), model, this.httpOptions)
            .pipe(
                tap(response => {
                    if (!environment.production) {
                        // tslint:disable-next-line:no-console
                        console.debug(`Service response for ${this.resourceUrl}`, response);
                    }
                }),
                catchError(this.handleError)
            );
    }

    protected postGetKey<T>(model: T): any {
        return this.post(model)
            .pipe(
                map(result => result.entityKey)
            );
    }

    protected postGetEntity<T>(model: T): Observable<T> {
        return this.post(model)
            .pipe(
                map(result => result.data)
            );
    }


    /**
     * @description Make a request using PUT method mapping the result into a defined type T.
     *
     * @model parameter with data to update model. The property id of model is required.
     * 
     * @return an `Observable` of the type T.
     */
    protected put<T>(model: T): Observable<T> {
        let id: string;
        if (model) {
            id = (<IModelBase><any>model).id.toString();
        }

        return this._httpClient.put<ServiceResponse<T>>(this.createApiUrl() + (id || ''), model, this.httpOptions)
            .pipe(
                tap(response => {
                    if (!environment.production) {
                        // tslint:disable-next-line:no-console
                        console.debug(`Service response for ${this.resourceUrl}`, response);
                    }
                }),
                map(response => response.data),
                catchError(this.handleError)
            );
    }

    /**
     * @description Make a request using DELETE method mapping the result into a defined type T.
     * 
     * @id id of model to delete.
     *
     * @return an `Observable` of the type T.
     */
    protected delete(id: number): Observable<boolean> {
        return this._httpClient.delete(this.createApiUrl() + (id || ''), this.httpOptions)
            .pipe(
                tap(response => {
                    if (!environment.production) {
                        // tslint:disable-next-line:no-console
                        console.debug(`Service response for ${this.resourceUrl}`, response);
                    }
                }),
                map(response => (<ServiceResponse<any>><any>response).isValid),
                catchError(this.handleError)
            );
    }

    /**
     * @description
     * Generate the full URL to make calls to API.
     * 
     * @return string with full API URL
     */
    protected createApiUrl(): string {
        return this.apiUrl + this.resourceUrl.replace(/-/g, '');
    }

    protected handleError(error: HttpErrorResponse) {
        console.error('Http response error.', error);
        return Observable.throw(error.message || 'Server error');
    }

    private createFilterPath(filters: object) {
        var filter: string;

        if (filters && !Object.keys(filters).isEmpty()) {
            filter = '?';
            Object.keys(filters).forEach(key => {
                filter += `${key}=${filters[key]};`;
            });
            filter = filter.slice(0, -1);
        }

        return filter;
    }
}
