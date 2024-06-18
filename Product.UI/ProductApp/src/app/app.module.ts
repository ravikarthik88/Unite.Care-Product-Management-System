import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CollapseModule} from 'ngx-bootstrap/collapse';
import { GeneralHeaderComponent } from './layouts/general-header/general-header.component';
import { GeneralFooterComponent } from './layouts/general-footer/general-footer.component';
import { HomeComponent } from './layouts/home/home.component';
import { GeneralLayoutComponent } from './layouts/general-layout/general-layout.component';
import { LoginComponent } from './layouts/login/login.component';
import { RegisterComponent } from './layouts/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    GeneralHeaderComponent,
    GeneralFooterComponent,
    HomeComponent,
    GeneralLayoutComponent,    
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,    
    CollapseModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
