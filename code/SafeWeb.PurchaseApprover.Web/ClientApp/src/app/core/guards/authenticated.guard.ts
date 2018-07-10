import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthenticatedGuard implements CanActivate {

    constructor(private _router: Router,
        private _authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (!this._authService.isLoggedIn()) {
            alert('User not logged in');
            this._router.navigate(['/']);
            return false;
        }
        return true;
    }
}
