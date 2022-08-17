Public Class WUCNegociacaoItem
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodNegociacao As String
    Private _SeqItem As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodNegociacao() As String
        Get
            Return Session("CodNegociacao")
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Public Property SeqItem() As String
        Get
            Return Session("SSeqItemNegociacao")
        End Get
        Set(ByVal value As String)
            _SeqItem = value
        End Set
    End Property

    Private ReadOnly Property QuantidadeUD() As Double
        Get
            If String.IsNullOrEmpty(TxtQuantidadeUD.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtQuantidadeUD.Text) Then
                    Return CDbl(TxtQuantidadeUD.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private ReadOnly Property Quantidade() As Double
        Get
            If String.IsNullOrEmpty(TxtQuantidade.Text) Then
                Return 0.0
            Else
                If IsNumeric(TxtQuantidade.Text) Then
                    Return CDbl(TxtQuantidade.Text)
                Else
                    Return 0.0
                End If
            End If
        End Get
    End Property

    Private Sub CarregaEquipamentoCliente(ByVal numeroSerieSelecionado As String)
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("GlEstabelecimento")
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()
            If Not String.IsNullOrEmpty(objNegociacao.CodChamado) Then
                objChamado.Empresa = objNegociacao.Empresa
                objChamado.CodChamado = objNegociacao.CodChamado
                objChamado.Buscar()
                objEquipamentoCliente.Empresa = objChamado.Empresa
                If Not String.IsNullOrEmpty(objChamado.CodEmitenteAtendimento) And Not String.IsNullOrEmpty(objChamado.NumeroPontoAtendimento) Then
                    objEquipamentoCliente.CodCliente = objChamado.CodEmitenteAtendimento
                    objEquipamentoCliente.NumeroPontoAtendimento = objChamado.NumeroPontoAtendimento
                    Session("SPAEquipamento") = objChamado.NumeroPontoAtendimento
                    Session("SCliEquipamento") = objChamado.CodEmitenteAtendimento
                Else
                    objEquipamentoCliente.CodCliente = objChamado.CodEmitente
                    objEquipamentoCliente.NumeroPontoAtendimento = ""
                    Session("SPAEquipamento") = ""
                    Session("SCliEquipamento") = objChamado.CodEmitente
                End If

                If Session("GlTipoFaturamento").ToString = "G" Then
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.DescricaoItem, numeroSerieSelecionado)
                Else
                    objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "-1", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, numeroSerieSelecionado)
                End If
                DdlEquipamento.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChecaAlteracaoNumeroSerie()
        Try
            Dim NumeroSerieRetornado As String
            Dim recarregaEquipamentos As Long

            If Not String.IsNullOrEmpty(Session("SAlterouNumeroSerieItemPedido")) Then
                recarregaEquipamentos = Session("SAlterouNumeroSerieItemPedido")
            Else
                recarregaEquipamentos = 0
            End If

            If recarregaEquipamentos > 0 Then
                NumeroSerieRetornado = Session("SNumeroSerieItemPedido")
                Call CarregaEquipamentoCliente(NumeroSerieRetornado)
                If Not String.IsNullOrEmpty(NumeroSerieRetornado) Then
                    DdlEquipamento.SelectedValue = NumeroSerieRetornado
                End If
                Session("SAlterouNumeroSerieItemPedido") = recarregaEquipamentos - 2
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'Session("SModoCadEquipamento") = WUCEquipamento.ModoJanela.AberturaPorOutraTela

            TxtQuantidade.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
            TxtQuantidade.Attributes.Add("OnBlur", "submit();")
            TxtQuantidadeUD.Attributes.Add("OnKeyPress", "return(formata(this,'????????',event))")
            TxtQuantidadeUD.Attributes.Add("OnBlur", "submit();")
            BtnGravar.Visible = True
            If Not IsPostBack Then
                Dim objNatureza As New UCLNaturezaOperacao
                objNatureza.FillDropDown(DdlNaturOper, True, "")

                Call CarregaFormulario()

                Dim codFunil As String = ""
                Dim objNegociacaoCliente As New UCLNegociacao(StrConexao)
                Dim objFunil As New UCLFunilVenda
                objNegociacaoCliente.Empresa = Session("GlEmpresa")
                objNegociacaoCliente.Estabelecimento = Session("GlEstabelecimento")
                objNegociacaoCliente.CodNegociacao = CodNegociacao
                objNegociacaoCliente.Buscar()
                codFunil = IIf(String.IsNullOrEmpty(objNegociacaoCliente.CodFunil), "0", objNegociacaoCliente.CodFunil)
                objFunil.Empresa = Session("GlEmpresa")
                objFunil.Codigo = codFunil
                If objFunil.Buscar() Then
                    LblEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                    DdlEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                    BtnIncluirEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                    BtnAlterarEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                    BtnPesquisarEquipamento.Visible = (objFunil.OcultarEquipamento <> "S")
                End If

            Else
                ChecaAlteracaoNumeroSerie()
            End If

            If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
                If Session("SNAlterouCodItem") Is Nothing Then
                    Session("SNAlterouCodItem") = 0
                End If
                If Not IsNumeric(Session("SNAlterouCodItem")) Then
                    Session("SNAlterouCodItem") = 0
                End If
                If Session("SAlterouCodItem") = "S" Then
                    If DdlReferencia.SelectedValue <> Session("SReferenciaPesquisada") Then
                        Dim objItemReferencia As New UCLItemReferencia(StrConexao)
                        objItemReferencia.CodItem = Session("SCodItemPesquisado")
                        objItemReferencia.Referencia = Session("SReferenciaPesquisada")
                        objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")
                        DdlReferencia.SelectedValue = Session("SReferenciaPesquisada")
                    End If

                    Session("SNAlterouCodItem") = Session("SNAlterouCodItem") + 1

                    If Session("SNAlterouCodItem") > 1 Then
                        Session("SAlterouCodItem") = "N"
                        Session("SNAlterouCodItem") = 0
                    End If
                End If
            End If

            Call CarregaDescricaoItem()
            Call CalculaTotais()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Private Sub CarregaUnidades()
        Dim objItem As New UCLItem
        'objItem.FillDropDownUnidade(DdlUD, True, "", TxtCodItem.Text)
    End Sub
    Private Sub CarregaDescricaoItem()
        Try
            Dim objItem As New UCLItem
            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                objItem.CodItem = TxtCodItem.Text
                objItem.Buscar()
                LblDescricaoItem.Text = objItem.Descricao
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function IsDigitacaoOK()
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtCodItem.Text) Then
            LblErro.Text += "Preencha o campo Item.<br/>"
        End If

        If Quantidade = 0 Then
            LblErro.Text += "Preencha corretamente o campo Quantidade.<br/>"
        End If

        If QuantidadeUD = 0 Then
            LblErro.Text += "Preencha corretamente o campo Quantidade UD.<br/>"
        End If

        If String.IsNullOrEmpty(TxtPrecoUnitario.Text) Then
            LblErro.Text += "Preencha o campo Preço Unitário.<br/>"
        End If

        If Not IsNumeric(TxtPrecoUnitario.Text) Then
            LblErro.Text += "Preencha corretamente campo Preço Unitário.<br/>"
        End If

        If LblValorTotal.Text <= 0 Then
            LblErro.Text += "O total do item deve ser maior que R$ 0,00.<br/>"
        End If

        If DdlNaturOper.SelectedValue = 0 Then
            LblErro.Text += "Informe a natureza de operação.<br/>"
        End If

        If IsNumeric(LblICMSST.Text) AndAlso LblICMSST.Text < 0 Then
            LblErro.Text += "O valor de ICMS ST não pode ser inferior a R$ 0,00.<br/>"
        End If

        Return LblErro.Text = ""
    End Function
    Private Function CarregaObjeto(ByRef objNegociacaoItem As UCLNegociacaoItem) As UCLNegociacaoItem

        objNegociacaoItem.CodItem = TxtCodItem.Text.GetValidInputContent
        objNegociacaoItem.Referencia = DdlReferencia.SelectedValue
        objNegociacaoItem.Quantidade = Quantidade
        objNegociacaoItem.QuantidadeUD = QuantidadeUD
        objNegociacaoItem.PrecoUnitario = TxtPrecoUnitario.Text
        objNegociacaoItem.PrecoUnitarioUD = LblValorUD.Text
        'objNegociacaoItem.CodUnidade = DdlUD.SelectedValue
        objNegociacaoItem.Narrativa = TxtNarrativa.Text.GetValidInputContent
        objNegociacaoItem.AliquotaIPI = LblAliquotaIPI.Text
        objNegociacaoItem.AliquotaICMS = LblAliquotaICMS.Text
        objNegociacaoItem.BaseICMSSubstituicao = LblBaseIcmsSubstituicao.Text
        objNegociacaoItem.ICMSST = LblICMSST.Text
        objNegociacaoItem.IPI = LblIPI.Text
        objNegociacaoItem.ValorTotal = LblValorTotal.Text
        objNegociacaoItem.CodNaturOper = DdlNaturOper.SelectedValue
        objNegociacaoItem.ICMS = LblICMS.Text
        objNegociacaoItem.ValorDesconto = TxtValorDesconto.Text
        objNegociacaoItem.ValorMercadoria = LblValorMercadoria.Text
        objNegociacaoItem.PrazoEntrega = TxtPrazoEntrega.Text
        objNegociacaoItem.TpPrazoEntrega = DdlTpPrazoEntrega.SelectedValue
        objNegociacaoItem.FdAcaoDesejadaFuncao = TxtFdAcaoDesejadaProduto.Text
        objNegociacaoItem.FdColoracao = DdlFdColoracao.SelectedValue
        objNegociacaoItem.FdCorReferencia = TxtFdCorReferencia.Text
        objNegociacaoItem.FdDescricaoProduto = TxtFdDescricaoProduto.Text
        objNegociacaoItem.FdNomeProduto = TxtFdNomeProduto.Text
        objNegociacaoItem.FdOdor = DdlFdOdor.SelectedValue
        objNegociacaoItem.FdOdorDirecionamento = DdlFdOdorDirecionamento.SelectedValue
        objNegociacaoItem.FdOdorReferencia = TxtFdOdorReferencia.Text
        If DdlEquipamento.SelectedValue = "-1" OrElse DdlEquipamento.SelectedValue = "0" Then
            objNegociacaoItem.NumeroSerie = ""
        Else
            objNegociacaoItem.NumeroSerie = DdlEquipamento.SelectedValue
        End If

        Return objNegociacaoItem
    End Function

    Private Function Gravar() As Boolean
        Try
            Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objNegociacaoItem.CodNegociacao = CodNegociacao
                    objNegociacaoItem.SeqItem = SeqItem
                    objNegociacaoItem.Empresa = Session("GlEmpresa")
                    objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
                    objNegociacaoItem.Buscar()
                    objNegociacaoItem = CarregaObjeto(objNegociacaoItem)
                    objNegociacaoItem.Alterar()

                End If
                Return True
            End If
            Return False
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            If Gravar() Then
                Response.Redirect("WGNegociacaoItem.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub CalculaTotais()
        Dim objCalculoImposto As New UCLCalculoImposto
        Dim retorno As String

        If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
            objCalculoImposto.Empresa = Session("GlEmpresa")
            objCalculoImposto.Estabelecimento = Session("GlEstabelecimento")
            objCalculoImposto.CodItem = TxtCodItem.Text
            objCalculoImposto.Quantidade = Quantidade
            objCalculoImposto.QuantidadeUD = QuantidadeUD
            objCalculoImposto.PrecoUnitario = CDbl(TxtPrecoUnitario.Text) + GetTotalOpcionais()
            objCalculoImposto.PrecoUnitarioUD = CDbl(LblValorUD.Text)
            objCalculoImposto.ValorDesconto = CDbl(TxtValorDesconto.Text)
            objCalculoImposto.CodEmitente = LblCodEmitente.Text
            objCalculoImposto.CNPJ = LblCNPJ.Text
            objCalculoImposto.CodNaturOper = DdlNaturOper.SelectedValue
            retorno = objCalculoImposto.CalculaTotais()
            LblErro.Text = retorno
            LblValorMercadoria.Text = objCalculoImposto.ValorMercadoria.ToString("F2")
            LblValorTotal.Text = objCalculoImposto.ValorTotalMercadoria.ToString("F2")
            If retorno = "" Then
                LblBaseIcmsSubstituicao.Text = objCalculoImposto.BaseIcmsSubstituicao.ToString("F4")
                LblICMSST.Text = objCalculoImposto.IcmsSubstituicao.ToString("F4")
                LblIPI.Text = objCalculoImposto.ValorIPI.ToString("F4")
                LblICMS.Text = objCalculoImposto.ValorICMS.ToString("F4")
                LblAliquotaICMS.Text = objCalculoImposto.AliquotaICMS.ToString
                LblAliquotaIPI.Text = objCalculoImposto.AliquotaIPI.ToString
                LblValorUD.Text = objCalculoImposto.PrecoUnitarioUD.ToString("F4")
            Else
                LblErro.Text += " Por esse motivo, os valores abaixo podem não ser calculados corretamente."
            End If
        End If
    End Sub

    Private Function GetTotalOpcionais() As Double
        Try
            Dim StrSql As String = "select isnull(sum(n.preco_total),0) tot_opc" +
                                    " from negociacao_cliente_item_estrutura n" +
                                   " where n.empresa                = " + Session("GlEmpresa") +
                                     " and n.estabelecimento        = " + Session("GlEstabelecimento") +
                                     " and n.cod_negociacao_cliente = " + CodNegociacao +
                                     " and n.seq_item               = " + LblSeqItem.Text
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("tot_opc")) Then
                    Return 0
                Else
                    Return CDbl(dt.Rows.Item(0).Item("tot_opc"))
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub CarregaFormulario()
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        objNegociacaoItem.SeqItem = SeqItem
        objNegociacaoItem.Buscar()
        LblSeqItem.Text = objNegociacaoItem.SeqItem
        TxtCodItem.Text = objNegociacaoItem.CodItem

        Dim objItemReferencia As New UCLItemReferencia(StrConexao)
        objItemReferencia.CodItem = TxtCodItem.Text
        objItemReferencia.Referencia = objNegociacaoItem.Referencia
        objItemReferencia.FillDropDown(DdlReferencia, True, "(selecione)")

        DdlReferencia.SelectedValue = objNegociacaoItem.Referencia
        Session("SCodItemPesquisado") = TxtCodItem.Text
        Session("SReferenciaPesquisada") = DdlReferencia.SelectedValue
        Call CarregaUnidades()
        'DdlUD.SelectedValue = objNegociacaoItem.CodUnidade
        TxtPrecoUnitario.Text = objNegociacaoItem.PrecoUnitario
        LblValorUD.Text = objNegociacaoItem.PrecoUnitarioUD
        TxtQuantidade.Text = objNegociacaoItem.Quantidade
        TxtQuantidadeUD.Text = objNegociacaoItem.QuantidadeUD
        LblValorTotal.Text = objNegociacaoItem.ValorTotal
        LblICMSST.Text = objNegociacaoItem.ICMSST
        LblIPI.Text = objNegociacaoItem.IPI
        TxtNarrativa.Text = objNegociacaoItem.Narrativa
        TxtValorDesconto.Text = objNegociacaoItem.ValorDesconto
        LblICMS.Text = objNegociacaoItem.ICMS
        LblValorMercadoria.Text = objNegociacaoItem.ValorMercadoria
        DdlNaturOper.SelectedValue = objNegociacaoItem.CodNaturOper
        LblCNPJ.Text = objNegociacaoItem.CNPJCliente
        LblCodEmitente.Text = objNegociacaoItem.CodCliente
        CarregaEquipamentoCliente(objNegociacaoItem.NumeroSerie)
        DdlEquipamento.SelectedValue =
        TxtPrazoEntrega.Text = objNegociacaoItem.PrazoEntrega
        DdlTpPrazoEntrega.SelectedValue = objNegociacaoItem.TpPrazoEntrega
        Session("SNumeroSerieItemPedido") = objNegociacaoItem.NumeroSerie
        DdlFdColoracao.SelectedValue = objNegociacaoItem.FdColoracao
        DdlFdOdor.SelectedValue = objNegociacaoItem.FdOdor
        DdlFdOdorDirecionamento.SelectedValue = objNegociacaoItem.FdOdorDirecionamento
        TxtFdAcaoDesejadaProduto.Text = objNegociacaoItem.FdAcaoDesejadaFuncao
        TxtFdCorReferencia.Text = objNegociacaoItem.FdCorReferencia
        TxtFdDescricaoProduto.Text = objNegociacaoItem.FdDescricaoProduto
        TxtFdNomeProduto.Text = objNegociacaoItem.FdNomeProduto
        TxtFdOdorReferencia.Text = objNegociacaoItem.FdOdorReferencia
    End Sub

End Class