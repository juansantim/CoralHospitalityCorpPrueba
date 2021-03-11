import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductoDTO } from 'src/app/model/ProductoDTO';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-mantenimiento-producto',
  templateUrl: './mantenimiento-producto.component.html',
  styleUrls: ['./mantenimiento-producto.component.css']
})
export class MantenimientoProductoComponent implements OnInit {

  formulario:FormGroup = new FormGroup({
    codigo: new FormControl(),
    nombre: new FormControl(),
    descripcion: new FormControl(),
    tipoProducto: new FormControl(),
  });

  Producto:ProductoDTO = new ProductoDTO();
  TiposProductos:Array<any> = [];
  guardando:Boolean = false;

  constructor(private dataService:DataService, private router:Router, 
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.dataService.getTiposProductos().subscribe(tiposProductos => {
     this.TiposProductos = tiposProductos;
    });

    this.activatedRoute.params.subscribe(params => {
      let productoId = params['Id'];
      if(productoId){
        this.dataService.GetProductoById(productoId).subscribe(producto => {
          this.Producto = producto;
    
          this.formulario.get('codigo')?.setValue(producto.Codigo);
          this.formulario.get('nombre')?.setValue(producto.Nombre);
          this.formulario.get('descripcion')?.setValue(producto.Descripcion);
          this.formulario.get('tipoProducto')?.setValue(producto.TipoProductoId);
        })
      }

    })
  }

  Eliminar(){
    var confirmed = confirm('Seguro que desea eliminar este producto?');

    if(confirmed){
      this.guardando = true;
      this.dataService.Eliminar(this.Producto).subscribe(producto => {
        alert(`producto ${producto.Id} - ${producto.Nombre} eliminado satisfactoriamente`);
        this.router.navigate(['/consulta']);
      }, error => {
        console.log(error);
        this.guardando = false;
      })

    }

  }

  onSubmit(){
    if (this.formulario.valid){
      let {codigo, nombre, descripcion, tipoProducto} = this.formulario.controls;
      this.Producto.Codigo = codigo.value,
      this.Producto.Nombre = nombre.value,
      this.Producto.Descripcion = descripcion.value,
      this.Producto.TipoProductoId = tipoProducto.value;

      this.guardando = true;
      this.dataService.GuardarProducto(this.Producto).subscribe(response => {
        alert('producto registrado satisfactoriamente');
        this.router.navigate(['/consulta']);
      }, error => {
        console.log(error);
        this.guardando =false;
      })
    }
    else {
      alert('Existen errores en el formulario, todos los campos son requeridos')
    }
  }



}
