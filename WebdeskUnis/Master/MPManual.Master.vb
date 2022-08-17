Public Class MPManual
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack OrElse MnuSistemas.Items.Count = 0 Then
            Call CarregaSistemas()

            If MnuSistemas.Items.Count > 0 Then
                MnuSistemas.Items.Item(0).Selected = True
                Call CarregaModulos(MnuSistemas.Items.Item(0).Value)
            End If
        End If
    End Sub

    Private Sub CarregaSistemas()
        Try
            Dim ObjSistema As New UCLSistema
            Dim sistemas As List(Of UCLSistema) = ObjSistema.GetLista("S")
            Dim mi As MenuItem

            MnuSistemas.Items.Clear()

            For Each sistema As UCLSistema In sistemas
                mi = New MenuItem(sistema.GetConteudo("descricao"), sistema.GetConteudo("cod_sistema"))
                MnuSistemas.Items.Add(mi)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaModulos(ByVal pCodSistema As String)
        Try
            Dim ObjModulo As New UCLModulo
            Dim modulos As List(Of UCLModulo) = ObjModulo.GetLista(pCodSistema)
            Dim mi As MenuItem

            Session("SM_CodSistema") = pCodSistema

            MnuModulos.Items.Clear()

            For Each modulo As UCLModulo In modulos
                mi = New MenuItem(modulo.GetConteudo("ds_modulo"), modulo.GetConteudo("cod_modulo"))
                MnuModulos.Items.Add(mi)
            Next

            If modulos.Count > 0 Then
                MnuModulos.Items.Item(0).Selected = True
                Session("SM_CodModulo") = MnuModulos.Items.Item(0).Value
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub MnuSistemas_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuSistemas.MenuItemClick
        Try
            TxtRotina.Text = ""
            Session.Remove("SM_NomeRotina")
            Session.Remove("SM_CodModulo")
            Session.Remove("SM_CodRotina")

            Call CarregaModulos(e.Item.Value)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub MnuModulos_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles MnuModulos.MenuItemClick
        Session("SM_CodModulo") = e.Item.Value
        Session.Remove("SM_CodRotina")
    End Sub

    Protected Sub BtnPesquisar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnPesquisar.Click
        If String.IsNullOrWhiteSpace(TxtRotina.Text) Then
            Session.Remove("SM_NomeRotina")
            Call CarregaSistemas()

            If MnuSistemas.Items.Count > 0 Then
                MnuSistemas.Items.Item(0).Selected = True
                Call CarregaModulos(MnuSistemas.Items.Item(0).Value)
            End If
        Else
            Session.Remove("SM_CodSstema")
            Session.Remove("SM_CodModulo")
            Session.Remove("SM_CodRotina")
            Session("SM_NomeRotina") = TxtRotina.Text
            Call CarregaSistemas()
            MnuModulos.Items.Clear()
        End If
    End Sub
End Class