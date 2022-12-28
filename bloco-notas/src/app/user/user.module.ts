import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { UserRoutingModule } from './user-routing.module';
import { LayoutComponent } from './layout/layout.component';

import { SharedModule } from '../shared/modules/shared.module';

import { HomeComponent } from './home/home.component';
import { ButtonAddComponent } from './shared/components/button-add/button-add.component';
import { DetailsComponent } from './details/details.component';
import { EditComponent } from './edit/edit.component';

@NgModule({
  declarations: [
    LayoutComponent,
    HomeComponent,
    ButtonAddComponent,
    DetailsComponent,
    EditComponent,
  ],
  imports: [CommonModule, UserRoutingModule, SharedModule, ReactiveFormsModule],
})
export class UserModule {}
