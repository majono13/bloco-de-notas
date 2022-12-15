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
import { HeaderComponent } from '../components/header/header.component';
import { FooterComponent } from '../components/footer/footer.component';

@NgModule({
  declarations: [
    NavbarComponent,
    BackgroundComponent,
    ButtonComponent,
    ErrorComponent,
    SpinnerComponent,
    HeaderComponent,
    FooterComponent,
  ],
  imports: [CommonModule, MaterialModule],
  exports: [
    NavbarComponent,
    MaterialModule,
    BackgroundComponent,
    ButtonComponent,
    ErrorComponent,
    SpinnerComponent,
    HeaderComponent,
    FooterComponent,
  ],
})
export class SharedModule {}
