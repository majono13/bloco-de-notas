import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modulos
import { MaterialModule } from './material.module';

//Componentes
import { NavbarComponent } from '../components/navbar/navbar.component';
import { BackgroundComponent } from '../components/background/background.component';
import { ErrorMessageComponent } from '../cpmponents/error-message/error-message.component';
import { ButtonComponent } from '../components/button/button.component';

@NgModule({
  declarations: [
    NavbarComponent,
    BackgroundComponent,
    ErrorMessageComponent,
    ButtonComponent,
  ],
  imports: [CommonModule, MaterialModule],
  exports: [
    NavbarComponent,
    MaterialModule,
    BackgroundComponent,
    ErrorMessageComponent,
    ButtonComponent,
  ],
})
export class SharedModule {}
