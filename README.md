# ToDo WebApp 

## Azureインフラ構成

* App Service
    - 公開： `コード`
    - ランタイム: `.NET 6 (LTS)`
    - OS: `Linux`
    - 設定-構成-接続文字列:

        |名前|値|種類|
        |---|---|---|
        | `MSSQLDB` | (作成された SQL Database への接続文字列) | `SQL Server` |

* SQL Database
    - 照合順序： `Latin1_General_100_CI_AI_SC_UTF8`


## 開発環境

### 環境準備

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

### 動作確認

1. ビルド/実行

        dotnet watch run
