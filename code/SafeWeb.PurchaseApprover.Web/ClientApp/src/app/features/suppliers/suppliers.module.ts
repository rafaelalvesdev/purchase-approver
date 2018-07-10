import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared/shared.module';

import { LoggerService } from '../../core/services/logger.service';

import { SupplierRoutingModule, routedComponents } from './suppliers.routing';

import { SuppliersService } from './suppliers.service';

@NgModule({
  imports: [
    SharedModule,
    SupplierRoutingModule
  ],
  declarations: [
    routedComponents
  ],
  exports: [],
  providers: [
    SuppliersService
  ]
})

export class SuppliersModule {
  constructor(private logger: LoggerService) {
    this.logger.log('start business unit module!');
  }
}
