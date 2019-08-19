Imports DevExpress.Pdf
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace pdf_custom_properties
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Using pdfProcessor As New PdfDocumentProcessor()
				pdfProcessor.LoadDocument("PageDeletion.pdf")
				ModifyCustomProperties(pdfProcessor.Document)
				pdfProcessor.SaveDocument("Result.pdf")
				Process.Start("Result.pdf")
			End Using
		End Sub

		Private Shared Sub ModifyCustomProperties(ByVal document As PdfDocument)
			'Add new property
			document.CustomProperties.Add("NumberOfCopies", "3")

			'Modify the CompanyEmail property value:
			If document.CustomProperties.ContainsKey("CompanyEmail") Then
				document.CustomProperties("CompanyEmail") = "clientservices@devexpress.com"
			End If

			'Remove the HasImages property:
			document.CustomProperties.Remove("HasImages")
		End Sub
	End Class
End Namespace
