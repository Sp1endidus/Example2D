using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example2D.Common.Editor.Googlesheets {
    public interface ISpreadsheetParser {
        string Parse(IList<IList<object>> sheetData);
    }
}