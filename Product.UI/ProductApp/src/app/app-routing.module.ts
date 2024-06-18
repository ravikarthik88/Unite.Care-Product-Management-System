import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashLayoutComponent } from './layouts/dash-layout/dash-layout.component';
import { HomeComponent } from './layouts/home/home.component';
import { GeneralLayoutComponent } from './layouts/general-layout/general-layout.component';
import { LoginComponent } from './layouts/login/login.component';
import { RegisterComponent } from './layouts/register/register.component';

const routes: Routes = [
  {
    path:'',
    redirectTo:'/login',
    pathMatch:'full'
  },
  {
    path:'home',
    component:GeneralLayoutComponent,
    children:[
      {path:'',component:HomeComponent,pathMatch:'full'}
    ]
  },
  {
    path:'dashboard',
    component:DashLayoutComponent,
    children:[
      {
        path:'',
        loadChildren:() => import('./layouts/dash-layout/dash-layout.module').then(m=> m.DashLayoutModule)
      }
    ]
  },
  {path:'/login',component:LoginComponent,pathMatch:'full'},
  {path:'/register',component:RegisterComponent,pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
