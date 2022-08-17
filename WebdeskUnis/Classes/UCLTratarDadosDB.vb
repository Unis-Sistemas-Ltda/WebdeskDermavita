Public Class UCLTratarDadosDB

    Public Sub TratarVariavel(ByRef PVariavel As String, ByVal PTipo As String)
        If PTipo = "Texto" Then
            PVariavel = TratarTexto(PVariavel)
        ElseIf PTipo = "Data" Then
            PVariavel = TratarData(PVariavel)
        ElseIf PTipo = "Long" Then
            PVariavel = TratarLong(PVariavel)
        ElseIf PTipo = "Decimal" Then
            PVariavel = TratarDecimal(PVariavel)
        ElseIf PTipo = "Hora" Then
            PVariavel = TratarHora(PVariavel)
        End If
    End Sub

    Function TratarTexto(ByVal PTexto As String) As String
        If PTexto = "" Then
            PTexto = "''"
        Else
            PTexto = ("'" & PTexto & "'")
        End If
        Return PTexto
    End Function

    Function TratarData(ByVal Pdata As String) As String
        Dim Ldata As Date
        If Pdata = "" Then
            Pdata = "null"
        Else
            Ldata = Pdata.ToString
            Pdata = "'" & Ldata.Year.ToString & "-" & Ldata.Month.ToString & "-" & Ldata.Day.ToString & "'"
        End If
        Return Pdata
    End Function

    Function TratarLong(ByVal PLong As String) As String
        If PLong = "" Then
            PLong = "null"
        End If
        Return PLong
    End Function

    Function TratarHora(ByVal PHora As String) As String
        Dim hora As String
        If PHora = Nothing Or PHora = "" Then
            hora = "'00:00:00'"
        Else
            hora = "'" + PHora + "'"
        End If
        Return hora
    End Function

    Function TratarDecimal(ByVal PDecimal As String) As String
        If PDecimal = "" Then
            PDecimal = "null"
        Else
            PDecimal = PDecimal.Replace(",", ";")
            PDecimal = PDecimal.Replace(".", "")
            PDecimal = PDecimal.Replace(";", ".")
        End If
        Return PDecimal
    End Function


End Class
