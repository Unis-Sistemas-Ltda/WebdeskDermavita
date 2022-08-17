Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.IO.File
Imports System.IO.FileStream
Imports System.IO.FileNotFoundException
Imports System.IO
Imports System.Net
Imports System.Collections
Imports System.Security.Cryptography
Imports System.Security
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text
Imports System

Imports iTextSharp.text.DocumentException
Imports iTextSharp.text.Rectangle
Imports iTextSharp.text.pdf.AcroFields
Imports iTextSharp.text.pdf.PdfReader
Imports iTextSharp.text.pdf.PdfDocument
Imports iTextSharp.text.pdf.PdfSignatureAppearance
Imports iTextSharp.text.pdf.PdfStamper
Imports iTextSharp.text.Document
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports SautinSoft

Public Class UCLBoleto
    Private objAcessoDados As UCLAcessoDados

    Public Sub New()
        objAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Sub atualiza_boleto(ByVal pEmpresa As String, ByVal pCodBorderoCr As String, ByVal pCodEspecie As String, ByVal pSerie As String, ByVal pCodTitCr As String, ByVal pParcela As String, ByVal pCodCenarioCtbl As String, ByVal mensagem_erro As String)
        Dim StrSql As String
        Try
            StrSql = " delete from bordero_cr_item_email "
            StrSql += " where empresa          = " + pEmpresa
            StrSql += "   and cod_bordero_cr   = " + pCodBorderoCr
            StrSql += "   and cod_especie      = " + pCodEspecie
            StrSql += "   and serie            = '" + pSerie + "'"
            StrSql += "   and cod_tit_cr       = " + pCodTitCr
            StrSql += "   and parcela          = " + pParcela
            StrSql += "   and cod_cenario_ctbl = '" + pCodCenarioCtbl + "'"
            objAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Enum TipoRetorno
        CaminhoCompleto = 1
        NomeDoArquivo = 2
    End Enum

    Public Function GerarBoletoPDF(ByVal pEmpresa As String, ByVal pCodBorderoCr As String, ByVal pCodEspecie As String, ByVal pSerie As String, ByVal pCodTitCr As String, ByVal pParcela As String, ByVal pCodCenarioCtbl As String, ByVal pTipoRetorno As TipoRetorno) As String
        Dim Local As String = "00"
        Try
            Dim StringHTMLBoleto As String
            Local = "01"
            Dim caminhoArquivo As String = ""
            Local = "02"
            Dim nomeArquivo As String = ""
            Local = "03"
            Dim ls_barra As String = ""
            Local = "04"
            StringHTMLBoleto = ""
            Local = "05"
            StringHTMLBoleto = Me.GetHTMLTemplateBoleto(pEmpresa)
            Local = "06"
            StringHTMLBoleto = Me.AlimentaHTMLBoleto(pEmpresa, pCodBorderoCr, pCodEspecie, pSerie, pCodTitCr, pParcela, pCodCenarioCtbl, StringHTMLBoleto, ls_barra)
            Local = "07"
            If Not String.IsNullOrEmpty(StringHTMLBoleto) Then
                Local = "08"
                caminhoArquivo = Me.GetDiretorioBoletoPDF(pEmpresa)
                Local = "09"
                If Not String.IsNullOrEmpty(caminhoArquivo) Then
                    Local = "10"
                    nomeArquivo = "Boleto_" + pEmpresa.PadLeftUnis(2, "0") + pCodBorderoCr.PadLeftUnis(6, "0") + pCodEspecie + pSerie + "_" + pCodTitCr + "_" + pParcela + "_" + pCodCenarioCtbl + ".pdf"
                    Local = "1A"
                    caminhoArquivo += nomeArquivo
                    Local = "1B"
                    Call Me.GeraArquivoPDF(pEmpresa, StringHTMLBoleto, caminhoArquivo, ls_barra)
                    Local = "1C"
                End If
            End If
            Local = "1D"
            If pTipoRetorno = TipoRetorno.CaminhoCompleto Then
                Local = "1E"
                Return caminhoArquivo
            Else
                Local = "1F"
                Return nomeArquivo
            End If
            Local = "11"
        Catch ex As Exception
            Throw New Exception("[" + Local + "]" + ex.ToString)
        End Try
    End Function

    Public Function GetHTMLTemplateBoleto(ByVal pEmpresa As String) As String
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = "select arquivo_template_boleto from parametros_email where empresa = " + pEmpresa
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            Dim ArquivoTemplateBoleto As String
            Dim Conteudo As String
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows.Item(0).Item("arquivo_template_boleto")) Then
                    ArquivoTemplateBoleto = dt.Rows.Item(0).Item("arquivo_template_boleto").ToString.Trim
                Else
                    ArquivoTemplateBoleto = ""
                End If
            Else
                ArquivoTemplateBoleto = ""
            End If
            If Not String.IsNullOrEmpty(ArquivoTemplateBoleto) AndAlso System.IO.File.Exists(ArquivoTemplateBoleto) Then
                Conteudo = System.IO.File.ReadAllText(ArquivoTemplateBoleto)
            Else
                Conteudo = ""
            End If
            Return Conteudo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCaminhoLogoBanco(ByVal pEmpresa As String, ByVal pCodFebraban As String) As String
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = "select arquivo_logo_cliente_boleto from parametros_email where empresa = " + pEmpresa
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            Dim Arquivo As String

            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows.Item(0).Item("arquivo_logo_cliente_boleto")) Then
                    Arquivo = dt.Rows.Item(0).Item("arquivo_logo_cliente_boleto").ToString.Trim
                    If Arquivo.LastIndexOf("\") <> Arquivo.Length - 1 Then
                        Arquivo += "\"
                    End If
                    Arquivo += "logo_banco_" + pCodFebraban.PadLeftUnis(3, "0") + ".GIF"
                Else
                    Arquivo = ""
                End If
            Else
                Arquivo = ""
            End If

            Return Arquivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCaminhoBackground(ByVal pEmpresa As String, ByVal pCodFebraban As String) As String
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = "select arquivo_logo_cliente_boleto from parametros_email where empresa = " + pEmpresa
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            Dim Arquivo As String

            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows.Item(0).Item("arquivo_logo_cliente_boleto")) Then
                    Arquivo = dt.Rows.Item(0).Item("arquivo_logo_cliente_boleto").ToString.Trim
                    If Arquivo.LastIndexOf("\") <> Arquivo.Length - 1 Then
                        Arquivo += "\"
                    End If
                    Arquivo += "boleto.png"
                Else
                    Arquivo = ""
                End If
            Else
                Arquivo = ""
            End If

            Return Arquivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDiretorioBoletoPDF(ByVal pEmpresa As String) As String
        Try
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Dim StrSql As String = "select diretorio_boleto_pdf from parametros_email where empresa = " + pEmpresa
            Dim dt As DataTable = objAcessoDados.BuscarDados(StrSql)
            Dim DiretorioBoletoPDF As String
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows.Item(0).Item("diretorio_boleto_pdf")) Then
                    DiretorioBoletoPDF = dt.Rows.Item(0).Item("diretorio_boleto_pdf").ToString.Trim
                Else
                    DiretorioBoletoPDF = ""
                End If
            Else
                DiretorioBoletoPDF = ""
            End If
            If Not String.IsNullOrEmpty(DiretorioBoletoPDF) AndAlso DiretorioBoletoPDF.Substring(DiretorioBoletoPDF.Length - 1, 1) <> "\" Then
                DiretorioBoletoPDF += "\"
            End If
            Return DiretorioBoletoPDF
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AlimentaHTMLBoleto(ByVal pEmpresa As String, ByVal pCodBorderoCr As String, ByVal pCodEspecie As String, ByVal pSerie As String, ByVal pCodTitCr As String, ByVal pParcela As String, ByVal pCodCenarioCtbl As String, ByVal ConteudoHTML As String, ByRef ls_barra As String) As String
        Dim Local As String = "00"
        Try
            Local = "01"
            Dim objAcessoDados As New UCLAcessoDados(StrConexao)
            Local = "02"
            Dim StrSql As String
            Local = "03"
            Dim dtBoleto As DataTable
            Local = "04"
            Dim dtItensNF As DataTable
            Local = "05"
            Dim caminhoLogoBanco As String
            Local = "06"
            Dim caminhoLogoBackground As String
            Local = "07"
            Dim CodFebraban As String
            Local = "08"
            Dim CodFebrabanCorrespondente As String
            Local = "08A"
            Dim CodCarteiraBanco As String
            Local = "09"
            Dim CodCarteiraBancoBoleto As String
            Local = "0A"
            Dim ls_moeda As String = "9"
            Local = "0B"
            Dim ld_vencimento As Date
            Local = "0C"
            Dim ld_vencimento_original As Date
            Local = "0D"
            Dim ls_nnumero As String
            Local = "0E"
            Dim ld_valor As Double
            Local = "0F"
            Dim ls_valor As String
            Local = "10"
            Dim ls_convenio As String
            Local = "11"
            Dim ls_fator As String
            Local = "12"
            Dim ll_emitente As Long
            Local = "13"
            Dim ls_agencia As String
            Local = "14"
            Dim ls_cedente_imp As String
            Local = "15"
            Dim ls_banco As String = ""
            Local = "16"
            Dim ls_cedente As String
            Local = "17"
            Dim ls_cc As String
            Local = "18"
            Dim ls_cc_dv As String
            Local = "19"
            Dim ls_especie As String = ""
            Local = "1A"
            Dim ll_cedente As Long
            Local = "1B"
            Dim is_cedente As String
            Local = "1C"
            Dim ls_documento As String = ""
            Local = "1D"
            Dim ls_campo_livre As String = ""
            Local = "1E"
            Dim ls_dac As String
            Local = "1F"
            Dim il_operacao As String
            Local = "20"
            Dim ls_digito As String
            Local = "21"
            Dim ls_campo1 As String
            Local = "22"
            Dim ls_campo2 As String
            Local = "23"
            Dim ls_campo3 As String
            Local = "24"
            Dim ls_campo4 As String
            Local = "25"
            Dim ls_campo5 As String
            Local = "26"
            Dim cod_nfs As String
            Local = "27"
            Dim ls_modelo_boleto As String
            Local = "28"
            Dim ls_descricaoitem() As String = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
            Local = "29"
            Dim ls_valoritem() As String = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
            Local = "2A"
            Dim ls_dv_nosso_numero As String = ""

            If String.IsNullOrEmpty(ConteudoHTML) Then
                Local = "2B"
                Return ""
            End If

            Local = "2C"

            StrSql = ""
            StrSql += "  SELECT b.cod_conta_corrente,"
            StrSql += "	 	    b.cod_carteira,"
            StrSql += "         t.data_vencimento,"
            StrSql += "         t.data_vencimento_original,"
            StrSql += "         i.valor_recebimento_bordero,"
            StrSql += "         i.cod_documento_recebimento_banco,"
            StrSql += "         i.cod_emitente,"
            StrSql += "         i.cnpj_cobranca,"
            StrSql += " 		t.data_emissao,"
            StrSql += "		    if trim(isnull(carteira.cod_conta_correspondente,'')) = '' then cc.cod_conta_corrente_banco else trim(isnull(carteira.cod_conta_correspondente,'')) endif cod_conta_corrente_banco,"
            StrSql += "		    if trim(isnull(carteira.dv_conta_correspondente,'')) = '' then cc.digito_conta_corrente else trim(isnull(carteira.dv_conta_correspondente,'')) endif digito_conta_corrente,"
            StrSql += "		    if trim(isnull(carteira.agencia_correspondente,'')) = '' then agencia.cod_agencia else trim(isnull(carteira.agencia_correspondente,'')) endif cod_agencia,"
            StrSql += "		    if trim(isnull(carteira.dv_agencia_correspondente,'')) = '' then agencia.digito_agencia else trim(isnull(carteira.dv_agencia_correspondente,'')) endif digito_agencia,"
            StrSql += "         '' agencia,"
            StrSql += "         '' cedente,"
            StrSql += "		    isnull(agencia.cnpj,'') as agencia_cnpj,"
            StrSql += "		    banco.cod_febrabam,"
            StrSql += "		    trim(isnull(carteira.banco_correspondente,'')) banco_correspondente,"
            StrSql += "		    if trim(isnull(carteira.cod_carteira_correspondente,'')) = '' then carteira.cod_carteira_banco else trim(isnull(carteira.cod_carteira_correspondente,'')) endif cod_carteira_banco,"
            StrSql += "		    carteira.cod_operacao_banco,"
            StrSql += "		    carteira.cod_cedente_banco,"
            StrSql += "         emitente.nome,"
            StrSql += "		    emitente.endereco || if isnull(emitente.numero,0) = 0 then '' else ' ' || emitente.numero endif as endereco,"
            StrSql += "		    emitente.cep emitente_cep,"
            StrSql += "		    emitente.bairro_nome emitente_bairro,"
            StrSql += "		    emitente.cidade_nome emitente_cidade,"
            StrSql += "		    emitente.estado_sigla,"
            StrSql += "		    est.razao_social,"
            StrSql += "		    isnull(cc.cedente,emp.razao_social) as cedente_nome,"
            StrSql += "         isnull(cc.cnpj_cedente,est.cnpj) as cnpj_cedente,"
            StrSql += "         carteira.cod_convenio,"
            StrSql += "         carteira.sacador_avalista,"
            StrSql += "         carteira.cnpj_sacador_avalista,"
            StrSql += "         carteira.endereco_sacador_avalista,"
            StrSql += "         isnull(carteira.beneficiario_agencia,'N') beneficiario_agencia,"
            StrSql += "         carteira.id_padrao,"
            StrSql += "         i.cnpj_cobranca,"
            StrSql += "         emitente.tp_pessoa,"
            StrSql += "         est.rua || ' ' || isnull(convert(varchar(10),est.numero),'') || ' ' || isnull(est.complemento,'') || ' - Bairro ' || isnull(est.bairro,'') endereco_empresa,"
            StrSql += "         est.cep cep_empresa,"
            StrSql += "         ce.nome_cidade nome_cidade_empresa,"
            StrSql += "         ufe.sigla sigla_uf_empresa,"
            StrSql += "         i.estabelecimento, "
            StrSql += "         carteira.id_impressao, "
            StrSql += "         t.cod_nfs, "
            StrSql += "         ( select isnull(isnull(cf.mensagem_boleto, g.mensagem_boleto),'') from cliente_financeiro cf inner join grupo_cliente_financeiro g on cf.cod_grupo = g.cod_grupo and cf.empresa = g.empresa where cf.cod_emitente = t.cod_emitente and cf.empresa = t.empresa ) mensagem_boleto, "
            StrSql += "         agencia.endereco endereco_agencia,"
            StrSql += "         agencia.bairro bairro_agencia,"
            StrSql += "         ciag.nome_cidade cidade_agencia,"
            StrSql += "         ufag.sigla uf_agencia,"
            StrSql += "         agencia.cep cep_agencia, "
            StrSql += "         isnull(carteira.cod_carteira_banco_boleto,'') cod_carteira_banco_boleto, "
            StrSql += "         if f_dia_util(isnull(i.data_calculo_juros_boleto,t.data_vencimento)) >= today() then 0 else datediff(day, isnull(i.data_calculo_juros_boleto,t.data_vencimento), today()) endif dias, "
            StrSql += "         ( select if isnull(cf.perc_juro_mensal_atraso,0) = 0 then isnull(g.perc_juro_mensal_atraso,0) else isnull(cf.perc_juro_mensal_atraso,0) endif from cliente_financeiro cf inner join grupo_cliente_financeiro g on cf.cod_grupo = g.cod_grupo and cf.empresa = g.empresa where cf.cod_emitente = t.cod_emitente and cf.empresa = t.empresa ) perc_juro,"
            StrSql += "         ( select if isnull(cf.perc_multa_atraso,0) = 0 then isnull(g.perc_multa_atraso,0) else isnull(cf.perc_multa_atraso,0) endif from cliente_financeiro cf inner join grupo_cliente_financeiro g on cf.cod_grupo = g.cod_grupo and cf.empresa = g.empresa where cf.cod_emitente = t.cod_emitente and cf.empresa = t.empresa ) perc_multa, "
            StrSql += "         round(if dias > 0 then (isnull(i.valor_recebimento_bordero,0) * isnull(dias,0) * isnull(perc_juro,0) / 100 / 30) + (isnull(i.valor_recebimento_bordero,0) * isnull(perc_multa,0) / 100 ) else 0 endif,2) valor_acrescimo "
            StrSql += "    FROM bordero_cr_item i inner join titulo_cr t on t.cod_cenario_ctbl	= i.cod_cenario_ctbl"
            StrSql += "	                                                and t.parcela			= i.parcela"
            StrSql += "	                                                and t.cod_tit_cr	    = i.cod_tit_cr"
            StrSql += "	                                                and t.serie				= i.serie"
            StrSql += "	                                                and t.cod_especie		= i.cod_especie"
            StrSql += "	                                                and t.estabelecimento	= i.estabelecimento"
            StrSql += "	                                                and t.empresa			= i.empresa"
            StrSql += "			                  inner join bordero_cr b on i.cod_bordero_cr	= b.cod_bordero_cr"
            StrSql += "                                                  and i.empresa			= b.empresa"
            StrSql += "                           inner join estabelecimento est on est.estabelecimento	= i.estabelecimento "
            StrSql += "	                                                        and est.empresa			= i.empresa "
            StrSql += "                           inner join empresa emp on emp.empresa			= i.empresa "
            StrSql += "                           left outer join conta_corrente_carteira_bancaria carteira on carteira.cod_carteira	    = b.cod_carteira"
            StrSql += "	  							   												       and carteira.cod_conta_corrente	= b.cod_conta_corrente"
            StrSql += "	  																			       and carteira.empresa				= b.empresa "
            StrSql += "		                      inner join conta_corrente cc on cc.cod_conta_corrente	 = b.cod_conta_corrente "
            StrSql += "	                                                      and cc.empresa			 = b.empresa"
            StrSql += "			                  inner join agencia on agencia.cod_agencia	 = cc.cod_agencia "
            StrSql += "	                                            and agencia.cod_banco	 = cc.cod_banco "
            StrSql += "			                  inner join banco on banco.cod_banco	 	 = agencia.cod_banco "
            StrSql += "                           inner join v_emitente_endereco emitente on emitente.cnpj			= i.cnpj_cobranca"
            StrSql += "	                                                                 and emitente.cod_emitente 	= i.cod_emitente"
            StrSql += "		                      inner join cidade ce on est.cod_pais = ce.cod_pais and est.cod_estado = ce.cod_estado and est.cod_cidade = ce.cod_cidade"
            StrSql += "                           inner join estado ufe on ufe.cod_pais = est.cod_pais and ufe.cod_estado = est.cod_estado"
            StrSql += "                           inner join estado ufag on ufag.cod_pais   = agencia.cod_pais"
            StrSql += "                                                 and ufag.cod_estado = agencia.cod_estado"
            StrSql += "                           inner join cidade ciag on ciag.cod_pais   = agencia.cod_pais"
            StrSql += "                                                 and ciag.cod_estado = agencia.cod_estado"
            StrSql += "                                                 and ciag.cod_cidade = agencia.cod_cidade"
            StrSql += "   WHERE i.cod_documento_recebimento_banco is not null"
            StrSql += "	    AND i.empresa          = " + pEmpresa
            StrSql += "     AND i.cod_bordero_cr   = " + pCodBorderoCr
            StrSql += "     AND i.cod_especie      = " + pCodEspecie
            StrSql += "     AND i.serie            = '" + pSerie + "'"
            StrSql += "     AND i.cod_tit_cr       = " + pCodTitCr
            StrSql += "     AND i.parcela          = " + pParcela
            StrSql += "     AND i.cod_cenario_ctbl = '" + pCodCenarioCtbl + "'"

            Local = "2D"

            dtBoleto = objAcessoDados.BuscarDados(StrSql)
            Local = "2E"
            If dtBoleto.Rows.Count = 0 Then
                Local = "2F"
                Return ""
            End If

            'Substitui tags pelos conteúdos
            Local = "30"
            CodFebraban = dtBoleto.Rows.Item(0).Item("cod_febrabam").ToString
            CodFebrabanCorrespondente = dtBoleto.Rows.Item(0).Item("banco_correspondente").ToString
            Local = "31"
            CodCarteiraBanco = dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString
            Local = "32"
            CodCarteiraBancoBoleto = dtBoleto.Rows.Item(0).Item("cod_carteira_banco_boleto").ToString
            Local = "33"

            ls_modelo_boleto = dtBoleto.Rows.Item(0).Item("id_impressao").ToString
            Local = "34"
            If ls_modelo_boleto = "0" Then
                Local = "35"
                ls_modelo_boleto = "1"
            End If

            Local = "36"
            cod_nfs = dtBoleto.Rows.Item(0).Item("cod_nfs").ToString
            Local = "37"
            is_cedente = dtBoleto.Rows.Item(0).Item("cedente_nome").ToString
            Local = "38"
            If Not IsDBNull(dtBoleto.Rows.Item(0).Item("cod_cedente_banco")) AndAlso IsNumeric(ll_cedente = dtBoleto.Rows.Item(0).Item("cod_cedente_banco").ToString) Then
                Local = "39"
                ll_cedente = dtBoleto.Rows.Item(0).Item("cod_cedente_banco").ToString
            Else
                Local = "3A"
                ll_cedente = 0
            End If
            If Not String.IsNullOrWhiteSpace(CodFebrabanCorrespondente) Then
                Local = "3B"
                caminhoLogoBanco = GetCaminhoLogoBanco(pEmpresa, CodFebrabanCorrespondente)
                Local = "3C"
                caminhoLogoBackground = GetCaminhoLogoBanco(pEmpresa, CodFebrabanCorrespondente)
            Else
                Local = "3B"
                caminhoLogoBanco = GetCaminhoLogoBanco(pEmpresa, CodFebraban)
                Local = "3C"
                caminhoLogoBackground = GetCaminhoLogoBanco(pEmpresa, CodFebraban)
            End If
            ld_vencimento = dtBoleto.Rows.Item(0).Item("data_vencimento")
            Local = "3E"
            ld_vencimento_original = dtBoleto.Rows.Item(0).Item("data_vencimento_original")
            Local = "3F"
            If ld_vencimento < Now.Date Then
                Local = "40"
                ld_vencimento = Now.Date
                While ld_vencimento.DayOfWeek = DayOfWeek.Saturday Or ld_vencimento.DayOfWeek = DayOfWeek.Sunday
                    ld_vencimento = ld_vencimento.AddDays(1)
                End While
            End If
            Local = "41"
            ls_nnumero = dtBoleto.Rows.Item(0).Item("cod_documento_recebimento_banco").ToString
            Local = "42"
            ld_valor = dtBoleto.Rows.Item(0).Item("valor_recebimento_bordero")
            Local = "43"
            ld_valor += dtBoleto.Rows.Item(0).Item("valor_acrescimo")
            Local = "44"
            ls_convenio = dtBoleto.Rows.Item(0).Item("cod_convenio").ToString
            Local = "45"
            ls_fator = DateDiff(DateInterval.Day, New Date(1997, 10, 7), ld_vencimento).ToString.PadLeftUnis(4, "0")
            Local = "46"
            ls_valor = (ld_valor * 100).ToString("F0").PadLeftUnis(10, "0")
            Local = "47"
            ll_emitente = dtBoleto.Rows.Item(0).Item("cod_emitente").ToString
            Local = "48"
            If Not IsDBNull(dtBoleto.Rows.Item(0).Item("cod_operacao_banco")) AndAlso IsNumeric(dtBoleto.Rows.Item(0).Item("cod_operacao_banco").ToString) Then
                Local = "49"
                il_operacao = dtBoleto.Rows.Item(0).Item("cod_operacao_banco").ToString
            Else
                Local = "4A"
                il_operacao = 0
            End If
            Local = "4B"
            If Trim(dtBoleto.Rows.Item(0).Item("digito_agencia").ToString) <> "" Then
                Local = "4C"
                ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString + "." + Trim(dtBoleto.Rows.Item(0).Item("digito_agencia").ToString)
            Else
                Local = "4D"
                ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString
            End If
            Local = "4E"
            ls_cc = dtBoleto.Rows.Item(0).Item("cod_conta_corrente_banco").ToString
            Local = "4F"
            ls_cc_dv = dtBoleto.Rows.Item(0).Item("digito_conta_corrente").ToString
            Local = "50"
            ls_cedente_imp = ls_cc + "." + ls_cc_dv
            Local = "51"
            Select Case CodFebraban
                Case "001", "085"
                    Local = "52"
                    If CodFebraban = "001" Then
                        Local = "53"
                        ls_banco = "BANCO DO BRASIL"
                    Else
                        Local = "54"
                        ls_banco = "CECRED"
                    End If
                    Local = "55"
                    ls_cedente = ls_cc
                    Local = "56"
                    ls_cc = ls_cc.PadLeftUnis(8, "0")
                    Local = "57"
                    ls_especie = "DM"
                    Local = "58"
                    If CLng(ls_convenio) <= 999999 Then
                        Local = "59"
                        ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString + "-" + Trim(dtBoleto.Rows.Item(0).Item("digito_agencia").ToString)
                        Local = "5A"
                        ls_cedente_imp = ls_cc + "-" + ls_cc_dv
                        Local = "5B"
                        If CodFebraban = "085" Then
                            Local = "5C"
                            ls_documento = ls_nnumero.Trim.PadLeftUnis(17, "0")
                            Local = "5D"
                            ls_campo_livre = ls_convenio.Trim.PadLeftUnis(6, "0")
                            Local = "5E"
                            ls_campo_livre += ls_documento
                            Local = "5F"
                            ls_campo_livre += CDbl(dtBoleto.Rows.Item(0).Item("cod_carteira_banco")).ToString.PadLeftUnis(2, "0")
                        Else
                            Local = "60"
                            If Len(ll_cedente.ToString) = 4 Then
                                Local = "61"
                                ls_documento = Mascarar(ls_nnumero, "####.######.#")
                            Else
                                Local = "62"
                                ls_documento = Mascarar(ls_nnumero, "######.#####-#")
                            End If
                            Local = "63"
                            ls_nnumero = ls_nnumero.Substring(0, 11)
                            Local = "64"
                            ls_campo_livre = CDbl(ls_nnumero).ToString.PadLeftUnis(11, "0")
                            Local = "65"
                            ls_campo_livre += CDbl(dtBoleto.Rows.Item(0).Item("cod_agencia")).ToString.PadLeftUnis(4, "0")
                            Local = "66"
                            ls_campo_livre += CDbl(ls_cc).ToString.PadLeftUnis(8, "0")
                            Local = "67"
                            ls_campo_livre += CDbl(dtBoleto.Rows.Item(0).Item("cod_carteira_banco")).ToString.PadLeftUnis(2, "0")
                        End If
                    Else
                        Local = "68"
                        ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString + "-" + Trim(dtBoleto.Rows.Item(0).Item("digito_agencia").ToString)
                        Local = "69"
                        ls_cedente_imp = ls_cc + "-" + ls_cc_dv
                        'deve ser da carteira 17 ou 18
                        If CodCarteiraBanco = "11" Then
                            Local = "6A"
                            ls_documento = ls_nnumero.PadRightUnis(17, "0") + "-" + of_modulo_11(ls_nnumero.PadRightUnis(17, "0")).ToString.PadLeftUnis(1, "0")
                        Else
                            Local = "6A1"
                            ls_documento = Mascarar(ls_nnumero, "##################")
                        End If
                        Local = "6B"
                        ls_campo_livre = "000000" + ls_nnumero + CDbl(dtBoleto.Rows.Item(0).Item("cod_carteira_banco")).ToString.PadLeftUnis(2, "0")
                    End If
                Case "027"
                    Local = "6C"
                    'Em desuso - BESC
                Case "033"
                    Local = "6D"
                    ls_banco = "Santander"
                    Local = "6E"
                    ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString
                    Local = "6F"
                    ls_documento = ls_nnumero
                    Local = "70"
                    ls_dac = of_dv2a1mod10(ls_nnumero + dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0") + ls_cc.ToString.PadLeftUnis(7, "0"))
                    Local = "71"
                    ls_cedente_imp = ll_cedente.ToString.PadLeftUnis(7, "0")
                    Local = "72"
                    ls_campo_livre = "9" + ll_cedente.ToString.PadLeftUnis(7, "0")
                    Local = "73"
                    ls_campo_livre += ls_nnumero.PadLeftUnis(13, "0")
                    Local = "74"
                    ls_campo_livre += "0" '/*IOS - Informar zero*/
                    Local = "75"
                    If CodCarteiraBancoBoleto.Trim <> "" Then
                        Local = "76"
                        ls_campo_livre += CodCarteiraBancoBoleto.PadLeftUnis(3, "0")
                    Else
                        Local = "77"
                        If CodCarteiraBanco.Substring(CodCarteiraBanco.Length - 1, 1) = "5" Then
                            Local = "78"
                            ls_campo_livre += "101"
                        Else
                            Local = "79"
                            ls_campo_livre += "102"
                        End If
                    End If
                Case "041"
                    Local = "7A"
                    ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0")
                    Local = "7B"
                    ls_cedente_imp = dtBoleto.Rows.Item(0).Item("cod_cedente_banco").ToString.PadLeftUnis(9, "0")
                    Local = "7C"
                    ll_cedente = CLng(dtBoleto.Rows.Item(0).Item("cod_cedente_banco").ToString.Substring(0, dtBoleto.Rows.Item(0).Item("cod_cedente_banco").ToString.Length - 2))
                    Local = "7D"
                    ls_banco = "Banrisul"
                    Local = "7E"
                    ls_documento = Mascarar(ls_nnumero, "###.###.###-##")
                    Local = "7F"
                    ls_campo_livre = "2"
                    Local = "80"
                    ls_campo_livre += "1"
                    Local = "81"
                    ls_campo_livre += ls_agencia.Substring(0, 4).PadLeftUnis(4, "0")
                    Local = "82"
                    ls_campo_livre += ll_cedente.ToString.PadLeftUnis(7, "0")
                    Local = "83"
                    ls_campo_livre += ls_nnumero.Substring(0, ls_nnumero.Length - 2)
                    Local = "84"
                    ls_campo_livre += "40"
                    Local = "85"
                    ls_campo_livre = of_dac_campo_livre(CodFebraban, ls_campo_livre)
                    Local = "86"
                Case "104"
                    Local = "87"
                    ls_nnumero = of_cobranca_escritural_dac(CodFebraban, dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString, is_cedente, ls_nnumero)
                    Local = "88"
                    ls_banco = "Caixa"
                    Local = "89"
                    ls_especie = "DM"
                    Local = "8A"
                    ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString
                    Local = "8B"
                    ls_cedente = ll_cedente.ToString.PadLeftUnis(8, "0")
                    Local = "8C"
                    If il_operacao <> Nothing AndAlso il_operacao > 0 Then
                        Local = "8D"
                        ls_documento = Mascarar(ls_nnumero, "##.########.#")
                        Local = "8E"
                        ls_cedente_imp = il_operacao.PadLeftUnis(3, "0") + "." + ls_cc + "-" + ls_cc_dv
                        Local = "8F"
                        ls_campo_livre = ls_nnumero.PadRightUnis(10, " ")
                        Local = "90"
                        ls_campo_livre += ls_agencia.PadLeftUnis(4, "0")
                        Local = "91"
                        ls_campo_livre += il_operacao.PadLeftUnis(3, "0")
                        Local = "92"
                        ls_campo_livre += ls_cedente
                        Local = "93"
                    Else
                        Local = "94"
                        ls_documento = Mascarar(ls_nnumero, "##################")
                        Local = "95"
                        ls_cedente_imp = ls_cc + "-" + ls_cc_dv
                        Local = "96"
                        ls_campo_livre = ls_cc + ls_cc_dv
                        Local = "97"
                        ls_campo_livre += Mid(ls_nnumero, 3, 3)
                        Local = "98"
                        ls_campo_livre += Mid(ls_nnumero, 1, 1)
                        Local = "99"
                        ls_campo_livre += Mid(ls_nnumero, 6, 3)
                        Local = "A0"
                        ls_campo_livre += Mid(ls_nnumero, 2, 1)
                        Local = "A1"
                        ls_campo_livre += Mid(ls_nnumero, 9, 9)
                        Local = "A2"
                        ls_campo_livre = ls_campo_livre + of_modulo_11(ls_campo_livre).ToString
                        Local = "A3"
                    End If

                Case "237"
                    Local = "A4"
                    ls_documento = dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString + "/" + Mascarar(ls_nnumero.PadLeftUnis(11, "0"), "##########-#")
                    Local = "A5"
                    ls_especie = "DM"
                    Local = "A6"
                    ls_banco = "Bradesco"
                    Local = "A7"
                    ls_campo_livre = ls_agencia.PadLeftUnis(4, "0")
                    Local = "A8"
                    ls_campo_livre += CDbl(CodCarteiraBanco).ToString.PadLeftUnis(2, "0")
                    Local = "A9"
                    ls_campo_livre += CDbl(ls_nnumero.Substring(0, Len(ls_nnumero) - 1)).ToString("00000000000")
                    Local = "B0"
                    ls_campo_livre += ls_cc.PadLeftUnis(7, "0")
                    Local = "B1"
                    ls_campo_livre += "0"
                    Local = "B2"
                Case "341"
                    Local = "B3"
                    ls_banco = "Banco Itaú SA"
                    Local = "B4"
                    ls_nnumero = ls_nnumero.PadLeftUnis(8, "0")
                    If CodCarteiraBanco = "112" Then
                        Local = "B5"
                        ls_documento = dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString + "/" + ls_nnumero.PadLeftUnis(8, "0") + "-" + of_modulo_10(CodCarteiraBanco.PadLeftUnis(3, "0") + ls_nnumero.PadLeftUnis(8, "0")).ToString.PadLeftUnis(1, "0")
                        ls_dac = of_modulo_10(CodCarteiraBanco.PadLeftUnis(3, "0") + ls_nnumero).ToString.PadLeftUnis(1, "0")
                    Else
                        Local = "B6"
                        ls_documento = dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString + "/" + ls_nnumero.PadLeftUnis(8, "0") + "-" + of_modulo_10(ls_agencia + ls_cc.PadLeftUnis(5, "0") + dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString.PadLeftUnis(3, "0") + ls_nnumero.PadLeftUnis(8, "0")).ToString.PadLeftUnis(1, "0")
                        ls_dac = of_modulo_10(dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0") + ls_cc.PadLeftUnis(5, "0") + CodCarteiraBanco.PadLeftUnis(3, "0") + ls_nnumero).ToString.PadLeftUnis(1, "0")
                    End If
                    Local = "B7"
                    ls_cedente_imp = ls_cc + "-" + ls_cc_dv
                    Local = "B8"
                    ls_campo_livre = CodCarteiraBanco.ToString.PadLeftUnis(3, "0")
                    Local = "B9"
                    ls_campo_livre += ls_nnumero
                    Local = "C0"
                    ls_campo_livre += ls_dac
                    Local = "C1"
                    ls_campo_livre += dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0")
                    Local = "C2"
                    ls_campo_livre += ls_cc.ToString.PadLeftUnis(5, "0")
                    Local = "C3"
                    ls_campo_livre += ls_cc_dv.ToString.PadLeftUnis(1, "0")
                    Local = "C4"
                    ls_campo_livre += "000"
                    Local = "C5"
                Case "347"
                    Local = "C6"
                    ls_banco = "Sudameris"
                    Local = "C7"
                    ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString
                    Local = "C8"
                    ls_documento = ls_nnumero
                    Local = "C9"
                    ls_dac = of_dv2a1mod10(ls_nnumero + ls_agencia.PadLeftUnis(4, "0") + ls_cc.PadLeftUnis(7, "0"))
                    Local = "D0"
                    ls_cedente_imp = ls_cc + "." + ls_dac
                    Local = "D1"
                    ls_campo_livre = ls_agencia.PadLeftUnis(4, "0")
                    Local = "D2"
                    ls_campo_livre += ls_cc.PadLeftUnis(7, "0")
                    Local = "D3"
                    ls_campo_livre += ls_dac.PadLeftUnis(1, "0")
                    Local = "D4"
                    ls_campo_livre += ls_nnumero.PadLeftUnis(13, "0")
                    Local = "D5"
                Case "356"
                    Local = "D6"
                    ls_banco = "Real"
                    Local = "D7"
                    ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString
                    Local = "D8"
                    ls_documento = ls_nnumero
                    Local = "D9"
                    ls_dac = of_dv2a1mod10(ls_nnumero + ls_agencia.PadLeftUnis(4, "0") + ls_cc.ToString.PadLeftUnis(7, "0"))
                    Local = "E0"
                    ls_cedente_imp = ls_cc + "." + ls_dac
                    Local = "E1"
                    ls_campo_livre = ls_agencia.PadLeftUnis(4, "0")
                    Local = "E2"
                    ls_campo_livre += ls_cc.PadLeftUnis(7, "0")
                    Local = "E3"
                    ls_campo_livre += ls_dac.PadLeftUnis(1, "0")
                    Local = "E4"
                    ls_campo_livre += ls_nnumero.PadLeftUnis(13, "0")
                    Local = "E5"
                Case "399"
                    Local = "E6"
                    ls_banco = "HSBC"
                    Local = "E7"
                    ls_especie = "PD"
                    Local = "E8"
                    ls_nnumero = ls_nnumero.PadLeftUnis(10, "0")
                    Local = "E9"
                    ls_documento = Mascarar(ls_nnumero.PadLeftUnis(11, "0"), "#####.#####-#")
                    Local = "F0"
                    ls_cedente_imp = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0") + "."
                    Local = "F1"
                    ls_cedente_imp += Trim(dtBoleto.Rows.Item(0).Item("digito_agencia").ToString)
                    Local = "F2"
                    ls_cedente_imp += ls_cc.PadLeftUnis(5, "0")
                    Local = "F3"
                    ls_cedente_imp += ls_cc_dv.PadLeftUnis(2, "0")
                    Local = "F4"
                    ls_campo_livre = ls_nnumero
                    Local = "F5"
                    ls_campo_livre += dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0")
                    Local = "F6"
                    ls_campo_livre += ls_cc.PadLeftUnis(5, "0")
                    Local = "F7"
                    ls_campo_livre += ls_cc_dv.PadLeftUnis(2, "0")
                    Local = "F8"
                    ls_campo_livre += "001"
                    Local = "F9"
                Case "422"
                    Local = "G0"
                    If CodFebrabanCorrespondente = "237" Then
                        Local = "G1"
                        ls_banco = "BRADESCO"
                        Local = "G2"
                        ls_especie = "DM"
                        Local = "G3"
                        ls_nnumero = Now().ToString("yy") + CDbl(ls_nnumero).ToString.PadLeftUnis(9, "0")
                        Local = "G4"
                        ls_dv_nosso_numero = (of_modulo_11(Strings.Right("00" + CodCarteiraBanco, 2) + ls_nnumero)).ToString
                        Local = "G5"
                        ls_documento = Strings.Right("00" + CodCarteiraBanco, 2) + "/ " + CDbl(ls_nnumero).ToString("00\ 000000000") + " " + ls_dv_nosso_numero
                        Local = "G6"
                        ls_cedente_imp = ls_cc + "-" + ls_cc_dv
                        Local = "G7"
                        ls_dac = (of_modulo_10(ls_agencia.PadLeftUnis(4, "0") + ls_cc.PadLeftUnis(5, "0") + CodCarteiraBanco.PadLeftUnis(3, "0") + ls_nnumero)).ToString
                        Local = "G8"
                        ls_campo_livre = ls_agencia.PadLeftUnis(4, "0")
                        Local = "G9"
                        ls_campo_livre += Strings.Right("00" + CodCarteiraBanco, 2)
                        Local = "G0"
                        ls_campo_livre += ls_nnumero
                        Local = "GA"
                        ls_campo_livre += ls_cc.PadLeftUnis(7, "0")
                        Local = "GB"
                        ls_campo_livre += "0"
                        Local = "GC"
                    Else
                        Local = "GD"
                        ls_cedente_imp = ls_cc.PadLeftUnis(8, "0") + "-" + ls_cc_dv
                        Local = "GE"
                        ls_banco = "BANCO SAFRA S/A"
                        Local = "GF"
                        ls_especie = "DM"
                        Local = "H0"
                        ls_nnumero = CDbl(ls_nnumero).ToString.PadLeftUnis(9, "0")
                        Local = "H1"
                        ls_documento = Strings.Right("00" + CodCarteiraBanco, 2) + "/ " + CDbl(ls_nnumero).ToString("00000000\-0")
                        Local = "H2"
                        ls_campo_livre = "7" + ls_agencia.PadLeftUnis(5, "0")
                        Local = "H3"
                        ls_campo_livre += ls_cc.PadLeftUnis(9, "0")
                        Local = "H4"
                        ls_campo_livre += ls_nnumero
                        Local = "H5"
                        ls_campo_livre += "2"
                        Local = "H6"
                    End If
                Case "707"
                    Local = "100"
                    ls_banco = "Banco Daycoval"
                    Local = "101"
                    ls_nnumero = ls_nnumero.PadLeftUnis(8, "0")
                    Local = "102"
                    ls_documento = dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString + "/" + ls_nnumero.PadLeftUnis(8, "0") + "-" + of_modulo_10(dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0") + ls_cc.PadLeftUnis(5, "0") + dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString.PadLeftUnis(3, "0") + ls_nnumero.PadLeftUnis(8, "0")).ToString.PadLeftUnis(1, "0")
                    Local = "103"
                    ls_cedente_imp = ls_cc + "-" + ls_cc_dv
                    Local = "104"
                    ls_dac = of_modulo_10(dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0") + ls_cc.PadLeftUnis(5, "0") + dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString.PadLeftUnis(3, "0") + ls_nnumero).ToString.PadLeftUnis(1, "0")
                    Local = "105"
                    ls_campo_livre = dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString.PadLeftUnis(3, "0")
                    Local = "106"
                    ls_campo_livre += ls_nnumero
                    Local = "107"
                    ls_campo_livre += ls_dac
                    Local = "108"
                    ls_campo_livre += dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeftUnis(4, "0")
                    Local = "109"
                    ls_campo_livre += ls_cc.PadLeftUnis(5, "0")
                    Local = "10A"
                    ls_campo_livre += ls_cc - ls_cc_dv.PadLeftUnis(1, "0")
                    Local = "10B"
                    ls_campo_livre += "000"
                    Local = "10C"
                Case "756"
                    ls_banco = ""
                    ls_nnumero = ls_nnumero.PadLeftUnis(8, "0")
                    ls_documento = ls_nnumero
                    ls_cedente_imp = ls_cc + "-" + ls_cc_dv
                    ls_especie = "DM"
                    ls_agencia = dtBoleto.Rows.Item(0).Item("cod_agencia").ToString.PadLeft(4, "0")

                    ls_campo_livre = "1"
                    ls_campo_livre += ls_agencia
                    ls_campo_livre += il_operacao.ToString.PadLeft(2, "0")
                    ls_campo_livre += ll_cedente.ToString.PadLeft(7, "0")
                    ls_campo_livre += ls_nnumero
                    ls_campo_livre += "001"
            End Select
            Local = "10D"
            If ls_documento Is Nothing OrElse String.IsNullOrEmpty(ls_documento) OrElse ls_documento.Trim = "" Then
                Local = "10E"
                If CodFebraban = "001" Then
                    Local = "10F"
                    ls_documento = dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString + "/" + ls_nnumero + ls_dac
                Else
                    Local = "110"
                    ls_documento = dtBoleto.Rows.Item(0).Item("cod_carteira_banco").ToString + "/" + ls_nnumero + "." + ls_dac
                End If
            End If
            Local = "111"
            If Not String.IsNullOrWhiteSpace(CodFebrabanCorrespondente) Then
                ls_digito = uf_dv2of9mod11(CodFebrabanCorrespondente + ls_moeda + ls_fator + ls_valor + ls_campo_livre)
                Local = "112A"
                ls_barra = CodFebrabanCorrespondente + ls_moeda + ls_digito + ls_fator + ls_valor + ls_campo_livre
                Local = "113A"
            Else
                ls_digito = uf_dv2of9mod11(CodFebraban + ls_moeda + ls_fator + ls_valor + ls_campo_livre)
                Local = "112B"
                ls_barra = CodFebraban + ls_moeda + ls_digito + ls_fator + ls_valor + ls_campo_livre
                Local = "113B"
            End If
            
            If CodFebraban = "027" Then
                Local = "114"
                ls_campo1 = CodFebraban + ls_moeda + ls_campo_livre.Substring(0, 5) + of_dv2a1mod10(CodFebraban + ls_moeda + ls_campo_livre.Substring(0, 5))
                Local = "115"
                ls_campo2 = ls_campo_livre.Substring(5, 10) + of_dv2a1mod10(ls_campo_livre.Substring(5, 10))
                Local = "116"
                ls_campo3 = ls_campo_livre.Substring(15, 10) + of_dv2a1mod10(ls_campo_livre.Substring(15, 10))
            Else
                If Not String.IsNullOrWhiteSpace(CodFebrabanCorrespondente) Then
                    Local = "117A"
                    ls_campo1 = CodFebrabanCorrespondente + ls_moeda + ls_campo_livre.Substring(0, 5) + of_modulo_10(CodFebrabanCorrespondente + ls_moeda + ls_campo_livre.Substring(0, 5))
                    Local = "118A"
                Else
                    Local = "117B"
                    ls_campo1 = CodFebraban + ls_moeda + ls_campo_livre.Substring(0, 5) + of_modulo_10(CodFebraban + ls_moeda + ls_campo_livre.Substring(0, 5))
                    Local = "118B"
                End If
                ls_campo2 = ls_campo_livre.Substring(5, 10) + of_modulo_10(ls_campo_livre.Substring(5, 10))
                Local = "119"
                ls_campo3 = ls_campo_livre.Substring(15, 10) + of_modulo_10(ls_campo_livre.Substring(15, 10))
            End If
            Local = "11A"
            ls_campo4 = ls_digito
            Local = "11B"
            ls_campo5 = ls_fator + ls_valor
            Local = "11C"
            StrSql = ""
            StrSql += "select i.descricao, ni.valor_total"
            StrSql += "  from nfs_item ni inner join item i on ni.cod_item = i.cod_item"
            StrSql += " where ni.empresa         = " + pEmpresa
            StrSql += "   and ni.estabelecimento = " + dtBoleto.Rows.Item(0).Item("estabelecimento").ToString
            StrSql += "   and ni.serie           = '" + pSerie + "'"
            StrSql += "   and ni.cod_nfs         = " + IIf(String.IsNullOrEmpty(cod_nfs), "0", cod_nfs)
            Local = "11D"
            dtItensNF = objAcessoDados.BuscarDados(StrSql)
            Local = "11E"
            If dtBoleto.Rows.Item(0).Item("valor_acrescimo") > 0 Then
                Local = "11F"
                Dim nr As DataRow = dtItensNF.NewRow
                Local = "120"
                nr.Item("descricao") = "Juros " + CDbl(dtBoleto.Rows.Item(0).Item("perc_juro")).ToString("F1") + "%a.m. +Multa " + CDbl(dtBoleto.Rows.Item(0).Item("perc_multa")).ToString("F1") + "% (Vencto Orig. " + ld_vencimento_original.ToString("dd/MM/yy") + ")"
                Local = "121"
                nr.Item("valor_total") = dtBoleto.Rows.Item(0).Item("valor_acrescimo")
                Local = "122"
                dtItensNF.Rows.InsertAt(nr, 0)
                Local = "123"
            End If
            Local = "124"
            For i As Long = 0 To dtItensNF.Rows.Count - 1
                Local = "125"
                If i <= 17 Then
                    Local = "126"
                    ls_descricaoitem(i) = " - " + dtItensNF.Rows.Item(i).Item("descricao").ToString
                    Local = "127"
                    ls_valoritem(i) = "R$" + CDbl(dtItensNF.Rows.Item(i).Item("valor_total")).ToString("F2")
                    Local = "128"
                End If
            Next
            If Not String.IsNullOrWhiteSpace(CodFebrabanCorrespondente) Then
                CodFebraban = CodFebrabanCorrespondente
            End If
            Local = "129"
            ConteudoHTML = ConteudoHTML.Replace("#arquivo_imagem_logo#", caminhoLogoBanco)
            Local = "12A"
            ConteudoHTML = ConteudoHTML.Replace("#aceite#", IIf(CodFebraban = "237" OrElse CodFebraban = "756", "N", "Não"))
            Local = "12B"
            ConteudoHTML = ConteudoHTML.Replace("#agencia#", ls_agencia)
            Local = "12C"
            ConteudoHTML = ConteudoHTML.Replace("#bairrosacado#", dtBoleto.Rows.Item(0).Item("emitente_bairro").ToString)
            Local = "12D"
            ConteudoHTML = ConteudoHTML.Replace("#bordero#", pCodBorderoCr)
            Local = "12E"
            ConteudoHTML = ConteudoHTML.Replace("#carteira#", IIf(CodFebraban = "033", IIf(CodCarteiraBanco = "5", "COB. SIMPLES ECR", "COB. SIMPLES CSR"), IIf(CodFebraban = "341" OrElse CodFebraban = "237", Mascarar(CodCarteiraBanco, "###"), IIf(CodFebraban = "001", CodCarteiraBanco + "/" + dtBoleto.Rows.Item(0).Item("cod_operacao_banco").ToString.PadLeftUnis(3, "0"), If(CodFebraban = "104", IIf(CodCarteiraBanco = "12", "CR", "CS"), CodCarteiraBanco)))))
            Local = "12F"
            If dtBoleto.Rows.Item(0).Item("beneficiario_agencia").ToString = "S" Then
                Local = "130"
                ConteudoHTML = ConteudoHTML.Replace("#enderecocedente#", dtBoleto.Rows.Item(0).Item("endereco_agencia").ToString)
                Local = "131"
                ConteudoHTML = ConteudoHTML.Replace("#cidadeempresa#", dtBoleto.Rows.Item(0).Item("cidade_agencia").ToString)
                Local = "132"
                ConteudoHTML = ConteudoHTML.Replace("#ufempresa#", dtBoleto.Rows.Item(0).Item("uf_agencia").ToString)
                Local = "133"
                ConteudoHTML = ConteudoHTML.Replace("#cepcedente#", dtBoleto.Rows.Item(0).Item("cep_agencia").ToString)
            Else
                Local = "134"
                ConteudoHTML = ConteudoHTML.Replace("#enderecocedente#", dtBoleto.Rows.Item(0).Item("endereco_empresa").ToString)
                Local = "135"
                ConteudoHTML = ConteudoHTML.Replace("#cidadeempresa#", dtBoleto.Rows.Item(0).Item("nome_cidade_empresa").ToString)
                Local = "136"
                ConteudoHTML = ConteudoHTML.Replace("#ufempresa#", dtBoleto.Rows.Item(0).Item("sigla_uf_empresa").ToString)
                Local = "137"
                ConteudoHTML = ConteudoHTML.Replace("#cepcedente#", dtBoleto.Rows.Item(0).Item("cep_empresa").ToString)
            End If
            Local = "138"
            ConteudoHTML = ConteudoHTML.Replace("#cepsacado#", dtBoleto.Rows.Item(0).Item("emitente_cep").ToString)
            Local = "139"
            ConteudoHTML = ConteudoHTML.Replace("#cidadesacado#", dtBoleto.Rows.Item(0).Item("emitente_cidade").ToString)
            Local = "13A"
            ConteudoHTML = ConteudoHTML.Replace("#cnpjcedente#", dtBoleto.Rows.Item(0).Item("cnpj_cedente").ToString.MascaraCNPJ)
            Local = "13B"
            ConteudoHTML = ConteudoHTML.Replace("#cnpjsacado#", IIf(dtBoleto.Rows.Item(0).Item("tp_pessoa").ToString = "PJ", dtBoleto.Rows.Item(0).Item("cnpj_cobranca").ToString.MascaraCNPJ, dtBoleto.Rows.Item(0).Item("cnpj_cobranca").ToString.MascaraCPF))
            Local = "13C"
            If Not IsDBNull(dtBoleto.Rows.Item(0).Item("cnpj_sacador_avalista")) Then
                Local = "13D"
                ConteudoHTML = ConteudoHTML.Replace("#cnpjsacadoravalista#", dtBoleto.Rows.Item(0).Item("cnpj_sacador_avalista").ToString.MascaraCNPJ)
            Else
                Local = "13E"
                ConteudoHTML = ConteudoHTML.Replace("#cnpjsacadoravalista#", "")
            End If
            Local = "13F"
            If Not IsDBNull(dtBoleto.Rows.Item(0).Item("endereco_sacador_avalista")) Then
                Local = "140"
                ConteudoHTML = ConteudoHTML.Replace("#enderecosacadoravalista#", dtBoleto.Rows.Item(0).Item("endereco_sacador_avalista").ToString.Trim)
            Else
                Local = "141"
                ConteudoHTML = ConteudoHTML.Replace("#enderecosacadoravalista#", "")
            End If
            Local = "142"
            ConteudoHTML = ConteudoHTML.Replace("#codigobarras#", "")
            Local = "143"
            ConteudoHTML = ConteudoHTML.Replace("#codigocedente#", ls_cedente_imp)
            Local = "144"
            If ls_modelo_boleto = "1" Or ls_modelo_boleto = "3" Then
                Local = "145"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem1#", ls_descricaoitem(0))
                Local = "146"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem2#", ls_descricaoitem(1))
                Local = "147"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem3#", ls_descricaoitem(2))
                Local = "148"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem4#", ls_descricaoitem(3))
                Local = "149"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem5#", ls_descricaoitem(4))
                Local = "14A"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem6#", ls_descricaoitem(5))
                Local = "14B"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem7#", ls_descricaoitem(6))
                Local = "14C"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem8#", ls_descricaoitem(7))
                Local = "14D"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem9#", ls_descricaoitem(8))
                Local = "14E"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem10#", ls_descricaoitem(9))
                Local = "150"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem11#", ls_descricaoitem(10))
                Local = "151"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem12#", ls_descricaoitem(11))
                Local = "152"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem13#", ls_descricaoitem(12))
                Local = "153"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem14#", ls_descricaoitem(13))
                Local = "154"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem15#", ls_descricaoitem(14))
                Local = "155"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem16#", ls_descricaoitem(15))
                Local = "156"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem17#", ls_descricaoitem(16))
                Local = "157"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem18#", ls_descricaoitem(17))
            Else
                Local = "158"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem1#", "")
                Local = "159"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem2#", "")
                Local = "15A"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem3#", "")
                Local = "15B"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem4#", "")
                Local = "15C"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem5#", "")
                Local = "15D"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem6#", "")
                Local = "15E"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem7#", "")
                Local = "160"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem8#", "")
                Local = "161"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem9#", "")
                Local = "162"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem10#", "")
                Local = "163"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem11#", "")
                Local = "164"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem12#", "")
                Local = "167"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem13#", "")
                Local = "168"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem14#", "")
                Local = "169"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem15#", "")
                Local = "16A"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem16#", "")
                Local = "16B"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem17#", "")
                Local = "16C"
                ConteudoHTML = ConteudoHTML.Replace("#descricaoitem18#", "")
                Local = "16D"
            End If
            Local = "170"
            ConteudoHTML = ConteudoHTML.Replace("#documento#", IIf(CodFebraban = "001" And CodCarteiraBanco = "17", pSerie.PadLeftUnis(2, "0") + pCodTitCr.PadLeftUnis(6, "0") + pParcela.PadLeftUnis(2, "0"), IIf(CodFebraban = "341" Or CodFebraban = "707", pCodTitCr.PadLeftUnis(8, "0") + pParcela.PadLeftUnis(2, "0"), IIf(CodFebraban = "237" And dtBoleto.Rows.Item(0).Item("id_padrao").ToString = 2, pCodTitCr, pCodBorderoCr + "." + pSerie + "." + pCodTitCr + "." + pParcela))))
            Local = "171"
            ConteudoHTML = ConteudoHTML.Replace("#emissao#", CDate(dtBoleto.Rows.Item(0).Item("data_emissao")).ToString("dd/MM/yyyy"))
            Local = "172"
            ConteudoHTML = ConteudoHTML.Replace("#enderecosacado#", dtBoleto.Rows.Item(0).Item("endereco").ToString)
            Local = "173"
            ConteudoHTML = ConteudoHTML.Replace("#especie#", IIf(CodFebraban = "237" OrElse CodFebraban = "756", "R$", "REAL"))
            Local = "174"
            ConteudoHTML = ConteudoHTML.Replace("#especiedoc#", ls_especie)
            Local = "175"
            ConteudoHTML = ConteudoHTML.Replace("#febraban#", " |" + CodFebraban + IIf(CLng(CodFebraban) = 1, "-9", IIf(CLng(CodFebraban) = 27, "-2", IIf(CLng(CodFebraban) = 41, "-8", IIf(CLng(CodFebraban) = 237, "-2", IIf(CLng(CodFebraban) = 33 Or CLng(CodFebraban) = 341, "-7", IIf(CLng(CodFebraban) = 347, "-6", IIf(CLng(CodFebraban) = 104 OrElse CLng(CodFebraban) = 756, "-0", ""))))))) + "|")
            Local = "176"
            ConteudoHTML = ConteudoHTML.Replace("#instrucao1#", of_mensagem_boleto(pEmpresa, dtBoleto.Rows.Item(0).Item("estabelecimento").ToString, pCodBorderoCr, pCodEspecie, pSerie, pCodTitCr, pParcela, pCodCenarioCtbl, 1))
            Local = "177"
            ConteudoHTML = ConteudoHTML.Replace("#instrucao2#", of_mensagem_boleto(pEmpresa, dtBoleto.Rows.Item(0).Item("estabelecimento").ToString, pCodBorderoCr, pCodEspecie, pSerie, pCodTitCr, pParcela, pCodCenarioCtbl, 2))
            Local = "178"
            ConteudoHTML = ConteudoHTML.Replace("#instrucao3#", of_mensagem_boleto(pEmpresa, dtBoleto.Rows.Item(0).Item("estabelecimento").ToString, pCodBorderoCr, pCodEspecie, pSerie, pCodTitCr, pParcela, pCodCenarioCtbl, 3))
            Local = "179"
            ConteudoHTML = ConteudoHTML.Replace("#instrucao4#", of_mensagem_boleto(pEmpresa, dtBoleto.Rows.Item(0).Item("estabelecimento").ToString, pCodBorderoCr, pCodEspecie, pSerie, pCodTitCr, pParcela, pCodCenarioCtbl, 4))
            Local = "17A"
            ConteudoHTML = ConteudoHTML.Replace("#mensagemboleto#", dtBoleto.Rows.Item(0).Item("mensagem_boleto").ToString)
            Local = "17B"
            ConteudoHTML = ConteudoHTML.Replace("#linhadigitavel#", Mascarar((ls_campo1 + ls_campo2 + ls_campo3 + ls_campo4 + ls_campo5).Replace(".", ""), "#####.#####  #####.######  #####.######  #  ##############"))
            Local = "17C"
            ConteudoHTML = ConteudoHTML.Replace("#localpagamento#", IIf(CodFebraban = "033", "Pagar preferencialmente no banco Santander", IIf(CodFebraban = "341", "Até o vencimento, preferencialmente no Itaú. Após o vecimento, somente no Itaú.", IIf(CodFebraban = "237", "Pagável preferencialmente na Rede Bradesco ou Bradesco Expresso.", IIf(CodFebraban = "104", "Pagamento em qualquer agência bancária ou lotéricas até o vencimento, após somente na " + ls_banco, IIf(CLng(CodFebraban) = 1 OrElse CLng(CodFebraban) = 756, "PAGÁVEL EM QUALQUER BANCO ATÉ O VENCIMENTO", "Pagável preferencialmente nas agências do " + ls_banco))))))
            Local = "17D"
            If CodFebraban = "756" Then
                ConteudoHTML = ConteudoHTML.Replace("<img src=""#logo_banco#"" style=""width: 38px; height: 38px"" />", "<img src=""#logo_banco#"" style=""width: 176px; height: 38px"" />")
            End If
            ConteudoHTML = ConteudoHTML.Replace("#logo_banco#", caminhoLogoBanco)
            Local = "17E"
            ConteudoHTML = ConteudoHTML.Replace("#background#", caminhoLogoBackground)
            Local = "17F"
            ConteudoHTML = ConteudoHTML.Replace("#nome_banco#", ls_banco)
            Local = "180"
            ConteudoHTML = ConteudoHTML.Replace("#nomecedente#", is_cedente)
            Local = "181"
            ConteudoHTML = ConteudoHTML.Replace("#nomesacado#", dtBoleto.Rows.Item(0).Item("nome").ToString)
            Local = "182"
            ConteudoHTML = ConteudoHTML.Replace("#nossonumero#", ls_documento)
            Local = "183"
            ConteudoHTML = ConteudoHTML.Replace("#parcela#", pParcela)
            Local = "184"
            ConteudoHTML = ConteudoHTML.Replace("#processamento#", CDate(dtBoleto.Rows.Item(0).Item("data_emissao")).ToString("dd/MM/yyyy"))
            Local = "185"
            If ls_modelo_boleto = "1" OrElse ls_modelo_boleto = "2" Then
                Local = "186"
                ConteudoHTML = ConteudoHTML.Replace("#referentea#", CDate(dtBoleto.Rows.Item(0).Item("data_emissao")).ToString("MM/yyyy"))
                Local = "187"
                ConteudoHTML = ConteudoHTML.Replace("#reftext#", "Referente a:")
            Else
                Local = "188"
                ConteudoHTML = ConteudoHTML.Replace("#referentea#", "")
                Local = "189"
                ConteudoHTML = ConteudoHTML.Replace("#reftext#", "")
            End If
            Local = "18A"
            ConteudoHTML = ConteudoHTML.Replace("#sacadoravalista#", dtBoleto.Rows.Item(0).Item("sacador_avalista").ToString)
            Local = "18B"
            ConteudoHTML = ConteudoHTML.Replace("#serie#", pSerie)
            Local = "18C"
            ConteudoHTML = ConteudoHTML.Replace("#titulo#", pCodTitCr)
            Local = "18D"
            ConteudoHTML = ConteudoHTML.Replace("#ufsacado#", dtBoleto.Rows.Item(0).Item("estado_sigla").ToString)
            Local = "18E"
            ConteudoHTML = ConteudoHTML.Replace("#valor#", ld_valor.ToString("F2"))
            Local = "18F"
            If ls_modelo_boleto = "1" Or ls_modelo_boleto = "3" Then
                Local = "190"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem1#", ls_valoritem(0))
                Local = "191"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem2#", ls_valoritem(1))
                Local = "192"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem3#", ls_valoritem(2))
                Local = "193"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem4#", ls_valoritem(3))
                Local = "194"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem5#", ls_valoritem(4))
                Local = "195"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem6#", ls_valoritem(5))
                Local = "196"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem7#", ls_valoritem(6))
                Local = "197"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem8#", ls_valoritem(7))
                Local = "198"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem9#", ls_valoritem(8))
                Local = "199"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem10#", ls_valoritem(9))
                Local = "19A"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem11#", ls_valoritem(10))
                Local = "19B"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem12#", ls_valoritem(11))
                Local = "19C"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem13#", ls_valoritem(12))
                Local = "19D"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem14#", ls_valoritem(13))
                Local = "19E"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem15#", ls_valoritem(14))
                Local = "19F"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem16#", ls_valoritem(15))
                Local = "1A0"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem17#", ls_valoritem(16))
                Local = "1A1"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem18#", ls_valoritem(17))
                Local = "1A2"
            Else
                Local = "1A3"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem1#", "")
                Local = "1A4"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem2#", "")
                Local = "1A5"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem3#", "")
                Local = "1A6"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem4#", "")
                Local = "1A7"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem5#", "")
                Local = "1A8"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem6#", "")
                Local = "1A9"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem7#", "")
                Local = "1B0"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem8#", "")
                Local = "1B1"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem9#", "")
                Local = "1B2"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem10#", "")
                Local = "1B3"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem11#", "")
                Local = "1B4"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem12#", "")
                Local = "1B5"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem13#", "")
                Local = "1B6"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem14#", "")
                Local = "1B7"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem15#", "")
                Local = "1B8"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem16#", "")
                Local = "1B9"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem17#", "")
                Local = "1C0"
                ConteudoHTML = ConteudoHTML.Replace("#valoritem18#", "")
            End If
            Local = "1C1"
            ConteudoHTML = ConteudoHTML.Replace("#vencimento#", CDate(ld_vencimento).ToString("dd/MM/yyyy"))
            Local = "1C2"
            Return ConteudoHTML
        Catch ex As Exception
            Throw New Exception("[" + Local + "] " + ex.ToString)
        End Try
    End Function

    Public Sub GeraArquivoPDF(ByVal pEmpresa As String, ByVal htmlString As String, ByVal CaminhoArquivoPDF As String, ByVal ls_barra As String)
        Try
            Dim pdf As New PdfMetamorphosis()

            If File.Exists(CaminhoArquivoPDF) Then
                File.Delete(CaminhoArquivoPDF)
            End If

            pdf.Serial = "10042729429"
            pdf.PageStyle.PageNumFormat = ""
            pdf.PageStyle.PageSize.A4()
            pdf.PageStyle.PageOrientation.Portrait()
            pdf.HtmlOptions.BaseUrl = GetDiretorioBoletoPDF(pEmpresa).Substring(0, GetDiretorioBoletoPDF(pEmpresa).Length - 2)
            pdf.HtmlToPdfConvertStringToFile(htmlString, CaminhoArquivoPDF)

            Call ColocarBarrasNoPDF(CaminhoArquivoPDF, ls_barra)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ColocarBarrasNoPDF(ByVal CaminhoArquivoPDF As String, ByVal ls_barra As String) As Boolean
        Try
            Dim oldFile As String = CaminhoArquivoPDF
            Dim newFile As String = CaminhoArquivoPDF + ".tmp"

            ' open the reader
            Dim reader As New PdfReader(oldFile)
            Dim size As Rectangle = reader.GetPageSizeWithRotation(1)
            Dim document As New Document(size)

            ' open the writer
            Dim fs As New FileStream(newFile, FileMode.Create, FileAccess.Write)
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, fs)
            document.Open()

            ' the pdf content
            Dim cb As PdfContentByte = writer.DirectContent

            ' image
            Dim code As New BarcodeInter25()
            Dim img As iTextSharp.text.Image

            code.Code = ls_barra
            img = code.CreateImageWithBarcode(cb, New iTextSharp.text.BaseColor(0, 0, 0), New iTextSharp.text.BaseColor(255, 255, 255))
            img.SetAbsolutePosition(40, 10)
            cb.AddImage(img)

            ' create the new page and add it to the pdf
            Dim page As PdfImportedPage = writer.GetImportedPage(reader, 1)
            cb.AddTemplate(page, 0, 0)

            ' close the streams and voilá the file should be changed :)
            document.Close()
            fs.Close()
            writer.Close()
            reader.Close()

            If File.Exists(oldFile) Then
                File.Delete(oldFile)
            End If

            File.Copy(newFile, oldFile)

            If File.Exists(newFile) Then
                File.Delete(newFile)
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function of_modulo_10(ByVal numero As String) As String
        Try
            Dim i, ii, digito, fator, soma As Integer
            Dim calculo As String = ""
            numero = numero.Replace(".", "").Replace("-", "").Replace("/", "")
            ii = Len(numero.ToString)

            fator = 2

            For i = ii To 1 Step -1
                calculo = (CLng(Mid(numero, i, 1)) * fator).ToString + calculo
                If fator = 2 Then
                    fator = 1
                Else
                    fator = 2
                End If
            Next

            For i = 1 To Len(calculo)
                soma += CLng(Mid(calculo, i, 1))
            Next

            digito = soma Mod 10
            If digito > 0 Then
                digito = 10 - digito
            End If

            Return digito
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function of_dv2a1mod10(ByVal numero As String) As String
        Try
            Dim i, resultado, digito, fator, soma As Integer
            numero = numero.Replace(".", "").Replace("-", "").Replace("/", "")
            fator = 2

            For i = Len(numero) To 1 Step -1

                resultado = CInt(Mid(numero, i, 1)) * fator
                If resultado > 9 Then resultado -= 9

                soma += resultado

                If fator = 2 Then
                    fator = 1
                Else
                    fator = 2
                End If

            Next

            digito = soma Mod 10

            If digito > 0 Then
                digito = 10 - digito
            End If

            Return digito.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function uf_dv2of9mod11(ByVal ls_chave As String) As String
        Dim ll_multiplicador, ll_acumulado, ll_cont, ll_tam, ll_resto As Long
        Dim local As String = "00"
        Try
            ll_tam = Len(ls_chave)
            local = "01"
            ll_multiplicador = 2
            local = "02"
            ll_acumulado = 0
            local = "03"
            For ll_cont = ll_tam To 1 Step -1
                local = "04|M-" + Mid(ls_chave, ll_cont, 1) + "|N-" + ll_cont.ToString + "|C-" + ls_chave + "|"
                ll_acumulado += CLng(Mid(ls_chave, ll_cont, 1)) * ll_multiplicador
                local = "05"
                ll_multiplicador += 1
                local = "06"
                If ll_multiplicador > 9 Then
                    local = "07"
                    ll_multiplicador = 2
                End If
            Next
            local = "08"
            ll_resto = 11 - ll_acumulado Mod 11
            local = "09"
            If ll_resto = 0 Or ll_resto = 1 Or ll_resto > 9 Then
                local = "0A"
                ll_resto = 1
            End If

            local = "0B"
            Return ll_resto.ToString
        Catch ex As Exception
            Throw New Exception("[" + local + "]" + ex.ToString)
        End Try
    End Function

    Public Function of_cobranca_escritural_dac(is_febrabam As String, is_carteira As String, is_cedente As String, ls_nnumero As String) As String
        Try
            Dim StrSql As String = "select f_cobranca_escritural_dac(convert(integer," + is_febrabam + "), '" + is_carteira + "', '" + is_cedente + "', '" + ls_nnumero + "') dac from dummy;"
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("dac").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function of_dac_campo_livre(ByVal febrabam As String, ByVal numero As String) As String
        Try
            Dim StrSql As String = "select f_cobranca_escritural_dac(convert(integer," + febrabam + "), null, null, '" + numero + "') dac from dummy;"
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("dac").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function uf_barra_2of5(ByVal as_codebar As String)
        Try
            as_codebar = as_codebar.Replace(".", "").Replace("-", "").Replace("/", "")
            Dim ls_CodeBin As String = "" ' codigo binario intercalado  
            Dim ls_CodeRet As String = "" ' codigo convertido retornado
            Dim li_Size As Integer  ' tamanho do codigo

            ' Array dos pares binarios em string
            Dim ls_Bin As String() = {"00", "01", "10", "11"}

            ' Array dos pares binarios em decimal
            Dim ls_Dec As String() = {"A", "B", "C", "D"}

            ' Array da representacao intercalada 2 de 5 dos digitos 0 a 9
            Dim ls_Dig As String() = {"00110", "10001", "01001", "11000", "00101", "10100", "01100", "00011", "10010", "01010"}

            Dim li_Ind As Integer ' indice para o codigo
            Dim li_Aux As Integer   ' indice auxiliar
            Dim li_Dig1 As Integer  ' primeiro digito
            Dim li_Dig2 As Integer  ' segundo digito
            Dim ls_Par As String = ""    ' par binario em string


            ' Acrescenta um 0 a esquerda caso o codigo a converter tenha tamanho impar
            li_Size = Len(as_codebar)

            If li_Size Mod 2 <> 0 Then
                as_codebar = "0" + as_codebar
                li_Size += 1
            End If

            ' Monta o codigo de barras na sua representacao binaria
            For li_Ind = 1 To li_Size Step 2
                ' Pega os digitos para formar o per decimal
                li_Dig1 = CInt(Mid(as_codebar, li_Ind, 1))
                li_Dig2 = CInt(Mid(as_codebar, li_Ind + 1, 1))

                ' Intercala a representacao binaria do primeiro digito com o segundo
                For li_Aux = 1 To 5
                    ls_CodeBin += Mid(ls_Dig(li_Dig1), li_Aux, 1) + Mid(ls_Dig(li_Dig2), li_Aux, 1)
                Next
            Next
            li_Size = Len(ls_CodeBin)

            ' Monta o codigo de barras na representacao EBCDIC
            For li_Ind = 1 To li_Size Step 2
                ' Pega o par binario em string
                ls_Par = Mid(ls_CodeBin, li_Ind, 2)
                ' Procura a posicao do par decimal
                For li_Aux = 0 To 3
                    If (ls_Par = ls_Bin(li_Aux)) Then
                        Exit For
                    End If
                Next
                ls_CodeRet += ls_Dec(li_Aux)
            Next
            Return "<" + ls_CodeRet + ">"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function of_mensagem_boleto(ByVal empresa As String, ByVal estabelecimento As String, ByVal cod_bordero_cr As String, ByVal especie As String, ByVal serie As String, ByVal cod_tit_cr As String, ByVal parcela As String, ByVal cod_cenario_ctbl As String, ByVal linha_mensagem As String) As String
        Try
            Dim StrSql As String = "select f_mensagem_boleto(" + empresa + ", " + estabelecimento + ", " + cod_bordero_cr + ", " + especie + ", '" + serie + "', " + cod_tit_cr + ", " + parcela + ", '" + cod_cenario_ctbl + "', " + linha_mensagem + ") mensagem from dummy"
            Dim ObjacessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = ObjacessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("mensagem").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function of_modulo_11(numero As String)
        Try
            Dim ll_fatores(24) As Long
            Dim k As Long
            Dim ll_aux_soma As Long
            Dim ll_soma As Long
            Dim ll_dac As Long
            Dim ll_aux_dac As Long
            Dim ll_fator As Long

            ll_fatores = {9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}

            If Len(numero) < 24 Then
                numero = Strings.Right("000000000000000000000000" + numero, 24)
            End If

            ll_soma = 0

            For k = 1 To 24
                ll_fator = ll_fatores(k - 1)

                ll_aux_soma = CInt(numero.Substring(k - 1, 1))
                ll_aux_soma = ll_aux_soma * ll_fator

                ll_soma += ll_aux_soma
            Next

            ll_aux_dac = ll_soma Mod 11
            ll_dac = 11 - ll_aux_dac

            If ll_dac > 9 Then
                ll_dac = 0
            End If

            Return ll_dac

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
