import { Component, OnInit } from '@angular/core';

import { UsersService } from '../../users.service';
import { IUser } from '../../../../core/models/user.interface';

@Component({
    templateUrl: 'user-list.component.html'
})
export class UserListComponent implements OnInit {
    users: IUser[];

    constructor(private _service: UsersService) { }

    ngOnInit() {
        this._service
            .list()
            .subscribe(users => this.users = users);
    }
}
