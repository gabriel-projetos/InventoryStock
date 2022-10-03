using Api.Service.Stock.Models;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Context
{
    public partial class ApiDbContext : DbContext
    {
   

        public ApiDbContext(DbContextOptions<ApiDbContext> ctx) : base(ctx)
        {
            
        }

        

        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ItensCompra> ItensCompras { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<TipoPagamento> TipoPagamentos { get; set; }
        public virtual DbSet<ItensVenda> ItensVendas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DefaultModelV2Setup<Produto>(modelBuilder);
            modelBuilder.Entity<Produto>().HasIndex(m => m.Uid).IsUnique();
            modelBuilder.Entity<Produto>().HasIndex(m => m.Estoque);
            modelBuilder.Entity<Produto>().Property(m => m.Status).HasConversion(new EnumToStringConverter<EStatus>()).HasMaxLength(50);

            DefaultModelV2Setup<ItensCompra>(modelBuilder);
            modelBuilder.Entity<ItensCompra>().HasIndex(m => m.Uid).IsUnique();
            
            modelBuilder.Entity<ItensCompra>().HasOne(d => d.DbProduto)
                .WithMany(p => p.DbItensCompraModel)
                .HasForeignKey(d => d.ProdutoUid)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ItensCompra>().HasOne(d => d.DbCompra)
                .WithMany(p => p.DbItensCompraModel)
                .HasForeignKey(d => d.CompraUid)
                .OnDelete(DeleteBehavior.ClientSetNull);

            DefaultModelV2Setup<Compra>(modelBuilder);
            modelBuilder.Entity<Compra>().HasIndex(m => m.Uid).IsUnique();
            modelBuilder.Entity<Compra>().HasOne(d => d.DbFornecedorModel)
                    .WithMany(p => p.DbComprasModel)
                    .HasForeignKey(d => d.FornecedorUid);
            modelBuilder.Entity<Compra>().HasOne(d => d.DbTipoPagamentoModel)
                    .WithMany(p => p.DbComprasModel)
                    .HasForeignKey(d => d.TipoPagamentoUid);

            DefaultModelV2Setup<Fornecedor>(modelBuilder);
            modelBuilder.Entity<Fornecedor>().HasIndex(m => m.Uid).IsUnique();

            DefaultModelV2Setup<Cliente>(modelBuilder);
            modelBuilder.Entity<Cliente>().HasIndex(m => m.Uid).IsUnique();
            
            DefaultModelV2Setup<Venda>(modelBuilder);
            modelBuilder.Entity<Venda>().HasIndex(m => m.Uid).IsUnique();
            modelBuilder.Entity<Venda>().HasOne(d => d.DbCliente)
                    .WithMany(p => p.DbVendasModel)
                    .HasForeignKey(d => d.ClienteUid);
            modelBuilder.Entity<Venda>().HasOne(d => d.DbTipoPagamento)
                    .WithMany(p => p.DbVendasModel)
                    .HasForeignKey(d => d.TipoPagamentoUid);

            DefaultModelV2Setup<TipoPagamento>(modelBuilder);
            modelBuilder.Entity<TipoPagamento>().HasIndex(m => m.Uid).IsUnique();

            DefaultModelV2Setup<ItensVenda>(modelBuilder);
            modelBuilder.Entity<ItensVenda>().HasOne(d => d.DbProduto)
               .WithMany(p => p.DbItensVendasModel)
               .HasForeignKey(d => d.ProdutoUid)
               .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ItensVenda>().HasOne(d => d.DbVenda)
                .WithMany(p => p.DbItensVendasModel)
                .HasForeignKey(d => d.VendaUid)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }



        private void DefaultModelV2Setup<T>(ModelBuilder modelBuilder, bool registerKey = true) where T : BaseData
        {
            modelBuilder.Entity<T>().Property(m => m.CreatedAt).IsRequired();
            modelBuilder.Entity<T>().Property(m => m.UpdatedAt).IsRequired();

            modelBuilder.Entity<T>().HasKey(m => m.Uid);
            modelBuilder.Entity<T>().Property(m => m.Uid).IsRequired().HasDefaultValueSql("NEWSEQUENTIALID()").ValueGeneratedOnAdd();
        }
    }
}
