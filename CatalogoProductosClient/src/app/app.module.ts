import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { MantenimientoProductoComponent } from './productos/mantenimiento-producto/mantenimiento-producto.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ConsultaProductosComponent } from './productos/consulta-productos/consulta-productos.component';
//import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    MantenimientoProductoComponent,
    ConsultaProductosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
