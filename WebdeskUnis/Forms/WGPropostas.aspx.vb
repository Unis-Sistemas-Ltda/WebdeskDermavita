Public Class WGPropostas
    Inherits System.Web.UI.Page

    Private Sub AjustaVisibilidadeCampos(ByVal logado As Boolean)
        Try
            If logado Then
                If Session("GlEmitente") IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("GlEmitente")) AndAlso IsNumeric(Session("GlEmitente")) AndAlso Session("GlEmitente") > 0 Then
                    LblCodEmitente.Text = Session("GlEmitente").ToString
                End If

                GridView1.Visible = True
                LblInstrucoesBoleto.Visible = True

            Else
                LblCodEmitente.Text = "0"

                GridView1.Visible = False
                LblInstrucoesBoleto.Visible = False

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("GlEmitente") IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("GlEmitente")) AndAlso IsNumeric(Session("GlEmitente")) AndAlso Session("GlEmitente") > 0 Then
                    Call AjustaVisibilidadeCampos(True)
                Else
                    Call AjustaVisibilidadeCampos(False)
                End If
                Call CarregaGrid()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaGrid()
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim Localizacao As String = "00"
        Try
            'Dim chave As String() '(0) = Empresa | (1) = Cód. Borderô | (2) = Cód. Espécie | (3) = Série | (4) = cod_tit_cr | (5) = Parcela | (6) = Cenário
            Localizacao = "01"

            If e.CommandName = "ALTERAR" Then
                Localizacao = "03"
                'chave = e.CommandArgument
                Localizacao = "04"
                If e.CommandArgument IsNot Nothing Then
                    Localizacao = "05"
                    Response.Redirect("WFNegociacaoDetalhes.aspx?nid=" + e.CommandArgument.ToString)
                    Localizacao = "06"

                End If
            End If
        Catch ex As Exception
            LblErro.Text = "[" + Localizacao + "] " + ex.ToString
        End Try
    End Sub


End Class