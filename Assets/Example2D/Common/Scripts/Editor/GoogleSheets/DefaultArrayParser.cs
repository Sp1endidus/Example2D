using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Example2D.Common.Editor.Googlesheets {
    [ParserType(SpreadsheetParserType.DefaultArray)]
    public class DefaultArrayParser : BaseParser {
        public override string Parse(IList<IList<object>> sheetData) {
            var result = new JArray();
            var item = new JObject();

            for (int i = 1; i < sheetData.Count; i++) {
                for (int j = 0; j < sheetData[i].Count; j++) {
                    item.Add(new JProperty(sheetData[0][j].ToString(),
                        TryParseValue(sheetData[i][j])));
                }

                result.Add(item.DeepClone());
                item = new JObject();
            }

            return result.ToString();
        }
    }
}