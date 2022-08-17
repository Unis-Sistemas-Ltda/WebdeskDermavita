Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Net

Module VariaveisGlobais
    Public ReadOnly Property CaminhoAnexoFollowUp As String
        Get
            Dim objAcessoDados As New UCLAcessoDados
            Dim strSql As String = "select caminho_anexo_follow_up from parametros_manutencao where empresa = 1 and estabelecimento = 1"
            Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows.Item(0).Item("caminho_anexo_follow_up")) Then
                    Return dt.Rows.Item(0).Item("caminho_anexo_follow_up").ToString()
                Else
                    Return "C:\\inetpub\\wwwroot\\webdeskunis\\Atendimento\\FollowUp\"
                End If
            Else
                Return "C:\\inetpub\\wwwroot\\webdeskunis\\Atendimento\\FollowUp\"
            End If
        End Get
    End Property
    Public __Dsn As String = System.Configuration.ConfigurationManager.AppSettings("dsn")
    Public __Uid As String = "results"
    Public ReadOnly __Pwd As String = "results#01"
    Public ReadOnly Property UsuarioPadraoResults As String
        Get
            Try
                Dim StrSql As String = "select f_busca_cod_usuario('" + __Uid + "') cod from dummy"
                Dim objAcessoDados As New UCLAcessoDados(StrConexao)
                Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows.Item(0).Item("cod").ToString()
                Else
                    Return "20"
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    'Para alterar o DirVirtual deve-se alterar no arquivo web.config, sessão appsettings, variável "caminho".
    'na variável acima, não se deve colocar barra (nem "/"  nem "\"), apenas o nome da pasta
    Public ReadOnly Property DirVirtual() As String
        Get
            Dim caminho As String = System.Configuration.ConfigurationManager.AppSettings("caminho")
            caminho = caminho.Trim
            If String.IsNullOrEmpty(caminho) Then
                Return ""
            Else
                Return caminho + "\"
            End If
        End Get
    End Property

    Public Function ValorNumericoBanco(ByVal StrNumero As String, ByVal Decimais As Integer) As String
        Dim retorno As String
        Dim numero As Double

        If StrNumero = "" Then
            'Se valor não estiver preenchido, retorne null
            retorno = "null"
        Else
            'Retira separadores de milhar
            StrNumero = StrNumero.Replace(".", "")
            If IsNumeric(StrNumero) Then
                numero = CDbl(StrNumero)
                'Dá o número de casas decimais necessário e converte para o formato do banco de dados
                retorno = numero.ToString("F" + Decimais.ToString)
                retorno = retorno.Replace(",", ".")
            Else
                retorno = "null"
            End If

        End If

        Return retorno
    End Function

    Public Function IsNull(ByVal valor1, ByVal valor2, Optional ByVal PadraoBancoDeDados = True)
        If TypeOf valor1 Is String Then
            If String.IsNullOrEmpty(valor1) Then
                If PadraoBancoDeDados Then
                    Return "'" + valor2.ToString + "'"
                Else
                    Return valor2.ToString
                End If
            Else
                If PadraoBancoDeDados Then
                    Return "'" + valor1.ToString + "'"
                Else
                    Return valor1.ToString
                End If
            End If
        Else
            If valor1 Is Nothing Then
                If TypeOf valor2 Is Double Or TypeOf valor2 Is Long Then
                    If PadraoBancoDeDados Then
                        Return valor2.ToString.Replace(",", ".")
                    Else
                        Return valor2
                    End If
                Else
                    Return valor2
                End If
            Else
                If TypeOf valor1 Is Double Or TypeOf valor1 Is Long Then
                    If PadraoBancoDeDados Then
                        Return valor1.ToString.Replace(",", ".")
                    Else
                        Return valor1
                    End If
                Else
                    Return valor1
                End If
            End If
        End If
    End Function

    Public Sub SetUidBD(ByVal uid As String)
        __Uid = uid
    End Sub

    Public Sub SetDsn(ByVal dsn As String)
        __Dsn = dsn
    End Sub

    Public ReadOnly Property StrConexao() As String
        Get
            Return "Dsn=" + __Dsn + ";uid=" + __Uid + ";pwd=results#01"
        End Get
    End Property

    Public Function StrConexaoUsuario(ByVal idUsuario As String) As String
        Return "Dsn=" + __Dsn + ";uid=" + idUsuario + ";pwd=results#01"
    End Function

    Public Sub SetaDsnAplicacao()
        Dim LDsn As String = System.Configuration.ConfigurationManager.AppSettings("dsn")
        LDsn = LDsn.Trim
        SetDsn(LDsn)
    End Sub

    Public Function GetHtmlFromAspx(ByVal url As String) As String
        Dim contents As String = ""

        If url.Length > 6 Then
            'open 'http://' file
            If (url.Chars(0) = "h"c OrElse url.Chars(0) = "H"c) AndAlso _
               (url.Chars(1) = "t"c OrElse url.Chars(1) = "T"c) AndAlso _
               (url.Chars(2) = "t"c OrElse url.Chars(2) = "T"c) AndAlso _
               (url.Chars(3) = "p"c OrElse url.Chars(3) = "P"c) AndAlso _
               url.Chars(4) = ":"c AndAlso _
               url.Chars(5) = "/"c AndAlso _
               url.Chars(6) = "/"c Then

                Dim StreamHttp As Stream = Nothing
                Dim resp As WebResponse = Nothing
                Dim webrequest As HttpWebRequest = Nothing
                Try
                    webrequest = CType(webrequest.Create(url), HttpWebRequest)
                    resp = webrequest.GetResponse()
                    StreamHttp = resp.GetResponseStream()
                    Dim sr As New StreamReader(StreamHttp)
                    contents = sr.ReadToEnd()
                    Return contents
                Catch
                End Try
                'or open local file
            Else
                Try
                    Dim sr As New StreamReader(url)
                    contents = sr.ReadToEnd()
                    sr.Close()

                Catch
                End Try

            End If
        End If
        Return contents
    End Function

    Public Function ImprimeTexto(ByVal entrada As String) As String
        Dim saida As String

        saida = entrada.Replace(Chr(10), "<br>")
        saida = saida.Replace("[", "<")
        saida = saida.Replace("]", ">")

        Return saida
    End Function

    Public Enum TipoQuantidadeCalcular As Long
        QtdUD = 1
        QtdPedida = 2
    End Enum

    Public Function CalculaQuantidade_Unidade_UD(ByVal qtd_pedida As Double, ByVal qtd_ud As Double, ByVal tipo As TipoQuantidadeCalcular, ByVal item As String, ByVal referencia As String) As Double
        Dim ld_ud As Double
        Dim strSql As String
        Dim dt As DataTable
        Dim objAcessoDados As New UCLAcessoDados(StrConexao)
        Dim ld_conversao As Double
        Dim ld_qtd As Double
        Dim ld_consumo As Double

        If tipo = TipoQuantidadeCalcular.QtdPedida Then

            ld_conversao = 0
            ld_ud = qtd_ud

            strSql = "  Select u.fator_conversao from referencia r, unidade_despacho u where r.cod_referencia = '" + referencia + "' and u.cod_ud = r.cod_ud"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("fator_conversao")) Then
                    ld_conversao = 0
                Else
                    ld_conversao = dt.Rows.Item(0).Item("fator_conversao")
                End If
            End If

            If ld_conversao = 0 Then
                strSql = " Select u.fator_conversao from item i, unidade_despacho u where i.cod_item = '" + item + "' and u.cod_ud = i.cod_ud"
                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows.Item(0).Item("fator_conversao")) Then
                        ld_conversao = 0
                    Else
                        ld_conversao = dt.Rows.Item(0).Item("fator_conversao")
                    End If
                End If
            End If

            If ld_conversao = Nothing OrElse ld_conversao = 0 Then
                ld_conversao = 1
            End If

            ld_qtd = ld_ud * ld_conversao
            qtd_pedida = ld_qtd

        ElseIf tipo = TipoQuantidadeCalcular.QtdUD Then

            ld_conversao = 0
            ld_consumo = qtd_pedida

            strSql = "  Select u.fator_conversao from referencia r, unidade_despacho u where r.cod_referencia = '" + referencia + "' and u.cod_ud 	= r.cod_ud"
            dt = objAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("fator_conversao")) Then
                    ld_conversao = 0
                Else
                    ld_conversao = dt.Rows.Item(0).Item("fator_conversao")
                End If
            End If

            If ld_conversao = 0 Then
                strSql = " Select u.fator_conversao from item i, unidade_despacho u where i.cod_item = '" + item + "' and u.cod_ud 	= i.cod_ud"
                dt = objAcessoDados.BuscarDados(strSql)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows.Item(0).Item("fator_conversao")) Then
                        ld_conversao = 0
                    Else
                        ld_conversao = dt.Rows.Item(0).Item("fator_conversao")
                    End If
                End If
            End If

            If ld_conversao = Nothing Or ld_conversao = 0 Then
                ld_conversao = 1
            End If

            ld_qtd = ld_consumo / ld_conversao
            qtd_ud = ld_qtd
        End If

        If tipo = TipoQuantidadeCalcular.QtdPedida Then
            Return qtd_pedida
        ElseIf tipo = TipoQuantidadeCalcular.QtdUD Then
            Return qtd_ud
        End If

    End Function

    Function F_DateAdd(ByVal data As Date, ByVal tipo As String, ByVal quantidade As Long, ByVal dutil As String) As Date
        Try
            Dim retorno As Date
            Dim inc As Long = 1
            Dim strSql As String
            Dim dt As DataTable
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)

            If quantidade < 0 Then
                inc = -1
            End If

            strSql = "select f_dateadd(" + data.ToString("yyyyMMdd") + ", '" + tipo + "'," + quantidade.ToString + ") dt from dummy;"
            dt = objAcessoDados.BuscarDados(strSql)

            If dt.Rows.Count > 0 Then
                retorno = dt.Rows.Item(0).Item("dt")
            End If

            If dutil.ToUpper = "U" Then
                While retorno.DayOfWeek = DayOfWeek.Sunday Or retorno.DayOfWeek = DayOfWeek.Saturday
                    strSql = "select f_dateadd(" + retorno.ToString("yyyyMMdd") + ", 'd'," + inc.ToString + ") dt from dummy;"
                    dt = objAcessoDados.BuscarDados(strSql)
                    If dt.Rows.Count > 0 Then
                        retorno = dt.Rows.Item(0).Item("dt")
                    Else
                        Exit While
                    End If
                End While
            End If

            Return retorno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public ReadOnly Property EmailPadraoContato() As String
        Get
            Return "suporte@unisnet.com.br"
        End Get
    End Property

    Public ReadOnly Property SenhaPadraoContato() As String
        Get
            Return "*suporte#2013"
        End Get
    End Property

    Public Function Mascarar(ByVal valor As String, ByVal mascara As String) As String
        Dim novoValor As String = String.Empty
        Dim posicao As Integer = 0
        Dim i As Integer = 0
        While mascara.Length > i
            If mascara.Substring(i, 1) = "#" Then
                If valor.Length > posicao Then
                    novoValor = novoValor & valor(posicao)
                    posicao += 1
                Else
                    Exit While
                End If
            Else
                If valor.Length > posicao Then
                    novoValor = novoValor & mascara(i)
                Else
                    Exit While
                End If
            End If
            i += 1
        End While
        Return novoValor
    End Function

    Public Function GetQuantidadeTitulosVencidos(ByVal pEmpresa As String, ByVal pCodEmitente As String) As Long
        Try
            Dim ret As Long = 0
            Dim strSql As String = ""
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable
            strSql += " select count(1) qtd"
            strSql += "    from titulo_cr t inner join bordero_cr_item bi on t.empresa          = bi.empresa"
            strSql += "                                                  and t.estabelecimento  = bi.estabelecimento"
            strSql += "                                                  and t.cod_especie      = bi.cod_especie"
            strSql += "                                                  and t.serie            = bi.serie"
            strSql += "                                                  and t.cod_tit_cr       = bi.cod_tit_cr"
            strSql += "                                                  and t.parcela          = bi.parcela"
            strSql += "                                                  and t.cod_cenario_ctbl = bi.cod_cenario_ctbl"
            strSql += "                    inner join bordero_cr b on b.empresa        = bi.empresa"
            strSql += "                                           and b.cod_bordero_cr = bi.cod_bordero_cr"
            strSql += "  where t.cod_emitente = " + pCodEmitente
            strSql += "    and t.empresa      = " + pEmpresa
            strSql += "    and b.tp_bordero   = 5"
            strSql += "    and b.atualizado   = 'S'"
            strSql += "    and t.cod_tit_cr_banco is not null"
            strSql += "    and t.situacao <> 10"
            strSql += "    and t.sit_saldo = 1"
            strSql += "    and t.data_vencimento <= today()"
            strSql += "    and ((t.sit_saldo = 1 and isnull(b.enviado,'N') = 'S') or t.sit_saldo = 2)"
            dt = ObjAcessoDados.BuscarDados(strSql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows.Item(0).Item("qtd").ToString
            End If
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private ReadOnly DataNovosConvenios As Date = New Date(2016, 6, 22)

    Public Function GetSeqAdesaoConvenioAnfarmag(ByVal pEmpresa As String, ByVal pCodEmitente As String, ByVal pConvenio As String) As String
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = "select seq_adesao from adesao_parceria_santander where empresa = " + pEmpresa + " and cod_emitente = " + pCodEmitente + " and convenio = '" + pConvenio + "' and (data_inclusao is null or date(data_inclusao) >= '" + DataNovosConvenios.ToString("yyyy-MM-dd") + "' )"
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            Dim objAdesaoSantander As New UCLAdesaoParceriaSantander(StrConexao)
            Dim codAdesao As String
            If dt.Rows.Count > 0 Then
                codAdesao = dt.Rows.Item(0).Item("seq_adesao").ToString
            Else
                codAdesao = objAdesaoSantander.GetProximoCodigo(pEmpresa)
            End If
            Return codAdesao
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Enum ModoFormulario As Integer
        Inclusao = 1
        Consulta = 2
        ConsultaAlteracao = 3
        ConsultaAlteracaoExclusao = 4
        ConfirmaDados = 5
    End Enum


End Module
