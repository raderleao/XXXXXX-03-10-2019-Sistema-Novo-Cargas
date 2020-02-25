Imports Microsoft.VisualBasic
Imports System.Data

Public Class ControleCarga
	Private IN02_COD_NUMERO_ARQUIVO as Integer
	Private IN02_NUM_ARQUIVO as Integer
    Private IN02_DATA_CRIACAO_ARQUIVO As Date
    Private IN02_NUM_REMESSA_DETRAN as Integer
    Private IN02_DATA_REMESSA_DETRAN As Date
    Private IN02_NOME_ARQUIVO_ECARTA As String

    Public Property Codigo() as Integer
		Get
			Return IN02_COD_NUMERO_ARQUIVO
		End Get
		Set(ByVal Value As Integer)
			IN02_COD_NUMERO_ARQUIVO = Value
		End Set
	End Property
	Public Property NumArquivo() as Integer
		Get
			Return IN02_NUM_ARQUIVO
		End Get
		Set(ByVal Value As Integer)
			IN02_NUM_ARQUIVO = Value
		End Set
	End Property
    Public Property DataCriacaoArquivo() As Date
        Get
            Return IN02_DATA_CRIACAO_ARQUIVO
        End Get
        Set(ByVal Value As Date)
            IN02_DATA_CRIACAO_ARQUIVO = Value
        End Set
    End Property
    Public Property NumRemessaDetran() as Integer
		Get
			Return IN02_NUM_REMESSA_DETRAN
		End Get
		Set(ByVal Value As Integer)
			IN02_NUM_REMESSA_DETRAN = Value
		End Set
	End Property
    Public Property DataRemessaDetran() As Date
        Get
            Return IN02_DATA_REMESSA_DETRAN
        End Get
        Set(ByVal Value As Date)
            IN02_DATA_REMESSA_DETRAN = Value
        End Set
    End Property
    Public Property NomeArquivoECarta() As String
        Get
            Return IN02_NOME_ARQUIVO_ECARTA
        End Get
        Set(ByVal Value As String)
            IN02_NOME_ARQUIVO_ECARTA = Value
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
		strSQL.Append(" from IN02_CONTROLE_CARGA")
		strSQL.Append(" where IN02_COD_NUMERO_ARQUIVO = " & Codigo)

		dt = cnn.EditarDataTable(strSQL.ToString)

		If dt.Rows.Count = 0 Then
			dr = dt.NewRow
		Else
			dr = dt.Rows(0)
		End If

		dr("IN02_NUM_ARQUIVO") = ProBanco(IN02_NUM_ARQUIVO, eTipoValor.CHAVE)
		dr("IN02_DATA_CRIACAO_ARQUIVO") = ProBanco(IN02_DATA_CRIACAO_ARQUIVO, eTipoValor.DATA)
		dr("IN02_NUM_REMESSA_DETRAN") = ProBanco(IN02_NUM_REMESSA_DETRAN, eTipoValor.CHAVE)
        dr("IN02_DATA_REMESSA_DETRAN") = ProBanco(IN02_DATA_REMESSA_DETRAN, eTipoValor.DATA)
        dr("IN02_NOME_ARQUIVO_ECARTA") = ProBanco(IN02_NOME_ARQUIVO_ECARTA, eTipoValor.TEXTO)


        cnn.SalvarDataTable(dr)

		dt.Dispose()
		dt = Nothing

        cnn = Nothing
	End Sub

	Public Sub Obter(ByVal Codigo as Integer)
		Dim cnn As New Conexao
		Dim dt As DataTable
		Dim dr As DataRow
		Dim strSQL As New StringBuilder
		
		strSQL.Append(" select * ")
		strSQL.Append(" from IN02_CONTROLE_CARGA")
		strSQL.Append(" where IN02_COD_NUMERO_ARQUIVO = " & Codigo)

		dt = cnn.AbrirDataTable(strSQL.ToString)

		If dt.Rows.Count > 0 Then
			dr = dt.Rows(0)
			
			IN02_COD_NUMERO_ARQUIVO = DoBanco(dr("IN02_COD_NUMERO_ARQUIVO"), eTipoValor.CHAVE)
			IN02_NUM_ARQUIVO = DoBanco(dr("IN02_NUM_ARQUIVO"), eTipoValor.CHAVE)
			IN02_DATA_CRIACAO_ARQUIVO = DoBanco(dr("IN02_DATA_CRIACAO_ARQUIVO"), eTipoValor.DATA)
			IN02_NUM_REMESSA_DETRAN = DoBanco(dr("IN02_NUM_REMESSA_DETRAN"), eTipoValor.CHAVE)
            IN02_DATA_REMESSA_DETRAN = DoBanco(dr("IN02_DATA_REMESSA_DETRAN"), eTipoValor.DATA)
            IN02_NOME_ARQUIVO_ECARTA = DoBanco(dr("IN02_NOME_ARQUIVO_ECARTA"), eTipoValor.TEXTO)
        End If

        cnn = Nothing
	End Sub

	Public Function Pesquisar(Optional ByVal Sort as String = "", Optional Codigo as Integer = 0, Optional NumArquivo as Integer = 0, Optional DataCriacaoArquivo as String = "", Optional NumRemessaDetran as Integer = 0, Optional DataRemessaDetran as Integer = 0) as DataTable
		Dim cnn As New Conexao
		Dim strSQL As New StringBuilder
		
		strSQL.Append(" select * ")
		strSQL.Append(" from IN02_CONTROLE_CARGA")
		'strSQL.Append(" left join tabela on coluna1 = coluna2 ")
		strSQL.Append(" where IN02_COD_NUMERO_ARQUIVO is not null")
		
		If Codigo > 0 then 
			strSQL.Append(" and IN02_COD_NUMERO_ARQUIVO = " & Codigo)
		End If
		
		If NumArquivo > 0 then 
			strSQL.Append(" and IN02_NUM_ARQUIVO = " & NumArquivo)
		End If
		
		If isDate(DataCriacaoArquivo) then 
			strSQL.Append(" and IN02_DATA_CRIACAO_ARQUIVO = Convert(DateTime, '" & DataCriacaoArquivo & "', 103)")
		End If
		
		If NumRemessaDetran > 0 then 
			strSQL.Append(" and IN02_NUM_REMESSA_DETRAN = " & NumRemessaDetran)
		End If
		
		If DataRemessaDetran > 0 then 
			strSQL.Append(" and IN02_DATA_REMESSA_DETRAN = " & DataRemessaDetran)
		End If
		
		strSQL.Append(" Order By " & IIf(Sort = "", "IN02_COD_NUMERO_ARQUIVO", Sort))

		Return cnn.AbrirDataTable(strSQL.ToString)
	End Function

	Public Function ObterTabela() as DataTable
		Dim cnn As New Conexao
		Dim dt As DataTable
		Dim strSQL As New StringBuilder
		
		strSQL.Append(" select IN02_COD_NUMERO_ARQUIVO as CODIGO, IN02_DATA_CRIACAO_ARQUIVO as DESCRICAO")
		strSQL.Append(" from IN02_CONTROLE_CARGA")
		strSQL.Append(" order by 2 ")

		dt = cnn.AbrirDataTable(strSQL.ToString)

        cnn = Nothing

		Return dt
	End Function

	Public Function ObterUltimo() as Integer
		Dim cnn As New Conexao
		Dim strSQL As New StringBuilder
		Dim CodigoUltimo As Integer

        strSQL.Append(" select max(IN02_NUM_ARQUIVO) from IN02_CONTROLE_CARGA")

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
	Public Function Excluir(ByVal Codigo as Integer) As Integer
		Dim cnn As New Conexao
		Dim strSQL As New StringBuilder
		Dim LinhasAfetadas As Integer
		
		strSQL.Append(" delete ")
		strSQL.Append(" from IN02_CONTROLE_CARGA")
		strSQL.Append(" where IN02_COD_NUMERO_ARQUIVO = " & Codigo)

		LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        cnn = Nothing

		Return LinhasAfetadas
	End Function

End Class