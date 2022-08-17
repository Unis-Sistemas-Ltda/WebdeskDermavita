Public Class WUCSolicitacaoDesenvolvimento
    Inherits System.Web.UI.UserControl

    Public Property Empresa As String
    Public Property CodSolicitacao As String
    Public Property Acao As String

    Public Property AcaoOriginal() As String
        Get
            Return Session("SAcaoOriginal")
        End Get
        Set(ByVal value As String)
            Session("SAcaoOriginal") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim alterouCodCliente As Long
        Dim CodClientePesquisado As String
        If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
            alterouCodCliente = Session("SAlterouCodCliente")
        Else
            alterouCodCliente = 0
        End If

        CodClientePesquisado = Session("SCodClientePesquisado")

        If Not String.IsNullOrEmpty(CodClientePesquisado) Then
            If alterouCodCliente > 0 Then
                If TxtCliente.Text <> CodClientePesquisado Then
                    TxtCliente.Text = CodClientePesquisado
                    Call CodigoClienteMudou()
                End If
                Session("SAlterouCodCliente") = alterouCodCliente - 1
            End If
        End If


        If Not IsPostBack Then
            Call CarregaDropDowns()
            AcaoOriginal = Acao
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
                txtDataSolicitacao.Enabled = False
                ChkClienteAprovar.Enabled = False
            ElseIf Acao = "INCLUIR" Then
                Session("SAcaoSolicitacao") = Acao
                Call CarregaNovaPK()
                txtDataSolicitacao.Text = Now.Date.ToString("dd/MM/yyyy")
                DdlOrigem.SelectedValue = "2"
                ddlAnalista.SelectedValue = 7
                TxtCliente.Text = Session("GlEmitente")
                Call CodigoClienteMudou()
                Call CarregaFrame(WUCFrame1, "WGSolicitacaoDesenvolvimentoFollowUp.aspx")
            End If
        End If
    End Sub

    Private Sub CarregaDropDowns()
        Call CarregaAnalista()
        Call CarregaSistema()
    End Sub

    Private Sub CarregaAnalista()
        Dim objAnalista As New UCLAnalista
        objAnalista.FillDropDown(ddlAnalista, False, "", "", True, 0)
    End Sub

    Private Sub CarregaSistema()
        Dim objSistema As New UCLSistema
        objSistema.FillDropDown(DdlSistema)
    End Sub

    Private Function Gravar() As Boolean
        Dim ObjSolicitacao As New UCLSolicitacaoDesenvolvimento()
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjSolicitacao.CodSolicitacao = LblCodSolicitacao.Text
                    ObjSolicitacao.Empresa = Session("GlEmpresa")
                    ObjSolicitacao.Buscar()
                    ObjSolicitacao = CarregaObjeto(ObjSolicitacao)
                    ObjSolicitacao.Alterar()
                    LblErro.Text = "Dados salvos com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjSolicitacao.CodSolicitacao = LblCodSolicitacao.Text
                    ObjSolicitacao.Empresa = Session("GlEmpresa")
                    ObjSolicitacao.Buscar()
                    ObjSolicitacao = CarregaObjeto(ObjSolicitacao)
                    ObjSolicitacao.Incluir()
                    LblErro.Text = "Dados salvos com sucesso."
                    Session("SAcao") = "ALTERAR"
                    Session("SCodSolicitacao") = LblCodSolicitacao.Text
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(txtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Nome.<br/>"
        End If

        If String.IsNullOrEmpty(txtAssunto.Text) Then
            LblErro.Text += "Preencha o campo Assunto.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjSolicitacaoDesenvolvimento As UCLSolicitacaoDesenvolvimento) As UCLSolicitacaoDesenvolvimento

        ObjSolicitacaoDesenvolvimento.Empresa = Session("GlEmpresa")
        ObjSolicitacaoDesenvolvimento.CodSolicitacao = LblCodSolicitacao.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.DataSolicitacao = txtDataSolicitacao.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.Origem = DdlOrigem.SelectedValue
        ObjSolicitacaoDesenvolvimento.CodAnalista = ddlAnalista.SelectedValue
        ObjSolicitacaoDesenvolvimento.CodEmitente = TxtCliente.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.CodSistema = DdlSistema.SelectedValue
        ObjSolicitacaoDesenvolvimento.Descricao = txtDescricao.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.RegraNegocio = txtRegraNegocio.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.Urgencia = ddlUrgencia.SelectedValue
        ObjSolicitacaoDesenvolvimento.PrazoObrigatorio = ChkPrazoObrigatorio.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjSolicitacaoDesenvolvimento.DataObrigatoria = txtPrazoObrigatorio.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.EmailClienteAprovar = ChkClienteAprovar.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjSolicitacaoDesenvolvimento.Assunto = txtAssunto.Text
        ObjSolicitacaoDesenvolvimento.ProximaVisita = txtProximaVisita.Text
        ObjSolicitacaoDesenvolvimento.Status = DdlStatus.SelectedValue
        ObjSolicitacaoDesenvolvimento.DataPrevisaoEntrega = txtDataEntregaPrevista.Text.GetValidInputContent
        ObjSolicitacaoDesenvolvimento.SeqPrioridadeCliente = TxtSeqPrioridade.Text
        Return ObjSolicitacaoDesenvolvimento
    End Function

    Private Sub CarregaFormulario()
        Dim ObjSolicitacaoDesenvolvimento As New UCLSolicitacaoDesenvolvimento()
        Dim ObjUsuario As New UCLUsuario

        ObjSolicitacaoDesenvolvimento.CodSolicitacao = CodSolicitacao
        ObjSolicitacaoDesenvolvimento.Empresa = Session("GlEmpresa")
        ObjSolicitacaoDesenvolvimento.Buscar()
        LblCodSolicitacao.Text = CodSolicitacao
        txtDataSolicitacao.Text = ObjSolicitacaoDesenvolvimento.DataSolicitacao
        txtDataEntregaPrevista.Text = ObjSolicitacaoDesenvolvimento.DataPrevisaoEntrega
        DdlOrigem.SelectedValue = ObjSolicitacaoDesenvolvimento.Origem
        ddlAnalista.SelectedValue = ObjSolicitacaoDesenvolvimento.CodAnalista
        TxtCliente.Text = ObjSolicitacaoDesenvolvimento.CodEmitente
        DdlSistema.SelectedValue = ObjSolicitacaoDesenvolvimento.CodSistema
        txtDescricao.Text = ObjSolicitacaoDesenvolvimento.Descricao
        txtRegraNegocio.Text = ObjSolicitacaoDesenvolvimento.RegraNegocio
        ddlUrgencia.SelectedValue = ObjSolicitacaoDesenvolvimento.Urgencia

        If Not String.IsNullOrWhiteSpace(ObjSolicitacaoDesenvolvimento.PrazoObrigatorio) Then
            ChkPrazoObrigatorio.Checked = ObjSolicitacaoDesenvolvimento.PrazoObrigatorio.ToString.Replace("N", "False").Replace("S", "True")
        Else
            ChkPrazoObrigatorio.Checked = False
        End If

        If Not String.IsNullOrWhiteSpace(ObjSolicitacaoDesenvolvimento.EmailClienteAprovar) Then
            ChkClienteAprovar.Checked = ObjSolicitacaoDesenvolvimento.EmailClienteAprovar.ToString.Replace("N", "False").Replace("S", "True")
        Else
            ChkClienteAprovar.Checked = False
        End If

        txtPrazoObrigatorio.Text = ObjSolicitacaoDesenvolvimento.DataObrigatoria
        txtAssunto.Text = ObjSolicitacaoDesenvolvimento.Assunto
        TxtProximaVisita.Text = ObjSolicitacaoDesenvolvimento.ProximaVisita
        DdlStatus.SelectedValue = ObjSolicitacaoDesenvolvimento.Status

        If ObjSolicitacaoDesenvolvimento.Status = "0" OrElse ObjSolicitacaoDesenvolvimento.Status = "1" OrElse ObjSolicitacaoDesenvolvimento.Status = "4" OrElse ObjSolicitacaoDesenvolvimento.Status = "5" OrElse ObjSolicitacaoDesenvolvimento.Status = "6" Then
            BtnCancelar.Visible = True
        Else
            BtnCancelar.Visible = False
        End If

        TxtSeqPrioridade.Text = ObjSolicitacaoDesenvolvimento.SeqPrioridadeCliente
        Call CodigoClienteMudou()
        Select Case ObjSolicitacaoDesenvolvimento.Status
            Case "2", "3"
                DdlSistema.Enabled = False
                txtAssunto.Enabled = False
                txtDescricao.Enabled = False
                txtRegraNegocio.Enabled = False
                ddlUrgencia.Enabled = False
        End Select
        Call CarregaFrame(WUCFrame1, "WGSolicitacaoDesenvolvimentoFollowUp.aspx")
    End Sub

    Private Sub CarregaNovaPK()
        Dim objSolicitacaoDesenvolvimento As New UCLSolicitacaoDesenvolvimento()
        objSolicitacaoDesenvolvimento.Empresa = Session("GlEmpresa")
        LblCodSolicitacao.Text = objSolicitacaoDesenvolvimento.GetProximoCodigo
    End Sub

    Private Sub MostraNomeCliente()
        Try
            Dim ObjEmitente As New UCLEmitente()
            ObjEmitente.CodEmitente = TxtCliente.Text
            ObjEmitente.Buscar()
            LblNomeCliente.Text = ObjEmitente.Nome
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub CodigoClienteMudou()
        Call MostraNomeCliente()
        'Session("SCodEmitenteNegociacao") = TxtCliente.Text
        Session("SCodClientePesquisado") = TxtCliente.Text
    End Sub

    Protected Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        Call CodigoClienteMudou()
    End Sub

    Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Try
            DdlStatus.SelectedValue = "7"
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
End Class