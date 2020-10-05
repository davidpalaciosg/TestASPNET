using System;
using System.IO;

namespace TestWebApp.Models
{
    public class Producto
    {
        public Producto(int id, string nombreProducto, string descripcionProducto, bool activo, string imagenProducto, string observacionesProducto)
        {
            this.id = id;
            this.nombreProducto = nombreProducto;
            this.descripcionProducto = descripcionProducto;
            this.activo = activo;
            this.imagenProducto = imagenProducto;
            this.observacionesProducto = observacionesProducto;
            this.fecha_reg = DateTime.Now;
        }
        public int id { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public bool activo { get; set; }
        public string imagenProducto { get; set; }
        public string observacionesProducto { get; set; }
        public DateTime fecha_reg { get; set; }
    }
}