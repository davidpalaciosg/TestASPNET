using System;

namespace TestWebApp.Models
{
    public class VentaEncabezado
    {
        public VentaEncabezado(string Id, DateTime fechaVenta, string clienteNombre,string clienteApellido, string descripcionVenta, int num_productos, double totalVenta)
        {
            this.Id = Id;
            this.fechaVenta = fechaVenta;
            this.clienteNombre = clienteNombre;
            this.clienteApellido = clienteApellido;
            this.descripcionVenta = descripcionVenta;
            this.num_productos = num_productos;
            this.totalVenta = totalVenta;
            this.fecha_reg = DateTime.Now;
        }
        public string Id { get; set; }
        public DateTime fechaVenta { get; set; }
        public string clienteNombre { get; set; }
         public string clienteApellido { get; set; }

        public string descripcionVenta { get; set; }
        public int num_productos { get; set; }
        public double totalVenta { get; set; }
        public DateTime fecha_reg { get; set; }
    }
}