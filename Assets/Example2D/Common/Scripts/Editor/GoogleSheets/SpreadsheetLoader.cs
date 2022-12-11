using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.GetRequest;

namespace Example2D.Common.Editor.Googlesheets {
    public class SpreadsheetLoader {
        private readonly SheetsService _sheetsService;
        private readonly string _applicationName = "Google Sheets API .NET";
        private readonly string _configsCredentialsPath = "/../GoogleSheetsConfigs/configs_credentials.json";
        private readonly string _tokenPath = "/../GoogleSheetsConfigs/token";
        private readonly string[] _scopes = { SheetsService.Scope.SpreadsheetsReadonly };

        public SpreadsheetLoader() {
            var initializer = new BaseClientService.Initializer() {
                HttpClientInitializer = GetCredentials(),
                ApplicationName = _applicationName
            };
            _sheetsService = new SheetsService(initializer);
        }

        private UserCredential GetCredentials() {
            UserCredential result;

            string configsCredentialsFullPath = Application.dataPath + _configsCredentialsPath;
            string tokenFullPath = Application.dataPath + _tokenPath;

            using (var stream = new FileStream(configsCredentialsFullPath, FileMode.Open, FileAccess.Read)) {
                result = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    _scopes, "user", CancellationToken.None,
                    new FileDataStore(tokenFullPath, true)).Result;
            }
            
            return result;
        }

        public string Load(ISpreadsheetParser parser, string spreadsheetId, int sheetId, string range) {
            var sheetData = LoadSheet(spreadsheetId, sheetId, range);
            string result = parser.Parse(sheetData);
            return result;
        }

        private IList<IList<object>> LoadSheet(string spreadsheetId, int sheetId, string range = "") {
            string sheetArgs = GetSheetNameById(spreadsheetId, sheetId);
            if (sheetArgs == null) {
                Debug.LogError($"sheet id [{sheetId}] not found!");
                return null;
            }

            if (!string.IsNullOrEmpty(range)) {
                sheetArgs += $"!{range}";
            }

            Debug.Log($"Load sheet args [{sheetArgs}]");
            var request = _sheetsService.Spreadsheets.Values.Get(spreadsheetId, sheetArgs);
            request.ValueRenderOption = ValueRenderOptionEnum.FORMATTEDVALUE;
            request.DateTimeRenderOption = DateTimeRenderOptionEnum.SERIALNUMBER;
            request.MajorDimension = MajorDimensionEnum.ROWS;

            var response = request.Execute();
            return response.Values;
        }

        private string GetSheetNameById(string spreadsheetId, int sheetId) {
            SpreadsheetsResource.GetRequest request = _sheetsService.Spreadsheets.Get(spreadsheetId);
            request.Ranges = new List<string>();
            request.IncludeGridData = false;

            Spreadsheet response = request.Execute();
            foreach (var sheet in response.Sheets) {
                if (sheet.Properties.SheetId == sheetId) {
                    return sheet.Properties.Title;
                }
            }
            return null;
        }
    }
}