using OpenLabSDK.expression;
using OpenLabSDK.instruments;
using OpenLabSDK.plugin;
using OpenLabSDK.ui.ViewDeskEditor.ViewDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LogicBlockPortTutorial10
{
    public class LogicBlockCustomPort : LogicBlockPort
    {
        public LogicBlockCustomPort(string name, Type[]? dataType, DataDirection dataDirection) : base(name, [typeof(string), typeof(int), typeof(Key)], dataDirection)
        {
            IPluginsManager.commonsTypes.RegisterType("System.Windows.Input.Key", typeof(Key));
        }

        override public void setDataValueByEditor(DataEditorArgs args)
        {
            try
            {
                if (args.NewValue == null)
                {
                    throw new Exception("The value can't be null");
                }


                if (args.Type == typeof(int))
                {
                    int val = int.Parse(args.NewValue);
                    if (val < 1)
                    {
                        throw new Exception("The value can't be < 1");
                    }

                    setData(val, args.OnDataChangeEventTempDisable, false);
                }
                else if (args.Type == typeof(string))
                {
                    string val = ((string)args.NewValue);
                    if (val == "" || val == string.Empty)
                    {
                        throw new Exception("The value can't be empty");
                    }
                    setData(val, args.OnDataChangeEventTempDisable, false);
                }
                else if (args.Type == typeof(Key))
                {
                    string val = ((string)args.NewValue).Trim();
                    if (val == "" || val == string.Empty || val.ToLower() == "null" || val == null)
                    {
                        throw new Exception("The value can't be empty or null");
                    }

                    // check if is insert string key of enum or integer value
                    int enumVal;
                    if(int.TryParse(val, out enumVal))
                    {
                        // if passe integer value
                        setData(Enum.Parse(typeof(Key),val,true), args.OnDataChangeEventTempDisable, false);
                    }
                    // Enum.GetName(typeof(Key), 1)


                }

            }
            catch
            {
                throw;
            }

        }

        public override string dataValueViewerFormatter()
        {
            if (data == null)
            {
                return "NULL";
            }
            else
            {
                if (settings.showDataTypeInDataValueViewer)
                {
                    return data.GetType().GetElementType().Name;
                }
                else
                {
                    if(data.GetType() == typeof(string))
                    {
                        return (string)data;
                    }
                    else if (data.GetType() == typeof(Key))
                    {
                        return "Key." + Enum.GetName(typeof(Key), (int)data);
                    }
                    else if(data.GetType() == typeof(int))
                    {
                        return ((int)data).ToString()+" Bytes";
                    }
                    else
                    {
                        return "Unknown";
                    }
                }
            }
        }
    }
}

