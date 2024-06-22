import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashLayoutRoutingModule } from './dash-layout-routing.module';
import { DashLayoutComponent } from './dash-layout.component';
import { DashSidebarComponent } from './dash-sidebar/dash-sidebar.component';
import { DashFooterComponent } from './dash-footer/dash-footer.component';
import { DashTopbarComponent } from './dash-topbar/dash-topbar.component';
import { DashContentComponent } from './dash-content/dash-content.component';
import { DashboardComponent } from './dashboard/dashboard.component';


@NgModule({
  declarations: [
    DashLayoutComponent,
    DashSidebarComponent,
    DashFooterComponent,
    DashTopbarComponent,
    DashContentComponent,
    DashboardComponent
  ],
  imports: [
    CommonModule,
    DashLayoutRoutingModule
  ]
})
export class DashLayoutModule { }
