import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modulos
import { MaterialModule } from './material.module';

//Componentes
import { NavbarComponent } from '../components/navbar/navbar.component';
import { BackgroundComponent } from '../components/background/background.component';
import { ErrorMessageComponent } from '../cpmponents/error-message/error-message.component';

@NgModule({
  declarations: [NavbarComponent, BackgroundComponent, ErrorMessageComponent],
  imports: [CommonModule, MaterialModule],
  exports: [
    NavbarComponent,
    MaterialModule,
    BackgroundComponent,
    ErrorMessageComponent,
  ],
})
export class SharedModule {}
