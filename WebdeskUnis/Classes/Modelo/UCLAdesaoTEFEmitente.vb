Public Class UCLAdesaoTEFEmitente
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("adesao_tef_emitente")
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodEmitente As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodEmitente As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_emitente", pCodEmitente)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsereCNPJsQueAindaNaoForamInseridos(ByVal pEmpresa As String, ByVal pCodEmitente As String)
        Try
            Dim StrSql As String = ""

            StrSql += " insert into adesao_tef_loja ( empresa, cod_emitente, cnpj, cod_contato_responsavel, razao_social, cod_usuario_inclusao) "
            StrSql += "    select " + pEmpresa + ", ee.cod_emitente, ee.cnpj, (select cod_contato from contatos where cod_emitente = ee.cod_emitente and preferencial = 'S'), ee.nome, f_busca_cod_usuario(current user)"
            StrSql += "      from endereco_emitente ee "
            StrSql += "     where cod_emitente = " + pCodEmitente
            StrSql += "       and isnull(ativo,'N') = 'S'"
            StrSql += "       and not exists(select 1 from adesao_tef_loja a where a.cod_emitente = ee.cod_emitente and a.cnpj = ee.cnpj) "
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EnviaEmailAceite()
        Try
            Dim ObjEmail As New UCLEmail
            Dim TextoParaOCliente As String = ""
            Dim TextoParaODepartamentoComercial As String = ""
            Dim NomeDoCliente As String = ""
            Dim ObjEmitente As New UCLEmitente
            Dim StrLinkValidacao As String = "http://matriz.unissistemas.com.br/webdeskunis/simulador-tef/WFValidacaoAdesao.aspx?e=" + Me.GetConteudo("cod_emitente") + "&s=0&d=" + Now.ToString("yyyyMMddHHmmssfff")
            Dim dtConvenio As DataTable
            Dim StrSql As String = ""

            StrSql += " select a.nome_remetente_email_campanha, a.email_remetente_email_campanha, a.usuario_remetente_email_campanha, a.senha_remetente_email_campanha, p.smtp, p.porta_envio, p.utiliza_ssl"
            StrSql += "   from adesao_tef a inner join parametros_email p on p.empresa = 1 "
            StrSql += "  where a.cod_adesao = (select first cod_adesao from adesao_tef_loja where cod_emitente = " + Me.GetConteudo("cod_emitente") + ")"
            dtConvenio = ObjAcessoDados.BuscarDados(StrSql)

            NomeDoCliente = ObjEmitente.GetRazaoSocial(Me.GetConteudo("cod_emitente"))

            TextoParaOCliente += "Prezado cliente,<br/><br/>Este é um e-mail referente à confirmação de sua adesão ao Convênio TEF.<br><br>"
            TextoParaOCliente += "Para validar sua adesão e confirmar seu aceite aos termos e condições do convênio, por gentileza clique no link abaixo:<br/><br/>"
            TextoParaOCliente += "<a href=" + Chr(34) + StrLinkValidacao + Chr(34) + ">Confirmar adesão</a>" + "<br><br>"
            TextoParaOCliente += "Caso o link acima não esteja disponível para você, por gentileza copie o texto abaixo, cole na barra de endereços de seu navegador de internet (Google Chrome, Mozilla Firefox, Safari, Internet Explorer, etc) e em seguida tecle Enter:<br/><br/>"
            TextoParaOCliente += StrLinkValidacao + "<br><br>"
            TextoParaOCliente += "Atenciosamente,<br/>Departamento Comercial<br/>UNIS SISTEMAS<br>(48) 3664-3000"

            TextoParaODepartamentoComercial += "Prezado(a),<br><br>Informamos que a empresa " + NomeDoCliente + " (" + Me.GetConteudo("cod_emitente") + ") aderiu ao Convênio TEF nesta data.<br><br>"
            TextoParaODepartamentoComercial += "Pessoa de Contato: " + Me.GetConteudo("nome_contato") + "<br>"
            TextoParaODepartamentoComercial += "E-mail: " + Me.GetConteudo("email_contato") + "<br>"
            TextoParaODepartamentoComercial += "Telefone(s): " + Me.GetConteudo("telefone1_contato") + " / " + Me.GetConteudo("telefone2_contato") + "<br>"
            TextoParaODepartamentoComercial += "<br><br>Atenciosamente,<br/>Equipe Técnica<br/>UNIS SISTEMAS"

            Call ObjEmail.envia_email(dtConvenio.Rows.Item(0).Item("smtp").ToString(), dtConvenio.Rows.Item(0).Item("email_remetente_email_campanha").ToString(), Me.GetConteudo("email_contato"), "Adesão ao Convênio TEF ", TextoParaOCliente, dtConvenio.Rows.Item(0).Item("senha_remetente_email_campanha").ToString(), dtConvenio.Rows.Item(0).Item("porta_envio").ToString(), dtConvenio.Rows.Item(0).Item("utiliza_ssl").ToString())
            Call ObjEmail.envia_email(dtConvenio.Rows.Item(0).Item("smtp").ToString(), dtConvenio.Rows.Item(0).Item("email_remetente_email_campanha").ToString(), dtConvenio.Rows.Item(0).Item("email_remetente_email_campanha").ToString(), "Adesão TEF - " + NomeDoCliente, TextoParaODepartamentoComercial, dtConvenio.Rows.Item(0).Item("senha_remetente_email_campanha").ToString(), dtConvenio.Rows.Item(0).Item("porta_envio").ToString(), dtConvenio.Rows.Item(0).Item("utiliza_ssl").ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
