Public Class UCLTabelaGenericaCampo
    Public Property NomeCampo As String
    Public Property Tipo As ENTipoCampo
    Public Property Conteudo As String
    Public Property IsNull As Boolean


    Public Enum ENTipoCampo As Integer
        Data = 1
        Texto = 2
        NumeroInteiro = 3
        NumeroDecimal = 4
    End Enum

    Public Sub New(ByVal pNomeCampo As String, ByVal pTipo As ENTipoCampo)
        Tipo = pTipo
        NomeCampo = pNomeCampo
        IsNull = True
    End Sub

    Public Sub New(ByVal pNomeCampo As String, ByVal pTipo As ENTipoCampo, ByVal pConteudo As String)
        Tipo = pTipo
        NomeCampo = pNomeCampo
        Conteudo = pConteudo
        IsNull = False
    End Sub

End Class