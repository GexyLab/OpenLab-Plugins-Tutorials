using OpenLabSDK.config;
using OpenLabSDK.events;
using OpenLabSDK.instruments;
using OpenLabSDK.logicblocks;
using OpenLabSDK.plugin;
using OpenLabSDK.ui;

namespace LogicBlockPortTutorial10
{
    public class LogicBlockPortTutorial10 : LogicBlock
    {

        public class Info : LogicBlockInfo
        {
            public string UID => "";
            public string Title => "LogicBlock port tutorial 10";
            public int[] version => [1, 0, 0];
            public string vendorUID => "";
            public string url => "";
            public string description => "A tutorial of custom port for logic blocks";
            public string instrumentsMenuCategoryTitle => "Tutorials/Custom port";
        }

        public LogicBlockPortTutorial10(IPluginsManager _pluginsManager, IEventsManager _eventsManager, IWindowsManager _windowsManager, InstrumentDefinition instrumentDefinition) : base(_pluginsManager, _eventsManager, _windowsManager, instrumentDefinition)
        {
            logicBlockInfo = new Info();

            LogicBlockCustomPort p = new LogicBlockCustomPort("Recive packet delimiter", null, LogicBlockPort.DataDirection.Input);
            p.settings.horizontalPosition = LogicBlockPortDefaultSettings.Position.Left;
            p.settings.onDataChangeOperation = LogicBlockPort.OnDataChangeOperations.None;
            p.settings.onDataChangeOperationEditable = false;
            p.settings.toStartOperation = LogicBlockPort.ToStartOperations.None;
            p.settings.toStartOperationEditable = false;
            p.settings.dataValueEditable = true;
            p.settings.dataTypeEditable = true;
            p.setData(1, true, false);
            addPort(p);
        }

        public override void run()
        {
            
        }

        public override void stop()
        {
            
        }
    }
}
