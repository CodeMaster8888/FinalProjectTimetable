using System;

namespace Services.Configuration
{
    public class AppSettingsRoot
    {
        public AppSettingsConnectionStrings ConnectionStrings { get; set; }
        public string Secret { get; set; }
    }
}
