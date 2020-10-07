using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.Models
{
    //Clase que permite el uso de la DB con Entity Framework Core
    public class TestContext: DbContext
    {
        //Tabla de Clientes
        public DbSet<Cliente> clientes { get; set; }
        //Tabla de Productos
        public DbSet<Producto> productos { get; set; }
        //Tabla de Ventas (Encabezado)
        public DbSet<VentaEncabezado> ventasEncabezados { get; set; }
        //Tabla de Ventas (detalle)
        public DbSet<VentaDetalle> ventasDetalles { get; set; }
        
        //Constructor
        public TestContext(DbContextOptions<TestContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Sembrar datos en la DB

            var clientes = new List<Cliente>();
            clientes.Add(new Cliente("1","David Enrique", "Palacios Garcia", "09/15/2000"));
            clientes.Add(new Cliente("2", "Francisco", "Ruiz", "10/10/1985"));
            
            //Sembrar Clientes
           modelBuilder.Entity<Cliente>().HasData(clientes.ToArray());

            //Sembrar Productos
            var productos = new List<Producto>();
            productos.Add(new Producto("1","iPhone X","Celular de Apple",true,"https://image.freepik.com/vector-gratis/iphone-x-pantalla-blanca_23-2147852768.jpg","Producto en bodega"));
            productos.Add(new Producto("2","Macbook Pro", "Computador de Apple",true,"https://image.freepik.com/vector-gratis/apple-macbook-pro-vectores-pantalla-retina_23-2147729504.jpg?2","Producto en bodega"));
            productos.Add(new Producto("3","Airpods","Audífonos de Apple",true,"https://images.unsplash.com/photo-1535057929422-25260d3e1a54?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=839&q=80","Producto no disponible en bodega"));
            modelBuilder.Entity<Producto>().HasData(productos.ToArray());

            //Sembrar Ventas Encabezado
            var ventasEncabezado = new List<VentaEncabezado>();
            ventasEncabezado.Add(new VentaEncabezado("1",new DateTime(2020,10,6),"David Enrique","Palacios García","Compró un iPhone X",1,2200000));
            ventasEncabezado.Add(new VentaEncabezado("2",new DateTime(2020,09,6),"Francisco","Ruiz","Compró un Macbook",1,4200000));
            ventasEncabezado.Add(new VentaEncabezado("3",new DateTime(2020,09,8),"Francisco","Ruiz","Compró unos Airpods",1,600000));
            modelBuilder.Entity<VentaEncabezado>().HasData(ventasEncabezado.ToArray());

            //Sembrar Ventas Detalle
            var ventasDetalle = new List<VentaDetalle>();
            ventasDetalle.Add(new VentaDetalle("1","iPhone X",1,2000000,200000,2200000));
            ventasDetalle.Add(new VentaDetalle("2","Macbook",1,4000000,200000,4200000));
            ventasDetalle.Add(new VentaDetalle("3","Airpods",1,500000,100000,600000));
            modelBuilder.Entity<VentaDetalle>().HasData(ventasDetalle.ToArray());




        }
        
    }
}