using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example2D.Common.Editor.Googlesheets {
    [CreateAssetMenu(fileName = "GoogleSheet Settings", menuName = "Example2D/Configs/GoogleSheet Settings", order = 1)]
    public class GoogleSheetSettings : ScriptableObject {
        [field: SerializeField] public string ConfigsRoot { get; private set; }
        [field: SerializeField] public List<GoogleSpreadsheetData> Configs { get; private set; }
    }

    [Serializable]
    public class GoogleSpreadsheetData {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string SpreadsheetId { get; private set; }
        [field: SerializeField] public List<GoogleSheetData> Sheets { get; private set; }
    }

    [Serializable]
    public class GoogleSheetData {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int SheetId { get; private set; }
        [field: SerializeField] public string Range { get; private set; }
        [field: SerializeField] public SpreadsheetParserType Parser { get; private set; }
    }

    public enum SpreadsheetParserType {
        Default
    }
}