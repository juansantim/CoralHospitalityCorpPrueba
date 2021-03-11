import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsultaProductosComponent } from './productos/consulta-productos/consulta-productos.component';
import { MantenimientoProductoComponent } from './productos/mantenimiento-producto/mantenimiento-producto.component';

const routes: Routes = [
  { path: 'consulta', component: ConsultaProductosComponent },
  { path: 'producto', component: MantenimientoProductoComponent},
  { path: 'producto/:Id', component: MantenimientoProductoComponent},

  { path: '', redirectTo: 'consulta', pathMatch: 'full' },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
