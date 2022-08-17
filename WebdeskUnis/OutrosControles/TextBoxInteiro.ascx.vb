Partial Public Class TextBoxInteiro
    Inherits System.Web.UI.UserControl

    Private _MaxLength As String

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
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property

    Public Property MaxLength() As String
        Get
            Return TextBox1.MaxLength
        End Get
        Set(ByVal value As String)
            TextBox1.MaxLength = value
        End Set
    End Property

    Public Property AutoPostBack() As Boolean
        Get
            Return TextBox1.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            TextBox1.AutoPostBack = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Attributes.Add("OnKeyPress", "return(formata(this,'??????????',event))")
        'TextBox1.Attributes.Add("OnClick", "selecionaCampo(this)")

        If AutoPostBack Then
            TextBox1.Attributes.Add("OnBlur", "submit();")
        End If
    End Sub

End Class