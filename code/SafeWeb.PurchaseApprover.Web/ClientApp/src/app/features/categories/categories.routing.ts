import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AuthenticatedGuard } from '../../core/guards/authenticated.guard';
import { CategoryListComponent } from './pages/category-list/category-list.component';
import { CategoryDetailsComponent } from './pages/category-details/category-details.component';

const routes: Routes = [
    {
        path: 'categories', canActivate: [AuthenticatedGuard], children: [
            { path: '', component: CategoryListComponent, pathMatch: 'full', canActivate: [AuthenticatedGuard] },
            { path: 'add', component: CategoryDetailsComponent, canActivate: [AuthenticatedGuard] },
            { path: ':id', component: CategoryDetailsComponent, canActivate: [AuthenticatedGuard] },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class CategoryRoutingModule { }

export const routedComponents = [
    CategoryDetailsComponent,
    CategoryListComponent
];

export const publicRoutes = [
    { route: 'categories', title: 'Categorias' }
];
