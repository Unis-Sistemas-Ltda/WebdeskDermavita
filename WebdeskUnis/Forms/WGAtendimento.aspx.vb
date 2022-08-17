Partial Public Class WGAtendimento
    Inherits System.Web.UI.Page
    Dim objParametrosManutencao As New UCLParametrosManutencao
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objAnalista As New UCLAnalista

            If Not IsPostBack Then
                Call CarregaContatos()
                Call CarregaTipoChamado()
                Call AplicaFiltro()
            End If

            If Session("SSErro") IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("SSErro").ToString.Trim) Then
                LblErro.Text = Session("SSErro").ToString.Trim
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub


    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SCodAtendimento") = e.CommandArgument
            Session("SAcao") = "ALTERAR"
            Response.Redirect("WFAtendimentoCabecalho.aspx")
        End If
    End Sub

    Protected Sub AplicaFiltro()
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
        GridView1.Sort("data_chamado", SortDirection.Descending)
    End Sub

    Protected Sub Menu1_MenuItemClick(sender As Object, e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        LblFiltroChamado.Text = e.Item.Target
        Session("SFiltroChamado") = e.Item.Target

        Select Case LblFiltroChamado.Text
            Case "0"
                Session("SAcao") = "INCLUIR"
                Session("SCodAtendimento") = -1
                Response.Redirect("WFAtendimentoCabecalho.aspx")
            Case "1"
                GridView1.EmptyDataText = "<br><br>Não há chamados pendentes (conforme filtros acima informados).<br/>Se desejar abrir um chamado, clique na opção <b>Novo chamado</b> acima."
            Case "2"
                GridView1.EmptyDataText = "<br><br>Não há chamados aguardando aceite do cliente (conforme filtros acima informados).<br/>Se desejar abrir um chamado, clique na opção <b>Novo chamado</b> acima."
            Case "3"
                GridView1.EmptyDataText = "<br><br>Não há chamados encerrados (conforme filtros acima informados).<br/>Se desejar abrir um chamado, clique na opção <b>Novo chamado</b> acima."
        End Select
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call AplicaFiltro()
    End Sub

    Private Sub CarregaContatos()
        Try
            Dim objContatos As New UCLContato
            objContatos.CodEmitente = Session("GlEmitente")
            objContatos.FillDropDown(DdlContatoResponsavel, True, "(todos)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaTipoChamado()
        Try
            Dim objTipChamado As New UCLTipoChamado
            objTipChamado.Empresa = Session("GlEmpresa")
            objTipChamado.FillDropDownChamado(DdlTipoChamado, True, "(todos)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class