Partial Public Class TextBoxCEP
    Inherits System.Web.UI.UserControl

    Public Property Width() As String
        Get
            Return TextBox1.Width.ToString
        End Get
        Set(ByVal value As String)
            TextBox1.Width = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return TextBox1.Text.Replace("-", "")
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mask As String = "?????-???"
        TextBox1.Attributes.Add("OnKeyPress", "return(formata(this,'" + mask + "',event))")
        'TextBox1.Attributes.Add("OnClick", "selecionaCampo(this)")
    End Sub

End Class