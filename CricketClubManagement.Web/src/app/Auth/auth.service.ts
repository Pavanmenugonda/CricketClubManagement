import { Injectable, signal } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthService {

  private _isLoggedIn = signal(false);

  constructor(private router: Router) { }

  isLoggedIn() {
    return this._isLoggedIn();
  }

  login() {
    this._isLoggedIn.set(true);
    this.router.navigate(['/home']);
  }

  logout() {
   // this._isLoggedIn.set(false);   // END SESSION
   // this.router.navigate(['/login']); // FORCE EXIT
  }
}
