using System;
using System.Collections.Generic;
using System.Text;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.DunderMifflinManagers.Models
{
    public class WidgetConfiguration
    {
        [NopResourceDisplayName("Plugins.Widgets.DunderMifflinManagers.ManagerName")]
        public string ManagerName { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DunderMifflinManagers.ManagerAsstantName")]
        public string ManagerAssistantName { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DunderMifflinManagers.AssistantOfManagerAssistantName")]
        public string AssistantOfManagerAssistantName { get; set; }
    }
}
