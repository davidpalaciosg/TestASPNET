using System;

namespace TestWebApp.Models
{
    public class VentaEncabezado
    {
        public VentaEncabezado()
        {
            this.Id = "0";
            this.fechaVenta = DateTime.Now;
            this.stringFechaVenta = "N/A";
            this.clienteNombre = "N/A";
            this.clienteApellido = "N/A";
            this.descripcionVenta = "N/A";
            this.num_productos = 0;
            this.fecha_reg = DateTime.Now;
            this.producto = "N/A";
            this.cantidad = 0;
            this.valorUnitario = 0;
            this.impuesto = 0;
        }
        public VentaEncabezado(string id, string stringFechaVenta, string clienteNombre, string clienteApellido, string descripcionVenta, float totalVenta, string producto, int cantidad, float valorUnitario, float impuesto)
        {
            this.Id = id;

            var fecha = stringFechaVenta.Split("-");
            int dia = Int32.Parse(fecha[0]);
            int mes = Int32.Parse(fecha[1]);
            int anio = Int32.Parse(fecha[2]);

            this.fechaVenta = new DateTime(anio, mes, dia);
            
            this.stringFechaVenta = stringFechaVenta;
            this.clienteNombre = clienteNombre;
            this.clienteApellido = clienteApellido;
            this.descripcionVenta = descripcionVenta;
            this.num_productos = cantidad;
            this.totalVenta = totalVenta;
            this.fecha_reg = fecha_reg;
            this.producto = producto;
            this.cantidad = cantidad;
            this.valorUnitario = valorUnitario;
            this.impuesto = impuesto;
            this.fecha_reg = DateTime.Now;
        }
        public string Id { get; set; }
        public DateTime fechaVenta { get; set; }
        public string stringFechaVenta { get; set; }
        public string clienteNombre { get; set; }
        public string clienteApellido { get; set; }

        public string descripcionVenta { get; set; }
        public int num_productos { get; set; }
        public float totalVenta { get; set; }
        public DateTime fecha_reg { get; set; }

        //Unión
        public string producto { get; set; }
        public int cantidad { get; set; }
        public float valorUnitario { get; set; }
        public float impuesto { get; set; }
    }
}