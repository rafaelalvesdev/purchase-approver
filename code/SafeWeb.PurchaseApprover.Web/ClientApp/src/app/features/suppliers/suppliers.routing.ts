import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AuthenticatedGuard } from '../../core/guards/authenticated.guard';
import { SupplierListComponent } from './pages/supplier-list/supplier-list.component';
import { SupplierDetailsComponent } from './pages/supplier-details/supplier-details.component';

const routes: Routes = [
    {
        path: 'suppliers', canActivate: [AuthenticatedGuard], children: [
            { path: '', component: SupplierListComponent, pathMatch: 'full', canActivate: [AuthenticatedGuard] },
            { path: 'add', component: SupplierDetailsComponent, canActivate: [AuthenticatedGuard] },
            { path: ':id', component: SupplierDetailsComponent, canActivate: [AuthenticatedGuard] },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class SupplierRoutingModule { }

export const routedComponents = [
    SupplierDetailsComponent,
    SupplierListComponent
];

export const publicRoutes = [
    { route: 'suppliers', title: 'Categorias' }
];
