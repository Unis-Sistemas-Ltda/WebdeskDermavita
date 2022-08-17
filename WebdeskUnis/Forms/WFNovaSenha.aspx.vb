Partial Public Class WFNovaSenha
    Inherits System.Web.UI.Page
    Private ACnpj As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TxtCnpj.Text = Session("GlCNPJ")
        End If
    End Sub

    Protected Sub BtnGerarSenha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGerarSenha.Click
        Try
            Dim Cnpj As String
            Dim ObjEnderecoEmitente As New UCLEnderecoEmitente

            Cnpj = Trim(TxtCnpj.Text).Replace(".", "").Replace("/", "").Replace("-", "").Replace("\", "")

            ObjEnderecoEmitente.CNPJ = Cnpj
            LblMensagem.Text = ObjEnderecoEmitente.GerarSenha()
        Catch ex As Exception
            LblMensagem.Text = ex.Message.ToString
        End Try
        
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WFPrincipal.aspx")
    End Sub
End Class