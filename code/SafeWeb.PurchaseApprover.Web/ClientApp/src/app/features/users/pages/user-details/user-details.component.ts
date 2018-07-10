import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { UsersService } from '../../users.service';

import { IUser } from '../../../../core/models/user.interface';
import { IUserProfile } from '../../../../core/models/user-profile.interface';
import { User } from '../../../../core/models/user';
import { UserProfilesService } from '../../user-profiles.service';

@Component({
    templateUrl: 'user-details.component.html'
})
export class UserDetailsComponent implements OnInit {

    public user: IUser;
    public userProfiles: IUserProfile[];
    blockUI: boolean = false;
    loaded: boolean = false;

    constructor(private _router: Router,
        private _route: ActivatedRoute,
        private _service: UsersService,
        private _profilesService: UserProfilesService) {
    }

    ngOnInit() {
        this.blockUI = true;

        this._profilesService.list().subscribe(profiles => { this.userProfiles = profiles; });

        this._route.paramMap
            .subscribe((params: ParamMap) => {
                const userId = +params.get('id');
                if (userId)
                    this._service.read(userId)
                        .subscribe(user => {
                            this.user = user;
                            console.log(user, this.user);
                            this.blockUI = false;
                        });
                else {
                    this.user = new User();
                    this.blockUI = false;
                }
                this.loaded = true;
            });

    }


    onSubmit(): void {
        this.blockUI = true;
        this._service
            .save(this.user)
            .subscribe(response => {
                console.log('response', response);
                if (response != null) {
                    this._router.navigate(['../'], { relativeTo: this._route });
                }
                this.blockUI = false;
            });
    }
}
