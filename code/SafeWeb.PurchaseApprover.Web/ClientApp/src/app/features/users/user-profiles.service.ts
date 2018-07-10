import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { HttpBaseService } from '../../core/services/http-base.service';

import { IUserProfile } from '../../core/models/user-profile.interface';

@Injectable()
export class UserProfilesService extends HttpBaseService {

    constructor(_httpClient: HttpClient) {
        super(_httpClient);
        this.resourceUrl = '/users/profiles';
    }

    list(): Observable<IUserProfile[]> {
        return this.get<IUserProfile[]>();
    }
}
