import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/auth/services/auth.service';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  isLoggedIn$!: Observable<boolean>;
  user$: Observable<User>;

  constructor(private _router: Router, private _authService: AuthService) {
    this.isLoggedIn$ = this._authService?.isAuthenticated();
    this.user$ = this._authService?.subjUser$;

    this._authService.subjUser$.subscribe((user) => console.log(user));
  }

  ngOnInit(): void {}

  navigate(url: string) {
    this._router.navigateByUrl(url);
  }

  logout() {
    this._authService.logout();
    this._router.navigateByUrl('/login');
  }
}
