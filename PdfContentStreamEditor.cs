using System.Collections.Generic;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDFCleaner
{
    public class PdfContentStreamEditor : PdfContentStreamProcessor
    {
        /**
         * This method edits the immediate contents of a page, i.e. its content stream.
         * It explicitly does not descent into form xobjects, patterns, or annotations.
         */
        public void EditPage(PdfStamper pdfStamper, int pageNum)
        {
            var pdfReader = pdfStamper.Reader;
            var page = pdfReader.GetPageN(pageNum);
            var pageContentInput = ContentByteUtils.GetContentBytesForPage(pdfReader, pageNum);
            page.Remove(PdfName.CONTENTS);
            EditContent(pageContentInput, page.GetAsDict(PdfName.RESOURCES), pdfStamper.GetUnderContent(pageNum));
        }

        /**
         * This method processes the content bytes and outputs to the given canvas.
         * It explicitly does not descent into form xobjects, patterns, or annotations.
         */
        public virtual void EditContent(byte[] contentBytes, PdfDictionary resources, PdfContentByte canvas)
        {
            this.Canvas = canvas;
            ProcessContent(contentBytes, resources);
            this.Canvas = null;
        }

        /**
         * This method writes content stream operations to the target canvas. The default
         * implementation writes them as they come, so it essentially generates identical
         * copies of the original instructions the {@link ContentOperatorWrapper} instances
         * forward to it.
         *
         * Override this method to achieve some fancy editing effect.
         */

        protected virtual void Write(PdfContentStreamProcessor processor, PdfLiteral operatorLit, List<PdfObject> operands)
        {
            var index = 0;

            foreach (var pdfObject in operands)
            {
                pdfObject.ToPdf(null, Canvas.InternalBuffer);
                Canvas.InternalBuffer.Append(operands.Count > ++index ? (byte) ' ' : (byte) '\n');
            }
        }


        //
        // constructor giving the parent a dummy listener to talk to 
        //
        public PdfContentStreamEditor() : base(new DummyRenderListener())
        {
        }

        //
        // constructor giving the parent a dummy listener to talk to 
        //
        public PdfContentStreamEditor(IRenderListener renderListener) : base(renderListener)
        {
        }

        //
        // Overrides of PdfContentStreamProcessor methods
        //
        
        public override IContentOperator RegisterContentOperator(string operatorString, IContentOperator newOperator)
        {
            var wrapper = new ContentOperatorWrapper();
            wrapper.SetOriginalOperator(newOperator);
            var formerOperator = base.RegisterContentOperator(operatorString, wrapper);
            return (formerOperator is ContentOperatorWrapper operatorWrapper ? operatorWrapper.GetOriginalOperator() : formerOperator);
        }

        public override void ProcessContent(byte[] contentBytes, PdfDictionary resources)
        {
            this.Resources = resources; 
            base.ProcessContent(contentBytes, resources);
            this.Resources = null;
        }

        //
        // members holding the output canvas and the resources
        //
        protected PdfContentByte Canvas = null;
        protected PdfDictionary Resources = null;

        //
        // A content operator class to wrap all content operators to forward the invocation to the editor
        //
        class ContentOperatorWrapper : IContentOperator
        {
            public IContentOperator GetOriginalOperator()
            {
                return _originalOperator;
            }

            public void SetOriginalOperator(IContentOperator op)
            {
                this._originalOperator = op;
            }

            public void Invoke(PdfContentStreamProcessor processor, PdfLiteral oper, List<PdfObject> operands)
            {
                if (_originalOperator != null && !"Do".Equals(oper.ToString()))
                {
                    _originalOperator.Invoke(processor, oper, operands);
                }
                ((PdfContentStreamEditor)processor).Write(processor, oper, operands);
            }

            private IContentOperator _originalOperator = null;
        }

        //
        // A dummy render listener to give to the underlying content stream processor to feed events to
        //
        class DummyRenderListener : IRenderListener
        {
            public void BeginTextBlock() { }

            public void RenderText(TextRenderInfo renderInfo) { }

            public void EndTextBlock() { }

            public void RenderImage(ImageRenderInfo renderInfo) { }
        }
    }
}
