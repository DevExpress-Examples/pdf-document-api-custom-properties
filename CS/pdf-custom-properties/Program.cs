using DevExpress.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_custom_properties
{
    class Program
    {        
        static void Main(string[] args)
        {
            using (PdfDocumentProcessor pdfProcessor = new PdfDocumentProcessor())
            {
                pdfProcessor.LoadDocument("PageDeletion.pdf");
                ModifyCustomProperties(pdfProcessor.Document);
                pdfProcessor.SaveDocument("Result.pdf");
                Process.Start("Result.pdf");
            }
        }

        private static void ModifyCustomProperties(PdfDocument document)
        {
            //Add new property
            document.CustomProperties.Add("NumberOfCopies", "3");

            //Modify the CompanyEmail property value:
            if (document.CustomProperties.ContainsKey("CompanyEmail"))
                document.CustomProperties["CompanyEmail"] = "clientservices@devexpress.com";

            //Remove the HasImages property:
            document.CustomProperties.Remove("HasImages");
        }
    }
}
