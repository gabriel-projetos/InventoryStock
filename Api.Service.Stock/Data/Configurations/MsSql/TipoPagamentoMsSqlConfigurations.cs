using Api.Service.Stock.Models;
using Api.Service.Stock.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Data.Configurations.MsSql
{
    internal class TipoPagamentoMsSqlConfigurations : IEntityTypeConfiguration<TipoPagamento>
    {
        public void Configure(EntityTypeBuilder<TipoPagamento> modelBuilder)
        {
            DefaultModelSetup.DefaultModelV2Setup(modelBuilder);
            modelBuilder.HasIndex(m => m.Uid).IsUnique();
        }
    }
}
