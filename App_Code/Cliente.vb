Imports Microsoft.VisualBasic
Imports System.Data

Public Class Cliente
    Private IN05_COD_CLIENTE As Integer
    Private IN05_NOME As String
    Private IN05_SIGLA As String
    Public Property Codigo() As Integer
        Get
            Return IN05_COD_CLIENTE
        End Get
        Set(ByVal Value As Integer)
            IN05_COD_CLIENTE = Value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return IN05_NOME
        End Get
        Set(ByVal Value As String)
            IN05_NOME = Value
        End Set
    End Property

    Public Property Sigla() As String
        Get
            Return IN05_SIGLA
        End Get
        Set(ByVal Value As String)
            IN05_SIGLA = Value
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
        strSQL.Append(" from IN05_CLIENTE")
        strSQL.Append(" where IN05_COD_CLIENTE = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("IN05_NOME") = ProBanco(IN05_NOME, eTipoValor.TEXTO)
        dr("IN05_SIGLA") = ProBanco(IN05_SIGLA, eTipoValor.TEXTO)
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
        strSQL.Append(" from IN05_CLIENTE")
        strSQL.Append(" where IN05_COD_CLIENTE = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            IN05_COD_CLIENTE = DoBanco(dr("IN05_COD_CLIENTE"), eTipoValor.CHAVE)
            IN05_NOME = DoBanco(dr("IN05_NOME"), eTipoValor.TEXTO)
            IN05_SIGLA = DoBanco(dr("IN05_SIGLA"), eTipoValor.TEXTO)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional Codigo As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from IN05_CLIENTE")
        strSQL.Append(" where IN05_COD_CLIENTE is not null")

        If Codigo > 0 Then
            strSQL.Append(" and IN05_COD_CLIENTE = " & Codigo)
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "IN05_COD_CLIENTE", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select IN05_COD_CLIENTE As CODIGO, IN05_NOME As DESCRICAO")
        strSQL.Append(" from IN05_CLIENTE")
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        cnn = Nothing

        Return dt
    End Function
    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" Select max(IN05_COD_CLIENTE) from IN05_CLIENTE")

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
        strSQL.Append(" from IN05_CLIENTE")
        strSQL.Append(" where IN05_COD_CLIENTE = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        cnn = Nothing

        Return LinhasAfetadas
    End Function
End Class
