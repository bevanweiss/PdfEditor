using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
/*
using iTextSharp.text.pdf.parser;

namespace PDFCleaner
{
    public class MyTextRenderListener : IRenderListener
    {
        public List<iTextSharp.text.Rectangle> RectangleList = new List<iTextSharp.text.Rectangle>();
        private string _matchPattern;
        private string _replacePattern;

        public MyTextRenderListener(string matchPattern, string replacePattern)
        {
            _matchPattern = matchPattern;
            _replacePattern = replacePattern;
        }

        public void BeginTextBlock()
        {
            
        }

        public void RenderText(TextRenderInfo renderInfo)
        {
            var output = Regex.Match(renderInfo.PdfString.ToUnicodeString(), _matchPattern);

            if (!output.Success)
                return;

            //Grab the individual characters
            var chars = renderInfo.GetCharacterRenderInfos();

            //Grab the first and last character
            var firstChar = chars.First();
            var lastChar = chars.Last();

            //Get the bounding box for the chunk of text
            var bottomLeft = firstChar.GetDescentLine().GetStartPoint();
            var topRight = lastChar.GetAscentLine().GetEndPoint();

            //Create a rectangle from it
            var rect = new iTextSharp.text.Rectangle(
                bottomLeft[Vector.I1],
                bottomLeft[Vector.I2],
                topRight[Vector.I1],
                topRight[Vector.I2]
            );

            RectangleList.Add(rect);
        }

        public void EndTextBlock()
        {
            
        }

        public void RenderImage(ImageRenderInfo renderInfo)
        {
            
        }
    }
}
*/