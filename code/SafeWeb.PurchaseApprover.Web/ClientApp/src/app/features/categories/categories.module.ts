import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared/shared.module';

import { LoggerService } from '../../core/services/logger.service';

import { CategoryRoutingModule, routedComponents } from './categories.routing';

import { CategoriesService } from './categories.service';

@NgModule({
  imports: [
    SharedModule,
    CategoryRoutingModule
  ],
  declarations: [
    routedComponents
  ],
  exports: [],
  providers: [
    CategoriesService
  ]
})

export class CategoriesModule {
  constructor(private logger: LoggerService) {
    this.logger.log('start business unit module!');
  }
}
