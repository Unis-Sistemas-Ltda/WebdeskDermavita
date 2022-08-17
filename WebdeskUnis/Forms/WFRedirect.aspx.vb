Public Class WFRedirect
    Inherits System.Web.UI.Page

    Private Autenticacao_URL As String = ""
    Private CNPJ_URL As String = ""
    Private CodEmitente_URL As String = ""
    Private ID_URL As String = ""
    Private Codigo_URL As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim aut As String
            Dim dia As Long
            Dim ano As Long
            Dim minuto As Long

            If Request.QueryString.Count <> 5 Then
                Throw New Exception("Parâmetros para conexão não são válidos.")
            End If
            Session("SConectaAuto") = "True"
            Call CarregaVariaveisQueryString()

            If Not String.IsNullOrWhiteSpace(ID_URL) AndAlso ID_URL <> "387" Then
                aut = Autenticacao_URL

                aut = (CDbl(Autenticacao_URL) / 4).ToString.PadLeft(11, "0")

                minuto = aut.Substring(0, 4)
                ano = aut.Substring(4, 4)
                dia = aut.Substring(8, 3)

                If ano <> Now.Year Then
                    Throw New Exception("Ano inválido.")
                End If

                If dia <> Now.DayOfYear Then
                    Throw New Exception("Dia inválido.")
                End If

                If minuto < Now.TimeOfDay.TotalMinutes - 120 OrElse minuto > Now.TimeOfDay.TotalMinutes + 120 Then
                    Throw New Exception("Minuto inválido.")
                End If
            End If
            
            If Not String.IsNullOrWhiteSpace(CNPJ_URL) Then
                Session("SCNPJConexao") = Math.Round(CDbl(CNPJ_URL) / 4, 0).ToString.PadLeft(14, "0")
                Dim objLogin As New UCLLogin
                If objLogin.Conectar(Session("SCNPJConexao"), "", True, LblErro) Then
                    FormsAuthentication.SetAuthCookie(Session("SCNPJConexao"), False)
                    Response.Redirect("WFPrincipal.aspx?a=" + Autenticacao_URL + "&c=" + CNPJ_URL + "&g=" + CodEmitente_URL + "&i=" + ID_URL + "&f=" + Codigo_URL)
                End If
            Else
                Response.Redirect("WFPrincipal.aspx?a=" + Autenticacao_URL + "&c=" + CNPJ_URL + "&g=" + CodEmitente_URL + "&i=" + ID_URL + "&f=" + Codigo_URL)
            End If


        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaVariaveisQueryString()
        Try
            Autenticacao_URL = Request.QueryString.Item("a")
            CNPJ_URL = Request.QueryString.Item("c")
            CodEmitente_URL = Request.QueryString.Item("g")
            ID_URL = Request.QueryString.Item("i")
            Codigo_URL = Request.QueryString.Item("f")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class