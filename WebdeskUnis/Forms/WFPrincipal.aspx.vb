Public Partial Class WFPrincipal
    Inherits System.Web.UI.Page

    Private Autenticacao_URL As String = ""
    Private CNPJ_URL As String = ""
    Private CodEmitente_URL As String = ""
    Private ID_URL As String = ""
    Private Codigo_URL As String = ""
    Private CNPJ As String

    Private ReadOnly INDICE_MENU_CHAMADOS As Integer = 0
    Private ReadOnly INDICE_MENU_DESENVOLVIMENTOS As Integer = 1
    Private ReadOnly INDICE_MENU_PROPOSTAS As Integer = 2
    Private ReadOnly INDICE_MENU_FINANCEIRO As Integer = 3
    Private ReadOnly INDICE_MENU_AGENDA_ACADEMIA As Integer = 4
    Private ReadOnly INDICE_MENU_CONFIGURACOES As Integer = 5
    Private ReadOnly INDICE_MENU_AJUDA As Integer = 6
    Private ReadOnly INDICE_MENU_ADMIN As Integer = 7

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CNPJ = Session("GlCNPJ")
        If Not IsPostBack Then
            Try
                Dim periodo As String = ""
                Dim objParametrosWebdesk As New UCLParametrosWebdesk
                Dim indiceMenuSelecionado As Integer = 0
                Dim objEstabelecimento As New UCLEstabelecimento

                If String.IsNullOrEmpty(Session("GlCNPJ")) Then
                    Response.Redirect("~/WFDesconectar.aspx")
                End If

                Select Case System.DateTime.Now.Hour
                    Case 4 To 11
                        periodo = "Bom dia, "
                    Case 12 To 17
                        periodo = "Boa tarde, "
                    Case 18 To 23, 0 To 3
                        periodo = "Boa noite, "
                End Select

                LblNomeUsuario.Text = Session("GlNomeCliente").ToString.Trim
                LblRazaoSocial.Text = Session("GlRazaoSocial")
                LblCNPJ.Text = Session("GlCNPJ")
                If LblCNPJ.Text.Length = 11 Then
                    LblCNPJ.Text = LblCNPJ.Text.MascaraCPF
                    LblTpPessoa.Text = "CPF:"
                Else
                    LblCNPJ.Text = LblCNPJ.Text.MascaraCNPJ
                    LblTpPessoa.Text = "CNPJ:"
                End If
                LblEmail.Text = Session("GlEmailAcesso")

                LblBoasVindas.Text = periodo + "seja bem vindo!"

                CarregaVariaveisQueryString()

                If Not IsPostBack Then
                    If Not String.IsNullOrWhiteSpace(ID_URL) Then
                        Select Case ID_URL
                            Case 1
                                Session("SCodFAQ") = Codigo_URL
                                CarregaFrame(FrameConteudo, "WGFAQ.aspx")
                                MnuPrincipal.Items.Item(INDICE_MENU_CHAMADOS).Selected = False
                                indiceMenuSelecionado = -1
                            Case 670
                                CarregaFrame(FrameConteudo, "WGTitulo.aspx")
                                MnuPrincipal.Items.Item(INDICE_MENU_CHAMADOS).Selected = False
                                MnuPrincipal.Items.Item(INDICE_MENU_FINANCEIRO).Selected = True
                                indiceMenuSelecionado = INDICE_MENU_FINANCEIRO
                        End Select
                    End If
                End If

                If GetQuantidadeTitulosVencidos(Session("GlEmpresa"), Session("GlEmitente")) Then
                    MnuPrincipal.Items.Item(INDICE_MENU_FINANCEIRO).Text = "<b style=""color:Maroon"">Financeiro*</b>"
                    MnuPrincipal.Items.Item(INDICE_MENU_FINANCEIRO).ToolTip = "Há títulos em aberto vencidos. Clique para visualizar."
                    If indiceMenuSelecionado = INDICE_MENU_FINANCEIRO Then
                        MnuPrincipal.Items.Item(INDICE_MENU_FINANCEIRO).Selected = True
                        CarregaFrame(FrameConteudo, MnuPrincipal.Items.Item(indiceMenuSelecionado).Value)
                    End If
                End If
                Dim objEmitente As New UCLEmitente
                objEmitente.CodEmitente = Session("GlEmitente")
                objEmitente.Buscar()
                If Not objEstabelecimento.BuscarPorCNPJ(Session("GlCNPJ")) AndAlso objEmitente.Professor <> "S" Then
                    MnuPrincipal.Items.RemoveAt(INDICE_MENU_ADMIN)
                End If

                If objParametrosWebdesk.Buscar(Session("GlEmpresa")) Then
                    If objParametrosWebdesk.GetConteudo("menu_ajuda") = "N" Then
                        MnuPrincipal.Items.RemoveAt(INDICE_MENU_AJUDA)
                    End If
                    If objParametrosWebdesk.GetConteudo("menu_configuracoes") = "N" Then
                        MnuPrincipal.Items.RemoveAt(INDICE_MENU_CONFIGURACOES)
                    End If
                    If objParametrosWebdesk.GetConteudo("menu_agenda_academia") = "N" Then
                        MnuPrincipal.Items.RemoveAt(INDICE_MENU_AGENDA_ACADEMIA)
                    End If
                    If objParametrosWebdesk.GetConteudo("menu_financeiro") = "N" Then
                        MnuPrincipal.Items.RemoveAt(INDICE_MENU_FINANCEIRO)
                    End If
                    If objParametrosWebdesk.GetConteudo("menu_desenvolvimentos") = "N" Then
                        MnuPrincipal.Items.RemoveAt(INDICE_MENU_DESENVOLVIMENTOS)
                    End If
                    If objParametrosWebdesk.GetConteudo("menu_chamados") = "N" Then
                        MnuPrincipal.Items.RemoveAt(INDICE_MENU_CHAMADOS)
                    End If
                    If objParametrosWebdesk.GetConteudo("menu_propostas") = "N" Then
                        MnuPrincipal.Items.RemoveAt(INDICE_MENU_PROPOSTAS)
                    End If

                End If

                If CNPJ = "0" Then
                    CarregaFrame(FrameConteudo, "WGDadosCadastrais.aspx")
                Else
                    If MnuPrincipal.SelectedValue = "" Then
                        indiceMenuSelecionado = 0
                        MnuPrincipal.Items.Item(indiceMenuSelecionado).Selected = True
                    End If

                    If indiceMenuSelecionado <> -1 Then
                        If indiceMenuSelecionado <> INDICE_MENU_FINANCEIRO Then
                            CarregaFrame(FrameConteudo, MnuPrincipal.Items.Item(indiceMenuSelecionado).Value)
                        End If
                    Else
                        CarregaFrame(FrameConteudo, "WGAtendimento.aspx")
                    End If
                End If

            Catch ex As Exception
                LblBoasVindas.Text = ex.Message
            End Try
        Else
            LblCNPJ.Text = CNPJ
            If LblCNPJ.Text.Length = 11 Then
                LblCNPJ.Text = LblCNPJ.Text.MascaraCPF
                LblTpPessoa.Text = "CPF:"
            Else
                LblCNPJ.Text = LblCNPJ.Text.MascaraCNPJ
                LblTpPessoa.Text = "CNPJ:"
            End If
        End If
    End Sub

    Protected Sub MnuPrincipal_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuPrincipal.MenuItemClick
        Dim pagina As String = e.Item.Value
        If CNPJ = "0" Then
            CarregaFrame(FrameConteudo, "WGDadosCadastrais.aspx")
        Else
            Call CarregaFrame(FrameConteudo, pagina)
        End If

    End Sub

    Protected Sub CarregaFrame(ByVal frame As WUCFrame, ByVal pagina As String)
        frame.Pagina = pagina
        frame.Height = "100%"
        frame.Width = "100%"
        frame.DataBind()
    End Sub

    Private Sub CarregaVariaveisQueryString()
        Try
            If Request.QueryString.Count > 0 Then
                Autenticacao_URL = Request.QueryString.Item("a")
                CNPJ_URL = Request.QueryString.Item("c")
                CodEmitente_URL = Request.QueryString.Item("g")
                ID_URL = Request.QueryString.Item("i")
                Codigo_URL = Request.QueryString.Item("f")

                If IsNumeric(Autenticacao_URL) Then
                    Autenticacao_URL = Math.Round(CDbl(Autenticacao_URL) / 4, 0).ToString
                End If
                If IsNumeric(CNPJ_URL) Then
                    CNPJ_URL = Math.Round(CDbl(CNPJ_URL) / 4, 0).ToString.PadLeft(14, "0")
                End If
                If IsNumeric(CodEmitente_URL) Then
                    CodEmitente_URL = Math.Round(CDbl(CodEmitente_URL) / 4, 0).ToString
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class