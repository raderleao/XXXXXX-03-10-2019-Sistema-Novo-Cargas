Imports Microsoft.VisualBasic
Imports System.Data

Public Class PerfilFuncionalidade
	Private AC04_COD_PERFIL_FUNCIONALIDADE as Integer
	Private FKAC04AC02_COD_FUNCIONALIDADE as Integer
	Private FKAC04AC03_COD_PERFIL as Integer
    Private AC04_SOMENTE_LEITURA As Boolean

    Public Property Codigo() as Integer
		Get
			Return AC04_COD_PERFIL_FUNCIONALIDADE
		End Get
		Set(ByVal Value As Integer)
			AC04_COD_PERFIL_FUNCIONALIDADE = Value
		End Set
	End Property
	Public Property Funcionalidade() as Integer
		Get
			Return FKAC04AC02_COD_FUNCIONALIDADE
		End Get
		Set(ByVal Value As Integer)
			FKAC04AC02_COD_FUNCIONALIDADE = Value
		End Set
	End Property
	Public Property Perfil() as Integer
		Get
			Return FKAC04AC03_COD_PERFIL
		End Get
		Set(ByVal Value As Integer)
			FKAC04AC03_COD_PERFIL = Value
		End Set
	End Property
    Public Property SomenteLeitura() As Boolean
        Get
            Return AC04_SOMENTE_LEITURA
        End Get
        Set(ByVal Value As Boolean)
            AC04_SOMENTE_LEITURA = Value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Sub New(Optional ByVal Perfil As Integer = 0, Optional ByVal Funcionalidade As Integer = 0)
        If Funcionalidade > 0 And Perfil <> 0 Then
            ObterPerfilFuncionalidade(Perfil, Funcionalidade)
        End If
    End Sub

    Public Sub Salvar()
		Dim cnn As New Conexao
		Dim dt As DataTable
		Dim dr As DataRow
		Dim strSQL As New StringBuilder
		
		strSQL.Append(" select * ")
		strSQL.Append(" from AC04_PERFIL_FUNCIONALIDADE")
		strSQL.Append(" where AC04_COD_PERFIL_FUNCIONALIDADE = " & Codigo)

		dt = cnn.EditarDataTable(strSQL.ToString)

		If dt.Rows.Count = 0 Then
			dr = dt.NewRow
		Else
			dr = dt.Rows(0)
		End If

		dr("FKAC04AC02_COD_FUNCIONALIDADE") = ProBanco(FKAC04AC02_COD_FUNCIONALIDADE, eTipoValor.CHAVE)
		dr("FKAC04AC03_COD_PERFIL") = ProBanco(FKAC04AC03_COD_PERFIL, eTipoValor.CHAVE)
        dr("AC04_SOMENTE_LEITURA") = ProBanco(AC04_SOMENTE_LEITURA, eTipoValor.BOOLEANO)

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
        strSQL.Append(" from AC04_PERFIL_FUNCIONALIDADE")
        strSQL.Append(" where AC04_COD_PERFIL_FUNCIONALIDADE = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AC04_COD_PERFIL_FUNCIONALIDADE = DoBanco(dr("AC04_COD_PERFIL_FUNCIONALIDADE"), eTipoValor.CHAVE)
            FKAC04AC02_COD_FUNCIONALIDADE = DoBanco(dr("FKAC04AC02_COD_FUNCIONALIDADE"), eTipoValor.CHAVE)
            FKAC04AC03_COD_PERFIL = DoBanco(dr("FKAC04AC03_COD_PERFIL"), eTipoValor.CHAVE)
            AC04_SOMENTE_LEITURA = DoBanco(dr("AC04_SOMENTE_LEITURA"), eTipoValor.BOOLEANO)
        End If


        cnn = Nothing
    End Sub
    Public Sub ObterPerfilFuncionalidade(ByVal Perfil As Integer, ByVal Funcionalidade As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from AC04_PERFIL_FUNCIONALIDADE")
        strSQL.Append(" where FKAC04AC02_COD_FUNCIONALIDADE = " & Funcionalidade)
        strSQL.Append(" and FKAC04AC03_COD_PERFIL = " & Perfil)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AC04_COD_PERFIL_FUNCIONALIDADE = DoBanco(dr("AC04_COD_PERFIL_FUNCIONALIDADE"), eTipoValor.CHAVE)
            FKAC04AC02_COD_FUNCIONALIDADE = DoBanco(dr("FKAC04AC02_COD_FUNCIONALIDADE"), eTipoValor.CHAVE)
            FKAC04AC03_COD_PERFIL = DoBanco(dr("FKAC04AC03_COD_PERFIL"), eTipoValor.CHAVE)
            AC04_SOMENTE_LEITURA = DoBanco(dr("AC04_SOMENTE_LEITURA"), eTipoValor.TEXTO)
        End If

        '
        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional Codigo As Integer = 0,
                              Optional Funcionalidade As Integer = 0,
                              Optional Perfil As Integer = 0,
                              Optional Aplicacao As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from AC04_PERFIL_FUNCIONALIDADE")
        strSQL.Append(" left join AC03_PERFIL on AC03_COD_PERFIL =  FKAC04AC03_COD_PERFIL ")
        strSQL.Append(" left join AC02_FUNCIONALIDADE on AC02_COD_FUNCIONALIDADE = FKAC04AC02_COD_FUNCIONALIDADE ")
        strSQL.Append(" where AC04_COD_PERFIL_FUNCIONALIDADE is not null")

        If Codigo > 0 Then
            strSQL.Append(" and AC04_COD_PERFIL_FUNCIONALIDADE = " & Codigo)
        End If

        If Funcionalidade > 0 Then
            strSQL.Append(" and FKAC04AC02_COD_FUNCIONALIDADE = " & Funcionalidade)
        End If

        If Perfil > 0 Then
            strSQL.Append(" and FKAC04AC03_COD_PERFIL = " & Perfil)
        End If

        If Aplicacao > 0 Then
            strSQL.Append(" and FKAC03AC01_COD_APLICACAO = " & Aplicacao)
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "AC04_COD_PERFIL_FUNCIONALIDADE", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function Pesquisar2(Optional ByVal Sort As String = "", Optional ByVal Aplicacao As Integer = 0, Optional ByVal Funcionalidade As Integer = 0, Optional ByVal Perfil As Integer = 0, Optional ByVal SomenteLeitura As Boolean = False) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select *, ")
        strSQL.Append(" case AC04_SOMENTE_LEITURA when 0 then 'ESCRITA' else 'LEITURA' end ESCRITA_LEITURA ")
        strSQL.Append(" from AC04_PERFIL_FUNCIONALIDADE")
        strSQL.Append(" left join AC03_PERFIL on AC03_COD_PERFIL = FKAC04AC03_COD_PERFIL ")
        strSQL.Append(" left join AC02_FUNCIONALIDADE on AC02_COD_FUNCIONALIDADE = FKAC04AC02_COD_FUNCIONALIDADE ")
        strSQL.Append(" where FKAC04AC02_COD_FUNCIONALIDADE is not null")

        If Aplicacao > 0 Then
            strSQL.Append(" and FKAC03AC01_COD_APLICACAO = " & Aplicacao)
        End If

        If Funcionalidade > 0 Then
            strSQL.Append(" and FKAC04AC02_COD_FUNCIONALIDADE = " & Funcionalidade)
        End If

        If Perfil > 0 Then
            strSQL.Append(" and FKAC04AC03_COD_PERFIL = " & Perfil)
        End If

        If SomenteLeitura Then
            strSQL.Append(" and AC04_SOMENTE_LEITURA = 1")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "AC03_DESCRICAO, AC02_DESCRICAO", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select AC04_COD_PERFIL_FUNCIONALIDADE as CODIGO, ")
        strSQL.Append(" from AC04_PERFIL_FUNCIONALIDADE")
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)


        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(AC04_COD_PERFIL_FUNCIONALIDADE) from AC04_PERFIL_FUNCIONALIDADE")

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
        strSQL.Append(" from AC04_PERFIL_FUNCIONALIDADE")
        strSQL.Append(" where AC04_COD_PERFIL_FUNCIONALIDADE = " & Codigo)

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

