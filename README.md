# PdfEditor

A very basic trial project for manipulation of PDF files using iTextSharp.
This allows for:
* Removing Javascript from a PDF file (only the global JS is done)
* Searching and replacing text within a PDF.  Note: It must be actual (Tj/TJ) text, and can't have placement modifiers between the letters.
* Searching and redacting text within a PDF.  Note: This just puts a black bar over the text regex in question, it also then marks the PDF as secure and prevents copying (or reading) to further obscure the text.
