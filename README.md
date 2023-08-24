# ToDo WebApp 

## 前提環境

* 開発環境にインストール

    * .Net 6
    * Visual Studio Code
        * C#
        * App Service

 

* appsettings.json を準備

    /appsettings.json

    ```
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "ConnectionStrings": {
        "MSSQLDB": "{YOUR_SQLDB_CONNECTION_STRING}"
      },
      "AllowedHosts": "*"
    }
    ```

## 動作確認

1. ビルド/実行

        dotnet watch run
