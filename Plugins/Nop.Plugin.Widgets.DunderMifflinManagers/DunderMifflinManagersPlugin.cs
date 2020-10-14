using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.DunderMifflinManagers
{
    public class DunderMifflinManagersPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        public DunderMifflinManagersPlugin(IWebHelper webHelper, ISettingService settingService)
        {
            _settingService = settingService;
            _webHelper = webHelper;
        }

        public override void Install()
        {
            _settingService.SaveSetting(new DunderMifflinSettings
            {
                ManagerName = "Michael Scott",
                ManagerAssistantName = "Dwight Schrute",
                AssistantOfManagerAssistantName = "Jim Halpert"
            });

            base.Install();
        }

        public override void Uninstall()
        {
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
