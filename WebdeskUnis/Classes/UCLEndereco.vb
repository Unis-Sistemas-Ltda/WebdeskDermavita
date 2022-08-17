Public Class UCLEndereco
    Dim ObjAcessoDados As UCLAcessoDados
    Public Sub New(ByVal strConexao As String)
        ObjAcessoDados = New UCLAcessoDados(strConexao)
    End Sub
    Public Function buscar_pais() As DataTable
        Dim strSql As String = " select * from pais "
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

    Public Function buscar_estado(ByVal cod_pais As Long) As DataTable
        Dim strSql As String = " select * from estado where cod_pais = " & cod_pais.ToString & " order by nome_estado "
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

    Public Function buscarEstadoSigla(ByVal codPais As Long, ByVal codEstado As Long) As String
        Dim strSql As String = " select sigla from estado where cod_pais = " & codPais.ToString & " and cod_estado = " & codEstado.ToString
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Dim ret As String = ""
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("sigla").ToString
        End If
        Return ret
    End Function

    Public Function buscarEstadoNome(ByVal codPais As Long, ByVal codEstado As Long) As String
        Dim strSql As String = " select nome_estado from estado where cod_pais = " & codPais.ToString & " and cod_estado = " & codEstado.ToString
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Dim ret As String = ""
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("nome_estado").ToString
        End If
        Return ret
    End Function

    Public Function buscarCidadeNome(ByVal codPais As Long, ByVal codEstado As Long, ByVal codCidade As Long) As String
        Dim strSql As String = " select nome_cidade from cidade where cod_pais = " & codPais.ToString & " and cod_estado = " & codEstado.ToString & " and cod_cidade = " & codCidade.ToString
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Dim ret As String = ""
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("nome_cidade").ToString
        End If
        Return ret
    End Function

    Public Function buscar_cidade(ByVal cod_pais As Long, ByVal cod_estado As Long) As DataTable
        Dim strSql As String = " select  *  from cidade where cod_pais = " & cod_pais.ToString & " and cod_estado = " & cod_estado.ToString & " order by nome_cidade"
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

    Public Function buscar_bairro(ByVal cod_pais As Long, ByVal cod_estado As Long) As DataTable
        Dim strSql As String = " select  *  from cidade where cod_pais = " & cod_pais.ToString & " and cod_estado = " & cod_estado.ToString
        Dim dt As DataTable = ObjAcessoDados.BuscarDados(strSql)
        Return dt
    End Function

End Class
