using System;

namespace TestWebApp.Models
{
    public class VentaEncabezado
    {
        public VentaEncabezado(string Id, string fechaVenta, string clienteNombre,string clienteApellido, string descripcionVenta, int num_productos, double totalVenta)
        {
            this.Id = Id;

            this.stringFechaVenta = fechaVenta;
            
            var fecha = fechaVenta.Split("/");
            int mes = Int32.Parse(fecha[0]);
            int dia = Int32.Parse(fecha[1]);
            int anio = Int32.Parse(fecha[2]);

            this.fechaVenta = new DateTime(anio,mes,dia);
            this.clienteNombre = clienteNombre;
            this.clienteApellido = clienteApellido;
            this.descripcionVenta = descripcionVenta;
            this.num_productos = num_productos;
            this.totalVenta = totalVenta;
            this.fecha_reg = DateTime.Now;
        }
        public VentaEncabezado()
        {
            this.Id="0";
            this.fechaVenta=DateTime.Now;
            this.stringFechaVenta="N/A";
            this.clienteNombre="N/A";
            this.clienteApellido="N/A";
            this.descripcionVenta="N/A";
            this.num_productos=0;
            this.fecha_reg=DateTime.Now;
        }
        public string Id { get; set; }
        public DateTime fechaVenta { get; set; }
        public string stringFechaVenta { get; set; }
        public string clienteNombre { get; set; }
         public string clienteApellido { get; set; }

        public string descripcionVenta { get; set; }
        public int num_productos { get; set; }
        public double totalVenta { get; set; }
        public DateTime fecha_reg { get; set; }
    }
}