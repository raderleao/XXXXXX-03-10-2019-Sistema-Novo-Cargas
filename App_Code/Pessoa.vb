Imports Microsoft.VisualBasic
Imports System.Data

Public Class Pessoa
	Private AL01_COD_PESSOA as Integer
	Private FKAL01CG09_COD_CATEGORIA_CNH as Integer
    Private FKAL01CG11_COD_BAIRRO As Integer
    Private FKAL01AL01_COD_PESSOA As Integer
    Private AL01_NOME As String
    Private AL01_CPF As String
    Private AL01_RG As String
    Private AL01_CNH As String
    Private AL01_LOGRADOURO As String
    Private AL01_PAI As String
    Private AL01_MAE As String
    Private AL01_FOTO As String

    Public Property Codigo() As Integer
        Get
            Return AL01_COD_PESSOA
        End Get
        Set(ByVal Value As Integer)
            AL01_COD_PESSOA = Value
        End Set
    End Property
    Public Property CategoriaCnh() As Integer
        Get
            Return FKAL01CG09_COD_CATEGORIA_CNH
        End Get
        Set(ByVal Value As Integer)
            FKAL01CG09_COD_CATEGORIA_CNH = Value
        End Set
    End Property
    Public Property Bairro() As Integer
        Get
            Return FKAL01CG11_COD_BAIRRO
        End Get
        Set(ByVal Value As Integer)
            FKAL01CG11_COD_BAIRRO = Value
        End Set
    End Property
    Public Property PessoaAlvara() As Integer
        Get
            Return FKAL01AL01_COD_PESSOA
        End Get
        Set(ByVal Value As Integer)
            FKAL01AL01_COD_PESSOA = Value
        End Set
    End Property
    Public Property Nome() As String
        Get
            Return AL01_NOME
        End Get
        Set(ByVal Value As String)
            AL01_NOME = Value
        End Set
    End Property
    Public Property Cpf() As String
        Get
            Return AL01_CPF
        End Get
        Set(ByVal Value As String)
            AL01_CPF = Value
        End Set
    End Property
    Public Property Rg() As String
        Get
            Return AL01_RG
        End Get
        Set(ByVal Value As String)
            AL01_RG = Value
        End Set
    End Property
    Public Property Cnh() As String
        Get
            Return AL01_CNH
        End Get
        Set(ByVal Value As String)
            AL01_CNH = Value
        End Set
    End Property
    Public Property Logradouro() As String
        Get
            Return AL01_LOGRADOURO
        End Get
        Set(ByVal Value As String)
            AL01_LOGRADOURO = Value
        End Set
    End Property
    Public Property Pai() As String
        Get
            Return AL01_PAI
        End Get
        Set(ByVal Value As String)
            AL01_PAI = Value
        End Set
    End Property
    Public Property Mae() As String
        Get
            Return AL01_MAE
        End Get
        Set(ByVal Value As String)
            AL01_MAE = Value
        End Set
    End Property
    Public Property Foto() As String
        Get
            Return AL01_FOTO
        End Get
        Set(ByVal Value As String)
            AL01_FOTO = Value
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
        strSQL.Append(" from AL01_PESSOA")
        strSQL.Append(" where AL01_COD_PESSOA = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("FKAL01CG09_COD_CATEGORIA_CNH") = ProBanco(FKAL01CG09_COD_CATEGORIA_CNH, eTipoValor.CHAVE)
        dr("FKAL01CG11_COD_BAIRRO") = ProBanco(FKAL01CG11_COD_BAIRRO, eTipoValor.CHAVE)
        dr("FKAL01AL01_COD_PESSOA") = ProBanco(FKAL01AL01_COD_PESSOA, eTipoValor.CHAVE)
        dr("AL01_NOME") = ProBanco(AL01_NOME, eTipoValor.TEXTO)
        dr("AL01_CPF") = ProBanco(AL01_CPF, eTipoValor.TEXTO)
        dr("AL01_RG") = ProBanco(AL01_RG, eTipoValor.TEXTO)
        dr("AL01_CNH") = ProBanco(AL01_CNH, eTipoValor.TEXTO)
        dr("AL01_LOGRADOURO") = ProBanco(AL01_LOGRADOURO, eTipoValor.TEXTO)
        dr("AL01_PAI") = ProBanco(AL01_PAI, eTipoValor.TEXTO)
        dr("AL01_MAE") = ProBanco(AL01_MAE, eTipoValor.TEXTO)
        dr("AL01_FOTO") = ProBanco(AL01_FOTO, eTipoValor.TEXTO)

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
        strSQL.Append(" from AL01_PESSOA")
        strSQL.Append(" where AL01_COD_PESSOA = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            AL01_COD_PESSOA = DoBanco(dr("AL01_COD_PESSOA"), eTipoValor.CHAVE)
            FKAL01CG09_COD_CATEGORIA_CNH = DoBanco(dr("FKAL01CG09_COD_CATEGORIA_CNH"), eTipoValor.CHAVE)
            FKAL01CG11_COD_BAIRRO = DoBanco(dr("FKAL01CG11_COD_BAIRRO"), eTipoValor.CHAVE)
            FKAL01AL01_COD_PESSOA = DoBanco(dr("FKAL01AL01_COD_PESSOA"), eTipoValor.CHAVE)
            AL01_NOME = DoBanco(dr("AL01_NOME"), eTipoValor.TEXTO)
            AL01_CPF = DoBanco(dr("AL01_CPF"), eTipoValor.TEXTO)
            AL01_RG = DoBanco(dr("AL01_RG"), eTipoValor.TEXTO)
            AL01_CNH = DoBanco(dr("AL01_CNH"), eTipoValor.TEXTO)
            AL01_LOGRADOURO = DoBanco(dr("AL01_LOGRADOURO"), eTipoValor.TEXTO)
            AL01_PAI = DoBanco(dr("AL01_PAI"), eTipoValor.TEXTO)
            AL01_MAE = DoBanco(dr("AL01_MAE"), eTipoValor.TEXTO)
            AL01_FOTO = DoBanco(dr("AL01_FOTO"), eTipoValor.TEXTO)
        End If


        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional Codigo As Integer = 0,
                              Optional CategoriaCnh As Integer = 0,
                              Optional Bairro As Integer = 0,
                              Optional PessoaAlvara As Integer = 0,
                              Optional Nome As String = "",
                              Optional Cpf As String = "",
                              Optional Rg As String = "",
                              Optional Cnh As String = "",
                              Optional Logradouro As String = "",
                              Optional Pai As String = "",
                              Optional Mae As String = "",
                              Optional Foto As String = "",
                              Optional NaoIncluir As Integer = 0,
                              Optional SomenteProprietario As Boolean = False) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append("SELECT * FROM ( ")
        strSQL.Append(" select AL01_COD_PESSOA, FKAL01AL01_COD_PESSOA, FKAL01CG09_COD_CATEGORIA_CNH, AL01_NOME, AL01_CPF, AL01_CNH, CG09_DESCRICAO")
        strSQL.Append(" , iif(FKAL01AL01_COD_PESSOA is null, 'PROPRIETARIO', 'SUBSTITUTO') AS PESSOA_ALVARA,  REPLACE(REPLACE(AL01_CPF,'.',''),'-','') AS CPF ")
        strSQL.Append(" from AL01_PESSOA")
        strSQL.Append(" left join CG09_CATEGORIA_CNH on CG09_COD_CATEGORIA_CNH = FKAL01CG09_COD_CATEGORIA_CNH ")
        strSQL.Append(" ) as Pessoa ")
        strSQL.Append(" where AL01_COD_PESSOA is not null")

        If Codigo > 0 Then
            strSQL.Append(" and AL01_COD_PESSOA = " & Codigo)
        End If

        If CategoriaCnh > 0 Then
            strSQL.Append(" and FKAL01CG09_COD_CATEGORIA_CNH = " & CategoriaCnh)
        End If

        If Bairro > 0 Then
            strSQL.Append(" and FKAL01CG11_COD_BAIRRO = " & Bairro)
        End If

        If PessoaAlvara > 0 Then
            strSQL.Append(" and FKAL01AL01_COD_PESSOA = " & PessoaAlvara)
        End If

        If Nome <> "" Then
            strSQL.Append(" and upper(AL01_NOME) like '%" & Nome.ToUpper & "%'")
        End If

        If Cpf <> "" Then
            strSQL.Append(" and CPF like '%" & Cpf & "%'")
        End If

        If Rg <> "" Then
            strSQL.Append(" and upper(AL01_RG) like '%" & Rg.ToUpper & "%'")
        End If

        If Cnh <> "" Then
            strSQL.Append(" and upper(AL01_CNH) like '%" & Cnh.ToUpper & "%'")
        End If

        If Logradouro <> "" Then
            strSQL.Append(" and upper(AL01_LOGRADOURO) like '%" & Logradouro.ToUpper & "%'")
        End If

        If Pai <> "" Then
            strSQL.Append(" and upper(AL01_PAI) like '%" & Pai.ToUpper & "%'")
        End If

        If Mae <> "" Then
            strSQL.Append(" and upper(AL01_MAE) like '%" & Mae.ToUpper & "%'")
        End If

        If Foto <> "" Then
            strSQL.Append(" and upper(AL01_FOTO) like '%" & Foto.ToUpper & "%'")
        End If

        If NaoIncluir > 0 Then
            strSQL.Append(" and AL01_COD_PESSOA <> " & NaoIncluir)
        End If

        If SomenteProprietario Then
            strSQL.Append(" and PESSOA_ALVARA = 'PROPRIETARIO' ")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "AL01_COD_PESSOA", Sort))

            Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select AL01_COD_PESSOA as CODIGO, AL01_NOME as DESCRICAO")
        strSQL.Append(" from AL01_PESSOA")
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)


        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(AL01_COD_PESSOA) from AL01_PESSOA")

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
        strSQL.Append(" from AL01_PESSOA")
        strSQL.Append(" where AL01_COD_PESSOA = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)


        cnn = Nothing

		Return LinhasAfetadas
	End Function

End Class
