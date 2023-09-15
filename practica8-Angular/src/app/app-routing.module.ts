import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component'
import { ShippersComponent } from './components/shippers/shippers.component';
import { SuppliersComponent } from './components/suppliers/suppliers.component';


const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'shippers', component: ShippersComponent },
  { path: 'suppliers', component: SuppliersComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
