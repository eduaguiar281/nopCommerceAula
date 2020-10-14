using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.DunderMifflinManagers.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.DunderMifflinManagers.Components
{
    [ViewComponent(Name = "WidgetsDunderMifflin")]
    public class WidgetsDunderMifflinViewComponent: NopViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public WidgetsDunderMifflinViewComponent(ISettingService settingService, 
            IStoreContext storeContext)
        {
            _settingService = settingService;
            _storeContext = storeContext;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var settings = _settingService.LoadSetting<DunderMifflinSettings>(_storeContext.CurrentStore.Id);
            var model = new WidgetConfiguration
            {
                ManagerName = settings.ManagerName,
                ManagerAssistantName = settings.ManagerAssistantName,
                AssistantOfManagerAssistantName = settings.AssistantOfManagerAssistantName
            };

            if (string.IsNullOrEmpty(model.ManagerName) && string.IsNullOrEmpty(model.ManagerAssistantName) &&
                string.IsNullOrEmpty(model.AssistantOfManagerAssistantName))
                //no pictures uploaded
                return Content("");

            return View($"{DunderMiffilnConstants.ViewsPlugginPath}PublicInfo.cshtml", model);


        }
    }
}
