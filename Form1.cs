using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace PDFCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cbReplaceText_CheckedChanged(object sender, EventArgs e)
        {
            tbReplaceMatch.Enabled = cbReplaceText.Checked;
            tbReplaceReplace.Enabled = cbReplaceText.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbRedactMatch.Enabled = false;
            tbReplaceMatch.Enabled = false;
            tbReplaceReplace.Enabled = false;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(tbPath.Text))
                return;

            dataGridView1.Rows.Clear();
            Cursor = Cursors.WaitCursor;

            IEnumerable<string> srcFiles;
            if(System.IO.File.GetAttributes(tbPath.Text).HasFlag(FileAttributes.Directory))
            {
                srcFiles = Directory.EnumerateFiles(tbPath.Text, "*.pdf", SearchOption.AllDirectories);
            }
            else
            {
                srcFiles = new string[] { tbPath.Text };
            }

            foreach(var srcFile in srcFiles)
            {
                var dataGridRowNum = dataGridView1.Rows.Add(new object[] { srcFile, 0 } );
                PdfReader reader = null;
                PdfStamper pdfStamper = null;

                try
                {
                    reader = new PdfReader(srcFile);
                    var dstFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(srcFile),
                        System.IO.Path.GetFileNameWithoutExtension(srcFile) + "_clean.pdf");
                    var output = File.Open(dstFile, FileMode.Create);
         
                    pdfStamper = new PdfStamper(reader, output, reader.PdfVersion, false);
                    pdfStamper.RotateContents = false;
            
                    var replaceTextProcessor = new TextReplaceStreamEditor(tbReplaceMatch.Text, tbReplaceReplace.Text);
                    if(cbReplaceText.Checked)
                    {
                        for(int i=1; i <= reader.NumberOfPages; i++)
                            replaceTextProcessor.EditPage(pdfStamper, i);
                    }

                    var redactTextProcessor = new TextRedactStreamEditor(tbRedactMatch.Text);
                    if(cbRedactText.Checked)
                    {
                        for(int i=1; i <= reader.NumberOfPages; i++)
                            redactTextProcessor.EditPage(pdfStamper, i);
                        pdfStamper.Writer.SetEncryption(null, 
                            Encoding.UTF8.GetBytes("ownerPassword"),
                            PdfWriter.AllowDegradedPrinting | PdfWriter.AllowPrinting,
                            PdfWriter.ENCRYPTION_AES_256);
                    }


                    if (cbRemoveJavascript.Checked && reader.JavaScript != null)
                    {
                        pdfStamper.JavaScript = ""; 
                    }

                    pdfStamper.Writer.CompressionLevel = PdfStream.BEST_COMPRESSION;
                    pdfStamper.SetFullCompression();
                    pdfStamper.Writer.Info?.Clear();
                    pdfStamper.XmpMetadata = new byte[0];
                    pdfStamper.MoreInfo?.Clear();

                    dataGridView1.Rows[dataGridRowNum].ErrorText = "";;
                }
                catch(Exception ex)
                {
                    dataGridView1.Rows[dataGridRowNum].ErrorText = ex.Message;
                }
                finally
                {
                    pdfStamper?.Close();
                    reader?.Close();
                }
            }
            
            Cursor = Cursors.Arrow;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var browse = new CommonOpenFileDialog()
            {
                EnsurePathExists = true,
                //IsFolderPicker = true,
                Multiselect = false,
                Title = "Select Path for PDF Cleaner",
            };
            browse.Filters.Add( new CommonFileDialogFilter("PDF Files", ".pdf") );
            browse.DefaultExtension = ".pdf";
            
            if (browse.ShowDialog() == CommonFileDialogResult.Ok)
                tbPath.Text = browse.FileName;
        }

        private void cbRedactText_CheckedChanged(object sender, EventArgs e)
        {
            tbRedactMatch.Enabled = cbRedactText.Checked;
        }
    }
}
