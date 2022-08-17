Public MustInherit Class UCLClasseGenerica

    Public ObjTabelaGenerica As UCLTabelaGenerica
    Public ObjAcessoDados As New UCLAcessoDados

    Public Property Campos As List(Of UCLTabelaGenericaCampo)
        Get
            Return ObjTabelaGenerica.Campos
        End Get
        Set(ByVal value As List(Of UCLTabelaGenericaCampo))
            ObjTabelaGenerica.Campos = value
        End Set
    End Property

    Public Property CamposPK As List(Of UCLTabelaGenericaCampo)
        Get
            Return ObjTabelaGenerica.CamposPK
        End Get
        Set(ByVal value As List(Of UCLTabelaGenericaCampo))
            ObjTabelaGenerica.CamposPK = value
        End Set
    End Property

    Public Overridable Function IsNull(ByVal pNomeCampo As String) As Boolean
        Try
            Dim campo As UCLTabelaGenericaCampo = Campos.Find(Function(x) x.NomeCampo = pNomeCampo)
            If campo IsNot Nothing Then
                Return campo.IsNull
            Else
                Throw New Exception("Campo [" + pNomeCampo + "] não foi encontrado")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Overridable Function GetConteudo(ByVal pNomeCampo As String) As String
        Try
            Dim campo As UCLTabelaGenericaCampo = Campos.Find(Function(x) x.NomeCampo = pNomeCampo)
            If campo IsNot Nothing Then
                If campo.IsNull Then
                    Return ""
                Else
                    Return campo.Conteudo
                End If
            Else
                Throw New Exception("Campo [" + pNomeCampo + "] não foi encontrado")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Overridable Sub SetConteudo(ByVal pNomeCampo As String, ByVal pConteudo As String)
        Try
            Dim campo As UCLTabelaGenericaCampo = Campos.Find(Function(x) x.NomeCampo = pNomeCampo)
            Dim campoPK As UCLTabelaGenericaCampo = CamposPK.Find(Function(x) x.NomeCampo = pNomeCampo)
            If campo IsNot Nothing Then
                If campo.Tipo = UCLTabelaGenericaCampo.ENTipoCampo.Data AndAlso pConteudo.Contains("/") Then
                    pConteudo = CType(pConteudo, DateTime).ToString("yyyy-MM-dd HH:mm:ss.fff")
                End If
                campo.Conteudo = pConteudo
                campo.IsNull = False
            Else
                Throw New Exception("Campo [" + pNomeCampo + "] não foi encontrado")
            End If
            If campoPK IsNot Nothing Then
                If campo.Tipo = UCLTabelaGenericaCampo.ENTipoCampo.Data AndAlso pConteudo.Contains("/") Then
                    pConteudo = CType(pConteudo, DateTime).ToString("yyyy-MM-dd HH:mm:ss.fff")
                End If
                campoPK.Conteudo = pConteudo
                campo.IsNull = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub SetNull(ByVal pNomeCampo As String)
        Try
            Dim campo As UCLTabelaGenericaCampo = Campos.Find(Function(x) x.NomeCampo = pNomeCampo)
            Dim campoPK As UCLTabelaGenericaCampo = CamposPK.Find(Function(x) x.NomeCampo = pNomeCampo)
            If campo IsNot Nothing Then
                campo.Conteudo = ""
                campo.IsNull = True
            Else
                Throw New Exception("Campo [" + pNomeCampo + "] não foi encontrado")
            End If
            If campoPK IsNot Nothing Then
                campoPK.Conteudo = ""
                campoPK.IsNull = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub Buscar()
        Try
            ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub Incluir()
        Try
            ObjTabelaGenerica.Incluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub Alterar()
        Try
            ObjTabelaGenerica.Alterar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub Excluir()
        Try
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
