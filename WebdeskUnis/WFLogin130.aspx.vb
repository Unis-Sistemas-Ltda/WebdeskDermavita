Public Class WFLogin130
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim auto As Boolean
            Call SetaDsnAplicacao()

            If Session("SConectaAuto") = "True" Or Session("SConectaAuto") = "False" Then
                auto = Session("SConectaAuto")
            Else
                auto = False
            End If

            If auto Then
                TxtLogin.Text = Session("SCNPJConexao")
                Dim objLogin As New UCLLogin
                If objLogin.Conectar(TxtLogin.Text, TxtSenha.Text, auto, LblErro) Then
                    FormsAuthentication.RedirectFromLoginPage(TxtLogin.Text, False)
                End If
            End If
        End If
    End Sub

    Protected Sub BtnConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConectar.Click
        Dim objLogin As New UCLLogin
        If objLogin.Conectar(TxtLogin.Text, TxtSenha.Text, False, LblErro) Then
            FormsAuthentication.RedirectFromLoginPage(TxtLogin.Text, False)
        End If
    End Sub

    Protected Sub BtnEsqueciMinhaSenha_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEsqueciMinhaSenha.Click
        If IsNumeric(TxtLogin.Text.Replace("/", "").Replace("\", "").Replace(".", "").Replace("-", "").Replace(" ", "")) Then
            Session("GlCNPJ") = TxtLogin.Text.Replace("/", "").Replace("\", "").Replace(".", "").Replace("-", "").Replace(" ", "")
        End If
        Response.Redirect("Forms/WFNovaSenha.aspx")
    End Sub

End Class