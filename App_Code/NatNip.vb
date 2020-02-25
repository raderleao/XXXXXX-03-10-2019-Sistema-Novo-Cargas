Imports Microsoft.VisualBasic
Imports System.Data

Public Class NatNip
    Private IN04_COD_NAT_NIP As Integer
    Private FKIN04IN05_COD_CLIENTE As Integer
    Private IN04_NOME As String
    Private IN04_CARTAO_POSTAGEM As String
    Private IN04_NUMERO_CONTRATO As String
    Private IN04_SERVICO_ADICIONAL As String
    Private IN04_IDENTIFIC_ARQ_SPOOL As String
    Private IN04_NOME_ARQ_SPOOL As String
    Private IN04_IDENTIFIC_ARQ_COMPLEM As String
    Private IN04_NOME_ARQ_COMPLEM As String
    Private IN04_NUM_END_DESTINATARIO As String
    Private IN04_COMPLEM_END_DESTINATARIO As String
    Public Property Codigo() As Integer
        Get
            Return IN04_COD_NAT_NIP
        End Get
        Set(ByVal Value As Integer)
            IN04_COD_NAT_NIP = Value
        End Set
    End Property

    Public Property Cliente() As Integer
        Get
            Return FKIN04IN05_COD_CLIENTE
        End Get
        Set(ByVal Value As Integer)
            FKIN04IN05_COD_CLIENTE = Value
        End Set
    End Property


    Public Property Nome() As String
        Get
            Return IN04_NOME
        End Get
        Set(ByVal Value As String)
            IN04_NOME = Value
        End Set
    End Property

    Public Property CartaoPostagem() As String
        Get
            Return IN04_CARTAO_POSTAGEM
        End Get
        Set(ByVal Value As String)
            IN04_CARTAO_POSTAGEM = Value
        End Set
    End Property

    Public Property NumeroContrato() As String
        Get
            Return IN04_NUMERO_CONTRATO
        End Get
        Set(ByVal Value As String)
            IN04_NUMERO_CONTRATO = Value
        End Set
    End Property

    Public Property ServicoAdicional() As String
        Get
            Return IN04_SERVICO_ADICIONAL
        End Get
        Set(ByVal Value As String)
            IN04_SERVICO_ADICIONAL = Value
        End Set
    End Property

    Public Property IdentificadorArquivoSpool() As String
        Get
            Return IN04_IDENTIFIC_ARQ_SPOOL
        End Get
        Set(ByVal Value As String)
            IN04_IDENTIFIC_ARQ_SPOOL = Value
        End Set
    End Property

    Public Property NomeArquivoSpool() As String
        Get
            Return IN04_NOME_ARQ_SPOOL
        End Get
        Set(ByVal Value As String)
            IN04_NOME_ARQ_SPOOL = Value
        End Set
    End Property

    Public Property IdentificadorArquivoComplementar() As String
        Get
            Return IN04_IDENTIFIC_ARQ_COMPLEM
        End Get
        Set(ByVal Value As String)
            IN04_IDENTIFIC_ARQ_COMPLEM = Value
        End Set
    End Property

    Public Property NomeArquivoComplementar() As String
        Get
            Return IN04_NOME_ARQ_COMPLEM
        End Get
        Set(ByVal Value As String)
            IN04_NOME_ARQ_COMPLEM = Value
        End Set
    End Property

    Public Property NumeroEnderoDestinatario() As String
        Get
            Return IN04_NUM_END_DESTINATARIO
        End Get
        Set(ByVal Value As String)
            IN04_NUM_END_DESTINATARIO = Value
        End Set
    End Property

    Public Property ComplementoEnderecoDestinatario() As String
        Get
            Return IN04_COMPLEM_END_DESTINATARIO
        End Get
        Set(ByVal Value As String)
            IN04_COMPLEM_END_DESTINATARIO = Value
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
        strSQL.Append(" from IN04_NAT_NIP")
        strSQL.Append(" where IN04_COD_NAT_NIP = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("FKIN04IN05_COD_CLIENTE") = ProBanco(FKIN04IN05_COD_CLIENTE, eTipoValor.CHAVE)
        dr("IN04_NOME") = ProBanco(IN04_NOME, eTipoValor.TEXTO)
        dr("IN04_CARTAO_POSTAGEM") = ProBanco(IN04_CARTAO_POSTAGEM, eTipoValor.TEXTO)
        dr("IN04_NUMERO_CONTRATO") = ProBanco(IN04_NUMERO_CONTRATO, eTipoValor.TEXTO)
        dr("IN04_SERVICO_ADICIONAL") = ProBanco(IN04_SERVICO_ADICIONAL, eTipoValor.TEXTO)
        dr("IN04_IDENTIFIC_ARQ_SPOOL") = ProBanco(IN04_IDENTIFIC_ARQ_SPOOL, eTipoValor.TEXTO)
        dr("IN04_NOME_ARQ_SPOOL") = ProBanco(IN04_NOME_ARQ_SPOOL, eTipoValor.TEXTO)
        dr("IN04_IDENTIFIC_ARQ_COMPLEM") = ProBanco(IN04_IDENTIFIC_ARQ_COMPLEM, eTipoValor.TEXTO)
        dr("IN04_NOME_ARQ_COMPLEM") = ProBanco(IN04_NOME_ARQ_COMPLEM, eTipoValor.TEXTO)
        dr("IN04_NUM_END_DESTINATARIO") = ProBanco(IN04_NUM_END_DESTINATARIO, eTipoValor.TEXTO)
        dr("IN04_COMPLEM_END_DESTINATARIO") = ProBanco(IN04_COMPLEM_END_DESTINATARIO, eTipoValor.TEXTO)
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
        strSQL.Append(" from IN04_NAT_NIP")
        strSQL.Append(" where IN04_COD_NAT_NIP = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            IN04_COD_NAT_NIP = DoBanco(dr("IN04_COD_NAT_NIP"), eTipoValor.CHAVE)
            FKIN04IN05_COD_CLIENTE = DoBanco(dr("FKIN04IN05_COD_CLIENTE"), eTipoValor.CHAVE)
            IN04_NOME = DoBanco(dr("IN04_NOME"), eTipoValor.TEXTO)
            IN04_CARTAO_POSTAGEM = DoBanco(dr("IN04_CARTAO_POSTAGEM"), eTipoValor.TEXTO)
            IN04_NUMERO_CONTRATO = DoBanco(dr("IN04_NUMERO_CONTRATO"), eTipoValor.TEXTO)
            IN04_SERVICO_ADICIONAL = DoBanco(dr("IN04_SERVICO_ADICIONAL"), eTipoValor.TEXTO)
            IN04_IDENTIFIC_ARQ_SPOOL = DoBanco(dr("IN04_IDENTIFIC_ARQ_SPOOL"), eTipoValor.TEXTO)
            IN04_NOME_ARQ_SPOOL = DoBanco(dr("IN04_NOME_ARQ_SPOOL"), eTipoValor.TEXTO)
            IN04_IDENTIFIC_ARQ_COMPLEM = DoBanco(dr("IN04_IDENTIFIC_ARQ_COMPLEM"), eTipoValor.TEXTO)
            IN04_NOME_ARQ_COMPLEM = DoBanco(dr("IN04_NOME_ARQ_COMPLEM"), eTipoValor.TEXTO)
            IN04_NUM_END_DESTINATARIO = DoBanco(dr("IN04_NUM_END_DESTINATARIO"), eTipoValor.TEXTO)
            IN04_COMPLEM_END_DESTINATARIO = DoBanco(dr("IN04_COMPLEM_END_DESTINATARIO"), eTipoValor.TEXTO)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional Codigo As Integer = 0,
                              Optional Sigla As String = "",
                              Optional NatNip As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from IN04_NAT_NIP")
        strSQL.Append(" left join  IN05_CLIENTE on IN05_COD_CLIENTE = FKIN04IN05_COD_CLIENTE")
        strSQL.Append(" where IN04_COD_NAT_NIP is not null")

        If Codigo > 0 Then
            strSQL.Append(" and IN04_COD_NAT_NIP = " & Codigo)
        End If

        If Sigla <> "" Then
            strSQL.Append(" and IN05_SIGLA = '" & Sigla & "'")
        End If

        If NatNip <> "" Then
            strSQL.Append(" and IN04_NOME = '" & NatNip & "'")
        End If


        strSQL.Append(" Order By " & IIf(Sort = "", "IN04_COD_NAT_NIP", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela(Optional Cliente As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select IN04_COD_NAT_NIP As CODIGO, IN04_NOME As DESCRICAO")
        strSQL.Append(" from IN04_NAT_NIP")
        strSQL.Append(" where IN04_COD_NAT_NIP is not null")

        If Cliente > 0 Then
            strSQL.Append(" and FKIN04IN05_COD_CLIENTE = " & Cliente)
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

        strSQL.Append(" Select max(IN04_COD_NAT_NIP) from IN04_NAT_NIP")

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
        strSQL.Append(" from IN04_NAT_NIP")
        strSQL.Append(" where IN04_COD_NAT_NIP = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        cnn = Nothing

        Return LinhasAfetadas
    End Function

End Class
