using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDFCleaner
{
    public class TextRedactStreamEditor : PdfContentStreamEditor
    {
        public TextRedactStreamEditor(string MatchPattern) : base(new RedactRenderListener(MatchPattern))
        {
            _matchPattern = MatchPattern;
        }

        private string _matchPattern;

        protected override void Write(PdfContentStreamProcessor processor, PdfLiteral oper, List<PdfObject> operands)
        {
            base.Write(processor, oper, operands);
        }

        public override void EditContent(byte[] contentBytes, PdfDictionary resources, PdfContentByte canvas)
        {
            ((RedactRenderListener)base.RenderListener).SetCanvas(canvas);
            base.EditContent(contentBytes, resources, canvas);
        }
    }

    //
    // A dummy render listener to give to the underlying content stream processor to feed events to
    //
    class RedactRenderListener : IRenderListener
    {
        private PdfContentByte _canvas;
        private string _matchPattern;

        public RedactRenderListener(string MatchPattern)
        {
            _matchPattern = MatchPattern;
        }
        
        public RedactRenderListener(PdfContentByte Canvas, string MatchPattern)
        {
            _canvas = Canvas;
            _matchPattern = MatchPattern;
        }

        public void SetCanvas(PdfContentByte Canvas)
        {
            _canvas = Canvas;
        }

        public void BeginTextBlock() { }

        public void RenderText(TextRenderInfo renderInfo)
        {
            var text = renderInfo.GetText();

            var match = Regex.Match(text, _matchPattern);
            if(match.Success)
            {
                var p1 = renderInfo.GetCharacterRenderInfos()[match.Index].GetAscentLine().GetStartPoint();
                var p2 = renderInfo.GetCharacterRenderInfos()[match.Index+match.Length].GetAscentLine().GetEndPoint();
                var p3 = renderInfo.GetCharacterRenderInfos()[match.Index+match.Length].GetDescentLine().GetEndPoint();
                var p4 = renderInfo.GetCharacterRenderInfos()[match.Index].GetDescentLine().GetStartPoint();

                _canvas.SaveState();
                _canvas.SetColorStroke(BaseColor.BLACK);
                _canvas.SetColorFill(BaseColor.BLACK);
                _canvas.MoveTo(p1[Vector.I1], p1[Vector.I2]);
                _canvas.LineTo(p2[Vector.I1], p2[Vector.I2]);
                _canvas.LineTo(p3[Vector.I1], p3[Vector.I2]);
                _canvas.LineTo(p4[Vector.I1], p4[Vector.I2]);
                _canvas.ClosePathFillStroke();
                _canvas.RestoreState();
            }
        }

        public void EndTextBlock() { }

        public void RenderImage(ImageRenderInfo renderInfo) { }
    }
}
