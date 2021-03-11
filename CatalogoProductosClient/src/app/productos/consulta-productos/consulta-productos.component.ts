import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-consulta-productos',
  templateUrl: './consulta-productos.component.html',
  styleUrls: ['./consulta-productos.component.css']
})
export class ConsultaProductosComponent implements OnInit {

  productos:Array<any> = [];
  cargando:boolean = false;

  constructor(private dataService:DataService) { }

  ngOnInit(): void {
    this.cargando = true;
    this.dataService.GetProductos().subscribe(productos => {
      this.productos = productos;
      this.cargando = false;
    }, error => {
      console.log(error);
      alert('Hubo un error al mostrar datos de producto, favor verificar')
      this.cargando = false;
    })
  }

}
