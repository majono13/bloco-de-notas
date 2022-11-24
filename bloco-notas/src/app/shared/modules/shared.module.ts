import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modulos
import { MaterialModule } from './material.module';

//Componentes
import { NavbarComponent } from '../components/navbar/navbar.component';

@NgModule({
  declarations: [NavbarComponent],
  imports: [CommonModule, MaterialModule],
  exports: [NavbarComponent, MaterialModule],
})
export class SharedModule {}
