import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/auth/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  isLoggedIn$!: Observable<boolean>;
  constructor(private _router: Router, private _authService: AuthService) {
    this.isLoggedIn$ = this._authService.isAuthenticated();
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
