Public Class WFRedirecionar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call Registrar()
            End If
            Call Redirecionar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString()
        End Try
    End Sub

    Private Sub Redirecionar()
        Try
            Dim caminho As String = Prop_Redirecionar
            caminho = caminho.Replace("_b", "/")
            caminho = caminho.Replace("_p", ".")
            caminho = caminho.Replace("_d", ":")
            caminho = caminho.Replace("_e", "&")
            caminho = caminho.Replace("_i", "?")
            caminho = caminho.Replace("_q", "=")
            Response.Redirect(caminho)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Registrar()
        Try
            Dim objAcessoCampanhaTEF As New UCLAcessoCampanhaTEF
            objAcessoCampanhaTEF.SetConteudo("empresa", "1")
            objAcessoCampanhaTEF.SetConteudo("seq_acesso", objAcessoCampanhaTEF.GetProximoCodigo(1))
            objAcessoCampanhaTEF.SetConteudo("cod_emitente", Prop_CodEmitente)
            objAcessoCampanhaTEF.SetConteudo("cod_adesao", Prop_CodAdesao)
            objAcessoCampanhaTEF.SetConteudo("tipo_conteudo", Prop_TipoConteudo)
            objAcessoCampanhaTEF.SetConteudo("data_acesso", Now.ToString("dd/MM/yyyy HH:mm:ss"))
            objAcessoCampanhaTEF.Incluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Prop_CodEmitente As String
        Get
            Return Request.QueryString.Item("e")
        End Get
    End Property

    Private ReadOnly Property Prop_CodAdesao As String
        Get
            Return Request.QueryString.Item("a")
        End Get
    End Property

    Private ReadOnly Property Prop_TipoConteudo As String
        Get
            Return Request.QueryString.Item("t")
        End Get
    End Property

    Private ReadOnly Property Prop_Redirecionar As String
        Get
            Return Request.QueryString.Item("r")
        End Get
    End Property

End Class