using System;

namespace TestWebApp.Models
{
    public class Cliente
    {
        public Cliente(string id, string nombreCliente, string apellidoCliente, string stringfechaNacimiento)
        {
            this.Id = id;
            this.nombreCliente = nombreCliente;
            this.apellidoCliente = apellidoCliente;
            this.stringfechaNacimiento = stringfechaNacimiento;

            var fecha = stringfechaNacimiento.Split("-");
            int dia = Int32.Parse(fecha[0]);
            int mes = Int32.Parse(fecha[1]);
            int anio = Int32.Parse(fecha[2]);

            this.fechaNacimiento = new DateTime(anio,mes,dia);
            this.fecha_reg = DateTime.Now;
        }
        public Cliente()
        {
            this.Id="0";
            this.nombreCliente="N/A";
            this.apellidoCliente="N/A";
            this.stringfechaNacimiento="09/15/2000";
            this.fecha_reg=DateTime.Now;
            this.fechaNacimiento=DateTime.Now;
        }
        public string Id { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string stringfechaNacimiento { get; set; }
        public DateTime fecha_reg { get; set; }
    }
}