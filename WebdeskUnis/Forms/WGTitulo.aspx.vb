Public Class WGTitulo
    Inherits System.Web.UI.Page

    Private Sub AjustaVisibilidadeCampos(ByVal logado As Boolean)
        Try
            If logado Then
                If Session("GlEmitente") IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("GlEmitente")) AndAlso IsNumeric(Session("GlEmitente")) AndAlso Session("GlEmitente") > 0 Then
                    LblCodEmitente.Text = Session("GlEmitente").ToString
                End If
                Menu1.Visible = True
                GridView1.Visible = True
                LblInstrucoesBoleto.Visible = True
                LblInstrucoesLogin.Visible = False
                LblCNPJ_CPF.Visible = False
                LblSenha.Visible = False
                TxtCNPJ.Visible = False
                TxtSenha.Visible = False
                Btn_OK_Login.Visible = False
            Else
                LblCodEmitente.Text = "0"
                Menu1.Visible = False
                GridView1.Visible = False
                LblInstrucoesBoleto.Visible = False
                LblInstrucoesLogin.Visible = True
                LblCNPJ_CPF.Visible = True
                LblSenha.Visible = True
                TxtCNPJ.Visible = True
                TxtSenha.Visible = True
                Btn_OK_Login.Visible = True
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("GlEmitente") IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session("GlEmitente")) AndAlso IsNumeric(Session("GlEmitente")) AndAlso Session("GlEmitente") > 0 Then
                    Call AjustaVisibilidadeCampos(True)
                Else
                    Call AjustaVisibilidadeCampos(False)
                End If
                Call CarregaGrid()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaGrid()
        Try
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Menu1_MenuItemClick(sender As Object, e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        Try
            Call CarregaGrid()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim Localizacao As String = "00"
        Try
            Dim chave As String() '(0) = Empresa | (1) = Cód. Borderô | (2) = Cód. Espécie | (3) = Série | (4) = cod_tit_cr | (5) = Parcela | (6) = Cenário
            Localizacao = "01"
            Dim nomeArq As String
            Localizacao = "02"
            If e.CommandName = "IMPRIMIR" Then
                Localizacao = "03"
                chave = e.CommandArgument.ToString.Split("|")
                Localizacao = "04"
                If chave IsNot Nothing Then
                    Localizacao = "05"
                    If chave.Length >= 7 Then
                        Localizacao = "06"
                        Dim ObjBoleto As New UCLBoleto
                        Localizacao = "07"
                        nomeArq = ObjBoleto.GerarBoletoPDF(chave(0), chave(1), chave(2), chave(3), chave(4), chave(5), chave(6), UCLBoleto.TipoRetorno.NomeDoArquivo).Trim
                        Localizacao = "08"
                        Response.Redirect("..\Boletos\" + nomeArq)
                        Localizacao = "09"
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = "[" + Localizacao + "] " + ex.ToString
        End Try
    End Sub

    Protected Sub Btn_OK_Login_Click(sender As Object, e As EventArgs) Handles Btn_OK_Login.Click
        Try
            LblErro.Text = ""
            Dim ObjEmitente As New UCLEmitente
            Dim cnpjInformado As String = ""
            Dim senhaInformada As String = ""
            Dim senhaDB As String = ""
            Dim dt As DataTable

            cnpjInformado = TxtCNPJ.Text.Replace("/", "").Replace("-", "").Replace("\", "").Replace(".", "")
            senhaInformada = TxtSenha.Text.Trim

            If String.IsNullOrWhiteSpace(cnpjInformado) Then
                LblErro.Text = "Informe seu CNPJ, conforme cadastro da empresa na Unis Sistemas."
                Return
            End If

            If String.IsNullOrWhiteSpace(senhaInformada) Then
                LblErro.Text = "Informe sua senha de acesso, conforme cadastro junto a Unis Sistemas."
                Return
            End If

            dt = ObjEmitente.BuscarPorCNPJ(cnpjInformado)

            If dt.Rows.Count = 0 Then
                LblErro.Text = "CNPJ não cadastrado."
                Return
            Else
                senhaDB = dt.Rows.Item(0).Item("senha").ToString

                If senhaDB = senhaInformada Then
                    Call AjustaVisibilidadeCampos(True)
                    LblCodEmitente.Text = dt.Rows.Item(0).Item("cod_emitente").ToString
                Else
                    LblErro.Text = "<b>Senha informada não confere</b>"
                    Return
                End If
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class