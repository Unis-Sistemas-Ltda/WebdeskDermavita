Public Class UCLEmitente

    Private _CodEmitente As String
    Private _Nome As String
    Private _TpPessoa As String
    Private _NomeAbreviado As String
    Private _Situacao As String
    Private _Tipo As String
    Private _Procedencia As String
    Private _Natureza As String
    Private _Funcionario As String
    Private _Transportador As String
    Private _Representante As String
    Private _Licenciador As String
    Private _OptantePeloSimples As String
    Private _DataCadastramento As String
    Private _DDataCadastramento As Date
    Private _UsuarioCadastramento As String
    Private _DataAlteracao As String
    Private _DDataAlteracao As Date
    Private _UsuarioAlteracao As String
    Private _TitulosEmAberto As Long
    Private _DiasInadimplente As Long
    Private _CnpjPreferencial As String
    Private _CnpjCobranca As String
    Private objAcessoDados As UCLAcessoDados

    Public Enum TipoDDL
        Cliente = 1
        Fornecedor = 2
        Representante = 3
    End Enum

    Public Property Professor() As String

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property

    Public Property TpPessoa() As String
        Get
            Return _TpPessoa
        End Get
        Set(ByVal value As String)
            _TpPessoa = value
        End Set
    End Property

    Public Property NomeAbreviado() As String
        Get
            Return _NomeAbreviado
        End Get
        Set(ByVal value As String)
            _NomeAbreviado = value
        End Set
    End Property

    Public Property Situacao() As String
        Get
            Return _Situacao
        End Get
        Set(ByVal value As String)
            _Situacao = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property Procedencia() As String
        Get
            Return _Procedencia
        End Get
        Set(ByVal value As String)
            _Procedencia = value
        End Set
    End Property

    Public Property Natureza() As String
        Get
            Return _Natureza
        End Get
        Set(ByVal value As String)
            _Natureza = value
        End Set
    End Property

    Public Property Funcionario() As String
        Get
            If String.IsNullOrEmpty(_Funcionario) Then
                _Funcionario = "N"
            End If
            Return _Funcionario
        End Get
        Set(ByVal value As String)
            _Funcionario = value
        End Set
    End Property

    Public Property Transportador() As String
        Get
            If String.IsNullOrEmpty(_Transportador) Then
                _Transportador = "N"
            End If
            Return _Transportador
        End Get
        Set(ByVal value As String)
            _Transportador = value
        End Set
    End Property

    Public Property Representante() As String
        Get
            If String.IsNullOrEmpty(_Representante) Then
                _Representante = "N"
            End If
            Return _Representante
        End Get
        Set(ByVal value As String)
            _Representante = value
        End Set
    End Property

    Public Property Licenciador() As String
        Get
            If String.IsNullOrEmpty(_Licenciador) Then
                _Licenciador = "N"
            End If
            Return _Licenciador
        End Get
        Set(ByVal value As String)
            _Licenciador = value
        End Set
    End Property

    Public Property OptantePeloSimples() As String
        Get
            If String.IsNullOrEmpty(_OptantePeloSimples) Then
                _OptantePeloSimples = "N"
            End If
            Return _OptantePeloSimples
        End Get
        Set(ByVal value As String)
            _OptantePeloSimples = value
        End Set
    End Property

    Public Property DataCadastramento() As String
        Get
            If DDataCadastramento <> Nothing Then
                Return DDataCadastramento.ToString("dd/MM/yyyy")
            End If
            Return _DataCadastramento
        End Get
        Set(ByVal value As String)
            If IsDate(_DataCadastramento) Then
                DDataCadastramento = CDate(_DataCadastramento)
            End If
            _DataCadastramento = value
        End Set
    End Property

    Public Property DDataCadastramento() As Date
        Get
            Return _DDataCadastramento
        End Get
        Set(ByVal value As Date)
            _DDataCadastramento = value
        End Set
    End Property

    Public Property UsuarioCadastramento() As String
        Get
            Return _UsuarioCadastramento
        End Get
        Set(ByVal value As String)
            _UsuarioCadastramento = value
        End Set
    End Property

    Public Property DataAlteracao() As String
        Get
            If DDataAlteracao <> Nothing Then
                Return DDataAlteracao.ToString("dd/MM/yyyy")
            End If
            Return _DataAlteracao
        End Get
        Set(ByVal value As String)
            If IsDate(_DataAlteracao) Then
                DDataAlteracao = CDate(_DataAlteracao)
            End If
            _DataAlteracao = value
        End Set
    End Property

    Public Property DDataAlteracao() As Date
        Get
            Return _DDataAlteracao
        End Get
        Set(ByVal value As Date)
            _DDataAlteracao = value
        End Set
    End Property

    Public Property UsuarioAlteracao() As String
        Get
            Return _UsuarioAlteracao
        End Get
        Set(ByVal value As String)
            _UsuarioAlteracao = value
        End Set
    End Property

    Public Property CNPJPreferencial() As String
        Get
            Return _CnpjPreferencial
        End Get
        Set(ByVal value As String)
            _CnpjPreferencial = value
        End Set
    End Property

    Public Property CNPJCobranca() As String
        Get
            Return _CnpjCobranca
        End Get
        Set(ByVal value As String)
            _CnpjCobranca = value
        End Set
    End Property

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As DataTable
        Dim strSql As String
        Dim dt As DataTable

        strSql = " select isnull(nome,'') nome, "
        strSql += "       isnull(nome_abreviado,'') nome_abreviado, "
        strSql += "       isnull(tp_pessoa,'') tp_pessoa, "
        strSql += "       isnull(tipo,'') tipo, "
        strSql += "       isnull(situacao,'') situacao, "
        strSql += "       isnull(procedencia,'') procedencia, "
        strSql += "       cod_usuario_cadastramento cod_usuario_cadastramento, "
        strSql += "       cod_usuario_alteracao cod_usuario_alteracao, "
        strSql += "       isnull(data_cadastramento,'1900-01-01') data_cadastramento, "
        strSql += "       isnull(data_alteracao,'1900-01-01') data_alteracao, "
        strSql += "       isnull(representante,'N') representante,  "
        strSql += "       isnull(natureza_emitente,'') natureza_emitente, "
        strSql += "       isnull(licenciador,'N') licenciador, "
        strSql += "       isnull(funcionario,'N') funcionario, "
        strSql += "       isnull(transportador,'N') transportador, "
        strSql += "       isnull(optante_pelo_simples,'N') optante_pelo_simples, "
        strSql += "       isnull(professor,'N') professor "
        strSql += "  from emitente "
        strSql += " where cod_emitente = " + CodEmitente


        dt = objAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Nome = dt.Rows.Item(0).Item("nome").ToString
            NomeAbreviado = dt.Rows.Item(0).Item("nome_abreviado").ToString
            TpPessoa = dt.Rows.Item(0).Item("tp_pessoa").ToString
            Situacao = dt.Rows.Item(0).Item("situacao").ToString
            Tipo = dt.Rows.Item(0).Item("tipo").ToString
            Procedencia = dt.Rows.Item(0).Item("procedencia").ToString
            Professor = dt.Rows.Item(0).Item("professor").ToString
            If Not IsDBNull(dt.Rows.Item(0).Item("cod_usuario_cadastramento")) Then
                UsuarioCadastramento = dt.Rows.Item(0).Item("cod_usuario_cadastramento").ToString
            Else
                UsuarioCadastramento = 1
            End If
            If Not IsDBNull(dt.Rows.Item(0).Item("cod_usuario_alteracao")) Then
                UsuarioAlteracao = dt.Rows.Item(0).Item("cod_usuario_alteracao").ToString
            Else
                UsuarioAlteracao = 1
            End If
            DataCadastramento = dt.Rows.Item(0).Item("data_cadastramento")
            DataAlteracao = dt.Rows.Item(0).Item("data_alteracao")
            Representante = dt.Rows.Item(0).Item("representante").ToString
            Natureza = dt.Rows.Item(0).Item("natureza_emitente").ToString
            Licenciador = dt.Rows.Item(0).Item("licenciador").ToString
            Funcionario = dt.Rows.Item(0).Item("funcionario").ToString
            Transportador = dt.Rows.Item(0).Item("transportador").ToString
            OptantePeloSimples = dt.Rows.Item(0).Item("optante_pelo_simples").ToString

            CNPJPreferencial = GetCNPJ(Me.CodEmitente, TipoCNPJ.Preferencial)
            If String.IsNullOrEmpty(CNPJPreferencial) Then
                CNPJPreferencial = GetCNPJ(Me.CodEmitente, TipoCNPJ.PrimeiroCadastrado)
            End If

            CNPJCobranca = GetCNPJ(Me.CodEmitente, TipoCNPJ.Cobranca)
            If String.IsNullOrEmpty(CNPJCobranca) Then
                CNPJCobranca = CNPJPreferencial
            End If

        End If

        Return dt
    End Function

    Public Enum TipoCNPJ As Integer
        Preferencial = 1
        Cobranca = 2
        PrimeiroCadastrado = 3
    End Enum

    Public Sub Incluir()
        Dim strSql As String = ""

        Try
            strSql += " insert into emitente( cod_emitente, "
            strSql += "       nome, "
            strSql += "       nome_abreviado, "
            strSql += "       tp_pessoa, "
            strSql += "       tipo, "
            strSql += "       situacao, "
            strSql += "       procedencia, "
            strSql += "       cod_usuario_cadastramento, "
            strSql += "       cod_usuario_alteracao, "
            strSql += "       data_cadastramento, "
            strSql += "       data_alteracao, "
            strSql += "       auxiliar1, "
            strSql += "       representante, "
            strSql += "       natureza_emitente, "
            strSql += "       licenciador, "
            strSql += "       funcionario, "
            strSql += "       transportador, "
            strSql += "       optante_pelo_simples) "
            strSql += " values("
            strSql += CodEmitente + ", "
            strSql += "'" + Nome + "', "
            strSql += "'" + NomeAbreviado + "', "
            strSql += "'" + TpPessoa + "', "
            strSql += "'" + Tipo + "', "
            strSql += "'" + Situacao + "', "
            strSql += "'" + Procedencia + "', "
            strSql += "f_busca_cod_usuario(current user), "
            strSql += "f_busca_cod_usuario(current user), "
            strSql += "getDate(), "
            strSql += "getDate(), "
            strSql += "0, "
            strSql += "'" + Representante + "', "
            strSql += "'" + Natureza + "', "
            strSql += "'" + Licenciador + "', "
            strSql += "'" + Funcionario + "', "
            strSql += "'" + Transportador + "', "
            strSql += "'" + OptantePeloSimples + "')"
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Alterar()
        Dim strSql As String = ""

        Try
            strSql += " update emitente"
            strSql += "    set nome                 = '" + Nome + "', "
            strSql += "        nome_abreviado       = '" + NomeAbreviado + "', "
            strSql += "        tp_pessoa            = '" + TpPessoa + "', "
            strSql += "        tipo                 = '" + Tipo + "', "
            strSql += "        situacao             = '" + Situacao + "', "
            strSql += "        procedencia          = '" + Procedencia + "', "
            'strSql += "        cod_usuario_cadastramento = " + UsuarioCadastramento + ", "
            'strSql += "        cod_usuario_alteracao = " + UsuarioAlteracao + ", "
            'If DDataCadastramento <> Nothing Then
            'strSql += "    data_cadastramento   = '" + DDataCadastramento.ToString("yyyy-MM-dd") + "', "
            'Else
            'strSql += "    data_cadastramento   = null, "
            'End If
            'If DDataAlteracao <> Nothing Then
            'strSql += "    data_alteracao       = '" + DDataAlteracao.ToString("yyyy-MM-dd") + "', "
            'Else
            'strSql += "    data_alteracao       = null, "
            'End If
            strSql += "        representante        = '" + Representante + "', "
            strSql += "        natureza_emitente    = '" + Natureza + "', "
            strSql += "        licenciador          = '" + Licenciador + "', "
            strSql += "        funcionario          = '" + Funcionario + "', "
            strSql += "        transportador        = '" + Transportador + "', "
            strSql += "        optante_pelo_simples = '" + OptantePeloSimples + "'"
            strSql += "  where cod_emitente         = " + CodEmitente
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_emitente),0) + 1 max from emitente "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal Tipo As TipoDDL, Optional ByVal CodEmitente As String = "0", Optional ByVal MostrarInativos As Boolean = True)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_emitente, nome || ' (' || cod_emitente || ')' nome "
        strSql += "   from emitente "
        Select Case Tipo
            Case TipoDDL.Representante
                strSql += "  where representante = 'S' "
            Case TipoDDL.Cliente
                strSql += "  where tipo in (2,3) "
            Case TipoDDL.Fornecedor
                strSql += "  where tipo in (1,2) "
        End Select
        If Not MostrarInativos Then
            strSql += " and ( situacao = 2 or cod_emitente = " + CodEmitente + " )"
        End If
        strSql += "  order by nome "
        dt = objAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_emitente") = 0
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod_emitente"
        DDL.DataBind()

    End Sub

    Public Function TitulosEmAberto(ByVal empresa As String)
        Try
            Dim StrSql As String = ""
            Dim qtd As Long
            Dim dt As DataTable

            StrSql += "	select count(*) qtd"
            StrSql += "	  from titulo_cr"
            StrSql += "	 where empresa       = " + empresa
            StrSql += "		and cod_emitente = " + CodEmitente
            StrSql += "		and data_vencimento < today()"
            StrSql += "		and situacao     = 1;"
            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                qtd = dt.Rows.Item(0).Item("qtd")
            Else
                qtd = 0
            End If

            Return qtd

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DiasInadimplente(ByVal empresa As String)
        Try
            Dim StrSql As String = ""
            Dim dias As Long
            Dim dt As DataTable

            StrSql += "	 select isnull(f_titulo_cr_consulta(0," + empresa + "," + CodEmitente + "),0) dias "
            StrSql += "	   from dummy;"
            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                dias = dt.Rows.Item(0).Item("dias")
            Else
                dias = 0
            End If

            Return dias
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarPorCNPJ(ByVal Cnpj As String) As DataTable
        Dim strSql As String = ""
        strSql += " select e.cod_emitente, "
        strSql += "        e.nome, "
        strSql += "        e.farmacia_classificacao, "
        strSql += "        e.socio_abfh, "
        strSql += "        e.nome_abreviado, "
        strSql += "        e.tp_pessoa, "
        strSql += "        e.associado, "
        strSql += "        e.situacao, "
        strSql += "        (isnull((select first 1 from inscricao_sinamm i, sysusuario s where i.cod_emitente = e.cod_emitente and i.cod_emitente = s.cod_emitente_externo and  s.id_situacao not in(4,5)),0)) as sinamm, "
        strSql += "        (isnull((select first i.cod_laboratorio from inscricao_sinamm i, sysusuario s where i.cod_emitente = e.cod_emitente and i.cod_emitente = s.cod_emitente_externo and  s.id_situacao not in(4,5)),0)) as cod_laboratorio, "
        strSql += "        e.numero_de_filiais, "
        strSql += "        e.numero_funcionario, "
        strSql += "        ee.cnpj, "
        strSql += "        ee.senha, "
        strSql += "        ee.insc_estadual, "
        strSql += "        ee.insc_municipal, "
        strSql += "        ee.endereco, "
        strSql += "        ee.cod_pais, "
        strSql += "        ee.cod_estado, "
        strSql += "        ee.cod_cidade, "
        strSql += "        ee.cep, "
        strSql += "        ee.telefone2, "
        strSql += "        ee.telefone, "
        strSql += "        ee.fax, "
        strSql += "        ee.numero_funcionario, "
        strSql += "        ee.autorizacao_funcionamento, "
        strSql += "        ee.autorizacao_especial, "
        strSql += "        ee.nome_responsavel_tecnico, "
        strSql += "        ee.cpf_responsavel_tecnico, "
        strSql += "        ee.id_profissional, "
        strSql += "        ee.cod_estado_id_profissional, "
        strSql += "        ee.orgao_exp, "
        strSql += "        c.email, "
        strSql += "        ee.master, "
        strSql += "        e.rg, "
        strSql += "        es.nome_estado, "
        strSql += "        ci.nome_cidade, "
        strSql += "        b.nome_bairro, "
        strSql += "        isnull((select first tsi.finalizado from turma_sinamm tsi join inscricao_sinamm ins on ins.cod_turma = tsi.cod_turma where ins.cod_emitente = e.cod_emitente),'N') as finalizado, "
        strSql += "        (select first cod_grupo from cliente_financeiro where cod_emitente = e.cod_emitente) tipo_forn, "
        strSql += "        case tipo_forn when 3 then 'INS' when 6 then 'EMB' else '' end forn, "
        strSql += "        cf.cod_grupo cod_grupo_cf "
        strSql += "   from emitente e inner join endereco_emitente ee on e.cod_emitente = ee.cod_emitente "
        strSql += "                   left outer join contatos c            on c.cod_emitente = ee.cod_emitente "
        strSql += "                   inner join cidade ci                  on ci.cod_pais    =  ee.cod_pais "
        strSql += "                                                        and ci.cod_estado  =  ee.cod_estado "
        strSql += "                                                        and ci.cod_cidade  =  ee.cod_cidade "
        strSql += "                   inner join estado es                  on es.cod_pais    =  ee.cod_pais "
        strSql += "                                                        and es.cod_estado  = ee.cod_estado "
        strSql += "                   left outer join bairro b              on b.cod_pais     = ee.cod_pais "
        strSql += "                                                        and b.cod_estado   = ee.cod_estado "
        strSql += "                                                        and b.cod_cidade   = ee.cod_cidade "
        strSql += "                                                        and b.cod_bairro   = ee.cod_bairro"
        strSql += "                   left outer join cliente_financeiro cf on cf.cod_emitente = e.cod_emitente"
        strSql += "  where isnull(c.preferencial,'S') = 'S' "
        strSql += "    and isnull(ee.ativo,'S')       = 'S'"
        strSql += "    and trim(ee.cnpj)              = '" & Cnpj.Trim & "'"
        strSql += "    and isnull(cf.empresa,1)       = 1"
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

    Public Function GetRazaoSocial(ByVal CodEmitente As String) As String
        Dim razao As String = ""
        Dim strSql As String
        Dim dt As DataTable

        Try
            strSql = "select nome from emitente where cod_emitente = " + CodEmitente
            dt = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                razao = dt.Rows.Item(0).Item("nome").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return razao

    End Function

    Public Function GetTelefone(ByVal CodEmitente As String) As String
        Try
            Dim strSql As String = "select telefone from endereco_emitente where preferencial = 'S' and cod_emitente = " + CodEmitente
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("telefone").ToString
            End If
            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTelefone2(ByVal CodEmitente As String) As String
        Try
            Dim strSql As String = "select telefone2 from endereco_emitente where preferencial = 'S' and cod_emitente = " + CodEmitente
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("telefone2").ToString
            End If
            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetEmail(ByVal CodEmitente As String) As String
        Try
            Dim strSql As String = "select contato_email from v_emitente_endereco where preferencial = 'S' and cod_emitente = " + CodEmitente
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("contato_email").ToString
            End If
            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetEndereco(ByVal CodEmitente As String, ByVal cnpj As String) As String
        Try
            Dim strSql As String = "select endereco || ' - ' || cidade_nome || ' / ' || estado_sigla || ' - CEP:' || cep endereco_completo from v_emitente_endereco where cod_emitente = " + CodEmitente + " and cnpj = '" + cnpj + "'"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("endereco_completo").ToString
            End If
            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub atualiza_endereco_emitente(ByVal cod_emitente As String, ByVal preferencial As String, ByVal cnpj As String, ByVal insc_estadual As String, ByVal insc_unicipal As String, ByVal endereco As String, ByVal numero As String, ByVal complemento As String, ByVal pais As String, ByVal estado As String, ByVal cidade As String, ByVal cep As String, ByVal telefone1 As String, ByVal telefone2 As String, ByVal fax As String, ByVal af As String, ByVal ae As String, ByVal NumFuncMatriz As String, ByVal RespTecnico As String, ByVal CpfRespTecnico As String, ByVal CrfRespTecnico As String, ByVal EstadoCrf As String, ByVal OrgaoExpeditor As String, ByVal Email As String, ByVal EmailXmlNfe As String, ByVal EmailBoleto As String)
        Dim strSql As String = ""

        Try
            endereco = endereco.Replace("'", "")
            complemento = complemento.Replace("'", "")
            If preferencial.ToString.Replace("'", "").Trim = "" Then preferencial = "preferencial"

            strSql += "update endereco_emitente "
            strSql += "   set preferencial = " & preferencial & ","
            strSql += "       endereco =  '" & endereco & "',"
            strSql += "       numero =  " & numero & ","
            strSql += "       complemento =  '" & complemento & "',"
            strSql += "       cod_pais = " & pais & ","
            strSql += "       cod_estado = " & estado & ","
            strSql += "       cod_cidade = '" & cidade & "',"
            strSql += "       email = '" & Email.Replace("'", "") & "',"
            strSql += "       email_xml_nfe = '" & EmailXmlNfe.Replace("'", "") & "',"
            strSql += "       contato_boleto = '" & EmailBoleto.Replace("'", "") & "',"
            strSql += "       cod_bairro = null,"
            strSql += "       cep = '" & cep & "',"
            strSql += "       insc_municipal = '" & insc_unicipal & "',"
            strSql += "       insc_estadual = '" & insc_estadual & "',"
            strSql += "       telefone2 = " & telefone2 & ","
            strSql += "       telefone = " & telefone1 & ","
            strSql += "       fax = " & IIf(fax = "?", "fax", fax) & ","
            strSql += "       cobranca = 'N', "
            strSql += "       ativo = 'S', "
            strSql += "       numero_funcionario = " & NumFuncMatriz & ","
            strSql += "       autorizacao_funcionamento = " & af & ","
            strSql += "       autorizacao_especial = " & ae & ","
            strSql += "       nome_responsavel_tecnico = " & RespTecnico & ","
            strSql += "       cpf_responsavel_tecnico = " & CpfRespTecnico & ","
            strSql += "       id_profissional = " & CrfRespTecnico & ","
            strSql += "       cod_estado_id_profissional = " & EstadoCrf & ","
            strSql += "       orgao_exp = " & OrgaoExpeditor
            strSql += " where cod_emitente = " & cod_emitente
            strSql += "   and trim(cnpj) = " & cnpj

            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub atualiza_contato_emitente(ByVal cod_emitente As String, ByVal email As String)
        Dim strSql As String = ""
        strSql += "update contatos "
        strSql += "   set email = '" & email & "'"
        strSql += " where cod_emitente = " & cod_emitente
        strSql += "   and preferencial = 'S'"
        Try
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub AtualizaEmitente(ByVal cod_emitente As String, ByVal nome As String, ByVal nome_abreviado As String, ByVal tp_pessoa As String, ByVal numero_de_filiais As String, ByVal numero_funcionario As String, ByVal rg As String, ByVal classificacao As String, ByVal socioABFH As String)
        Dim strSql As String

        classificacao = IIf(classificacao Is Nothing OrElse classificacao.Replace("'", "").Trim = "", "farmacia_classificacao", classificacao)
        socioABFH = IIf(socioABFH Is Nothing OrElse socioABFH.Replace("'", "").Trim = "", "socio_abfh", socioABFH)
        numero_funcionario = IIf(numero_funcionario Is Nothing OrElse numero_funcionario.Replace("'", "").Trim = "", "numero_funcionario", numero_funcionario)
        numero_de_filiais = IIf(numero_de_filiais Is Nothing OrElse numero_de_filiais.Replace("'", "").Trim = "", "numero_de_filiais", numero_de_filiais)
        rg = IIf(rg Is Nothing OrElse rg.Replace("'", "").Trim = "", "rg", rg.Replace("'", ""))

        strSql = "update emitente set "
        strSql += "   nome = " & nome & ","
        strSql += "   nome_abreviado = " & nome_abreviado & ","
        strSql += "   tp_pessoa = " & tp_pessoa & ","
        strSql += "   numero_de_filiais = " & numero_de_filiais & ","
        strSql += "   numero_funcionario = " & numero_funcionario & ","
        strSql += "   rg = '" + rg + "', "
        strSql += "   farmacia_classificacao = " & classificacao & ","
        strSql += "   socio_abfh = " & socioABFH
        strSql += " where cod_emitente = " & cod_emitente
        Try
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function busca_sequencia_emitente() As Long
        Dim strSql As String = "select (max(isnull(cod_emitente,0)) + 1) as sequencia from emitente"
        Dim sequencia As Long
        Dim DtSequencia As DataTable
        DtSequencia = ObjAcessoDados.BuscarDados(strSql)
        sequencia = DtSequencia.Rows(0)("sequencia")
        Return sequencia
    End Function

    Public Function BuscarEmitente(ByVal CodEmitente As Long) As DataTable
        Dim strSql As String = "select e.cod_emitente,e.nome,e.nome_abreviado,e.tp_pessoa,e.associado, e.situacao,(isnull((select first 1 from inscricao_sinamm i, sysusuario s where i.cod_emitente = e.cod_emitente and i.cod_emitente = s.cod_emitente_externo and  s.id_situacao not in(4,5)),0)) as sinamm, (isnull((select first i.cod_laboratorio from inscricao_sinamm i, sysusuario s where i.cod_emitente = e.cod_emitente and i.cod_emitente = s.cod_emitente_externo and  s.id_situacao not in(4,5)),0)) as cod_laboratorio, e.numero_de_filiais,e.numero_funcionario,ee.cnpj, ee.senha , ee.insc_estadual,ee.insc_municipal, ee.endereco,ee.cod_pais,ee.cod_estado,ee.cod_cidade,ee.cep,ee.telefone2,ee.telefone,ee.fax,ee.numero_funcionario,ee.autorizacao_funcionamento,ee.autorizacao_especial,ee.nome_responsavel_tecnico,ee.cpf_responsavel_tecnico,ee.id_profissional,isnull(ee.cod_estado_id_profissional,0) cod_estado_id_profissional ,ee.orgao_exp,c.email,c.nome contato_nome, ee.master, e.rg , es.nome_estado, ci.nome_cidade, b.nome_bairro from emitente e, endereco_emitente ee , contatos c , cidade ci, estado es, bairro b where e.cod_emitente = ee.cod_emitente  and c.cod_emitente =* ee.cod_emitente   and c.preferencial = 'S' and b.cod_pais =* ee.cod_pais and b.cod_estado =* ee.cod_estado and b.cod_cidade =* ee.cod_cidade and b.cod_bairro =* ee.cod_bairro and ci.cod_pais = ee.cod_pais and ci.cod_estado = ee.cod_estado and ci.cod_cidade = ee.cod_cidade and es.cod_pais = ee.cod_pais and es.cod_estado = ee.cod_estado and ee.cod_emitente = " & CodEmitente & " and ee.preferencial = 'S'"
        'Dim ds As New DataSet
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

    Public Sub IncluirEmitente(ByVal cod_emitente As String, ByVal nome As String, ByVal nome_abreviado As String, ByVal tp_pessoa As String, ByVal tipo As String, ByVal transportador As String, ByVal funcionario As String, ByVal situacao As String, ByVal procedencia As String, ByVal cod_usuario_cadastramento As String, ByVal cod_usuario_alteracao As String, ByVal data_cadastramento As String, ByVal representante As String, ByVal natureza_emitente As String, ByVal numero_de_filiais As String, ByVal numero_funcionario As String, ByVal rg As String, ByVal classificacao As String, ByVal socioABFH As String)
        Dim strSql As String

        If classificacao = Nothing Then classificacao = "1"
        If socioABFH = Nothing Then socioABFH = "null"

        strSql = "insert into emitente (cod_emitente, "
        strSql += " nome, "
        strSql += " nome_abreviado, "
        strSql += " tp_pessoa, "
        strSql += " tipo, "
        strSql += " transportador, "
        strSql += " funcionario, "
        strSql += " situacao, "
        strSql += " procedencia, "
        strSql += " cod_usuario_cadastramento, "
        strSql += " cod_usuario_alteracao, "
        strSql += " data_cadastramento, "
        strSql += " representante, "
        strSql += " natureza_emitente, "
        strSql += " numero_de_filiais, "
        strSql += " numero_funcionario, "
        strSql += " rg, "
        strSql += " farmacia_classificacao,"
        strSql += " socio_abfh ) "
        strSql += " values( "
        strSql += cod_emitente & ","
        strSql += nome & ","
        strSql += nome_abreviado & ","
        strSql += tp_pessoa & ","
        strSql += tipo & ","
        strSql += transportador & ","
        strSql += funcionario & ","
        strSql += situacao & ","
        strSql += procedencia & ","
        strSql += cod_usuario_cadastramento & ","
        strSql += cod_usuario_alteracao & ","
        strSql += data_cadastramento & ","
        strSql += representante & ","
        strSql += natureza_emitente & ","
        strSql += numero_de_filiais & ","
        strSql += numero_funcionario & ","
        strSql += rg & ","
        strSql += classificacao & ","
        strSql += socioABFH & ")"

        Try
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub IncluirEnderecoEmitente(ByVal cod_emitente As String, ByVal preferencial As String, ByVal cnpj As String, ByVal insc_estadual As String, ByVal insc_unicipal As String, ByVal endereco As String, ByVal numero As String, ByVal complemento As String, ByVal pais As String, ByVal estado As String, ByVal cidade As String, ByVal cep As String, ByVal telefone1 As String, ByVal telefone2 As String, ByVal fax As String, ByVal af As String, ByVal ae As String, ByVal NumFuncMatriz As String, ByVal RespTecnico As String, ByVal CpfRespTecnico As String, ByVal CrfRespTecnico As String, ByVal EstadoCrf As String, ByVal OrgaoExpeditor As String, ByVal Email As String, ByVal EmailXmlNfe As String, ByVal EmailBoleto As String)
        Dim nome As String = "(select first nome from emitente where cod_emitente = " + cod_emitente + ")"
        Dim nome_abreviado As String = "(select first nome_abreviado from emitente where cod_emitente = " + cod_emitente + ")"
        IncluirEnderecoEmitente(cod_emitente, nome, nome_abreviado, preferencial, cnpj, insc_estadual, insc_unicipal, endereco, numero, complemento, pais, estado, cidade, cep, telefone1, telefone2, fax, af, ae, NumFuncMatriz, RespTecnico, CpfRespTecnico, CrfRespTecnico, EstadoCrf, OrgaoExpeditor, Email, EmailXmlNfe, EmailBoleto)
    End Sub

    Public Sub IncluirEnderecoEmitente(ByVal cod_emitente As String, ByVal nome As String, ByVal nome_abreviado As String, ByVal preferencial As String, ByVal cnpj As String, ByVal insc_estadual As String, ByVal insc_unicipal As String, ByVal endereco As String, ByVal numero As String, ByVal complemento As String, ByVal pais As String, ByVal estado As String, ByVal cidade As String, ByVal cep As String, ByVal telefone1 As String, ByVal telefone2 As String, ByVal fax As String, ByVal af As String, ByVal ae As String, ByVal NumFuncMatriz As String, ByVal RespTecnico As String, ByVal CpfRespTecnico As String, ByVal CrfRespTecnico As String, ByVal EstadoCrf As String, ByVal OrgaoExpeditor As String, ByVal Email As String, ByVal EmailXmlNfe As String, ByVal EmailBoleto As String)
        cnpj = cnpj.Trim
        Dim strSql As String = "insert into endereco_emitente (cod_emitente,cnpj,nome,nome_abreviado,preferencial,endereco,numero,complemento,cod_pais,cod_estado,cod_cidade,cod_bairro,cep,email,email_xml_nfe,contato_boleto,insc_municipal,insc_estadual,telefone2,telefone,fax,cobranca,numero_funcionario,autorizacao_funcionamento,autorizacao_especial,nome_responsavel_tecnico,cpf_responsavel_tecnico,id_profissional,cod_estado_id_profissional,orgao_exp) values(" & cod_emitente & "," & cnpj & "," & nome & "," & nome_abreviado & "," & preferencial & "," & endereco & "," & numero & "," & complemento & "," & pais & "," & estado & "," & cidade & ", null, " & cep & ",'" & Email & "','" & EmailXmlNfe & "','" & EmailBoleto & "'," & insc_unicipal & "," & insc_estadual & "," & telefone2 & "," & telefone1 & "," & IIf(fax = "?", "null", fax) & "," & "'N' ," & NumFuncMatriz & "," & af & "," & ae & "," & RespTecnico & "," & CpfRespTecnico & "," & CrfRespTecnico & "," & EstadoCrf & "," & OrgaoExpeditor & ")"
        Try
            objAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub IncluirEnderecoEmitente(ByVal cod_emitente As String, ByVal nome As String, ByVal preferencial As String, ByVal cnpj As String, ByVal endereco As String, ByVal pais As String, ByVal estado As String, ByVal cidade As String, ByVal cep As String, ByVal telefone1 As String, ByVal telefone2 As String, ByVal fax As String)
        Dim strSql As String
        cnpj = cnpj.Trim
        strSql = "if not exists(select 1 from endereco_emitente where cod_emitente = " + cod_emitente + " and cnpj = " + cnpj + ") then "
        strSql += "insert into endereco_emitente (cod_emitente,cnpj,nome,preferencial,endereco,cod_pais,cod_estado,cod_cidade,cod_bairro,cep,telefone2,telefone,fax,cobranca,ativo) values(" & cod_emitente & "," & cnpj & "," & nome & "," & preferencial & "," & endereco & "," & pais & "," & estado & "," & cidade & ",null," & cep & "," & telefone2 & "," & telefone1 & "," & fax & "," & "'N','S' ) end if"
        Try
            ObjAcessoDados.ExecutarSql(strSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub gravaPrincipalParceriaSantander(ByVal codEmitente As String, ByVal cnpj As String)
        Dim strSql1 As String = ""
        Dim strSql2 As String = ""
        Dim dt As DataTable
        Dim i As Long

        dt = ObjAcessoDados.BuscarDados("select cnpj from endereco_emitente where cod_emitente = " + codEmitente)
        'Seta o endereço escolhido para principal='S'

        Try
            'Seta todos os endereços para principal='N'
            For i = 0 To dt.Rows.Count - 1
                strSql1 += "update endereco_emitente set preferencial_sinamm = 'N' where cod_emitente = " + codEmitente + " and cnpj = '" + dt.Rows.Item(i).Item("cnpj").ToString.Trim + "';"
                strSql1 += "update adesao_parceria_santander_cnpj set preferencial = 'N' where empresa = 1 and cod_emitente = " + codEmitente + " and cnpj = '" + dt.Rows.Item(i).Item("cnpj").ToString.Trim + "';"
                ObjAcessoDados.ExecutarSql(strSql1)
            Next

            strSql2 += "update endereco_emitente set preferencial_sinamm = 'S' where cod_emitente = " + codEmitente + " and cnpj = '" + cnpj + "';"
            strSql2 += "update adesao_parceria_santander_cnpj set preferencial = 'S' where empresa = 1 and cod_emitente = " + codEmitente + " and cnpj = '" + cnpj + "';"
            ObjAcessoDados.ExecutarSql(strSql2)

            '''''atualizaDataAlteracao(codEmitente)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetCNPJ(ByVal emitente As String, ByVal tipo As TipoCNPJ) As String
        Try
            Dim cnpj As String
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = "  select first cnpj "
            StrSql += "   from endereco_emitente "
            StrSql += " where cod_emitente = " + emitente

            If tipo = TipoCNPJ.Cobranca Then
                StrSql += "  and isnull(cobranca,'N') = 'S' "
            ElseIf tipo = TipoCNPJ.Preferencial Then
                StrSql += "  and isnull(preferencial,'N') = 'S' "
            End If

            StrSql += "  order by cnpj"
            dt = objAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count = 0 Then
                cnpj = ""
            Else
                cnpj = dt.Rows.Item(0).Item("cnpj").ToString
            End If

            Return cnpj
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCNPJPreferencial(ByVal codEmitente As String) As String
        Dim strSql As String = "select trim(cnpj) cnpjfarm from endereco_emitente where cod_emitente = " + codEmitente + " and preferencial = 'S'"
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)

        If dt.Rows.Count > 0 Then
            Return dt.Rows.Item(0).Item("cnpjfarm").ToString
        End If

        Return ""

    End Function
    Public Function BuscaEnderecoEmitente(ByVal cod_emitente As String, ByVal cnpj As String) As DataTable
        Dim strSql As String = " SELECT * FROM endereco_emitente ee WHERE ee.cod_emitente = " + cod_emitente + " and trim(ee.cnpj) = " + cnpj
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

    Public Function BuscaEnderecoCompleto(ByVal cod_emitente As String, ByVal cnpj As String) As DataTable
        Dim strSql As String = " SELECT * FROM v_emitente_endereco ee WHERE ee.cod_emitente = " + cod_emitente + " and trim(ee.cnpj) = " + cnpj
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

End Class