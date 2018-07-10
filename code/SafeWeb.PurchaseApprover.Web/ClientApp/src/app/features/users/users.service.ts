import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { HttpBaseService } from '../../core/services/http-base.service';

import { IUser } from '../../core/models/user.interface';

@Injectable()
export class UsersService extends HttpBaseService {

    constructor(_httpClient: HttpClient) {
        super(_httpClient);
        this.resourceUrl = '/users/';
    }

    save(user: IUser): Observable<IUser> {
        return this.postGetKey<IUser>(user);
    }

    list(): Observable<IUser[]> {
        return this.get<IUser[]>();
    }

    read(id: number): Observable<IUser> {
        if (id) {
            return this.get<IUser>(id);
        } else {
            throw Error('Parameter "id" cannot be null or undefined.')
        }
    }

    remove(id: number): Observable<boolean> {
        return this.delete(id);
    }
}
