using OpenLabSDK.config;
using OpenLabSDK.error;
using OpenLabSDK.events;
using OpenLabSDK.plugin;
using OpenLabSDK.ui;
using OpenLabStudio.project;
using System.Windows;

namespace PluginBaseTutorial1
{
    public class PluginUIBaseTutorial1 : Plugin
    {
        internal class Info : IPluginInfo
        {
            public string Name { get; } = "PluginUIBaseTutorial1";
            public string Title { get; } = "Plugin UI Base Tutorial 1";
            public int[] version { get; } = { 1, 0, 0 };
            public string vendorUID { get; }
            public string url { get; }
            public string description { get; }
        }

        public PluginUIBaseTutorial1(
            IErrorManager _errorManager, 
            IPluginsManager _pluginsManager, 
            IEventsManager _eventsManager, 
            IWindowsManager _windowsManager, 
            ProjectsManager _projectsManager,
            PluginDefinition _pluginDefinition) : base(
                _errorManager, 
                _pluginsManager, 
                _eventsManager, 
                _windowsManager, 
                _projectsManager,
                _pluginDefinition)
        {
            pluginInfo = new Info();
        }

        public override int deinit()
        {
            log.info("Deinit plugin" + pluginInfo.Title);
            return 0;
        }

        public override int init()
        {
            log.info("Init plugin " + pluginInfo.Title);

            eventsManager.addEventHandler("ols.ready", (object sender, EventArgs e) =>
            {
                log.info($"Plugin: {pluginInfo.Name} hello!!");
                return true;
            });

            return 0;
        }
    }
}
