//Modulos do Angular
import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

//Modulos
import { AuthRoutingModule } from './auth-routing.module';
import { SharedModule } from '../shared/modules/shared.module';

//Componentes
import { RegisterComponent } from './register/register.component';
import { AuthComponent } from './auth/auth.component';
import { LoginComponent } from './login/login.component';
import { AuthInterceptor } from './auth.interceptor';

@NgModule({
  declarations: [RegisterComponent, AuthComponent, LoginComponent],
  imports: [CommonModule, AuthRoutingModule, SharedModule, ReactiveFormsModule],
})
export class AuthModule {
  static forRoot(): ModuleWithProviders<any> {
    return {
      ngModule: AuthModule,
      providers: [AuthInterceptor],
    };
  }
}
