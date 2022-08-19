Public Partial Class WUCFrame
    Inherits System.Web.UI.UserControl
    Dim _Pagina As String
    Dim _Width As String
    Dim _Height As String

    Public Property Width() As String
        Get
            Return _Width
        End Get
        Set(ByVal value As String)
            _Width = value
        End Set
    End Property

    Public Property Height() As String
        Get
            Return _Height
        End Get
        Set(ByVal value As String)
            _Height = value
        End Set
    End Property


    Public Property Pagina()
        Get
            Return _Pagina
        End Get
        Set(ByVal value)
            _Pagina = "~/Forms/" + value
            IFPagina.Attributes.Item("SRC") = _Pagina
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IFPagina.Attributes.Item("Style") = "width: " & Width & "; height: " & Height
        IFPagina.DataBind()
    End Sub

End Class