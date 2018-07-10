import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { SuppliersService } from '../../suppliers.service';

import { ISupplier } from '../../../../core/models/supplier.interface';
import { Supplier } from '../../../../core/models/supplier';

@Component({
    templateUrl: 'supplier-details.component.html'
})
export class SupplierDetailsComponent implements OnInit {

    supplier: ISupplier;
    blockUI: boolean = false;

    constructor(private _router: Router,
        private _route: ActivatedRoute,
        private _service: SuppliersService) { }

    ngOnInit() {
        this.blockUI = true;
        this._route.paramMap
            .subscribe((params: ParamMap) => {
                const supplierId = +params.get('id');
                if (supplierId)
                    this._service.read(supplierId)
                        .subscribe(supplier => {
                            this.supplier = supplier;
                            this.blockUI = false;
                        });
                else {
                    this.supplier = new Supplier();
                    this.blockUI = false;
                }
            });
    }


    onSubmit(): void {
        this.blockUI = true;
        this._service
            .save(this.supplier)
            .subscribe(response => {
                console.log('response', response);
                if (response != null) {
                    this._router.navigate(['../'], { relativeTo: this._route });
                }
                this.blockUI = false;
            });
    }
}
