Public Class WFSimulador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtAntecipacaoMensalRecebiveis.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtFaturamentoMensalCartaoCredito.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtFaturamentoMensalCartaoDebito.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtTaxaAdesaoMaquininhaAtual.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtTaxaAtualAntecipacaoRecebiveis.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtTaxaAtualCartaoCredito.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtTaxaAtualCartaoDebito.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtValorAluguelMensalMaquininhaAtual.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtValorLinhaDiscadaAtual.Attributes.Add("onFocus", "selecionaCampo(this)")
        TxtValorPacoteContaCorrenteAtual.Attributes.Add("onFocus", "selecionaCampo(this)")

        If Not IsPostBack Then
            If Request.QueryString.Count > 0 Then
                If Not IsNothing(Request.QueryString.Item("vlar")) Then
                    TxtAntecipacaoMensalRecebiveis.Text = Request.QueryString.Item("vlar").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("fmcc")) Then
                    TxtFaturamentoMensalCartaoCredito.Text = Request.QueryString.Item("fmcc").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("fmcd")) Then
                    TxtFaturamentoMensalCartaoDebito.Text = Request.QueryString.Item("fmcd").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("txam")) Then
                    TxtTaxaAdesaoMaquininhaAtual.Text = Request.QueryString.Item("txam").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("txar")) Then
                    TxtTaxaAtualAntecipacaoRecebiveis.Text = Request.QueryString.Item("txar").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("txcc")) Then
                    TxtTaxaAtualCartaoCredito.Text = Request.QueryString.Item("txcc").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("txcd")) Then
                    TxtTaxaAtualCartaoDebito.Text = Request.QueryString.Item("txcd").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("valm")) Then
                    TxtValorAluguelMensalMaquininhaAtual.Text = Request.QueryString.Item("valm").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("vldi")) Then
                    TxtValorLinhaDiscadaAtual.Text = Request.QueryString.Item("vldi").ToString
                End If
                If Not IsNothing(Request.QueryString.Item("vlpc")) Then
                    TxtValorPacoteContaCorrenteAtual.Text = Request.QueryString.Item("vlpc").ToString
                End If
                Dim imagem_logo As String
                Dim convenio As String = Request.QueryString.Item("cvid")
                Dim strSql As String = " select taxa_debito, taxa_credito, descricao, imagem_logo from grupo_tef where cod_grupo = " + convenio
                Dim objAcessoDados As New UCLAcessoDados(StrConexao)
                Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
                Dim descricaoConvenio As String = ""
                If dt.Rows.Count > 0 Then
                    descricaoConvenio = dt.Rows.Item(0).Item("descricao").ToString
                    LblNomeConvenio.Text = descricaoConvenio
                    If Not IsDBNull(dt.Rows.Item(0).Item("imagem_logo")) Then
                        imagem_logo = dt.Rows.Item(0).Item("imagem_logo").ToString
                        ImgLogo.ImageUrl = imagem_logo
                    Else
                        ImgLogo.Visible = False
                    End If
                End If

            End If
        End If
    End Sub

    'Private Function GravaDadosInformados() As Boolean
    '    Try
    '        Dim StrSql As String
    '        Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
    '        Dim CodEmitente As String
    '        Dim objTratar As New UCLTratarDadosDb

    '        If Not IsNothing(Session("GlEmitente")) Then
    '            If Session("GlEmitente").ToString.Trim <> "" Then
    '                If IsNumeric(Session("GlEmitente")) Then
    '                    CodEmitente = Session("GlEmitente")
    '                Else
    '                    CodEmitente = "null"
    '                End If
    '            Else
    '                CodEmitente = "null"
    '            End If
    '        Else
    '            CodEmitente = "null"
    '        End If

    '        StrSql = " insert into simulacao_santander(seq_simulacao, data_hora, ip, cod_emitente, venda_credito, taxa_credito, venda_debito, taxa_debito, adesao_pos, aluguel_pos, pacote_cc, linha_discada, valor_antecipacao, taxa_antecipacao) "
    '        StrSql += " values(isnull((select max(seq_simulacao) from simulacao_santander),0) + 1, now(), '" + Request.UserHostAddress + "', " + CodEmitente + ", " + objTratar.TratarDecimal(TxtFaturamentoMensalCartaoCredito.Text) + ", " + objTratar.TratarDecimal(TxtTaxaAtualCartaoCredito.Text) + ", " + objTratar.TratarDecimal(TxtFaturamentoMensalCartaoDebito.Text) + ", " + objTratar.TratarDecimal(TxtTaxaAtualCartaoDebito.Text) + ", " + objTratar.TratarDecimal(TxtTaxaAdesaoMaquininhaAtual.Text) + ", " + objTratar.TratarDecimal(TxtValorAluguelMensalMaquininhaAtual.Text) + ", " + objTratar.TratarDecimal(TxtValorPacoteContaCorrenteAtual.Text) + ", " + objTratar.TratarDecimal(TxtValorLinhaDiscadaAtual.Text) + ", " + objTratar.TratarDecimal(TxtAntecipacaoMensalRecebiveis.Text) + ", " + objTratar.TratarDecimal(TxtTaxaAtualAntecipacaoRecebiveis.Text) + ");"
    '        ObjAcessoDados.ExecutarSql(StrSql)

    '        Return True

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Protected Sub ImageButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Try
            Dim vlar As String
            Dim fmcc As String
            Dim fmcd As String
            Dim txam As String
            Dim txar As String
            Dim txcc As String
            Dim txcd As String
            Dim valm As String
            Dim vldi As String
            Dim vlpc As String
            Dim convenio As String
            Dim redirect As String

            vlar = TxtAntecipacaoMensalRecebiveis.Text
            fmcc = TxtFaturamentoMensalCartaoCredito.Text
            fmcd = TxtFaturamentoMensalCartaoDebito.Text
            txam = TxtTaxaAdesaoMaquininhaAtual.Text
            txar = TxtTaxaAtualAntecipacaoRecebiveis.Text
            txcc = TxtTaxaAtualCartaoCredito.Text
            txcd = TxtTaxaAtualCartaoDebito.Text
            valm = TxtValorAluguelMensalMaquininhaAtual.Text
            vldi = TxtValorLinhaDiscadaAtual.Text
            vlpc = TxtValorPacoteContaCorrenteAtual.Text
            convenio = Request.QueryString.Item("cvid")

            If IsNumeric(vlar) AndAlso IsNumeric(fmcc) AndAlso IsNumeric(fmcd) AndAlso IsNumeric(txam) AndAlso IsNumeric(txar) AndAlso IsNumeric(txcc) AndAlso IsNumeric(txcd) AndAlso IsNumeric(valm) AndAlso IsNumeric(vldi) AndAlso IsNumeric(vlpc) Then
                redirect = "WFSimulador02.aspx?tid=" + Now.ToString("yyyyMMddHHmmssfff") + "&vlar=" + vlar.ToString + "&fmcc=" + fmcc.ToString + "&fmcd=" + fmcd.ToString + "&txam=" + txam.ToString + "&txar=" + txar.ToString + "&txcc=" + txcc.ToString + "&txcd=" + txcd.ToString + "&valm=" + valm.ToString + "&vldi=" + vldi.ToString + "&vlpc=" + vlpc.ToString + "&cvid=" + convenio
                Response.Redirect(redirect)
            Else
                LblErro.Text = "Verifique o preenchimento dos campos."
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class