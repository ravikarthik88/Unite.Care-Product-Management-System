import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneralLayoutRoutingModule } from './general-layout-routing.module';
import { GeneralLayoutComponent } from './general-layout.component';
import { MainHeaderComponent } from './main-header/main-header.component';
import { MainFooterComponent } from './main-footer/main-footer.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';


@NgModule({
  declarations: [
    GeneralLayoutComponent,
    MainHeaderComponent,
    MainFooterComponent,
    HomeComponent,
    AboutComponent
  ],
  imports: [
    CommonModule,
    GeneralLayoutRoutingModule
  ]
})
export class GeneralLayoutModule { }
