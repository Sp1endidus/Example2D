using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Example2D.Common.Editor.Googlesheets {
    [ParserType(SpreadsheetParserType.DefaultDict)]
    public class DefaultDictParser : BaseParser {
        public override string Parse(IList<IList<object>> sheetData) {
            var result = new JObject();
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
                    result[key] = item.DeepClone();
                    item = new JObject();
                }
            }

            return result.ToString();
        }
    }
}