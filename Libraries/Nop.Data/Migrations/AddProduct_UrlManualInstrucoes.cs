using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Migrations
{
    [NopMigration("2020/09/05 19:09:16:2551770", "Produto. Adicionando Url do Manual de Instrucoes")]
    public class AddProduct_UrlManualInstrucoes : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Column(nameof(Product.UrlManualInstrucoes))
                  .OnTable(nameof(Product))
                  .AsString(int.MaxValue)
                  .Nullable();

        }

    }
}
