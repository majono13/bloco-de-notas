import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modulos
import { MaterialModule } from './material.module';

//Componentes
import { NavbarComponent } from '../components/navbar/navbar.component';
import { BackgroundComponent } from '../components/background/background.component';
import { ButtonComponent } from '../components/button/button.component';
import { ErrorComponent } from '../components/error/error.component';
import { SpinnerComponent } from '../components/spinner/spinner.component';

@NgModule({
  declarations: [
    NavbarComponent,
    BackgroundComponent,
    ButtonComponent,
    ErrorComponent,
    SpinnerComponent,
  ],
  imports: [CommonModule, MaterialModule],
  exports: [
    NavbarComponent,
    MaterialModule,
    BackgroundComponent,
    ButtonComponent,
    ErrorComponent,
    SpinnerComponent,
  ],
})
export class SharedModule {}
