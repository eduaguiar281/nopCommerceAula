using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.DunderMifflinManagers
{
    public class DunderMifflinSettings: ISettings
    {
        public string ManagerName { get; set; }
        public string ManagerAssistantName { get; set; }
        public string AssistantOfManagerAssistantName { get; set; }
    }
}
