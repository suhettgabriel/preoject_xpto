using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTO_API.Models;

namespace XPTO_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Fornecedor>()
                .HasData(
                    new List<Fornecedor>() { 
                        new Fornecedor()
                        {
                            Id = 1,
                            Nome = "Tio João"
                        },
                        new Fornecedor()
                        {
                            Id = 2,
                            Nome = "Piracanjuba"
                        },
                        new Fornecedor()
                        {
                            Id = 3,
                            Nome = "Santa Amália"
                        },
                        new Fornecedor()
                        {
                            Id = 4,
                            Nome = "Friboi"
                        },
                    }
                );

            builder.Entity<Produto>()
                .HasData(
                    new List<Produto>() { 
                        new Produto()
                        {
                            Id = 1,
                            Nome = "Arroz tipo 1 5kg",
                            CodBarra = "45564 4564548 12312 12",
                            imagem = System.IO.File.ReadAllBytes(@"C:\Users\gabriel.suhett\source\repos\XPTOProject\Imagens\imgTioJoao.jpg"),
                            FornecedorId = 1
                        },
                        new Produto()
                        {
                            Id = 2,
                            Nome = "Leite Condensado 350gr",
                            CodBarra = "45564 4564548 12312 85",
                            imagem = System.IO.File.ReadAllBytes(@"C:\Users\gabriel.suhett\source\repos\XPTOProject\Imagens\leiteCondensado.jpg"),
                            FornecedorId = 2
                        },
                        new Produto()
                        {
                            Id = 3,
                            Nome = "Espaguete 8 Ovos 500 g",
                            CodBarra = "45564 4564548 12312 46",
                            imagem = System.IO.File.ReadAllBytes(@"C:\Users\gabriel.suhett\source\repos\XPTOProject\Imagens\macarraSpaguette.jpg"),
                            FornecedorId = 3
                        },
                        new Produto()
                        {
                            Id = 4,
                            Nome = "Picanha Maturata kg",
                            CodBarra = "45564 4564548 12312 99",
                            imagem = System.IO.File.ReadAllBytes(@"C:\Users\gabriel.suhett\source\repos\XPTOProject\Imagens\picanha.jpg"),
                            FornecedorId = 4
                        },
                    }
                );
        }
    }
}
