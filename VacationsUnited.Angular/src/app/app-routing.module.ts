import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Import every component that you are going to make a route for 
import { HomeComponent }      from './home/home.component';

//Add routes here
const routes: Routes = [
  { path: '', component: HomeComponent }
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ]
})
export class AppRoutingModule {}