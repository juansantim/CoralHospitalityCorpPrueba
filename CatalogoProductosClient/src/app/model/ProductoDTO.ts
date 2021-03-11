export class ProductoDTO{
    Id:number;
    Nombre:string;
    Descripcion:string;
    Codigo:string;
    TipoProductoId:number;
    
    constructor(){
        this.Id = 0;
        this.Nombre = "";
        this.Descripcion = "",
        this.Codigo = "",
        this.TipoProductoId = 0
    }
}