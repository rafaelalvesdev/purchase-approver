import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AuthenticatedGuard } from '../../core/guards/authenticated.guard';
import { UserListComponent } from './pages/user-list/user-list.component';
import { UserDetailsComponent } from './pages/user-details/user-details.component';

const routes: Routes = [
    {
        path: 'users', canActivate: [AuthenticatedGuard], children: [
            { path: '', component: UserListComponent, pathMatch: 'full', canActivate: [AuthenticatedGuard] },
            { path: 'add', component: UserDetailsComponent, canActivate: [AuthenticatedGuard] },
            { path: ':id', component: UserDetailsComponent, canActivate: [AuthenticatedGuard] },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class UserRoutingModule { }

export const routedComponents = [
    UserDetailsComponent,
    UserListComponent
];

export const publicRoutes = [
    { route: 'users', title: 'Categorias' }
];
