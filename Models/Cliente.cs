using System;

namespace TestWebApp.Models
{
    public class Cliente
    {
        public Cliente(int idCliente, string nombreCliente, string apellidoCliente, DateTime fechaNacimiento)
        {
            this.idCliente = idCliente;
            this.nombreCliente = nombreCliente;
            this.apellidoCliente = apellidoCliente;
            this.fechaNacimiento = fechaNacimiento;
            this.fecha_reg = DateTime.Now;
        }
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fecha_reg { get; set; }
    }
}