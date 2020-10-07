using System;

namespace TestWebApp.Models
{
    public class VentaDetalle
    {
        public VentaDetalle(string Id, string clienteNombre, string clienteApellido, string stringFechaVenta, string producto, int cantidad, float valorUnitario, float impuesto, float valorTotal)
        {
            this.Id = Id;
            this.producto = producto;
            this.cantidad = cantidad;
            this.valorUnitario = valorUnitario;
            this.impuesto = impuesto;
            this.valorTotal = valorTotal;
            this.fecha_reg = DateTime.Now;

            this.clienteNombre = clienteNombre;
            this.clienteApellido = clienteApellido;
            this.stringFechaVenta = stringFechaVenta;

            var fecha = stringFechaVenta.Split("-");
            int dia = Int32.Parse(fecha[0]);
            int mes = Int32.Parse(fecha[1]);
            int anio = Int32.Parse(fecha[2]);

            this.fechaVenta = new DateTime(anio,mes,dia);

        }
        public VentaDetalle()
        {
            this.Id = "N/A";
            this.producto = "N/A";
            this.cantidad = 0;
            this.valorUnitario = 0;
            this.impuesto = 0;
            this.valorTotal = 0;
            this.fecha_reg = DateTime.Now;
            this.clienteNombre = "N/A";
            this.clienteApellido = "N/A";
            this.stringFechaVenta = "N/A";
            this.fechaVenta = DateTime.Now;


        }
        public string Id { get; set; }
        public string producto { get; set; }
       public string clienteNombre { get; set; }
        public string clienteApellido { get; set; }
        public int cantidad { get; set; }
        public float valorUnitario { get; set; }
        public float impuesto { get; set; }
        public float valorTotal { get; set; }
        public string stringFechaVenta { get; set; }
        public DateTime fechaVenta { get; set; }
        public DateTime fecha_reg { get; set; }

    }
}