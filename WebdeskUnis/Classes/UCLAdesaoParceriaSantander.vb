Public Class UCLAdesaoParceriaSantander
    Private ObjAcessoDados As UCLAcessoDados
    Public Property empresa As String
    Public Property seq_adesao As String
    Public Property cod_emitente As String
    Public Property cadastro_conferido As String
    Public Property nome_contato As String
    Public Property telefone1_contato As String
    Public Property telefone2_contato As String
    Public Property email_contato As String
    Public Property aceito As String
    Public Property data_aceite As String
    Public Property ip_aceite As String
    Public Property lido As String
    Public Property contato_confirmado As String
    Public Property confirmou_lojas As String
    Public Property convenio As String

    Public Sub New(ByVal strC As String)
        ObjAcessoDados = New UCLAcessoDados(strC)
    End Sub

    Public Sub Incluir(ByVal pEmpresa As String, ByVal pSeqAdesao As String)
        Try
            Dim StrSql As String

            empresa = pEmpresa
            seq_adesao = pSeqAdesao

            StrSql = "insert into adesao_parceria_santander (empresa, seq_adesao, cod_emitente, cadastro_conferido, nome_contato, telefone1_contato, telefone2_contato, email_contato, aceito, data_aceite, ip_aceite, lido, contato_confirmado, confirmou_lojas, data_inclusao, convenio) "
            StrSql += " values(" + pEmpresa + ", " + pSeqAdesao + ", " + cod_emitente + ", '" + cadastro_conferido + "', '" + nome_contato + "', '" + telefone1_contato + "', '" + telefone2_contato + "', '" + email_contato + "', 'N', null, null, '" + lido + "', '" + contato_confirmado + "', '" + confirmou_lojas + "', now() ,'" + convenio + "') "
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pSeqAdesao As String) As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable

            empresa = pEmpresa
            seq_adesao = pSeqAdesao

            StrSql = "select * from adesao_parceria_santander where empresa = " + pEmpresa + " and seq_adesao = " + pSeqAdesao
            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                cod_emitente = dt.Rows.Item(0).Item("cod_emitente").ToString
                cadastro_conferido = dt.Rows.Item(0).Item("cadastro_conferido").ToString
                nome_contato = dt.Rows.Item(0).Item("nome_contato").ToString
                telefone1_contato = dt.Rows.Item(0).Item("telefone1_contato").ToString
                telefone2_contato = dt.Rows.Item(0).Item("telefone2_contato").ToString
                email_contato = dt.Rows.Item(0).Item("email_contato").ToString
                aceito = dt.Rows.Item(0).Item("aceito").ToString
                lido = dt.Rows.Item(0).Item("lido").ToString
                contato_confirmado = dt.Rows.Item(0).Item("contato_confirmado").ToString
                confirmou_lojas = dt.Rows.Item(0).Item("confirmou_lojas").ToString
                If IsDBNull(dt.Rows.Item(0).Item("data_aceite")) Then
                    data_aceite = ""
                Else
                    data_aceite = CDate(dt.Rows.Item(0).Item("data_aceite")).ToString("dd/MM/yyyy HH:mm:ss")
                End If
                ip_aceite = dt.Rows.Item(0).Item("ip_aceite").ToString
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Alterar(ByVal pEmpresa As String, ByVal pSeqAdesao As String)
        Try
            Dim StrSql As String

            empresa = pEmpresa
            seq_adesao = pSeqAdesao

            StrSql = "update adesao_parceria_santander "
            StrSql += "  set cadastro_conferido = '" + cadastro_conferido + "', "
            StrSql += "      lido               = '" + lido + "', "
            StrSql += "      confirmou_lojas    = '" + confirmou_lojas + "', "
            StrSql += "      contato_confirmado = '" + contato_confirmado + "', "
            StrSql += "      nome_contato       = '" + nome_contato + "', "
            StrSql += "      telefone1_contato  = '" + telefone1_contato + "', "
            StrSql += "      telefone2_contato  = '" + telefone2_contato + "', "
            StrSql += "      email_contato      = '" + email_contato + "', "
            StrSql += "      cod_emitente       = " + cod_emitente
            StrSql += "where empresa      = " + pEmpresa
            StrSql += "  and seq_adesao   = " + pSeqAdesao
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EnviaEmailAceite(ByVal Convenio As String)
        Try
            Dim ObjEmail As New UCLEmail
            Dim TextoParaOCliente As String = ""
            Dim TextoParaODepartamentoComercial As String = ""
            Dim NomeDoCliente As String = ""
            Dim ObjEmitente As New UCLEmitente
            Dim StrLinkValidacao As String = "http://matriz.unissistemas.com.br/webdeskunis/simulador-tef/WFValidacaoAdesao.aspx?e=" + Me.cod_emitente + "&s=" + Me.seq_adesao + "&d=" + Now.ToString("yyyyMMddHHmmssfff")
            Dim dtConvenio As DataTable
            Dim StrSql As String = ""

            StrSql += " select a.nome_remetente_email_campanha, a.email_remetente_email_campanha, a.usuario_remetente_email_campanha, a.senha_remetente_email_campanha, p.smtp, p.porta_envio, p.utiliza_ssl"
            StrSql += "   from adesao_tef a inner join convenio_anfarmag c on a.cod_adesao = c.cod_adesao "
            StrSql += "                     inner join parametros_email p on p.empresa = 1 "
            StrSql += "  where c.cod_convenio = '" + Convenio + "'"
            dtConvenio = ObjAcessoDados.BuscarDados(StrSql)

            NomeDoCliente = ObjEmitente.GetRazaoSocial(Me.cod_emitente)

            TextoParaOCliente += "Prezado cliente,<br/><br/>Este é um e-mail referente à confirmação de sua adesão ao Convênio TEF.<br><br>"
            TextoParaOCliente += "Para validar sua adesão e confirmar seu aceite aos termos e condições do convênio, por gentileza clique no link abaixo:<br/><br/>"
            TextoParaOCliente += "<a href=" + Chr(34) + StrLinkValidacao + Chr(34) + ">Confirmar adesão</a>" + "<br><br>"
            TextoParaOCliente += "Caso o link acima não esteja disponível para você, por gentileza copie o texto abaixo, cole na barra de endereços de seu navegador de internet (Google Chrome, Mozilla Firefox, Safari, Internet Explorer, etc) e em seguida tecle Enter:<br/><br/>"
            TextoParaOCliente += StrLinkValidacao + "<br><br>"
            TextoParaOCliente += "Atenciosamente,<br/>Departamento Comercial<br/>UNIS SISTEMAS<br>(48) 3664-3000"

            TextoParaODepartamentoComercial += "Prezado(a),<br><br>Informamos que a empresa " + NomeDoCliente + " (" + Me.cod_emitente + ") aderiu ao Convênio TEF nesta data.<br><br>"
            TextoParaODepartamentoComercial += "Pessoa de Contato: " + Me.nome_contato + "<br>"
            TextoParaODepartamentoComercial += "E-mail: " + Me.email_contato + "<br>"
            TextoParaODepartamentoComercial += "Telefone(s): " + Me.telefone1_contato + " / " + Me.telefone2_contato + "<br>"
            TextoParaODepartamentoComercial += "Qtd. Estabelecimentos: " + GetQtdLojas(Me.empresa, Me.seq_adesao) + "<br>"
            TextoParaODepartamentoComercial += "Qtd. Total de PDVs: " + GetQtdPDVs(Me.empresa, Me.seq_adesao) + "<br><br>"
            TextoParaODepartamentoComercial += "Estabelecimento(s):<br>"
            TextoParaODepartamentoComercial += GetTextoEstabelecimentos(Me.empresa, Me.seq_adesao, Me.cod_emitente)
            TextoParaODepartamentoComercial += "<br><br>Atenciosamente,<br/>Equipe Técnica<br/>UNIS SISTEMAS"

            Call ObjEmail.envia_email(dtConvenio.Rows.Item(0).Item("smtp").ToString(), dtConvenio.Rows.Item(0).Item("email_remetente_email_campanha").ToString(), Me.email_contato, "Adesão ao Convênio TEF ", TextoParaOCliente, dtConvenio.Rows.Item(0).Item("senha_remetente_email_campanha").ToString(), dtConvenio.Rows.Item(0).Item("porta_envio").ToString(), dtConvenio.Rows.Item(0).Item("utiliza_ssl").ToString())
            Call ObjEmail.envia_email(dtConvenio.Rows.Item(0).Item("smtp").ToString(), dtConvenio.Rows.Item(0).Item("email_remetente_email_campanha").ToString(), dtConvenio.Rows.Item(0).Item("email_remetente_email_campanha").ToString(), "Adesão TEF - " + NomeDoCliente, TextoParaODepartamentoComercial, dtConvenio.Rows.Item(0).Item("senha_remetente_email_campanha").ToString(), dtConvenio.Rows.Item(0).Item("porta_envio").ToString(), dtConvenio.Rows.Item(0).Item("utiliza_ssl").ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GravaAceite(ByVal pEmpresa As String, ByVal pSeqAdesao As String, ByVal Convenio As String)
        Try
            Dim StrSql As String

            If Convenio = "" Then
                Convenio = "null"
            Else
                Convenio = "'" + Convenio + "'"
            End If

            empresa = pEmpresa
            seq_adesao = pSeqAdesao

            StrSql = "update adesao_parceria_santander "
            StrSql += "  set aceito             = '" + aceito + "', "
            StrSql += "      data_aceite        = now(), "
            StrSql += "      ip_aceite          = '" + ip_aceite + "', "
            StrSql += "      convenio           = " + Convenio
            StrSql += "where empresa      = " + pEmpresa
            StrSql += "  and seq_adesao   = " + pSeqAdesao
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GravaValidacao(ByVal pEmpresa As String, ByVal pSeqAdesao As String, ByVal pIpValidacao As String)
        Try
            Dim StrSql As String

            empresa = pEmpresa
            seq_adesao = pSeqAdesao

            StrSql = "update adesao_parceria_santander "
            StrSql += "  set validado           = 'S', "
            StrSql += "      data_validacao     = now(), "
            StrSql += "      ip_validacao       = '" + pIpValidacao + "' "
            StrSql += "where empresa      = " + pEmpresa
            StrSql += "  and seq_adesao   = " + pSeqAdesao
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetQtdLojas(ByVal pEmpresa As String, ByVal pSeqAdesao As String) As String
        Try
            empresa = pEmpresa
            seq_adesao = pSeqAdesao

            Dim StrSql As String = "select isnull(count(1),0) qtd_lojas from adesao_parceria_santander_cnpj where empresa = " + pEmpresa + " and seq_adesao = " + pSeqAdesao
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("qtd_lojas").ToString
            Else
                Return "0"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetQtdPDVs(ByVal pEmpresa As String, ByVal pSeqAdesao As String) As String
        Try
            empresa = pEmpresa
            seq_adesao = pSeqAdesao

            Dim StrSql As String = "select isnull(sum(qtd_pdv),0) qtd_pdvs from adesao_parceria_santander_cnpj where empresa = " + pEmpresa + " and seq_adesao = " + pSeqAdesao
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("qtd_pdvs").ToString
            Else
                Return "0"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pSeqAdesao As String)
        Try
            Dim StrSql As String

            empresa = pEmpresa
            seq_adesao = pSeqAdesao

            StrSql = "delete from adesao_parceria_santander "
            StrSql += "where empresa    = " + pEmpresa
            StrSql += "  and seq_adesao = " + pSeqAdesao
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String) As Long
        Try
            Dim StrSql As String = " select max(seq_adesao) + 1 max from adesao_parceria_santander where empresa = " + pEmpresa
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("max")) Then
                    Return 1
                Else
                    Return dt.Rows.Item(0).Item("max")
                End If
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTextoEstabelecimentos(ByVal pEmpresa As String, ByVal pSeqAdesao As String, ByVal pCodEmitente As String) As String
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            Dim Texto As String = ""

            StrSql += " select isnull((select 'True'"
            StrSql += "                  from adesao_parceria_santander_cnpj c"
            StrSql += "                 where c.cod_emitente = e.cod_emitente"
            StrSql += "                   and e.cnpj         = c.cnpj"
            StrSql += "                   and c.seq_adesao   = sqad"
            StrSql += "                   and c.empresa      = 1  ),'False') checked,"
            StrSql += "        e.cnpj,"
            StrSql += "        e.endereco,"
            StrSql += "        e.numero,"
            StrSql += "        e.complemento,"
            StrSql += "        e.bairro_nome,"
            StrSql += "        e.cep,"
            StrSql += "        e.cidade_nome,"
            StrSql += "        e.estado_sigla,"
            StrSql += "       isnull((select convert(varchar(6),convert(integer,qtd_pdv))"
            StrSql += "                 from adesao_parceria_santander_cnpj c"
            StrSql += "                where c.cod_emitente = e.cod_emitente"
            StrSql += "                  and e.cnpj         = c.cnpj"
            StrSql += "                  and c.seq_adesao   = sqad"
            StrSql += "                  and c.empresa      = 1),'') qtd_pdv,"
            StrSql += "        " + pSeqAdesao + " sqad"
            StrSql += "   from v_emitente_endereco e"
            StrSql += "  where e.ativo        = 'S'"
            StrSql += "    and e.cod_emitente = " + pCodEmitente
            StrSql += "    and checked        = 'True'"

            dt = ObjAcessoDados.BuscarDados(StrSql)

            For Each row As DataRow In dt.Rows
                Texto += "CNPJ: " + row.Item("cnpj").ToString.MascaraCNPJ + "<br>"
                Texto += "Endereço: " + row.Item("endereco").ToString + " " + row.Item("numero").ToString + " " + row.Item("complemento").ToString + " - " + row.Item("bairro_nome").ToString + "<br>"
                Texto += "Município: " + row.Item("cidade_nome").ToString + " - " + row.Item("estado_sigla").ToString + " - CEP: " + row.Item("cep").ToString.MascaraCEP + "<br>"
                Texto += "Qtd. PDVs:" + row.Item("qtd_pdv").ToString + "<br><br>"
            Next

            Return Texto
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
