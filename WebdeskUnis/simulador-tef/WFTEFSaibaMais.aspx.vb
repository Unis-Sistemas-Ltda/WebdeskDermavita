Public Class WFTEFSaibaMais
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objGrupoAdesao As New UCLAdesaoTEF
            Dim objGrupoTEF As New UCLGrupoTEF
            Dim objEmitente As New UCLEmitente

            LblNome.Text = objEmitente.GetRazaoSocial(CodEmitente)

            If objGrupoAdesao.Buscar(1, CodGrupo) Then
                LblNomeGrupo.Text = objGrupoAdesao.GetConteudo("nome_rede")
                BtnAnexo1.NavigateUrl = "http://matriz.unissistemas.com.br/webdeskunis/CampanhaTEF/" + objGrupoAdesao.GetConteudo("anexo1_email_campanha").Trim
                BtnAnexo2.NavigateUrl = "http://matriz.unissistemas.com.br/webdeskunis/CampanhaTEF/" + objGrupoAdesao.GetConteudo("anexo2_email_campanha").Trim
                BtnAnexo3.NavigateUrl = "http://matriz.unissistemas.com.br/webdeskunis/CampanhaTEF/" + objGrupoAdesao.GetConteudo("anexo3_email_campanha").Trim
                BtnAnexo4.NavigateUrl = "http://matriz.unissistemas.com.br/webdeskunis/CampanhaTEF/" + objGrupoAdesao.GetConteudo("anexo4_email_campanha").Trim
            End If

            If objGrupoTEF.Buscar(CodConvenio) Then
                LblTaxaDebito.Text = objGrupoTEF.GetConteudo("taxa_debito")
                LblTaxaCreditoAVista.Text = objGrupoTEF.GetConteudo("taxa_credito")
                LblTaxaParcelado2a6.Text = objGrupoTEF.GetConteudo("taxa_parcelamento_2a6x")
                LblTaxaParcelado7a12.Text = objGrupoTEF.GetConteudo("taxa_parcelamento_7a12x")
                If objGrupoTEF.IsNull("taxa_antecipacao_automatica") Then
                    LblAntAuto.Visible = False
                    LblTaxaAntecipacaoAutomatica.Visible = False
                Else
                    LblAntAuto.Visible = True
                    LblTaxaAntecipacaoAutomatica.Visible = True
                    LblTaxaAntecipacaoAutomatica.Text = objGrupoTEF.GetConteudo("taxa_antecipacao_automatica") + "%"
                End If
                If objGrupoTEF.IsNull("taxa_antecipacao_pontual") Then
                    LblAntPontual.Visible = False
                    LblTaxaAntecipacaoPontual.Visible = False
                Else
                    LblAntPontual.Visible = True
                    LblTaxaAntecipacaoPontual.Visible = True
                    LblTaxaAntecipacaoPontual.Text = objGrupoTEF.GetConteudo("taxa_antecipacao_pontual") + "%"
                End If

                LblMensalidadeEquipamento.Text = objGrupoTEF.GetConteudo("valor_mensalidade")
            End If

            If CodGrupo = 5 Then
                ImgLogoCappta.Visible = False
                ImgLogoUnis.Visible = False
                LblRodapePagina.Text = "Caso tenha alguma dúvida, entre em contato conosco pelo e-mail financeiro@anfarmag.org.br ou pelo telefone (11) 2199 3499. Estamos à sua disposição.<br /><br />Atenciosamente,<br /><br /><b>Departamento Financeiro</b><br />ANFARMAG - Associação Nacional de Farmacêuticos Magistrais<br />Tel: (11) 2199-3499 | Fax.: (11) 5572-0132<br />www.anfarmag.org.br<br />"
            ElseIf CodGrupo = 8 Then
                ImgLogoStone.Visible = False
                LblNomeConvenio1.Text = "Cielo-Cappta"
                LblNomeConvenio2.Text = LblNomeConvenio1.Text
                LblNomeConvenio3.Text = LblNomeConvenio1.Text
                LblNomeConvenio4.Text = LblNomeConvenio1.Text
                LblBandeirasTaxa.Text = "Visa, Mastercard, Elo e Diners."
            End If
        End If
    End Sub

    Protected Sub BtnSimulador_Click(sender As Object, e As EventArgs) Handles BtnSimulador.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "onLoad", "window.open('http://matriz.unissistemas.com.br/webdeskunis/simulador-tef/WFRedirecionar.aspx?e=" + CodEmitente + "&a=" + CodGrupo + "&t=1&r=WFSimulador_paspx_icvid_q" + CodConvenio + "');", True)
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles BtnPortal.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "onLoad", "window.open('http://matriz.unissistemas.com.br/webdeskunis/simulador-tef/WFRedirecionar.aspx?e=" + CodEmitente + "&a=" + CodGrupo + "&t=3&r=http_d_b_bportal_pcappta_pcom_pbr_bdemo');", True)
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles BtnAderir.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "onLoad", "window.open('http://matriz.unissistemas.com.br/webdeskunis/simulador-tef/WFRedirecionar.aspx?e=" + CodEmitente + "&a=" + CodGrupo + "&t=2&r=WFAdesaoTEF_paspx_ie_q" + CodEmitente + "');", True)
    End Sub

    Private ReadOnly Property CodEmitente As String
        Get
            Return Request.QueryString.Item("e")
        End Get
    End Property

    Private ReadOnly Property CodGrupo As String
        Get
            Return Request.QueryString.Item("a")
        End Get
    End Property

    Private ReadOnly Property CodConvenio As String
        Get
            Return Request.QueryString.Item("c")
        End Get
    End Property
End Class