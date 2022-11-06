using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Example2D.Common.Editor.Googlesheets {
    [ParserType(SpreadsheetParserType.Default)]
    public class DefaultParser : ISpreadsheetParser {
        public string Parse(int sheedId, IList<IList<object>> sheetData) {
            var dictResult = new JObject();
            var item = new JObject();
            var key = "";

            for (int i = 1; i < sheetData.Count; i++) {
                if (!string.IsNullOrEmpty(sheetData[i][0].ToString())) {
                    for (int j = 0; j < sheetData[i].Count; j++) {
                        item.Add(new JProperty(sheetData[0][j].ToString(),
                            TryParseValue(sheetData[i][j])));
                    }
                    key = sheetData[i][0].ToString();
                }

                if (i == sheetData.Count - 1 || !string.IsNullOrEmpty(sheetData[i + 1][0].ToString())) {
                    dictResult[key] = item.DeepClone();
                    item = new JObject();
                }
            }

            return dictResult.ToString();
        }

        public static object TryParseValue(object value) {
            if (int.TryParse(value.ToString(), out int resInt)) {
                return resInt;
            }

            var resValue = value.ToString().Replace(',', '.');
            if (float.TryParse(resValue, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat,
                out float resFloat)) {
                return resFloat;
            }

            return resValue;
        }
    }
}