import { Component, OnInit } from '@angular/core';

import { CategoriesService } from '../../categories.service';
import { ICategory } from '../../../../core/models/category.interface';

@Component({
    templateUrl: 'category-list.component.html'
})
export class CategoryListComponent implements OnInit {
    categories: ICategory[];

    constructor(private _service: CategoriesService) { }

    ngOnInit() {
        this._service
            .list()
            .subscribe(categories => {
                this.categories = categories;
            });
    }
}
