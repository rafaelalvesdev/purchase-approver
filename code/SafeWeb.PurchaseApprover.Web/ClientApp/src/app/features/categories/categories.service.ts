import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { HttpBaseService } from '../../core/services/http-base.service';

import { ICategory } from '../../core/models/category.interface';

@Injectable()
export class CategoriesService extends HttpBaseService {

    constructor(_httpClient: HttpClient) {
        super(_httpClient);
        this.resourceUrl = '/categories/';
    }

    save(category: ICategory): Observable<ICategory> {
        return this.postGetKey<ICategory>(category);
    }

    list(): Observable<ICategory[]> {
        return this.get<ICategory[]>();
    }

    read(id: number): Observable<ICategory> {
        if (id) {
            return this.get<ICategory>(id);
        } else {
            throw Error('Parameter "id" cannot be null or undefined.')
        }
    }

    remove(id: number): Observable<boolean> {
        return this.delete(id);
    }
}
