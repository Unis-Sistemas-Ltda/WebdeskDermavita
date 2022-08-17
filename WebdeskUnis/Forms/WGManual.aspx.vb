Public Class WGManual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WUCFrame1.Pagina = "WGManual01.aspx"
        WUCFrame1.Width = "100%"
        WUCFrame1.Height = "100%"
        WUCFrame1.DataBind()
    End Sub

End Class