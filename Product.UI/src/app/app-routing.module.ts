import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeneralLayoutComponent } from './components/layouts/general-layout/general-layout.component';
import { DashLayoutComponent } from './components/layouts/dash-layout/dash-layout.component';

const routes: Routes = [
  {
    path: '',
    component: GeneralLayoutComponent,
    children:[
      { path:'',loadChildren: () => import('./components/layouts/general-layout/general-layout.module').then(m => m.GeneralLayoutModule) }
    ]
  }, {
    path: 'dashboard',
    component: DashLayoutComponent,
    children: [
      { path:'',loadChildren: () => import('./components/layouts/dash-layout/dash-layout.module').then(m => m.DashLayoutModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
