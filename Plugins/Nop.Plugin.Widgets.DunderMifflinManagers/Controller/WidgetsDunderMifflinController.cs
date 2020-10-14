using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.DunderMifflinManagers.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.DunderMifflinManagers.Controller
{
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsDunderMifflinController: BasePluginController
    {
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;

        public WidgetsDunderMifflinController(IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            INotificationService notificationService,
            ILocalizationService localizationService)
        {
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _notificationService = notificationService;
            _localizationService = localizationService;
        }

        [HttpGet]
        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            int storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<DunderMifflinSettings>(storeScope);
            var model = new WidgetConfiguration
            {
                ManagerName = settings.ManagerName,
                ManagerAssistantName = settings.ManagerAssistantName,
                AssistantOfManagerAssistantName = settings.AssistantOfManagerAssistantName
            };

            return View($"{DunderMiffilnConstants.ViewsPlugginPath}Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(WidgetConfiguration model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            int storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<DunderMifflinSettings>(storeScope);

            settings.ManagerAssistantName = model.ManagerAssistantName;
            settings.ManagerName = model.ManagerName;
            settings.AssistantOfManagerAssistantName = model.AssistantOfManagerAssistantName;

            _settingService.SaveSettingOverridablePerStore(settings, x => x.ManagerName, true, storeScope, true);
            _settingService.SaveSettingOverridablePerStore(settings, x => x.ManagerAssistantName, true, storeScope, true);
            _settingService.SaveSettingOverridablePerStore(settings, x => x.AssistantOfManagerAssistantName, true, storeScope, true);

            _settingService.ClearCache();

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }
    }
}
