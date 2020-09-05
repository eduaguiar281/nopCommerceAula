using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Nop.Core.Infrastructure;
using Nop.Services.Localization;

namespace Nop.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductValidator
    {
        private ILocalizationService _localizationService;
        protected override void PostInitialize()
        {
            _localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            RuleFor(x => x.UrlManualInstrucoes)
                .Matches(@"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?")
                .When(x => !string.IsNullOrEmpty(x.UrlManualInstrucoes))
                .WithMessage(_localizationService.GetResource("Admin.Catalog.Products.Fields.UrlManualInstrucoes.UrlError"));


        }

    }
}