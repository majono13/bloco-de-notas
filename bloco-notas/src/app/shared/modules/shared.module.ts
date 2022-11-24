import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modulos
import { MaterialModule } from './material.module';

//Componentes
import { NavbarComponent } from '../components/navbar/navbar.component';
import { BackgroundComponent } from '../components/background/background.component';

@NgModule({
  declarations: [NavbarComponent, BackgroundComponent],
  imports: [CommonModule, MaterialModule],
  exports: [NavbarComponent, MaterialModule, BackgroundComponent],
})
export class SharedModule {}
