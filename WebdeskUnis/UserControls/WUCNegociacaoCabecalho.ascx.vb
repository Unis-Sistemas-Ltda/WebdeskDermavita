Public Class WUCNegociacaoCabecalho
    Inherits System.Web.UI.UserControl

    Private _CodNegociacao As String
    Private _Acao As String

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
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim CodClientePesquisado As String

            Dim recarregaContatos As Long
            Dim alterouCodCliente As Long
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objParametrosFaturamento As New UCLParametrosFaturamento
            Dim segmento As String

            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")

            If objNegociacao.Estabelecimento Is Nothing Then
                objNegociacao.Estabelecimento = Session("GlEstabelecimento")
            End If

            objParametrosFaturamento.Empresa = Session("GlEmpresa")
            objParametrosFaturamento.Estabelecimento = Session("SEstabelecimentoNegociacao")
            If objParametrosFaturamento.Estabelecimento Is Nothing Then
                objParametrosFaturamento.Estabelecimento = Session("GlEstabelecimento")
            End If
            objParametrosFaturamento.Buscar()
            segmento = objParametrosFaturamento.Segmento


            If Not String.IsNullOrEmpty(Session("SRecarregaDdlContatos")) Then
                recarregaContatos = Session("SRecarregaDdlContatos")
            Else
                recarregaContatos = 0
            End If

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            CodClientePesquisado = Session("SCodClientePesquisado")


            If Not IsPostBack Then

                Call CarregaFormulario()

            End If

            Call MostraNomeCliente()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub





    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOk() Then

                objNegociacao.Empresa = Session("GlEmpresa")
                objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
                objNegociacao.CodNegociacao = LblNrNegociacao.Text
                objNegociacao.Buscar()
                objNegociacao = CarregaObjeto(objNegociacao)
                objNegociacao.Alterar()
                LblErro.Text = "<span style=""color:DarkGreen"">Os dados foram salvos com sucesso.</span>"

            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaDropDowns(ByVal pCodFunil As String, ByVal pCodEtapa As String)
        Try

            Call CarregaEtapa(pCodFunil, pCodEtapa)
            Call CarregaFormaPagto()
            Call CarregaCondPagto()
            Call CarregaCanalVenda()
            Call CarregaMoeda()
            Call CarregaContatos()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CarregaMoeda()
        Try
            Dim objMoeda As New UCLMoeda
            objMoeda.FillDropDown(DdlMoeda, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCanalVenda()
        Try
            Dim objCanalVenda As New UCLCanalVenda
            objCanalVenda.Empresa = Session("GlEmpresa")
            objCanalVenda.FillControl(DdlCanalVenda, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CarregaVendedores(ByVal codRepresentante As String, ByVal MostraInativos As Boolean)
        Try
            Dim objEmitente As New UCLEmitente()
            objEmitente.CodEmitente = Session("GlEmitente")
            objEmitente.FillDropDown(DdlRepresentante, True, "", UCLEmitente.TipoDDL.Representante, codRepresentante, MostraInativos)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAgentesVenda(ByVal codAgenteVenda As String)
        Try
            Dim objAgente As New UCLAgenteVendas
            If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
                objAgente.FillDropDown(DdlAgente, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
            Else
                objAgente.FillDropDown(DdlAgente, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEtapa(ByVal pCodFunil As String, ByVal pCodEtapa As String)
        Try
            Dim objEtapaNegociacao As New UCLEtapaNegociacao
            objEtapaNegociacao.Empresa = Session("GlEmpresa")
            objEtapaNegociacao.FillDropDown(DdlEtapa, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CarregaCondPagto()
        Try
            Dim objCondPagto As New UCLCondicaoPagamento
            objCondPagto.FillDropDown(DdlCondicaoPagto, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormaPagto()
        Try
            Dim objFormaPagto As New UCLFormaPagto
            objFormaPagto.FillDropDown(DdlFormaPagto, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaContatos()
        Try
            Dim objContato As New UCLContato
            Dim CodCliente As String = TxtCliente.Text

            If CodCliente IsNot Nothing AndAlso Not String.IsNullOrEmpty(CodCliente) Then
                objContato.CodEmitente = CodCliente
                objContato.FillDropDown(DdlContato, True, "", 0)
                DdlContato.DataBind()
            Else
                DdlContato.Items.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CarregaInfoContato()
        Try
            Dim objContato As New UCLContato
            Dim CodCliente As String = TxtCliente.Text
            Dim CodContato As String = DdlContato.SelectedValue
            If CodCliente IsNot Nothing AndAlso CodContato IsNot Nothing AndAlso Not String.IsNullOrEmpty(CodCliente) AndAlso Not String.IsNullOrWhiteSpace(CodContato) Then
                objContato.CodEmitente = CodCliente
                objContato.Codigo = CodContato
                If objContato.Buscar() Then
                    If Not String.IsNullOrWhiteSpace(objContato.Telefone) Then
                        LblTelefone.Text = objContato.Telefone
                    Else
                        LblTelefone.Text = ""
                    End If
                    If Not String.IsNullOrWhiteSpace(objContato.Celular) Then
                        LblCelular.Text = objContato.Celular
                    Else
                        LblCelular.Text = ""
                    End If
                    LblEmail.Text = objContato.Email
                Else
                    LblTelefone.Text = ""
                    LblEmail.Text = ""
                End If
            Else
                LblTelefone.Text = ""
                LblEmail.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub ContatoSelecionadoMudou()
        Session("SCodContatoNegociacao") = DdlContato.SelectedValue
        Call CarregaInfoContato()
    End Sub

    Protected Sub DdlContato_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlContato.SelectedIndexChanged
        Try
            Call ContatoSelecionadoMudou()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub


    Protected Function IsDigitacaoOk() As Boolean
        Try
            Dim permiteDataPrevisaoEmBranco = False
            Dim exigeDataRecontato = False
            Dim objEtapa As New UCLEtapaNegociacao
            'Dim objParametros As New UCLParametrosVenda
            Dim objNegociacao As New UCLNegociacao(StrConexao)

            Dim exigeMotivoFechamentoNegociacao As Boolean = False


            LblErro.Text = ""

            If String.IsNullOrEmpty(TxtCliente.Text) Then
                LblErro.Text += "Preencha o campo Cliente.<br/>"
            End If

            If DdlEtapa.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Etapa.<br/>"
            End If

            If DdlCanalVenda.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Canal de Venda.<br/>"
            End If

            If DdlAgente.SelectedValue = 0 Then
                LblErro.Text += "Preencha o campo Agente de vendas.<br/>"
            End If

            objEtapa.Empresa = Session("GlEmpresa")
            objEtapa.Codigo = DdlEtapa.SelectedValue
            objEtapa.Buscar()
            permiteDataPrevisaoEmBranco = True

            exigeDataRecontato = False



            Return LblErro.Text.Trim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Protected Function CarregaObjeto(ByRef objNegociacao As UCLNegociacao) As UCLNegociacao
        Try
            Dim dataHoraRecontato As String = ""

            objNegociacao.CodCliente = TxtCliente.Text


            If String.IsNullOrWhiteSpace(DdlContato.SelectedValue) OrElse DdlContato.SelectedValue = 0 Then
                objNegociacao.CodContato = "null"
            Else
                objNegociacao.CodContato = DdlContato.SelectedValue
            End If


            If String.IsNullOrWhiteSpace(DdlAgente.SelectedValue) OrElse DdlAgente.SelectedValue = 0 Then
                objNegociacao.CodAgenteVenda = "null"
            Else
                objNegociacao.CodAgenteVenda = DdlAgente.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlCanalVenda.SelectedValue) OrElse DdlCanalVenda.SelectedValue = "0" Then
                objNegociacao.CodCanalVendas = "null"
            Else
                objNegociacao.CodCanalVendas = DdlCanalVenda.SelectedValue
            End If




            objNegociacao.ManterInformado = TxtManterInformado.Text.GetValidInputContent
            objNegociacao.CodEtapaNegociacao = DdlEtapa.SelectedValue

            If String.IsNullOrWhiteSpace(DdlFormaPagto.SelectedValue) OrElse DdlFormaPagto.SelectedValue = 0 Then
                objNegociacao.CodFormaPagto = "null"
            Else
                objNegociacao.CodFormaPagto = DdlFormaPagto.SelectedValue
            End If

            If String.IsNullOrWhiteSpace(DdlCondicaoPagto.SelectedValue) OrElse DdlCondicaoPagto.SelectedValue = 0 Then
                objNegociacao.CodCondPagto = "null"
            Else
                objNegociacao.CodCondPagto = DdlCondicaoPagto.SelectedValue
            End If




            objNegociacao.Moeda = DdlMoeda.SelectedValue

            objNegociacao.CodRepresentante = DdlRepresentante.SelectedValue


            If String.IsNullOrWhiteSpace(DdlFrete.SelectedValue) OrElse DdlFrete.SelectedValue = 0 Then
                objNegociacao.tipo_frete = "2"
            Else
                objNegociacao.tipo_frete = DdlFrete.SelectedValue
            End If

            Return objNegociacao
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub MostraNomeCliente()
        Try
            Dim objEmitente As New UCLEmitente()
            Dim qtdTitulosEmAberto As Long
            Dim diasInadimplente As Long

            Dim ObjEnderecoEmitente As New UCLEnderecoEmitente()
            If Not String.IsNullOrEmpty(TxtCliente.Text) Then
                objEmitente.CodEmitente = TxtCliente.Text
                Session("SCodEmitente") = objEmitente.CodEmitente
                objEmitente.Buscar()

                LblNomeCliente.Text = objEmitente.Nome
                ObjEnderecoEmitente.CodEmitente = TxtCliente.Text
                'ObjEnderecoEmitente.CNPJ = DdlCNPJ.SelectedValue


                If ObjEnderecoEmitente.Buscar() Then
                    LblTelefone.Text = ObjEnderecoEmitente.Fone1
                    If Not String.IsNullOrWhiteSpace(ObjEnderecoEmitente.Fone2) Then
                        LblTelefone.Text += " / " + ObjEnderecoEmitente.Fone2
                    End If

                    LblEndereco.Text = ObjEnderecoEmitente.Logradouro
                    If Not String.IsNullOrEmpty(ObjEnderecoEmitente.Numero) AndAlso ObjEnderecoEmitente.Numero <> "0" Then
                        LblEndereco.Text += ", Nº " + ObjEnderecoEmitente.Numero
                    End If

                    If Not String.IsNullOrEmpty(ObjEnderecoEmitente.Bairro) Then
                        LblEndereco.Text += " - Bairro " + ObjEnderecoEmitente.Bairro
                    End If

                    Dim objPais As New UCLPais
                    Dim objEstado As New UCLEstado
                    Dim objCidade As New UCLCidade

                    objPais.CodPais = ObjEnderecoEmitente.CodPais
                    objPais.Buscar()

                    objEstado.CodPais = ObjEnderecoEmitente.CodPais
                    objEstado.CodEstado = ObjEnderecoEmitente.CodEstado
                    objEstado.Buscar()

                    objCidade.CodPais = ObjEnderecoEmitente.CodPais
                    objCidade.CodEstado = ObjEnderecoEmitente.CodEstado
                    objCidade.CodCidade = ObjEnderecoEmitente.CodCidade
                    objCidade.Buscar()

                    LblEndereco.Text += "<br>" + objCidade.NomeCidade + " / " + IIf(Not String.IsNullOrEmpty(objEstado.Sigla), objEstado.Sigla, objEstado.NomeEstado) + " - " + objPais.Nome
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try

            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            LblNrNegociacao.Text = Session("CodNegociacao")

            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objNegociacao.CodNegociacao = Session("CodNegociacao")
            objNegociacao.Buscar()

            TxtCliente.Text = objNegociacao.CodCliente
            Session("SCodEmitenteNegociacao") = TxtCliente.Text
            Session("SCodEmitenteNegociacaoAnterior") = TxtCliente.Text

            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            '----------------------------------------------
            Session("SCNPJEmitente") = objNegociacao.CNPJ
            '----------------------------------------------

            Call CarregaDropDowns(objNegociacao.CodFunil, objNegociacao.CodEtapaNegociacao)

            DdlMoeda.SelectedValue = objNegociacao.Moeda

            DdlCanalVenda.SelectedValue = objNegociacao.CodCanalVendas

            DdlContato.SelectedValue = objNegociacao.CodContato
            Call ContatoSelecionadoMudou()

            Call CarregaAgentesVenda(objNegociacao.CodAgenteVenda)
            DdlAgente.SelectedValue = objNegociacao.CodAgenteVenda

            Call CarregaVendedores(objNegociacao.CodRepresentante, False)
            DdlRepresentante.SelectedValue = objNegociacao.CodRepresentante


            DdlEtapa.SelectedValue = objNegociacao.CodEtapaNegociacao
            DdlFormaPagto.SelectedValue = objNegociacao.CodFormaPagto
            DdlCondicaoPagto.SelectedValue = objNegociacao.CodCondPagto


            TxtManterInformado.Text = objNegociacao.ManterInformado

            LblDataCadastramento.Text = objNegociacao.DataCadastramento

            DdlFrete.SelectedValue = objNegociacao.tipo_frete

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class