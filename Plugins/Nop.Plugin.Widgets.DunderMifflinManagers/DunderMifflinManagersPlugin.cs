using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.DunderMifflinManagers
{
    public class DunderMifflinManagersPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        public DunderMifflinManagersPlugin(IWebHelper webHelper, 
            ISettingService settingService,
            ILocalizationService localizationService)
        {
            _settingService = settingService;
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

        public override void Install()
        {
            _settingService.SaveSetting(new DunderMifflinSettings
            {
                ManagerName = "Michael Scott",
                ManagerAssistantName = "Dwight Schrute",
                AssistantOfManagerAssistantName = "Jim Halpert"
            });

            _localizationService.AddLocaleResource(new Dictionary<string, string>
            {
                ["Plugins.Widgets.DunderMifflinManagers.ManagerName"] = "Manager Name",
                ["Plugins.Widgets.DunderMifflinManagers.ManagerAsstantName"] = "Manager Assistant Name",
                ["Plugins.Widgets.DunderMifflinManagers.AssistantOfManagerAssistantName"] = "Assistant Of Manager Assistant Name",
                ["Plugins.Widgets.DunderMifflinManagers.ManagersComposite"] = "Our Managers",
                ["Plugins.Widgets.DunderMifflinManagers.MessageOfManager"] = "Heloooo Wooooorlld",
                ["Plugins.Widgets.DunderMifflinManagers.MessageOfManagerAsstant"] = "Hello World, don't buy here, buy with me by phone!",
                ["Plugins.Widgets.DunderMifflinManagers.MessageOfAssistantOfManagerAssistant"] = "Heloooo!",

            });

            base.Install();
        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<DunderMifflinSettings>();

            _localizationService.DeleteLocaleResource("Plugins.Widgets.DunderMifflinManagers");

            base.Uninstall();
        }

        public bool HideInWidgetList => false;

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsDunderMifflin";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.HomepageTop };
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/WidgetsDunderMifflin/Configure";
        }
    }
}
