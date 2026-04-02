using OpenLabSDK.config;
using OpenLabSDK.error;
using OpenLabSDK.events;
using OpenLabSDK.instruments;
using OpenLabSDK.plugin;
using OpenLabSDK.ui;

namespace LogicBlockTutorial1
{
    public class LogicBlockTutorial1 : LogicBlock
    {
        public LogicBlockTutorial1(IErrorManager _errorManager, IPluginsManager _pluginsManager, IEventsManager _eventsManager, IWindowsManager _windowsManager, InstrumentDefinition instrumentDefinition) : base(_errorManager, _pluginsManager, _eventsManager, _windowsManager, instrumentDefinition)
        {
        }

        public override void run()
        {
            throw new NotImplementedException();
        }

        public override void stop()
        {
            throw new NotImplementedException();
        }
    }
}
    