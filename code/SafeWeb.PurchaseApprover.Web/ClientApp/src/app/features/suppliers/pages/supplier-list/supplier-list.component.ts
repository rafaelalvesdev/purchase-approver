import { Component, OnInit } from '@angular/core';

import { SuppliersService } from '../../suppliers.service';
import { ISupplier } from '../../../../core/models/supplier.interface';

@Component({
    templateUrl: 'supplier-list.component.html'
})
export class SupplierListComponent implements OnInit {
    suppliers: ISupplier[];

    constructor(private _service: SuppliersService) { }

    ngOnInit() {
        this._service
            .list()
            .subscribe(suppliers => this.suppliers = suppliers);
    }
}
