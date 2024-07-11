using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.TestProduct;
using Nop.Core.Domain.Topics;

namespace Nop.Data.Mapping.Builders.TestProducts;
public class TestProductBuilder : NopEntityBuilder<TestProduct>
{
    #region Methods

    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(TestProduct.Name)).AsString(256).NotNullable()
            .WithColumn(nameof(TestProduct.ImageUrl)).AsString(256).NotNullable()
            .WithColumn(nameof(TestProduct.Description)).AsString(256).NotNullable();
    }

    #endregion
}
