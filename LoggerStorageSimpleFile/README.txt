Add config to OpenLab Studio config file
----------------------------------------
Edit OpenLab Studio config file: config/config.json
Add the following code in storages array

    {
      "enabled": true,
      "path": "plugins\\LoggerStoragesStandard\\LoggerStoragesStandard.dll",
      "config": {
        "path": "plugins\\LoggerStoragesStandard\\config.json"
      }
    }

this is an exemple:

[...]
"logger": {
  "enabled": true,
  "loadStoragesOnStart": true,
  "storages": [
    {
      "enabled": true,
      "path": "plugins\\LoggerStoragesStandard\\LoggerStoragesStandard.dll",
      "config": {
        "path": "plugins\\LoggerStoragesStandard\\config.json"
      }
    }
    [...]
  ]