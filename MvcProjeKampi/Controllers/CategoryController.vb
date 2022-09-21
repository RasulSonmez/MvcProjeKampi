Imports System.Web.Mvc

Namespace Controllers
    Public Class CategoryController
        Inherits Controller

        ' GET: Category
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace