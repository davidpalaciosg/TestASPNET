using System;

namespace TestWebApp.Models
{
    public class VentaEncabezado
    {
        public VentaEncabezado(int id, DateTime fechaVenta, Cliente cliente, string descripcionVenta, int num_productos, double totalVenta)
        {
            this.id = id;
            this.fechaVenta = fechaVenta;
            this.cliente = cliente;
            this.descripcionVenta = descripcionVenta;
            this.num_productos = num_productos;
            this.totalVenta = totalVenta;
            this.fecha_reg = DateTime.Now;
        }
        public int id { get; set; }
        public DateTime fechaVenta { get; set; }
        public Cliente cliente { get; set; }
        public string descripcionVenta { get; set; }
        public int num_productos { get; set; }
        public double totalVenta { get; set; }
        public DateTime fecha_reg { get; set; }
    }
}