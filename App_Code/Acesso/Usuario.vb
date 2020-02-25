Imports Microsoft.VisualBasic
Imports System.Data

Public Class Usuario
	Private AC06_COD_USUARIO as Integer
    Private AC06_USER As String
    Private AC06_SENHA as String
	Private AC06_NOME as String
	Private AC06_CPF as String
	Private AC06_CELULAR as String
	Private AC06_EMAIL as String
    Private AC06_PROGRAMADOR As Boolean
    Private AC06_ATIVO As Boolean
    Private AC06_DATA_CADASTRO as String
	Private AC06_DATA_ULTIMO_ACESSO as String

	Public Property Codigo() as Integer
		Get
			Return AC06_COD_USUARIO
		End Get
		Set(ByVal Value As Integer)
			AC06_COD_USUARIO = Value
		End Set
	End Property
    Public Property User() As String
        Get
            Return AC06_USER
        End Get
        Set(ByVal Value As String)
            AC06_USER = Value
        End Set
    End Property
    Public Property Senha() as String
		Get
			Return AC06_SENHA
		End Get
		Set(ByVal Value As String)
			AC06_SENHA = Value
		End Set
	End Property
	Public Property Nome() as String
		Get
			Return AC06_NOME
		End Get
		Set(ByVal Value As String)
			AC06_NOME = Value
		End Set
	End Property
	Public Property Cpf() as String
		Get
			Return AC06_CPF
		End Get
		Set(ByVal Value As String)
			AC06_CPF = Value
		End Set
	End Property
	Public Property Celular() as String
		Get
			Return AC06_CELULAR
		End Get
		Set(ByVal Value As String)
			AC06_CELULAR = Value
		End Set
	End Property
	Public Property Email() as String
		Get
			Return AC06_EMAIL
		End Get
		Set(ByVal Value As String)
			AC06_EMAIL = Value
		End Set
	End Property
    Public Property Programador() As Boolean
        Get
            Return AC06_PROGRAMADOR
        End Get
        Set(ByVal Value As Boolean)
            AC06_PROGRAMADOR = Value
        End Set
    End Property
    Public Property Ativo() As Boolean
        Get
            Return AC06_ATIVO
        End Get
        Set(ByVal Value As Boolean)
            AC06_ATIVO = Value
        End Set
    End Property
    Public Property DataCadastro() as String
		Get
			Return AC06_DATA_CADASTRO
		End Get
		Set(ByVal Value As String)
			AC06_DATA_CADASTRO = Value
		End Set
	End Property
	Public Property DataUltimoAcesso() as String
		Get
			Return AC06_DATA_ULTIMO_ACESSO
		End Get
		Set(ByVal Value As String)
			AC06_DATA_ULTIMO_ACESSO = Value
		End Set
	End Property

	Public Sub New(Optional ByVal Codigo as Integer = 0)
		If Codigo > 0 Then
			Obter(Codigo)
		End If
	End Sub

	Public Sub Salvar()
		Dim cnn As New Conexao
		Dim dt As DataTable
		Dim dr As DataRow
		Dim strSQL As New StringBuilder
		
		strSQL.Append(" select * ")
		strSQL.Append(" from AC06_USUARIO")
		strSQL.Append(" where AC06_COD_USUARIO = " & Codigo)

		dt = cnn.EditarDataTable(strSQL.ToString)

		If dt.Rows.Count = 0 Then
            dr = dt.NewRow
            dr("AC06_DATA_CADASTRO") = ProBanco(AC06_DATA_CADASTRO, eTipoValor.DATA)
        Else
			dr = dt.Rows(0)
		End If

        dr("AC06_USER") = ProBanco(AC06_USER, eTipoValor.TEXTO)
        dr("AC06_SENHA") = ProBanco(AC06_SENHA, eTipoValor.TEXTO)
		dr("AC06_NOME") = ProBanco(AC06_NOME, eTipoValor.TEXTO)
		dr("AC06_CPF") = ProBanco(AC06_CPF, eTipoValor.TEXTO)
		dr("AC06_CELULAR") = ProBanco(AC06_CELULAR, eTipoValor.TEXTO)
		dr("AC06_EMAIL") = ProBanco(AC06_EMAIL, eTipoValor.TEXTO)
        dr("AC06_PROGRAMADOR") = ProBanco(AC06_PROGRAMADOR, eTipoValor.BOOLEANO)
        dr("AC06_ATIVO") = ProBanco(AC06_ATIVO, eTipoValor.BOOLEANO)
        dr("AC06_DATA_ULTIMO_ACESSO") = ProBanco(AC06_DATA_ULTIMO_ACESSO, eTipoValor.DATA)

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
        strSQL.Append(" from AC06_USUARIO")
        strSQL.Append(" where AC06_COD_USUARIO = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AC06_COD_USUARIO = DoBanco(dr("AC06_COD_USUARIO"), eTipoValor.CHAVE)
            AC06_USER = DoBanco(dr("AC06_USER"), eTipoValor.TEXTO)
            AC06_SENHA = DoBanco(dr("AC06_SENHA"), eTipoValor.TEXTO)
            AC06_NOME = DoBanco(dr("AC06_NOME"), eTipoValor.TEXTO)
            AC06_CPF = DoBanco(dr("AC06_CPF"), eTipoValor.TEXTO)
            AC06_CELULAR = DoBanco(dr("AC06_CELULAR"), eTipoValor.TEXTO)
            AC06_EMAIL = DoBanco(dr("AC06_EMAIL"), eTipoValor.TEXTO)
            AC06_PROGRAMADOR = DoBanco(dr("AC06_PROGRAMADOR"), eTipoValor.BOOLEANO)
            AC06_ATIVO = DoBanco(dr("AC06_ATIVO"), eTipoValor.BOOLEANO)
            AC06_DATA_CADASTRO = DoBanco(dr("AC06_DATA_CADASTRO"), eTipoValor.DATA)
            AC06_DATA_ULTIMO_ACESSO = DoBanco(dr("AC06_DATA_ULTIMO_ACESSO"), eTipoValor.DATA)
        End If


        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional Codigo As Integer = 0,
                              Optional User As String = "",
                              Optional Senha As String = "",
                              Optional Nome As String = "",
                              Optional Cpf As String = "",
                              Optional Celular As String = "",
                              Optional Email As String = "",
                              Optional Programador As Boolean = False,
                              Optional Ativo As Boolean = False,
                              Optional DataCadastro As String = "",
                              Optional DataUltimoAcesso As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select *, ISNULL(DATEDIFF(DAY, AC06_DATA_ULTIMO_ACESSO, GETDATE()),0) as DIAS_SEM_ACESSO ")
        strSQL.Append(" from AC06_USUARIO")
        'strSQL.Append(" left join tabela on coluna1 = coluna2 ")
        strSQL.Append(" where AC06_COD_USUARIO is not null")

        If Codigo > 0 Then
            strSQL.Append(" and AC06_COD_USUARIO = " & Codigo)
        End If

        If User <> "" Then
            strSQL.Append(" and upper(AC06_USER) like '%" & User.ToUpper & "%'")
        End If

        If Senha <> "" Then
            strSQL.Append(" and upper(AC06_SENHA) like '%" & Senha.ToUpper & "%'")
        End If

        If Nome <> "" Then
            strSQL.Append(" and upper(AC06_NOME) like '%" & Nome.ToUpper & "%'")
        End If

        If Cpf <> "" Then
            strSQL.Append(" and upper(AC06_CPF) like '%" & Cpf.ToUpper & "%'")
        End If

        If Celular <> "" Then
            strSQL.Append(" and upper(AC06_CELULAR) like '%" & Celular.ToUpper & "%'")
        End If

        If Email <> "" Then
            strSQL.Append(" and upper(AC06_EMAIL) like '%" & Email.ToUpper & "%'")
        End If

        If Programador Then
            strSQL.Append(" and AC06_PROGRAMADOR = 1 ")
        End If

        If Ativo Then
            strSQL.Append(" and AC06_ATIVO = 1 ")
        End If

        If IsDate(DataCadastro) Then
            strSQL.Append(" and AC06_DATA_CADASTRO = Convert(DateTime, '" & DataCadastro & "', 103)")
        End If

        If IsDate(DataUltimoAcesso) Then
            strSQL.Append(" and AC06_DATA_ULTIMO_ACESSO = Convert(DateTime, '" & DataUltimoAcesso & "', 103)")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "AC06_COD_USUARIO", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select AC06_COD_USUARIO as CODIGO, AC06_USER as DESCRICAO")
        strSQL.Append(" from AC06_USUARIO")
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)


        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(AC06_COD_USUARIO) from AC06_USUARIO")

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
        strSQL.Append(" from AC06_USUARIO")
        strSQL.Append(" where AC06_COD_USUARIO = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)


        cnn = Nothing

		Return LinhasAfetadas
	End Function

End Class



