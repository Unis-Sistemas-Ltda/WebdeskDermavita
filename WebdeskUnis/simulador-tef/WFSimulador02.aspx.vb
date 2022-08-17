Public Class WFSimulador02
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim descricaoConvenio As String = ""
                LblFaturamentoMensalCartaoCredito01.Text = Request.QueryString.Item("fmcc").ToString
                LblFaturamentoMensalCartaoCredito02.Text = Request.QueryString.Item("fmcc").ToString

                LblFaturamentoMensalCartaoDebito01.Text = Request.QueryString.Item("fmcd").ToString
                LblFaturamentoMensalCartaoDebito02.Text = Request.QueryString.Item("fmcd").ToString

                TxtTaxaAdesaoMaquininhaAtual.Text = Request.QueryString.Item("txam").ToString
                TxtTaxaAtualCartaoCredito.Text = Request.QueryString.Item("txcc").ToString
                TxtTaxaAtualCartaoDebito.Text = Request.QueryString.Item("txcd").ToString
                TxtValorAluguelMensalMaquininhaAtual.Text = Request.QueryString.Item("valm").ToString
                TxtValorLinhaDiscadaAtual.Text = Request.QueryString.Item("vldi").ToString
                TxtValorPacoteContaCorrenteAtual.Text = Request.QueryString.Item("vlpc").ToString

                Dim imagem_logo As String
                Dim taxaDeb As Double = 1.3
                Dim taxaCred As Double = 2.1000000000000001
                Dim convenio As String = Request.QueryString.Item("cvid")
                Dim strSql As String = " select taxa_debito, taxa_credito, descricao, imagem_logo from grupo_tef where cod_grupo = " + convenio
                Dim objAcessoDados As New UCLAcessoDados(StrConexao)
                Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)

                If dt.Rows.Count > 0 Then
                    taxaDeb = CDbl(dt.Rows.Item(0).Item("taxa_debito"))
                    taxaCred = CDbl(dt.Rows.Item(0).Item("taxa_credito"))
                    descricaoConvenio = dt.Rows.Item(0).Item("descricao").ToString
                    If Not IsDBNull(dt.Rows.Item(0).Item("imagem_logo")) Then
                        imagem_logo = dt.Rows.Item(0).Item("imagem_logo").ToString
                        ImgLogo.ImageUrl = imagem_logo
                    Else
                        ImgLogo.Visible = False
                    End If
                End If

                LblTaxaCartaoCreditoConvenio.Text = taxaCred.ToString("F2")
                LblTaxaCartaoDebitoConvenio.Text = taxaDeb.ToString("F2")

                Call Calcular()

                If descricaoConvenio <> "" Then
                    LblNomeConveino.Text = descricaoConvenio
                    LblMensagemConvenio.Text = "* As condições acima são exclusivas para o convênio " + descricaoConvenio + "."
                End If

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Function Calcular() As Boolean
        Try
            Dim FaturamentoMensalCartaoCredito As Double
            Dim FaturamentoMensalCartaoDebito As Double
            Dim FaturamentoTotalCartoes As Double
            Dim TaxaAtualCartaoCredito As Double
            Dim TaxaAtualCartaoDebito As Double
            Dim CustoAtualCartaoCredito As Double
            Dim CustoAtualCartaoDebito As Double
            Dim CustoAtualCartoes As Double
            Dim TaxaCartaoCreditoConvenio As Double
            Dim TaxaCartaoDebitoConvenio As Double
            Dim CustoCartaoCreditoConvenio As Double
            Dim CustoCartaoDebitoConvenio As Double
            Dim CustoCartoesConvenio As Double
            Dim ValorEconomiaMensalCreditoConvenio As Double
            Dim ValorEconomiaMensalDebitoConvenio As Double
            Dim ValorEconomiaMensalFinalConvenio As Double

            If IsNumeric(LblFaturamentoMensalCartaoCredito01.Text) Then
                FaturamentoMensalCartaoCredito = CDbl(LblFaturamentoMensalCartaoCredito01.Text)
            Else
                If String.IsNullOrWhiteSpace(LblFaturamentoMensalCartaoCredito01.Text) Then
                    FaturamentoMensalCartaoCredito = 0
                Else
                    FaturamentoMensalCartaoCredito = 12000
                End If
                LblFaturamentoMensalCartaoCredito01.Text = FaturamentoMensalCartaoCredito.ToString("N2")
            End If
            If FaturamentoMensalCartaoCredito < 0 Then FaturamentoMensalCartaoCredito = FaturamentoMensalCartaoCredito * -1

            If IsNumeric(LblFaturamentoMensalCartaoDebito01.Text) Then
                FaturamentoMensalCartaoDebito = CDbl(LblFaturamentoMensalCartaoDebito01.Text)
            Else
                If String.IsNullOrWhiteSpace(LblFaturamentoMensalCartaoDebito01.Text) Then
                    FaturamentoMensalCartaoDebito = 0
                Else
                    FaturamentoMensalCartaoDebito = 3000
                End If
                LblFaturamentoMensalCartaoDebito01.Text = FaturamentoMensalCartaoDebito.ToString("N2")
            End If
            If FaturamentoMensalCartaoDebito < 0 Then FaturamentoMensalCartaoDebito = FaturamentoMensalCartaoDebito * -1

            If IsNumeric(TxtTaxaAtualCartaoCredito.Text) Then
                TaxaAtualCartaoCredito = CDbl(TxtTaxaAtualCartaoCredito.Text)
            Else
                If String.IsNullOrWhiteSpace(TxtTaxaAtualCartaoCredito.Text) Then
                    TaxaAtualCartaoCredito = 0.0
                Else
                    TaxaAtualCartaoCredito = 3.6000000000000001
                End If
                TxtTaxaAtualCartaoCredito.Text = TaxaAtualCartaoCredito.ToString("N2")
            End If
            If TaxaAtualCartaoCredito < 0 Then TaxaAtualCartaoCredito = TaxaAtualCartaoCredito * -1

            If IsNumeric(TxtTaxaAtualCartaoDebito.Text) Then
                TaxaAtualCartaoDebito = CDbl(TxtTaxaAtualCartaoDebito.Text)
            Else
                If String.IsNullOrWhiteSpace(TxtTaxaAtualCartaoDebito.Text) Then
                    TaxaAtualCartaoDebito = 0
                Else
                    TaxaAtualCartaoDebito = 2.5
                End If
                TxtTaxaAtualCartaoDebito.Text = TaxaAtualCartaoDebito.ToString("N2")
            End If
            If TaxaAtualCartaoDebito < 0 Then TaxaAtualCartaoDebito = TaxaAtualCartaoDebito * -1

            FaturamentoTotalCartoes = FaturamentoMensalCartaoCredito + FaturamentoMensalCartaoDebito
            CustoAtualCartaoCredito = FaturamentoMensalCartaoCredito * (TaxaAtualCartaoCredito / 100)
            CustoAtualCartaoDebito = FaturamentoMensalCartaoDebito * (TaxaAtualCartaoDebito / 100)
            CustoAtualCartoes = CustoAtualCartaoCredito + CustoAtualCartaoDebito

            LblCustoAtualCartaoCredito.Text = CustoAtualCartaoCredito.ToString("N2")
            LblCustoAtualCartaoDebito.Text = CustoAtualCartaoDebito.ToString("N2")
            LblCustoTotalSituacaoAtual.Text = CustoAtualCartoes.ToString("N2")

            LblFaturamentoTotalCartoes01.Text = FaturamentoTotalCartoes.ToString("N2")
            LblFaturamentoTotalCartoes02.Text = FaturamentoTotalCartoes.ToString("N2")

            TaxaCartaoCreditoConvenio = CDbl(LblTaxaCartaoCreditoConvenio.Text)
            TaxaCartaoDebitoConvenio = CDbl(LblTaxaCartaoDebitoConvenio.Text)

            CustoCartaoCreditoConvenio = FaturamentoMensalCartaoCredito * (TaxaCartaoCreditoConvenio / 100)
            CustoCartaoDebitoConvenio = FaturamentoMensalCartaoDebito * (TaxaCartaoDebitoConvenio / 100)
            CustoCartoesConvenio = CustoCartaoCreditoConvenio + CustoCartaoDebitoConvenio

            ValorEconomiaMensalCreditoConvenio = CustoAtualCartaoCredito - CustoCartaoCreditoConvenio
            If ValorEconomiaMensalCreditoConvenio < 0 Then ValorEconomiaMensalCreditoConvenio = 0

            ValorEconomiaMensalDebitoConvenio = CustoAtualCartaoDebito - CustoCartaoDebitoConvenio
            If ValorEconomiaMensalDebitoConvenio < 0 Then ValorEconomiaMensalDebitoConvenio = 0

            ValorEconomiaMensalFinalConvenio = CustoAtualCartoes - CustoCartoesConvenio
            If ValorEconomiaMensalFinalConvenio < 0 Then ValorEconomiaMensalFinalConvenio = 0

            LblFaturamentoMensalCartaoCredito01.Text = FaturamentoMensalCartaoCredito.ToString("N2")
            LblFaturamentoMensalCartaoCredito02.Text = FaturamentoMensalCartaoCredito.ToString("N2")

            LblFaturamentoMensalCartaoDebito01.Text = FaturamentoMensalCartaoDebito.ToString("N2")
            LblFaturamentoMensalCartaoDebito02.Text = FaturamentoMensalCartaoDebito.ToString("N2")

            LblCustoConvenioCartaoCredito.Text = CustoCartaoCreditoConvenio.ToString("N2")
            LblCustoConvenioCartaoDebito.Text = CustoCartaoDebitoConvenio.ToString("N2")
            LblCustoTotalParceriaConvenio.Text = CustoCartoesConvenio.ToString("N2")

            LblValorEconomiaMensalConvenioCredito.Text = ValorEconomiaMensalCreditoConvenio.ToString("N2")
            LblValorEconomiaMensalConvenioDebito.Text = ValorEconomiaMensalDebitoConvenio.ToString("N2")
            LblValorEconomiaMensalConvenioFinal.Text = ValorEconomiaMensalFinalConvenio.ToString("N2")
            LblValorEconomiaAnualConvenioCredito.Text = (ValorEconomiaMensalCreditoConvenio * 12).ToString("N2")
            LblValorEconomiaAnualConvenioDebito.Text = (ValorEconomiaMensalDebitoConvenio * 12).ToString("N2")
            LblValorEconomiaAnualConvenioFinal.Text = (ValorEconomiaMensalFinalConvenio * 12).ToString("N2")

            LblEconomiaFinal.Text = Math.Floor(CDbl(LblValorEconomiaAnualConvenioFinal.Text)).ToString("N0")

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub ImageButton3_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
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

            vlar = "0"
            fmcc = LblFaturamentoMensalCartaoCredito01.Text
            fmcd = LblFaturamentoMensalCartaoDebito01.Text
            txam = TxtTaxaAdesaoMaquininhaAtual.Text
            txar = "0"
            txcc = TxtTaxaAtualCartaoCredito.Text
            txcd = TxtTaxaAtualCartaoDebito.Text
            valm = TxtValorAluguelMensalMaquininhaAtual.Text
            vldi = TxtValorLinhaDiscadaAtual.Text
            vlpc = TxtValorPacoteContaCorrenteAtual.Text
            convenio = Request.QueryString.Item("cvid")

            Response.Redirect("WFSimulador.aspx?tid=" + Now.ToString("yyyyMMddHHmmssfff") + "&vlar=" + vlar.ToString + "&fmcc=" + fmcc.ToString + "&fmcd=" + fmcd.ToString + "&txam=" + txam.ToString + "&txar=" + txar.ToString + "&txcc=" + txcc.ToString + "&txcd=" + txcd.ToString + "&valm=" + valm.ToString + "&vldi=" + vldi.ToString + "&vlpc=" + vlpc.ToString + "&cvid=" + convenio)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub


End Class