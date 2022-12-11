using System.Collections.Generic;
using System.Globalization;

namespace Example2D.Common.Editor.Googlesheets {
    public abstract class BaseParser : ISpreadsheetParser {
        public abstract string Parse(IList<IList<object>> sheetData);
        public static object TryParseValue(object value) {
            if (int.TryParse(value.ToString(), out int resInt)) {
                return resInt;
            }

            var resValue = value.ToString().Replace(',', '.');
            if (float.TryParse(resValue, NumberStyles.Float,
                CultureInfo.InvariantCulture.NumberFormat, out float resFloat)) {
                return resFloat;
            }

            return resValue;
        }
    }
}