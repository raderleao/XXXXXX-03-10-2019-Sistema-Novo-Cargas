Imports Microsoft.VisualBasic
Imports System.Data

Public Class Cidade

    Private CG02_COD_CIDADE As Integer
    Private FKCG02CG01_COD_ESTADO As Integer
    Private CG02_DESCRICAO As String

    Public Property Codigo() As Integer
        Get
            Return CG02_COD_CIDADE
        End Get
        Set(ByVal Value As Integer)
            CG02_COD_CIDADE = Value
        End Set
    End Property
    Public Property Estado() As Integer
        Get
            Return FKCG02CG01_COD_ESTADO
        End Get
        Set(ByVal Value As Integer)
            FKCG02CG01_COD_ESTADO = Value
        End Set
    End Property
    Public Property Cidade() As String
        Get
            Return CG02_DESCRICAO
        End Get
        Set(ByVal Value As String)
            CG02_DESCRICAO = Value
        End Set
    End Property

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub


    'Public Sub Salvar()
    '    Dim cnn As New Conexao
    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    Dim strSQL As New StringBuilder

    '    strSQL.Append(" select * ")
    '    strSQL.Append(" from CG02_CIDADE")
    '    strSQL.Append(" where CG02_COD_CIDADE = " & Codigo)

    '    dt = cnn.EditarDataTable(strSQL.ToString)

    '    If dt.Rows.Count = 0 Then
    '        dr = dt.NewRow
    '    Else
    '        dr = dt.Rows(0)
    '    End If

    '    dr("FKCG02CG01_COD_ESTADO") = ProBanco(FKCG02CG01_COD_ESTADO, eTipoValor.CHAVE)
    '    dr("CG02_DESCRICAO") = ProBanco(CG02_DESCRICAO, eTipoValor.TEXTO)

    '    cnn.SalvarDataTable(dr)

    '    dt.Dispose()
    '    dt = Nothing


    '    cnn = Nothing
    'End Sub

    Public Sub Obter(ByVal Codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CG02_CIDADE")
        strSQL.Append(" where CG02_COD_CIDADE = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            CG02_COD_CIDADE = DoBanco(dr("CG02_COD_CIDADE"), eTipoValor.CHAVE)
            FKCG02CG01_COD_ESTADO = DoBanco(dr("FKCG02CG01_COD_ESTADO"), eTipoValor.CHAVE)
            CG02_DESCRICAO = DoBanco(dr("CG02_DESCRICAO"), eTipoValor.TEXTO)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional ByVal Codigo As Integer = 0,
                              Optional ByVal Estado As Integer = 0,
                              Optional ByVal Descricao As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CG02_CIDADE")
        'strSQL.Append(" left join tabela on coluna1 = coluna2 ")
        strSQL.Append(" where CG02_COD_CIDADE is not null")

        If Codigo > 0 Then
            strSQL.Append(" and CG02_COD_CIDADE = " & Codigo)
        End If

        If Estado > 0 Then
            strSQL.Append(" and FKCG02CG01_COD_ESTADO = " & Estado)
        End If

        If Descricao <> "" Then
            strSQL.Append(" and upper(CG02_DESCRICAO) like '%" & Descricao.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "CG02_COD_CIDADE", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function


    Public Function ObterTabela(Optional ByVal Estado As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select CG02_COD_CIDADE as CODIGO, CG02_DESCRICAO as DESCRICAO")
        strSQL.Append(" from CG02_CIDADE")
        strSQL.Append(" where CG02_COD_CIDADE is not null")

        If Estado > 0 Then
            strSQL.Append(" and FKCG02CG01_COD_ESTADO = " & Estado)
        Else
            strSQL.Append(" and FKCG02CG01_COD_ESTADO = 10")
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

        strSQL.Append(" select max(CG02_COD_CIDADE) from CG02_CIDADE")

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

    'Public Function Excluir(ByVal Codigo As Integer) As Integer
    '    Dim cnn As New Conexao
    '    Dim strSQL As New StringBuilder
    '    Dim LinhasAfetadas As Integer

    '    strSQL.Append(" delete ")
    '    strSQL.Append(" from CG02_CIDADE")
    '    strSQL.Append(" where CG02_COD_CIDADE = " & Codigo)

    '    LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)


    '    cnn = Nothing

    '    Return LinhasAfetadas
    'End Function



End Class
