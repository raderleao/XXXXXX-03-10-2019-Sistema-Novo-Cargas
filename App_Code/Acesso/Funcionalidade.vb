Imports Microsoft.VisualBasic
Imports System.Data

Public Class Funcionalidade
	Private AC02_COD_FUNCIONALIDADE as Integer
	Private FKAC02AC01_COD_APLICACAO as Integer
	Private AC02_DESCRICAO as String

    Public Property Codigo() as Integer
		Get
			Return AC02_COD_FUNCIONALIDADE
		End Get
		Set(ByVal Value As Integer)
			AC02_COD_FUNCIONALIDADE = Value
		End Set
	End Property
	Public Property Aplicacao() as Integer
		Get
			Return FKAC02AC01_COD_APLICACAO
		End Get
		Set(ByVal Value As Integer)
			FKAC02AC01_COD_APLICACAO = Value
		End Set
	End Property
	Public Property Descricao() as String
		Get
			Return AC02_DESCRICAO
		End Get
		Set(ByVal Value As String)
			AC02_DESCRICAO = Value
		End Set
	End Property
    Public Sub New(Optional ByVal Codigo As Integer = 0)
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
		strSQL.Append(" from AC02_FUNCIONALIDADE")
		strSQL.Append(" where AC02_COD_FUNCIONALIDADE = " & Codigo)

		dt = cnn.EditarDataTable(strSQL.ToString)

		If dt.Rows.Count = 0 Then
			dr = dt.NewRow
		Else
			dr = dt.Rows(0)
		End If

		dr("FKAC02AC01_COD_APLICACAO") = ProBanco(FKAC02AC01_COD_APLICACAO, eTipoValor.CHAVE)
		dr("AC02_DESCRICAO") = ProBanco(AC02_DESCRICAO, eTipoValor.TEXTO)

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
        strSQL.Append(" from AC02_FUNCIONALIDADE")
        strSQL.Append(" where AC02_COD_FUNCIONALIDADE = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AC02_COD_FUNCIONALIDADE = DoBanco(dr("AC02_COD_FUNCIONALIDADE"), eTipoValor.CHAVE)
            FKAC02AC01_COD_APLICACAO = DoBanco(dr("FKAC02AC01_COD_APLICACAO"), eTipoValor.CHAVE)
            AC02_DESCRICAO = DoBanco(dr("AC02_DESCRICAO"), eTipoValor.TEXTO)
        End If


        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional Codigo As Integer = 0,
                              Optional Aplicacao As Integer = 0,
                              Optional Descricao As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from AC02_FUNCIONALIDADE")
        'strSQL.Append(" left join tabela on coluna1 = coluna2 ")
        strSQL.Append(" where AC02_COD_FUNCIONALIDADE is not null")

        If Codigo > 0 Then
            strSQL.Append(" and AC02_COD_FUNCIONALIDADE = " & Codigo)
        End If

        If Aplicacao > 0 Then
            strSQL.Append(" and FKAC02AC01_COD_APLICACAO = " & Aplicacao)
        End If

        If Descricao <> "" Then
            strSQL.Append(" and upper(AC02_DESCRICAO) like '%" & Descricao.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "AC02_COD_FUNCIONALIDADE", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela(Optional Aplicacao As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select AC02_COD_FUNCIONALIDADE as CODIGO, AC02_DESCRICAO as DESCRICAO")
        strSQL.Append(" from AC02_FUNCIONALIDADE")

        If Aplicacao > 0 Then
            strSQL.Append(" where FKAC02AC01_COD_APLICACAO = " & Aplicacao)
        End If
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)


        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(AC02_COD_FUNCIONALIDADE) from AC02_FUNCIONALIDADE")

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
        strSQL.Append(" from AC02_FUNCIONALIDADE")
        strSQL.Append(" where AC02_COD_FUNCIONALIDADE = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)


        cnn = Nothing

		Return LinhasAfetadas
	End Function

End Class


