using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    public partial class ProductModel
    {
        [NopResourceDisplayName("Admin.Catalog.Products.Fields.UrlManualInstrucoes")]
        public string UrlManualInstrucoes { get; set; }

    }
}
