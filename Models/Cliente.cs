using System;

namespace TestWebApp.Models
{
    public class Cliente
    {
        public Cliente(string id, string nombreCliente, string apellidoCliente, DateTime fechaNacimiento)
        {
            this.Id = id;
            this.nombreCliente = nombreCliente;
            this.apellidoCliente = apellidoCliente;
            this.fechaNacimiento = fechaNacimiento;
            this.fecha_reg = DateTime.Now;
        }
        public string Id { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fecha_reg { get; set; }
    }
}