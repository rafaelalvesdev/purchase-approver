import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { CategoriesService } from '../../categories.service';

import { ICategory } from '../../../../core/models/category.interface';
import { Category } from '../../../../core/models/category';

@Component({
    templateUrl: 'category-details.component.html'
})
export class CategoryDetailsComponent implements OnInit {

    category: ICategory;
    blockUI: boolean = false;

    constructor(private _router: Router,
        private _route: ActivatedRoute,
        private _service: CategoriesService) { }

    ngOnInit() {
        this.blockUI = true;
        this._route.paramMap
            .subscribe((params: ParamMap) => {
                const categoryId = +params.get('id');
                if (categoryId)
                    this._service.read(categoryId)
                        .subscribe(category => {
                            this.category = category;
                            this.blockUI = false;
                        });
                else {
                    this.category = new Category();
                    this.blockUI = false;
                }
            });
    }


    onSubmit(): void {
        this.blockUI = true;
        this._service
            .save(this.category)
            .subscribe(response => {
                console.log('response', response);
                if (response != null) {
                    this._router.navigate(['../'], { relativeTo: this._route });
                }
                this.blockUI = false;
            });
    }
}
