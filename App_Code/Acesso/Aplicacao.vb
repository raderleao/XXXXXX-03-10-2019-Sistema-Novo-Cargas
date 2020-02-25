Imports Microsoft.VisualBasic
Imports System.Data

Public Class Aplicacao
	Private AC01_COD_APLICACAO as Integer
	Private AC01_DESCRICAO as String

	Public Property Codigo() as Integer
		Get
			Return AC01_COD_APLICACAO
		End Get
		Set(ByVal Value As Integer)
			AC01_COD_APLICACAO = Value
		End Set
	End Property
	Public Property Descricao() as String
		Get
			Return AC01_DESCRICAO
		End Get
		Set(ByVal Value As String)
			AC01_DESCRICAO = Value
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
		strSQL.Append(" from AC01_APLICACAO")
		strSQL.Append(" where AC01_COD_APLICACAO = " & Codigo)

		dt = cnn.EditarDataTable(strSQL.ToString)

		If dt.Rows.Count = 0 Then
			dr = dt.NewRow
		Else
			dr = dt.Rows(0)
		End If

		dr("AC01_DESCRICAO") = ProBanco(AC01_DESCRICAO, eTipoValor.TEXTO)

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
        strSQL.Append(" from AC01_APLICACAO")
        strSQL.Append(" where AC01_COD_APLICACAO = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AC01_COD_APLICACAO = DoBanco(dr("AC01_COD_APLICACAO"), eTipoValor.CHAVE)
            AC01_DESCRICAO = DoBanco(dr("AC01_DESCRICAO"), eTipoValor.TEXTO)
        End If


        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "", Optional Codigo As Integer = 0, Optional Descricao As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from AC01_APLICACAO")
        'strSQL.Append(" left join tabela on coluna1 = coluna2 ")
        strSQL.Append(" where AC01_COD_APLICACAO is not null")

        If Codigo > 0 Then
            strSQL.Append(" and AC01_COD_APLICACAO = " & Codigo)
        End If

        If Descricao <> "" Then
            strSQL.Append(" and upper(AC01_DESCRICAO) like '%" & Descricao.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "AC01_COD_APLICACAO", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select AC01_COD_APLICACAO as CODIGO, AC01_DESCRICAO as DESCRICAO")
        strSQL.Append(" from AC01_APLICACAO")
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)


        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(AC01_COD_APLICACAO) from AC01_APLICACAO")

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
        strSQL.Append(" from AC01_APLICACAO")
        strSQL.Append(" where AC01_COD_APLICACAO = " & Codigo)

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

