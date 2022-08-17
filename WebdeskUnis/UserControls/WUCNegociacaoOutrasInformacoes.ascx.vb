Partial Public Class WUCNegociacaoOutrasInformacoes
    Inherits System.Web.UI.UserControl
    Private _CodNegociacao As String

    Public Property CodNegociacao() As String
        Get
            Return Session("CodNegociacao")
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AlterouCodTransportadora As String
        Dim CodTransportadoraPesquisado As String
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))

        objNegociacao.Empresa = Session("GlEmpresa")
        objNegociacao.BuscarLabelsAuxiliares()
        'LblAuxLabel1.Text = objNegociacao.AuxLabel1
        'LblAux2Label.Text = objNegociacao.AuxLabel2
        'LblAux3Label.Text = objNegociacao.AuxLabel3

        If Not String.IsNullOrEmpty(Session("SAlterouCodTransportadora")) Then
            AlterouCodTransportadora = Session("SAlterouCodTransportadora")
        Else
            AlterouCodTransportadora = 0
        End If

        CodTransportadoraPesquisado = Session("SCodTransportadoraPesquisado")

        If Not String.IsNullOrEmpty(CodTransportadoraPesquisado) Then
            If AlterouCodTransportadora > 0 Then
                If TxtCodTransportadora.Text <> CodTransportadoraPesquisado Then
                    TxtCodTransportadora.Text = CodTransportadoraPesquisado
                    Call CodigoTransportadoraMudou()
                End If
                Session("SAlterouCodTransportadora") = AlterouCodTransportadora - 1
            End If
        End If

        If CodNegociacao = -1 Then
            LblErro.Text = "Antes de preencher os campos abaixo, é necessário que você salve a negociação."
            'BtnGravar.Enabled = False
            TxtObservacao.Enabled = False
        Else
            'BtnGravar.Enabled = True
            TxtObservacao.Enabled = True
        End If
        If Not IsPostBack Then
            Call CarregaFormulario()
        End If

        Call MostraNomeTransportadora()

        'If String.IsNullOrWhiteSpace(LblAuxLabel1.Text) Then
        '    TxtAux1.Visible = False
        'End If

        'If String.IsNullOrWhiteSpace(LblAux2Label.Text) Then
        '    TxtAux2.Visible = False
        'End If

        'If String.IsNullOrWhiteSpace(LblAux3Label.Text) Then
        '    DdlAux3.Visible = False
        'End If
    End Sub

    Private Sub CarregaFormulario()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))

        objNegociacao.Empresa = Session("GlEmpresa")
        objNegociacao.Estabelecimento = Session("GlEstabelecimento")
        objNegociacao.CodNegociacao = CodNegociacao
        objNegociacao.Buscar()

        TxtObservacao.Text = objNegociacao.Observacao
        TxtCodTransportadora.Text = objNegociacao.CodTransportadora
        'TxtAux1.Text = objNegociacao.Aux1
        'TxtAux2.Text = objNegociacao.Aux2
        'DdlAux3.SelectedValue = objNegociacao.Aux3
        'TxtDataEmissaoContrato.Text = objNegociacao.DataEmissaoContrato
        'TxtDataVencimentoContrato.Text = objNegociacao.DataVencimentoContrato
        'TxtDiaVencimentoContrato.Text = objNegociacao.DiaVencimentoContrato
        TxtDetalhesFormulacao.Text = objNegociacao.DetalhesFormulacao
        TxtDetalhesEmbalagem.Text = objNegociacao.DetalhesEmbalagem
        TxtDetalhesRotulos.Text = objNegociacao.DetalhesRotulos
        TxtDetalhesPrazoEntrega.Text = objNegociacao.DetalhesPrazoEntrega
        TxtDetalhesPagamento.Text = objNegociacao.DetalhesPagamento
    End Sub

    Private Sub GravarDados()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Try
            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("GlEstabelecimento")
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()

            If objNegociacao.CodContato = 0 Then
                objNegociacao.CodContato = "null"
            End If

            If objNegociacao.CodCarteira = 0 Then
                objNegociacao.CodCarteira = "null"
            End If

            If objNegociacao.CodGestorConta = 0 Then
                objNegociacao.CodGestorConta = "null"
            End If

            If objNegociacao.CodAgenteVenda = 0 Then
                objNegociacao.CodAgenteVenda = "null"
            End If

            If String.IsNullOrEmpty(objNegociacao.ProbabilidadeSucesso) Then
                objNegociacao.ProbabilidadeSucesso = "null"
            End If

            If objNegociacao.CodFormaPagto = 0 Then
                objNegociacao.CodFormaPagto = "null"
            End If

            If objNegociacao.CodCondPagto = 0 Then
                objNegociacao.CodCondPagto = "null"
            End If

            'If Not String.IsNullOrEmpty(TxtDiaVencimentoContrato.Text) Then
            '    If Not IsNumeric(TxtDiaVencimentoContrato.Text) OrElse CDbl(TxtDiaVencimentoContrato.Text) > 31 OrElse CDbl(TxtDiaVencimentoContrato.Text) < 1 Then
            '        Throw New Exception("Informe corretamente o dia do vencimento (cobrança) do contrato ou deixe o campo em branco.")
            '    End If
            'End If

            objNegociacao.Observacao = TxtObservacao.Text.GetValidInputContent
            'objNegociacao.Aux1 = TxtAux1.Text
            'objNegociacao.Aux2 = TxtAux2.Text
            'objNegociacao.Aux3 = DdlAux3.SelectedValue
            objNegociacao.CodTransportadora = TxtCodTransportadora.Text
            'objNegociacao.DataEmissaoContrato = TxtDataEmissaoContrato.Text
            'objNegociacao.DataVencimentoContrato = TxtDataVencimentoContrato.Text
            'objNegociacao.DiaVencimentoContrato = TxtDiaVencimentoContrato.Text
            objNegociacao.DetalhesFormulacao = TxtDetalhesFormulacao.Text
            objNegociacao.DetalhesEmbalagem = TxtDetalhesEmbalagem.Text
            objNegociacao.DetalhesRotulos = TxtDetalhesRotulos.Text
            objNegociacao.DetalhesPrazoEntrega = TxtDetalhesPrazoEntrega.Text
            objNegociacao.DetalhesPagamento = TxtDetalhesPagamento.Text
            objNegociacao.Alterar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
    '    Try
    '        Call GravarDados()
    '        LblErro.Text = "Dados gravados com sucesso."
    '    Catch ex As Exception
    '        LblErro.Text = ex.Message
    '    End Try
    'End Sub

    Protected Sub CodigoTransportadoraMudou()
        Dim objEmitente As New UCLEmitente()

        objEmitente.CodEmitente = TxtCodTransportadora.Text
        objEmitente.Buscar()
        LblNomeTransportadora.Text = objEmitente.Nome

        Session("SCodTransportadoraNegociacao") = TxtCodTransportadora.Text
        Session("SCodTransportadoraPesquisado") = TxtCodTransportadora.Text
    End Sub

    Private Sub MostraNomeTransportadora()
        Dim objEmitente As New UCLEmitente()
        If Not String.IsNullOrEmpty(TxtCodTransportadora.Text) Then
            objEmitente.CodEmitente = TxtCodTransportadora.Text
            objEmitente.Buscar()
            LblNomeTransportadora.Text = objEmitente.Nome
        End If
    End Sub

End Class