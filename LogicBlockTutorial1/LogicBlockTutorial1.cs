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

        public class Info : LogicBlockInfo
        {
            public string UID => "";
            public string Title => "LogicBlock base";
            public int[] version => [1, 0, 0];
            public string vendorUID => "";
            public string url => "";
            public string description => "A base logic blocks";
            public string instrumentsMenuCategoryTitle => "Tutorials/Logic blocks";
        }

        LogicBlockPort inputPortA, inputPortB, outputPort;

        public LogicBlockTutorial1(IErrorManager _errorManager, IPluginsManager _pluginsManager, IEventsManager _eventsManager, IWindowsManager _windowsManager, InstrumentDefinition instrumentDefinition) : base(_errorManager, _pluginsManager, _eventsManager, _windowsManager, instrumentDefinition)
        {
            logicBlockInfo = new Info();

            Type[] type = [
                typeof(float),
                typeof(int),
                typeof(uint),
                typeof(nint),
                typeof(nuint),
                typeof(long),
                typeof(ulong),
                typeof(ushort),
                typeof(double),
                typeof(decimal)
            ];

            inputPortA = new LogicBlockPort("A", type, LogicBlockPort.DataDirection.Input);
            inputPortA.settings.horizontalPosition = OpenLabSDK.logicblocks.LogicBlockPortDefaultSettings.Position.Left;
            inputPortA.settings.onDataChangeOperation = LogicBlockPort.OnDataChangeOperations.ExecuteLogicBlockRunMethod;
            addPort(inputPortA);

            inputPortA.settings.dataValueEditable = true;

            inputPortB = new LogicBlockPort("B", type, LogicBlockPort.DataDirection.Input);
            inputPortB.settings.horizontalPosition = OpenLabSDK.logicblocks.LogicBlockPortDefaultSettings.Position.Left;
            inputPortB.settings.onDataChangeOperation = LogicBlockPort.OnDataChangeOperations.ExecuteLogicBlockRunMethod;
            addPort(inputPortB);

            inputPortB.settings.dataValueEditable = true;

            outputPort = new LogicBlockPort("A+B", type, LogicBlockPort.DataDirection.Output);
            outputPort.settings.horizontalPosition = OpenLabSDK.logicblocks.LogicBlockPortDefaultSettings.Position.Right;
            outputPort.settings.onDataChangeOperation = LogicBlockPort.OnDataChangeOperations.PutDataViaConnection;
            addPort(outputPort);

            setToStringPortOnDataChange(outputPort);
        }

        public override void run()
        {
            if (inputPortA.getData(false) != null && inputPortB.getData(false) != null)
            {
                outputPort.setData(inputPortA.getData(false) + inputPortB.getData(false), false, false);

            }
        }

        public override void stop()
        {
        }
    }
}
    
