import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { environment } from '../environments/environment';

const routes: Routes = [
    { path: '', redirectTo: 'dummies', pathMatch: 'full' },
    // { path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [
        RouterModule.forRoot(
            routes,
            { enableTracing: false } // <-- debugging purposes only
        )],
    exports: [RouterModule]
})

export class AppRoutingModule { }
