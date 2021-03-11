import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { ProductoDTO } from '../model/ProductoDTO';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  Eliminar(producto:ProductoDTO):Observable<ProductoDTO> {
    let url = this.getUrl(`/api/productos?Id=${producto.Id}`);
    return this.http.delete<ProductoDTO>(url);
  }
  GetProductoById(productoId: any):Observable<ProductoDTO> {
   let url = this.getUrl(`/api/productos?Id=${productoId}`);

   return this.http.get<ProductoDTO>(url);
  }
  GetProductos():Observable<any> {
    let url = this.getUrl('/api/productos');
    return this.http.get(url);
  }
  GuardarProducto(Producto: ProductoDTO):Observable<any> {
    let url = this.getUrl('/api/productos');
    return this.http.post(url, Producto);
  }

  getUrl(endPoint:string){
    let baseUrl = 'https://localhost:44366';
    return `${baseUrl}${endPoint}`;
  }

  getTiposProductos():Observable<any>{
    let url = this.getUrl('/api/TiposProductos');
    return this.http.get(url);
  }

  constructor(private http: HttpClient) { }
}
