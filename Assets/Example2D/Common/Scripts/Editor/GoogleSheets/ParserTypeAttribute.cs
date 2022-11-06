using System;

namespace Example2D.Common.Editor.Googlesheets {
    public class ParserTypeAttribute : Attribute {
        public SpreadsheetParserType ParserType { get; private set; }
        public ParserTypeAttribute(SpreadsheetParserType parserType) {
            ParserType = parserType;
        }
    }
}