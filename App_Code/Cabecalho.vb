Imports Microsoft.VisualBasic
Imports System.Data

Public Class Cabecalho
    Private IN03_COD_CABECALHO As Integer
    Private FKIN03IN04_COD_NAT_NIP As Integer
    Private IN03_TIPO As Integer
    Private IN03_DESCRICAO_ARQUIVO As String
    Private IN03_DATA_GERACAO As String
    Private IN03_NUMERO_REMESSA As String
    Private IN03_DATA_REMESSA As String
    Private IN03_CNPJ As String
    Private IN03_DH_IMPORTADO As String
    Private IN03_COD_CABECALHO_1 As Integer

    Public Property Codigo() As Integer
        Get
            Return IN03_COD_CABECALHO
        End Get
        Set(ByVal Value As Integer)
            IN03_COD_CABECALHO = Value
        End Set
    End Property
    Public Property NatNip() As Integer
        Get
            Return FKIN03IN04_COD_NAT_NIP
        End Get
        Set(ByVal Value As Integer)
            FKIN03IN04_COD_NAT_NIP = Value
        End Set
    End Property
    Public Property Tipo() As Integer
        Get
            Return IN03_TIPO
        End Get
        Set(ByVal Value As Integer)
            IN03_TIPO = Value
        End Set
    End Property
    Public Property Descricao() As String
        Get
            Return IN03_DESCRICAO_ARQUIVO
        End Get
        Set(ByVal Value As String)
            IN03_DESCRICAO_ARQUIVO = Value
        End Set
    End Property
    Public Property DataGeracao() As String
        Get
            Return IN03_DATA_GERACAO
        End Get
        Set(ByVal Value As String)
            IN03_DATA_GERACAO = Value
        End Set
    End Property
    Public Property NumeroRemessa() As String
        Get
            Return IN03_NUMERO_REMESSA
        End Get
        Set(ByVal Value As String)
            IN03_NUMERO_REMESSA = Value
        End Set
    End Property
    Public Property DataRemessa() As String
        Get
            Return IN03_DATA_REMESSA
        End Get
        Set(ByVal Value As String)
            IN03_DATA_REMESSA = Value
        End Set
    End Property
    Public Property Cnpj() As String
        Get
            Return IN03_CNPJ
        End Get
        Set(ByVal Value As String)
            IN03_CNPJ = Value
        End Set
    End Property

    Public Property DataHoraImportado() As String
        Get
            Return IN03_DH_IMPORTADO
        End Get
        Set(ByVal Value As String)
            IN03_DH_IMPORTADO = Value
        End Set
    End Property

    Public Property CodigoRecursivo() As Integer
        Get
            Return IN03_COD_CABECALHO_1
        End Get
        Set(ByVal Value As Integer)
            IN03_COD_CABECALHO_1 = Value
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
        strSQL.Append(" from IN03_CABECALHO")
        strSQL.Append(" where IN03_COD_CABECALHO = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("FKIN03IN04_COD_NAT_NIP") = ProBanco(FKIN03IN04_COD_NAT_NIP, eTipoValor.CHAVE)
        dr("IN03_TIPO") = ProBanco(IN03_TIPO, eTipoValor.CHAVE)
        dr("IN03_DESCRICAO_ARQUIVO") = ProBanco(IN03_DESCRICAO_ARQUIVO, eTipoValor.TEXTO)
        dr("IN03_DATA_GERACAO") = ProBanco(IN03_DATA_GERACAO, eTipoValor.TEXTO)
        dr("IN03_NUMERO_REMESSA") = ProBanco(IN03_NUMERO_REMESSA, eTipoValor.TEXTO)
        dr("IN03_DATA_REMESSA") = ProBanco(IN03_DATA_REMESSA, eTipoValor.TEXTO)
        dr("IN03_CNPJ") = ProBanco(IN03_CNPJ, eTipoValor.TEXTO)
        dr("IN03_DH_IMPORTADO") = ProBanco(IN03_DH_IMPORTADO, eTipoValor.DATA_COMPLETA)
        dr("IN03_COD_CABECALHO_1") = ProBanco(IN03_COD_CABECALHO_1, eTipoValor.CHAVE)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing


        cnn = Nothing
    End Sub

    Public Sub SalvarCabecalhoProcessado(ByVal Cabecalho As Integer, ByVal Cliente As Integer, ByVal NatNip As Integer)
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" update IN03_CABECALHO ")
        strSQL.Append(" set IN03_COD_CABECALHO_1 = " & Cabecalho)
        strSQL.Append(" from IN04_NAT_NIP ")
        strSQL.Append(" where  FKIN03IN04_COD_NAT_NIP = IN04_COD_NAT_NIP ")
        strSQL.Append(" and FKIN04IN05_COD_CLIENTE = " & Cliente)
        strSQL.Append(" And IN04_COD_NAT_NIP = " & NatNip)
        strSQL.Append(" And IN03_COD_CABECALHO_1  is null")

        cnn.EditarDataTable(strSQL.ToString)

        cnn = Nothing

    End Sub

    Public Sub Obter(ByVal Codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from IN03_CABECALHO")
        strSQL.Append(" where IN03_COD_CABECALHO = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            IN03_COD_CABECALHO = DoBanco(dr("IN03_COD_CABECALHO"), eTipoValor.CHAVE)
            FKIN03IN04_COD_NAT_NIP = DoBanco(dr("FKIN03IN04_COD_NAT_NIP"), eTipoValor.CHAVE)
            IN03_TIPO = DoBanco(dr("IN03_TIPO"), eTipoValor.CHAVE)
            IN03_DESCRICAO_ARQUIVO = DoBanco(dr("IN03_DESCRICAO_ARQUIVO"), eTipoValor.TEXTO)
            IN03_DATA_GERACAO = DoBanco(dr("IN03_DATA_GERACAO"), eTipoValor.TEXTO)
            IN03_NUMERO_REMESSA = DoBanco(dr("IN03_NUMERO_REMESSA"), eTipoValor.TEXTO)
            IN03_DATA_REMESSA = DoBanco(dr("IN03_DATA_REMESSA"), eTipoValor.TEXTO)
            IN03_CNPJ = DoBanco(dr("IN03_CNPJ"), eTipoValor.TEXTO)
            IN03_DH_IMPORTADO = DoBanco(dr("IN03_DH_IMPORTADO"), eTipoValor.DATA_COMPLETA)
            IN03_COD_CABECALHO_1 = DoBanco(dr("IN03_COD_CABECALHO_1"), eTipoValor.CHAVE)
        End If


        cnn = Nothing
    End Sub

    Public Function ObterRemessa(ByVal Remessa As String, ByVal DescArquivo As String) As Boolean
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder
        Dim Existe As Boolean = False

        strSQL.Append(" select * ")
        strSQL.Append(" from IN03_CABECALHO")
        strSQL.Append(" where IN03_NUMERO_REMESSA = " & Remessa)
        strSQL.Append(" AND IN03_DESCRICAO_ARQUIVO = " & DescArquivo)


        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            Existe = True
        End If

        Return Existe
        cnn = Nothing
    End Function

    Public Function Pesquisar(Optional ByVal Sort As String = "", Optional Codigo As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from IN03_CABECALHO")
        'strSQL.Append(" left join tabela on coluna1 = coluna2 ")
        strSQL.Append(" where IN03_COD_CABECALHO is not null")

        If Codigo > 0 Then
            strSQL.Append(" and IN03_COD_CABECALHO = " & Codigo)
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "IN03_COD_CABECALHO", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function PesquisarDistinct(ByVal Cliente As Integer, ByVal NatNip As Integer) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select distinct IN03_NUMERO_REMESSA, IN04_NOME, IN04_COD_NAT_NIP, IN03_DATA_REMESSA, IN03_COD_CABECALHO ")
        strSQL.Append(" From IN01_TABELAO_INFRACAO ")
        strSQL.Append(" Left Join IN03_CABECALHO on IN03_COD_CABECALHO = FKIN01IN03_COD_CABECALHO ")
        strSQL.Append(" Left Join IN04_NAT_NIP on IN04_COD_NAT_NIP = FKIN03IN04_COD_NAT_NIP ")
        strSQL.Append(" where FKIN04IN05_COD_CLIENTE = " & Cliente)
        strSQL.Append(" And IN04_COD_NAT_NIP = " & NatNip)
        strSQL.Append(" And  IN03_COD_CABECALHO_1 Is null ")

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select IN03_COD_CABECALHO as CODIGO, IN03_DESCRICAO_ARQUIVO as DESCRICAO")
        strSQL.Append(" from IN03_CABECALHO")
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)


        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(IN03_COD_CABECALHO) from IN03_CABECALHO")

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
        strSQL.Append(" from IN03_CABECALHO")
        strSQL.Append(" where IN03_COD_CABECALHO = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)


        cnn = Nothing

        Return LinhasAfetadas
    End Function

End Class


