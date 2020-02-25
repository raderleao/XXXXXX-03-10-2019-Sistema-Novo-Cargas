Imports Microsoft.VisualBasic
Imports System.Data

Public Class Perfil
	Private AC03_COD_PERFIL as Integer
	Private FKAC03AC01_COD_APLICACAO as Integer
	Private AC03_DESCRICAO as String

	Public Property Codigo() as Integer
		Get
			Return AC03_COD_PERFIL
		End Get
		Set(ByVal Value As Integer)
			AC03_COD_PERFIL = Value
		End Set
	End Property
	Public Property Aplicacao() as Integer
		Get
			Return FKAC03AC01_COD_APLICACAO
		End Get
		Set(ByVal Value As Integer)
			FKAC03AC01_COD_APLICACAO = Value
		End Set
	End Property
	Public Property Descricao() as String
		Get
			Return AC03_DESCRICAO
		End Get
		Set(ByVal Value As String)
			AC03_DESCRICAO = Value
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
        strSQL.Append(" from AC03_PERFIL")
        strSQL.Append(" where AC03_COD_PERFIL = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("FKAC03AC01_COD_APLICACAO") = ProBanco(FKAC03AC01_COD_APLICACAO, eTipoValor.CHAVE)
        dr("AC03_DESCRICAO") = ProBanco(AC03_DESCRICAO, eTipoValor.TEXTO)

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
        strSQL.Append(" from AC03_PERFIL")
        strSQL.Append(" where AC03_COD_PERFIL = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AC03_COD_PERFIL = DoBanco(dr("AC03_COD_PERFIL"), eTipoValor.CHAVE)
            FKAC03AC01_COD_APLICACAO = DoBanco(dr("FKAC03AC01_COD_APLICACAO"), eTipoValor.CHAVE)
            AC03_DESCRICAO = DoBanco(dr("AC03_DESCRICAO"), eTipoValor.TEXTO)
        End If


        cnn = Nothing
    End Sub


    Public Function Pesquisar(Optional ByVal Sort As String = "", Optional Codigo As Integer = 0, Optional Aplicacao As Integer = 0, Optional Descricao As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from AC03_PERFIL")
        'strSQL.Append(" left join tabela on coluna1 = coluna2 ")
        strSQL.Append(" where AC03_COD_PERFIL is not null")

        If Codigo > 0 Then
            strSQL.Append(" and AC03_COD_PERFIL = " & Codigo)
        End If

        If Aplicacao > 0 Then
            strSQL.Append(" and FKAC03AC01_COD_APLICACAO = " & Aplicacao)
        End If

        If Descricao <> "" Then
            strSQL.Append(" and upper(AC03_DESCRICAO) like '%" & Descricao.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "AC03_COD_PERFIL", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela(Optional Aplicacao As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select AC03_COD_PERFIL as CODIGO, AC03_DESCRICAO as DESCRICAO")
        strSQL.Append(" from AC03_PERFIL")

        If Aplicacao > 0 Then
            strSQL.Append(" where FKAC03AC01_COD_APLICACAO = " & Aplicacao)
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

        strSQL.Append(" select max(AC03_COD_PERFIL) from AC03_PERFIL")

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
        strSQL.Append(" from AC03_PERFIL")
        strSQL.Append(" where AC03_COD_PERFIL = " & Codigo)

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

