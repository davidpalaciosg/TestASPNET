using System;
using System.IO;

namespace TestWebApp.Models
{
    public class Producto
    {
        public Producto(string id, string nombreProducto, string descripcionProducto, bool activo, string imagenProducto, string observacionesProducto)
        {
            this.Id = id;
            this.nombreProducto = nombreProducto;
            this.descripcionProducto = descripcionProducto;
            this.activo = activo;
            this.imagenProducto = imagenProducto;
            this.observacionesProducto = observacionesProducto;
            this.fecha_reg = DateTime.Now;
        }
        public Producto()
        {
            this.Id="0";
            this.nombreProducto="N/A";
            this.descripcionProducto="N/A";
            this.activo=true;
            this.observacionesProducto="N/A";
            this.fecha_reg=DateTime.Now;
        }
        public string Id { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public bool activo { get; set; }
        public string imagenProducto { get; set; }
        public string observacionesProducto { get; set; }
        public DateTime fecha_reg { get; set; }
    }
}