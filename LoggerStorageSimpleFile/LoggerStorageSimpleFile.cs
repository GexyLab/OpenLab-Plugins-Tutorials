using OpenLabSDK.config;
using OpenLabSDK.error;
using OpenLabSDK.events;
using OpenLabSDK.logger;
using OpenLabSDK.logger.LoggerStandard;
using System.IO;

namespace LoggerStorageSimpleFile
{
    public class LoggerStorageSimpleFile : LoggerStorage
    {
        string fileString;
        public LoggerStorageSimpleFile(IErrorManager errorManager, IEventsManager eventsManager, LoggerStorageDefinition def) : base(errorManager, eventsManager, def)
        {
            fileString = def.config.GetProperty("file").ToString();
        }

        public override void deinit()
        {
            throw new NotImplementedException();
        }

        public override void init()
        {
            return;
        }

        public override LoggerMessageData[] read()
        {
            throw new NotImplementedException();
        }

        private string syntaxDigest(LoggerMessageData data)
        {
            return "[" + $"{data.date:dd/MM/yyyy hh:mm:ss tt}" + "][" + data.Level + "] " + data.Message;
        }
        public override LoggerMessageData write(LoggerMessageData data)
        {
            using (StreamWriter outputFile = new StreamWriter(fileString, true))
            {
                outputFile.WriteLine(data);
            }

            return data;
        }
    }
}
