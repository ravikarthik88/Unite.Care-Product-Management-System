import { Routes } from '@angular/router';

export const routes: Routes = [
    {path:'',redirectTo:'',pathMatch:'full'},
    {
        path:'',
        loadChildren:() => import('./components/layout/layout.module').then(m=>m.LayoutModule)
    },
    {
        path:'dashboard',
        loadChildren:() => import('./components/dash-layout/dash-layout.module').then(m=>m.DashLayoutModule)
    },
    {
        path:'login',
        loadComponent:() => import('./components/layout/login/login.component').then(m=> m.LoginComponent)
    },
    {
        path:'register',
        loadComponent:() => import('./components/layout/register/register.component').then(m=> m.RegisterComponent)
    }

];
