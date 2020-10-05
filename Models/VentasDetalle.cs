using System;

namespace TestWebApp.Models
{
    public class VentasDetalle
    {
        public VentasDetalle(int id, string producto, int cantidad, float valorUnitario, float impuesto, float valorTotal)
        {
            this.id = id;
            this.producto = producto;
            this.cantidad = cantidad;
            this.valorUnitario = valorUnitario;
            this.impuesto = impuesto;
            this.valorTotal = valorTotal;
            this.fecha_reg = DateTime.Now;
        }
        public int id { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public float valorUnitario { get; set; }
        public float impuesto { get; set; }
        public float valorTotal { get; set; }
        public DateTime fecha_reg { get; set; }

    }
}