Imports Microsoft.VisualBasic
Imports System.Data
Public Class Permissao

    '0 = ACESSO NEGADO
    '1 = LEITURA
    '2 = ESCRITA
    Public Function Funcionalidade(ByVal CodigoUsuario As Integer, ByVal CodigoFuncionalidade As Integer) As Short
        Dim objUsuario As New Usuario(CodigoUsuario)
        Dim objFuncionalidade As New Funcionalidade(CodigoFuncionalidade)
        Dim objUsuarioPerfil As New UsuarioPerfil(CodigoUsuario, objFuncionalidade.Aplicacao)
        Dim objPerfilFuncionalidade As New PerfilFuncionalidade(objUsuarioPerfil.Perfil, CodigoFuncionalidade)

        Dim intRetorno As Short = 0

        If Not objUsuario.Programador Then
            If objUsuarioPerfil.Perfil > 0 Then
                With objPerfilFuncionalidade.Pesquisar2(, objFuncionalidade.Aplicacao, CodigoFuncionalidade, objUsuarioPerfil.Perfil)
                    If .Rows.Count > 0 Then
                        objPerfilFuncionalidade.ObterPerfilFuncionalidade(objUsuarioPerfil.Perfil, Funcionalidade)

                        If objPerfilFuncionalidade.SomenteLeitura Then
                            intRetorno = 1
                        Else
                            intRetorno = 2
                        End If

                    End If
                End With
            End If
        Else
            intRetorno = 2
        End If


        objUsuario = Nothing
        objFuncionalidade = Nothing
        objUsuarioPerfil = Nothing
        objPerfilFuncionalidade = Nothing

        Return intRetorno
    End Function

    'Public Function ObterUsuario(ByVal SessionID As String, ByVal CodigoAplicacao As Integer) As Integer
    '    Dim objSession As New Session
    '    Dim intRetorno As Integer = 0

    '    With objSession.Pesquisar(, , , SessionID, , , True) '30/03/2012:Franklinsley apenas Usuários Ativos
    '        If .Rows.Count > 0 Then
    '            Dim drSession As DataRow = .Rows(0)
    '            Dim objUsuario As New Usuario(drSession("FKCA10CA04_COD_USUARIO"))
    '            Dim objUsuarioPerfil As New Usuario.Perfil


    '            With objUsuarioPerfil.Pesquisar(, drSession("FKCA10CA04_COD_USUARIO"), CodigoAplicacao)
    '                If .Rows.Count > 0 Or objUsuario.Programador Then
    '                    objSession.Obter(drSession("CA10_COD_SESSION"))
    '                    objSession.DataAtual = Now
    '                    objSession.Ativo = True
    '                    objSession.Salvar()
    '                    intRetorno = drSession("FKCA10CA04_COD_USUARIO")
    '                End If
    '            End With

    '            objUsuarioPerfil = Nothing
    '        End If
    '    End With

    '    objSession = Nothing

    '    Return intRetorno
    'End Function

    Public Function ObterPerfil(ByVal CodigoUsuario As Integer, ByVal CodigoAplicacao As Integer) As Integer
        Dim objUsuarioPerfil As New UsuarioPerfil(CodigoUsuario, CodigoAplicacao)
        Dim intRetorno As Integer = objUsuarioPerfil.Perfil

        objUsuarioPerfil = Nothing

        Return intRetorno
    End Function

    Public Function ObterLogin(ByVal CodigoUsuario As Integer) As String
        Dim objUsuario As New Usuario(CodigoUsuario)
        Dim strRetorno As String = objUsuario.User

        objUsuario = Nothing

        Return strRetorno
    End Function

    Public Function ObterNome(ByVal CodigoUsuario As Integer) As String
        Dim objUsuario As New Usuario(CodigoUsuario)
        Dim strRetorno As String = objUsuario.Nome

        objUsuario = Nothing

        Return strRetorno
    End Function

    Public Function Programador(ByVal CodigoUsuario As Integer) As Integer
        Dim objUsuario As New Usuario(CodigoUsuario)
        Dim intRetorno As Integer = objUsuario.Programador

        objUsuario = Nothing

        Return intRetorno
    End Function


End Class
