import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersComponent } from './components/shippers/shippers.component';
import { SuppliersComponent } from './components/suppliers/suppliers.component';


const routes: Routes = [
  { path: '', component: SuppliersComponent},
  { path: 'shippers', component: ShippersComponent },
  { path: 'suppliers', component: SuppliersComponent },
  { path: '', redirectTo: '/suppliers', pathMatch: 'full' },
  { path: '**', component: SuppliersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
