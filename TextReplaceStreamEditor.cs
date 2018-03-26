using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDFCleaner
{
    public class TextReplaceStreamEditor : PdfContentStreamEditor
    {
        public TextReplaceStreamEditor(string MatchPattern, string ReplacePattern)
        {
            _matchPattern = MatchPattern;
            _replacePattern = ReplacePattern;
        }

        private string _matchPattern;
        private string _replacePattern;

        protected override void Write(PdfContentStreamProcessor processor, PdfLiteral oper, List<PdfObject> operands)
        {
            var operatorString = oper.ToString();
            if ("Tj".Equals(operatorString) || "TJ".Equals(operatorString))
            {
                for(var i = 0; i < operands.Count; i++)
                {
                    if(!operands[i].IsString())
                        continue;

                    var text = operands[i].ToString();
                    if(Regex.IsMatch(text, _matchPattern))
                    {
                        operands[i] = new PdfString(Regex.Replace(text, _matchPattern, _replacePattern));
                    }
                }
            }

            base.Write(processor, oper, operands);
        }
    }
}
