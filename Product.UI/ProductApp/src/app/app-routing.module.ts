import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashLayoutComponent } from './layouts/dash-layout/dash-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { HomeComponent } from './layouts/home/home.component';
import { GeneralLayoutComponent } from './layouts/general-layout/general-layout.component';

const routes: Routes = [
  {
    path:'',
    redirectTo:'/home',
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
  {
    path:'auth',
    component:AuthLayoutComponent,
    children:[
      {
        path:'',
        loadChildren:() =>import('./layouts/auth-layout/auth-layout.module').then(m=> m.AuthLayoutModule)
      }
    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
