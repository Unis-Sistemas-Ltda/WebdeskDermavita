Public Class WGSolicitacaoDesenvolvimento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPeriodoI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        txtPeriodoF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
        txtPeriodoI.Attributes.Add("OnFocus", "selecionaCampo(this)")
        txtPeriodoF.Attributes.Add("OnFocus", "selecionaCampo(this)")

        If Not IsPostBack Then
            Call CarregaAnalista()
            Call CarregaVersao()
        End If
    End Sub

    Private Sub CarregaVersao()
        Dim ObjVersaoSistema As New UCLVersaoSistema
        ObjVersaoSistema.FillDropDown(DdlReleaseVersaoBanco, True, "(Todas)")
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, True, "(Todos)", 0, True, 0)
        ddlAnalista.Items.FindByValue(0).Selected = True
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "ALTERAR" Then
            Session("SAcao") = e.CommandName
            Session("SCodSolicitacao") = e.CommandArgument
            Response.Redirect("WFSolicitacaoDesenvolvimentoDetalhes.aspx")
        End If
    End Sub


    Protected Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        GridView1.DataBind()
    End Sub

    Protected Sub BtnFiltrar0_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Session("SAcao") = "INCLUIR"
        Session("SCodSolicitacao") = -1
        Response.Redirect("WFSolicitacaoDesenvolvimentoDetalhes.aspx")
    End Sub
End Class