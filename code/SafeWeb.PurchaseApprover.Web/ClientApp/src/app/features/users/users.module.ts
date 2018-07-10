import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared/shared.module';

import { LoggerService } from '../../core/services/logger.service';

import { UserRoutingModule, routedComponents } from './users.routing';

import { UsersService } from './users.service';
import { UserProfilesService } from './user-profiles.service';

@NgModule({
  imports: [
    SharedModule,
    UserRoutingModule
  ],
  declarations: [
    routedComponents
  ],
  exports: [],
  providers: [
    UsersService,
    UserProfilesService
  ]
})

export class UsersModule {
  constructor(private logger: LoggerService) {
    this.logger.log('start business unit module!');
  }
}
