Imports Microsoft.VisualBasic
Imports System.Data

Public Class UsuarioPerfil
	Private AC05_COD_USUARIO_PERFIL as Integer
	Private FKAC05AC03_COD_PERFIL as Integer
	Private FKAC05AC01_COD_APLICACAO as Integer
	Private FKAC05AC06_COD_USUARIO as Integer

	Public Property Codigo() as Integer
		Get
			Return AC05_COD_USUARIO_PERFIL
		End Get
		Set(ByVal Value As Integer)
			AC05_COD_USUARIO_PERFIL = Value
		End Set
	End Property
	Public Property Perfil() as Integer
		Get
			Return FKAC05AC03_COD_PERFIL
		End Get
		Set(ByVal Value As Integer)
			FKAC05AC03_COD_PERFIL = Value
		End Set
	End Property
	Public Property Aplicacao() as Integer
		Get
			Return FKAC05AC01_COD_APLICACAO
		End Get
		Set(ByVal Value As Integer)
			FKAC05AC01_COD_APLICACAO = Value
		End Set
	End Property
	Public Property Usuario() as Integer
		Get
			Return FKAC05AC06_COD_USUARIO
		End Get
		Set(ByVal Value As Integer)
			FKAC05AC06_COD_USUARIO = Value
		End Set
	End Property

    Public Sub New()
    End Sub
    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Sub New(Optional ByVal Usuario As Integer = 0, Optional ByVal Aplicacao As Integer = 0)
        If Usuario > 0 And Aplicacao <> 0 Then
            ObterUsuarioPerfil(Usuario, Aplicacao)
        End If
    End Sub


    Public Sub Salvar()
		Dim cnn As New Conexao
		Dim dt As DataTable
		Dim dr As DataRow
		Dim strSQL As New StringBuilder
		
		strSQL.Append(" select * ")
		strSQL.Append(" from AC05_USUARIO_PERFIL")
		strSQL.Append(" where AC05_COD_USUARIO_PERFIL = " & Codigo)

		dt = cnn.EditarDataTable(strSQL.ToString)

		If dt.Rows.Count = 0 Then
			dr = dt.NewRow
		Else
			dr = dt.Rows(0)
		End If

		dr("FKAC05AC03_COD_PERFIL") = ProBanco(FKAC05AC03_COD_PERFIL, eTipoValor.CHAVE)
		dr("FKAC05AC01_COD_APLICACAO") = ProBanco(FKAC05AC01_COD_APLICACAO, eTipoValor.CHAVE)
		dr("FKAC05AC06_COD_USUARIO") = ProBanco(FKAC05AC06_COD_USUARIO, eTipoValor.CHAVE)

		cnn.SalvarDataTable(dr)

		dt.Dispose()
		dt = Nothing


        cnn = Nothing
    End Sub

    Public Sub Obter(ByVal Codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from AC05_USUARIO_PERFIL")
        strSQL.Append(" where AC05_COD_USUARIO_PERFIL = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AC05_COD_USUARIO_PERFIL = DoBanco(dr("AC05_COD_USUARIO_PERFIL"), eTipoValor.CHAVE)
            FKAC05AC03_COD_PERFIL = DoBanco(dr("FKAC05AC03_COD_PERFIL"), eTipoValor.CHAVE)
            FKAC05AC01_COD_APLICACAO = DoBanco(dr("FKAC05AC01_COD_APLICACAO"), eTipoValor.CHAVE)
            FKAC05AC06_COD_USUARIO = DoBanco(dr("FKAC05AC06_COD_USUARIO"), eTipoValor.CHAVE)
        End If


        cnn = Nothing
    End Sub
    Public Sub ObterUsuarioPerfil(ByVal Usuario As Integer, ByVal Aplicacao As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from AC05_USUARIO_PERFIL")
        strSQL.Append(" where FKAC05AC06_COD_USUARIO = " & Usuario)
        strSQL.Append(" and FKAC05AC01_COD_APLICACAO = " & Aplicacao)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AC05_COD_USUARIO_PERFIL = DoBanco(dr("AC05_COD_USUARIO_PERFIL"), eTipoValor.CHAVE)
            FKAC05AC03_COD_PERFIL = DoBanco(dr("FKAC05AC03_COD_PERFIL"), eTipoValor.CHAVE)
            FKAC05AC01_COD_APLICACAO = DoBanco(dr("FKAC05AC01_COD_APLICACAO"), eTipoValor.CHAVE)
            FKAC05AC06_COD_USUARIO = DoBanco(dr("FKAC05AC06_COD_USUARIO"), eTipoValor.CHAVE)
        End If

        '
        cnn = Nothing
    End Sub


    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional Codigo As Integer = 0,
                              Optional Perfil As Integer = 0,
                              Optional Aplicacao As Integer = 0,
                              Optional Usuario As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from AC05_USUARIO_PERFIL")
        strSQL.Append(" left join AC03_PERFIL on AC03_COD_PERFIL = FKAC05AC03_COD_PERFIL ")
        strSQL.Append(" left join AC01_APLICACAO on AC01_COD_APLICACAO = FKAC05AC01_COD_APLICACAO ")
        strSQL.Append(" where AC05_COD_USUARIO_PERFIL is not null")

        If Codigo > 0 Then
            strSQL.Append(" and AC05_COD_USUARIO_PERFIL = " & Codigo)
        End If

        If Perfil > 0 Then
            strSQL.Append(" and FKAC05AC03_COD_PERFIL = " & Perfil)
        End If

        If Aplicacao > 0 Then
            strSQL.Append(" and FKAC05AC01_COD_APLICACAO = " & Aplicacao)
        End If

        If Usuario > 0 Then
            strSQL.Append(" and FKAC05AC06_COD_USUARIO = " & Usuario)
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "AC05_COD_USUARIO_PERFIL", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select AC05_COD_USUARIO_PERFIL as CODIGO, ")
        strSQL.Append(" from AC05_USUARIO_PERFIL")
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)


        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(AC05_COD_USUARIO_PERFIL) from AC05_USUARIO_PERFIL")

        With cnn.AbrirDataTable(strSQL.ToString)
            If Not IsDBNull(.Rows(0)(0)) Then
                CodigoUltimo = .Rows(0)(0)
            Else
                CodigoUltimo = 0
            End If
        End With


        cnn = Nothing

        Return CodigoUltimo

    End Function
    Public Function Excluir(ByVal Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from AC05_USUARIO_PERFIL")
        strSQL.Append(" where AC05_COD_USUARIO_PERFIL = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)


        cnn = Nothing

		Return LinhasAfetadas
	End Function

End Class

'******************************************************************************
'*                                 26/01/2018                                 *
'*                                                                            *
'*          ESTE CÓDIGO FOI GERADO PELO GERA CODIGO VERSÃO 4.0                *
'*    SUPORTE PARA ASP.NET 2.0, AJAX, SQL SERVER COM ENTERPRISE LIBRARY       *
'*                                                                            *
'*  O Gera-Codigo gera um MODELO de código Página, Interface, Classe e Css    *
'*  cabe a cada programador fazer as adaptações quando NECESSÁRIAS.           *
'*                                                                            *
'*  Esta ferramenta é TOTALMENTE GRATUITA, por favor, não remova os créditos  *
'*                                                                            *
'*  O autor não se responsabiliza por qualquer evento acontecido com o uso    *
'*  desta ferramenta ou do sistema que ela vier a gerar.                      *
'*                                                                            *
'*          Desenvolvido por Nírondes Anglada Casanovas Tavares               *
'*                  E-Mail/MSN: nirondes@hotmail.com                          *
'*                                                                            *
'******************************************************************************

