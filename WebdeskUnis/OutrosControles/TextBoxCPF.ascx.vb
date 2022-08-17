Partial Public Class TextBoxCPF
    Inherits System.Web.UI.UserControl

    Private _AutoPostBack As Boolean

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
            Return TextBox1.Text.Replace("-", "").Replace(".", "")
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value.MascaraCPF
        End Set
    End Property

    Public Property AutoPostBack() As Boolean
        Get
            Return _AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            _AutoPostBack = value
            If value Then
                TextBox1.Attributes.Add("OnBlur", "submit();")
            Else
                TextBox1.Attributes.Remove("OnBlur")
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mask As String = "###.###.###-##"
        TextBox1.Attributes.Add("OnKeyPress", "formatacampo(this,'" + mask + "')")
        If AutoPostBack Then
            TextBox1.Attributes.Add("OnBlur", "submit();")
        Else
            TextBox1.Attributes.Remove("OnBlur")
        End If
    End Sub

End Class