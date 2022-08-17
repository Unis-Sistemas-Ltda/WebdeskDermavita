Partial Public Class WGNegociacaoHistorico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim emp = Session("SSequenciaEmail")
        Dim codEm = Session("SCodEmitente")
        Dim codNEg = Session("SCodNegociacao")
        If codNEg = 0 Then
            codNEg = 0
        End If
    End Sub

    'Protected Sub ImageButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
    '    If Session("SCodNegociacao") <> -1 Then
    '        Session("SSeqFollowUp") = -1
    '        Session("SAcaoFollowUp") = "INCLUIR"
    '        Response.Redirect("WFNegociacaoFollowUp.aspx")
    '    Else
    '        LblErro.Text = "Não é permitido incluir um registro de item antes de salvar o cabeçalho da negociação."
    '    End If
    'End Sub

    Private Sub GridView3_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView3.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqFolowUp") = e.CommandArgument
            Session("SAcaoFollowUp") = "ALTERAR"
            Response.Redirect("WFNegociacaoFollowUp.aspx")
        ElseIf e.CommandName = "EXPANDIR" Then
            Call Processa(e.CommandArgument)
        End If
    End Sub

    Protected Sub Processa(ByVal codFollowUp As String)
        Dim expandido As Boolean
        Dim linha As GridViewRow = Nothing

        For Each row As GridViewRow In GridView3.Rows
            If row.RowType = DataControlRowType.DataRow Then
                If CType(row.FindControl("LblCodFollowUp"), Label).Text = codFollowUp Then
                    linha = row
                    expandido = CType(row.FindControl("LblDetalhes"), Label).Visible
                    Exit For
                End If
            End If
        Next

        If linha IsNot Nothing Then
            If expandido Then
                Call OcultaDetalhamento(linha)
            Else
                Call Expande(linha)
            End If
        End If

    End Sub

    Protected Sub Expande(ByVal row As GridViewRow)
        Dim LblDetalhes As Label
        Dim LinkExpansao As LinkButton

        LblDetalhes = row.FindControl("LblDetalhes")
        LblDetalhes.Visible = True

        LinkExpansao = row.FindControl("LinkExpansao")
        LinkExpansao.Text = "-"
    End Sub

    Protected Sub OcultaDetalhamento(ByVal row As GridViewRow)
        Dim LblDetalhes As Label
        Dim LinkExpansao As LinkButton

        LblDetalhes = row.FindControl("LblDetalhes")
        LblDetalhes.Visible = False

        LinkExpansao = row.FindControl("LinkExpansao")
        LinkExpansao.Text = "+"
    End Sub

    Protected Sub Processa2(ByVal codFollowUp As String)
        Dim expandido As Boolean
        Dim linha As GridViewRow = Nothing

        For Each row As GridViewRow In GridView6.Rows
            If row.RowType = DataControlRowType.DataRow Then
                If CType(row.FindControl("LblCodFollowUp2"), Label).Text = codFollowUp Then
                    linha = row
                    expandido = CType(row.FindControl("LblComentario"), Label).Visible
                    Exit For
                End If
            End If
        Next

        If linha IsNot Nothing Then
            If expandido Then
                Call OcultaDetalhamento2(linha)
            Else
                Call Expande2(linha)
            End If
        End If

    End Sub

    Protected Sub Expande2(ByVal row As GridViewRow)
        Dim lblComentario As Label
        Dim LinkExpansao As LinkButton
        lblComentario = row.FindControl("LblComentario")
        lblComentario.Visible = True

        LinkExpansao = row.FindControl("LinkExpansao2")
        LinkExpansao.Text = "-"
    End Sub

    Protected Sub OcultaDetalhamento2(ByVal row As GridViewRow)
        Dim lblComentario As Label
        Dim LinkExpansao As LinkButton

        lblComentario = row.FindControl("LblComentario")
        lblComentario.Visible = False

        LinkExpansao = row.FindControl("LinkExpansao2")
        LinkExpansao.Text = "+"
    End Sub

    'Protected Sub ImageButton3_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
    '    If Session("SCodNegociacao") <> -1 Then
    '        Session("SSeqTarefaNegociacao") = -1
    '        Session("SAcaoItem") = "INCLUIR"
    '        Response.Redirect("WFNegociacaoTarefa.aspx")
    '    Else
    '        LblErro.Text = "Não é permitido incluir um registro de item antes de salvar o cabeçalho da negociação."
    '    End If
    'End Sub

    Protected Sub DdlSituacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlSituacao.SelectedIndexChanged
        SqlDataSource4.Select(DataSourceSelectArguments.Empty)
        SqlDataSource4.DataBind()
        GridView4.DataBind()
    End Sub

    Protected Sub GridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView3.SelectedIndexChanged

    End Sub

    Private Sub GridView4_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView4.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqTarefaNegociacao") = e.CommandArgument
            Session("SAcaoItem") = "ALTERAR"
            Response.Redirect("WFNegociacaoTarefa.aspx")
        End If
    End Sub

    Protected Sub GridView4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView4.SelectedIndexChanged

    End Sub

    'Protected Sub BtnNovoRegistro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNovoRegistro.Click
    '    Session("SAcaoVisitacao") = "INCLUIR"
    '    Session("SSeqVisita") = -1
    '    Response.Redirect("WFVisitacao.aspx?b=WGNegociacaoHistorico.aspx")
    'End Sub

    Private Sub GridView5_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView5.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqVisita") = e.CommandArgument
            Session("SAcaoVisitacao") = "ALTERAR"
            Response.Redirect("WFVisitacao.aspx?b=WGNegociacaoHistorico.aspx")
        End If
    End Sub

    Protected Sub GridView6_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView6.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SSeqFolowUp") = e.CommandArgument
            Session("SAcaoFollowUp") = "ALTERAR"
            Response.Redirect("WFNegociacaoFollowUp.aspx")
        ElseIf e.CommandName = "EXPANDIR" Then
            Call Processa2(e.CommandArgument)
        End If
    End Sub
End Class