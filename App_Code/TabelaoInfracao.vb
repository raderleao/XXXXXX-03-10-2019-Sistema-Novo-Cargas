Imports Microsoft.VisualBasic
Imports System.Data

Public Class TabelaoInfracao
    Private IN01_COD_TABELAO_INFRACAO As Integer
    Private FKIN01IN03_COD_CABECALHO As Integer
    Private IN01_TIPO_INFRACAO As Integer
    Private IN01_TipoRegistro As Integer
    Private IN01_COD_LOCAL_OCORRENCIA As String
    Private IN01_NUM_REMESSA As Integer
    Private IN01_DATA_REMESSA As String
    Private IN01_COD_ORGAO_AUTUADOR As Integer
    Private IN01_DES_ORGAO_AUTUADOR As String
    Private IN01_AUTO_INFRACAO As String
    Private IN01_DATA_HORA_COMETIMENTO As String
    Private IN01_LOCAL_COMETIMENTO As String
    Private IN01_PLACA_VEICULO As String
    Private IN01_UF_PLACA As String
    Private IN01_IDENTIFICACAO_AGENTE As String
    Private IN01_DES_MODELO As String
    Private IN01_CATEGORIA_VEICULO As String
    Private IN01_TIPO_VEICULO As String
    Private IN01_COR_VEICULO As String
    Private IN01_DATA_AFERICAO As String
    Private IN01_PROPRIETARIO As String
    Private IN01_ENDERECO As String
    Private IN01_COMPLEMENTO_BAIRRO As String
    Private IN01_CEP As Integer
    Private IN01_CIDADE As String
    Private IN01_UF_ENDERECO As String
    Private IN01_DES_INFRACAO As String
    Private IN01_ARTIGO As String
    Private IN01_VEL_AFERIDA As String
    Private IN01_VEL_PERMITIDA As String
    Private IN01_VEL_CONSIDERADA As String
    Private IN01_PENALIDADE As String
    Private IN01_VALOR_INFRACAO As Decimal
    Private IN01_COD_MUNICIPIO As Integer
    Private IN01_DATA_EMISSAO As String
    Private IN01_DATA_VENCIMENTO As String
    Private IN01_NUM_CONTROLE As String
    Private IN01_VALOR_DA_BARRA As String
    Private IN01_CODIDO_BARRAS As String
    Private IN01_PRONTUARIO As String
    Private IN01_UF_PRONTUARIO As String
    Private IN01_CODIGO_RETORNO As String
    Private IN01_SEQUENCIAL As String
    Private IN01_NUMERO_PONTOS As Integer
    Private IN01_COD_INFRAEST As String
    Private IN01_COD_INFRACAO As String
    Private IN01_ESPECIE_VEICULO As String
    Private IN01_PROCESSADO As Boolean
    Private IN01_DH_PROCESSADO As String

    Public Property CodTabelaoInfracao() As Integer
        Get
            Return IN01_COD_TABELAO_INFRACAO
        End Get
        Set(ByVal Value As Integer)
            IN01_COD_TABELAO_INFRACAO = Value
        End Set
    End Property

    Public Property Cabecalho() As Integer
        Get
            Return FKIN01IN03_COD_CABECALHO
        End Get
        Set(ByVal Value As Integer)
            FKIN01IN03_COD_CABECALHO = Value
        End Set
    End Property

    Public Property TipoInfracao() As Integer
        Get
            Return IN01_TIPO_INFRACAO
        End Get
        Set(ByVal Value As Integer)
            IN01_TIPO_INFRACAO = Value
        End Set
    End Property

    Public Property TipoRegistro() As Integer
        Get
            Return IN01_TipoRegistro
        End Get
        Set(ByVal Value As Integer)
            IN01_TipoRegistro = Value
        End Set
    End Property
    Public Property CodLocalOcorrencia() As String
        Get
            Return IN01_COD_LOCAL_OCORRENCIA
        End Get
        Set(ByVal Value As String)
            IN01_COD_LOCAL_OCORRENCIA = Value
        End Set
    End Property
    Public Property NumRemessa() As Integer
        Get
            Return IN01_NUM_REMESSA
        End Get
        Set(ByVal Value As Integer)
            IN01_NUM_REMESSA = Value
        End Set
    End Property
    Public Property DataRemessa() As String
        Get
            Return IN01_DATA_REMESSA
        End Get
        Set(ByVal Value As String)
            IN01_DATA_REMESSA = Value
        End Set
    End Property
    Public Property CodOrgaoAutuador() As Integer
        Get
            Return IN01_COD_ORGAO_AUTUADOR
        End Get
        Set(ByVal Value As Integer)
            IN01_COD_ORGAO_AUTUADOR = Value
        End Set
    End Property
    Public Property DesOrgaoAutuador() As String
        Get
            Return IN01_DES_ORGAO_AUTUADOR
        End Get
        Set(ByVal Value As String)
            IN01_DES_ORGAO_AUTUADOR = Value
        End Set
    End Property
    Public Property AutoInfracao() As String
        Get
            Return IN01_AUTO_INFRACAO
        End Get
        Set(ByVal Value As String)
            IN01_AUTO_INFRACAO = Value
        End Set
    End Property
    Public Property DataHoraCometimento() As String
        Get
            Return IN01_DATA_HORA_COMETIMENTO
        End Get
        Set(ByVal Value As String)
            IN01_DATA_HORA_COMETIMENTO = Value
        End Set
    End Property

    Public Property LocalCometimento() As String
        Get
            Return IN01_LOCAL_COMETIMENTO
        End Get
        Set(ByVal Value As String)
            IN01_LOCAL_COMETIMENTO = Value
        End Set
    End Property
    Public Property PlacaVeiculo() As String
        Get
            Return IN01_PLACA_VEICULO
        End Get
        Set(ByVal Value As String)
            IN01_PLACA_VEICULO = Value
        End Set
    End Property
    Public Property UfPlaca() As String
        Get
            Return IN01_UF_PLACA
        End Get
        Set(ByVal Value As String)
            IN01_UF_PLACA = Value
        End Set
    End Property
    Public Property Agente() As String
        Get
            Return IN01_IDENTIFICACAO_AGENTE
        End Get
        Set(ByVal Value As String)
            IN01_IDENTIFICACAO_AGENTE = Value
        End Set
    End Property
    Public Property DesModelo() As String
        Get
            Return IN01_DES_MODELO
        End Get
        Set(ByVal Value As String)
            IN01_DES_MODELO = Value
        End Set
    End Property
    Public Property CategoriaVeiculo() As String
        Get
            Return IN01_CATEGORIA_VEICULO
        End Get
        Set(ByVal Value As String)
            IN01_CATEGORIA_VEICULO = Value
        End Set
    End Property
    Public Property TipoVeiculo() As String
        Get
            Return IN01_TIPO_VEICULO
        End Get
        Set(ByVal Value As String)
            IN01_TIPO_VEICULO = Value
        End Set
    End Property
    Public Property Cor() As String
        Get
            Return IN01_COR_VEICULO
        End Get
        Set(ByVal Value As String)
            IN01_COR_VEICULO = Value
        End Set
    End Property
    Public Property DataAfericao() As String
        Get
            Return IN01_DATA_AFERICAO
        End Get
        Set(ByVal Value As String)
            IN01_DATA_AFERICAO = Value
        End Set
    End Property
    Public Property Proprietario() As String
        Get
            Return IN01_PROPRIETARIO
        End Get
        Set(ByVal Value As String)
            IN01_PROPRIETARIO = Value
        End Set
    End Property
    Public Property Endereco() As String
        Get
            Return IN01_ENDERECO
        End Get
        Set(ByVal Value As String)
            IN01_ENDERECO = Value
        End Set
    End Property
    Public Property ComplementoBairro() As String
        Get
            Return IN01_COMPLEMENTO_BAIRRO
        End Get
        Set(ByVal Value As String)
            IN01_COMPLEMENTO_BAIRRO = Value
        End Set
    End Property
    Public Property Cep() As Integer
        Get
            Return IN01_CEP
        End Get
        Set(ByVal Value As Integer)
            IN01_CEP = Value
        End Set
    End Property
    Public Property Cidade() As String
        Get
            Return IN01_CIDADE
        End Get
        Set(ByVal Value As String)
            IN01_CIDADE = Value
        End Set
    End Property
    Public Property UfEndereco() As String
        Get
            Return IN01_UF_ENDERECO
        End Get
        Set(ByVal Value As String)
            IN01_UF_ENDERECO = Value
        End Set
    End Property
    Public Property DesInfracao() As String
        Get
            Return IN01_DES_INFRACAO
        End Get
        Set(ByVal Value As String)
            IN01_DES_INFRACAO = Value
        End Set
    End Property
    Public Property Artigo() As String
        Get
            Return IN01_ARTIGO
        End Get
        Set(ByVal Value As String)
            IN01_ARTIGO = Value
        End Set
    End Property
    Public Property VelAferida() As String
        Get
            Return IN01_VEL_AFERIDA
        End Get
        Set(ByVal Value As String)
            IN01_VEL_AFERIDA = Value
        End Set
    End Property
    Public Property VelPermitida() As String
        Get
            Return IN01_VEL_PERMITIDA
        End Get
        Set(ByVal Value As String)
            IN01_VEL_PERMITIDA = Value
        End Set
    End Property
    Public Property VelCOnsiderada() As String
        Get
            Return IN01_VEL_CONSIDERADA
        End Get
        Set(ByVal Value As String)
            IN01_VEL_CONSIDERADA = Value
        End Set
    End Property
    Public Property Penalidade() As String
        Get
            Return IN01_PENALIDADE
        End Get
        Set(ByVal Value As String)
            IN01_PENALIDADE = Value
        End Set
    End Property
    Public Property ValorInfracao() As Decimal
        Get
            Return IN01_VALOR_INFRACAO
        End Get
        Set(ByVal Value As Decimal)
            IN01_VALOR_INFRACAO = Value
        End Set
    End Property
    Public Property CodMunicipio() As Integer
        Get
            Return IN01_COD_MUNICIPIO
        End Get
        Set(ByVal Value As Integer)
            IN01_COD_MUNICIPIO = Value
        End Set
    End Property
    Public Property DataEmissao() As String
        Get
            Return IN01_DATA_EMISSAO
        End Get
        Set(ByVal Value As String)
            IN01_DATA_EMISSAO = Value
        End Set
    End Property
    Public Property DataVencimento() As String
        Get
            Return IN01_DATA_VENCIMENTO
        End Get
        Set(ByVal Value As String)
            IN01_DATA_VENCIMENTO = Value
        End Set
    End Property
    Public Property NumControle() As String
        Get
            Return IN01_NUM_CONTROLE
        End Get
        Set(ByVal Value As String)
            IN01_NUM_CONTROLE = Value
        End Set
    End Property
    Public Property ValorBarra() As String
        Get
            Return IN01_VALOR_DA_BARRA
        End Get
        Set(ByVal Value As String)
            IN01_VALOR_DA_BARRA = Value
        End Set
    End Property
    Public Property CodigoBarras() As String
        Get
            Return IN01_CODIDO_BARRAS
        End Get
        Set(ByVal Value As String)
            IN01_CODIDO_BARRAS = Value
        End Set
    End Property
    Public Property Prontuario() As String
        Get
            Return IN01_PRONTUARIO
        End Get
        Set(ByVal Value As String)
            IN01_PRONTUARIO = Value
        End Set
    End Property
    Public Property UfProntuario() As String
        Get
            Return IN01_UF_PRONTUARIO
        End Get
        Set(ByVal Value As String)
            IN01_UF_PRONTUARIO = Value
        End Set
    End Property
    Public Property CodigoRetorno() As String
        Get
            Return IN01_CODIGO_RETORNO
        End Get
        Set(ByVal Value As String)
            IN01_CODIGO_RETORNO = Value
        End Set
    End Property
    Public Property Sequencial() As String
        Get
            Return IN01_SEQUENCIAL
        End Get
        Set(ByVal Value As String)
            IN01_SEQUENCIAL = Value
        End Set
    End Property
    Public Property NumPontos() As Integer
        Get
            Return IN01_NUMERO_PONTOS
        End Get
        Set(ByVal Value As Integer)
            IN01_NUMERO_PONTOS = Value
        End Set
    End Property
    Public Property CodInfraest() As String
        Get
            Return IN01_COD_INFRAEST
        End Get
        Set(ByVal Value As String)
            IN01_COD_INFRAEST = Value
        End Set
    End Property
    Public Property CodInfracao() As String
        Get
            Return IN01_COD_INFRACAO
        End Get
        Set(ByVal Value As String)
            IN01_COD_INFRACAO = Value
        End Set
    End Property
    Public Property EspecieVeiculo() As String
        Get
            Return IN01_ESPECIE_VEICULO
        End Get
        Set(ByVal Value As String)
            IN01_ESPECIE_VEICULO = Value
        End Set
    End Property

    Public Property Processado() As Boolean
        Get
            Return IN01_PROCESSADO
        End Get
        Set(ByVal Value As Boolean)
            IN01_PROCESSADO = Value
        End Set
    End Property

    Public Property DatahoraProcessado() As String
        Get
            Return IN01_DH_PROCESSADO
        End Get
        Set(ByVal Value As String)
            IN01_DH_PROCESSADO = Value
        End Set
    End Property

    Public Sub New(Optional ByVal CodTabelaoInfracao As Integer = 0)
        If CodTabelaoInfracao > 0 Then
            Obter(CodTabelaoInfracao)
        End If
    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from IN01_TABELAO_INFRACAO")
        strSQL.Append(" where IN01_COD_TABELAO_INFRACAO = " & CodTabelaoInfracao)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("IN01_TipoRegistro") = ProBanco(IN01_TipoRegistro, eTipoValor.CHAVE)
        dr("FKIN01IN03_COD_CABECALHO") = ProBanco(FKIN01IN03_COD_CABECALHO, eTipoValor.CHAVE)
        dr("IN01_TIPO_INFRACAO") = ProBanco(IN01_TIPO_INFRACAO, eTipoValor.CHAVE)
        dr("IN01_COD_LOCAL_OCORRENCIA") = ProBanco(IN01_COD_LOCAL_OCORRENCIA, eTipoValor.TEXTO)
        dr("IN01_NUM_REMESSA") = ProBanco(IN01_NUM_REMESSA, eTipoValor.CHAVE)
        dr("IN01_DATA_REMESSA") = ProBanco(IN01_DATA_REMESSA, eTipoValor.DATA)
        dr("IN01_COD_ORGAO_AUTUADOR") = ProBanco(IN01_COD_ORGAO_AUTUADOR, eTipoValor.CHAVE)
        dr("IN01_DES_ORGAO_AUTUADOR") = ProBanco(IN01_DES_ORGAO_AUTUADOR, eTipoValor.TEXTO)
        dr("IN01_AUTO_INFRACAO") = ProBanco(IN01_AUTO_INFRACAO, eTipoValor.TEXTO)
        dr("IN01_DATA_HORA_COMETIMENTO") = ProBanco(IN01_DATA_HORA_COMETIMENTO, eTipoValor.DATA)
        dr("IN01_LOCAL_COMETIMENTO") = ProBanco(IN01_LOCAL_COMETIMENTO, eTipoValor.TEXTO)
        dr("IN01_PLACA_VEICULO") = ProBanco(IN01_PLACA_VEICULO, eTipoValor.TEXTO)
        dr("IN01_UF_PLACA") = ProBanco(IN01_UF_PLACA, eTipoValor.TEXTO)
        dr("IN01_IDENTIFICACAO_AGENTE") = ProBanco(IN01_IDENTIFICACAO_AGENTE, eTipoValor.TEXTO)
        dr("IN01_DES_MODELO") = ProBanco(IN01_DES_MODELO, eTipoValor.TEXTO)
        dr("IN01_CATEGORIA_VEICULO") = ProBanco(IN01_CATEGORIA_VEICULO, eTipoValor.TEXTO)
        dr("IN01_TIPO_VEICULO") = ProBanco(IN01_TIPO_VEICULO, eTipoValor.TEXTO)
        dr("IN01_COR_VEICULO") = ProBanco(IN01_COR_VEICULO, eTipoValor.TEXTO)
        dr("IN01_DATA_AFERICAO") = ProBanco(IN01_DATA_AFERICAO, eTipoValor.DATA)
        dr("IN01_PROPRIETARIO") = ProBanco(IN01_PROPRIETARIO, eTipoValor.TEXTO)
        dr("IN01_ENDERECO") = ProBanco(IN01_ENDERECO, eTipoValor.TEXTO)
        dr("IN01_COMPLEMENTO_BAIRRO") = ProBanco(IN01_COMPLEMENTO_BAIRRO, eTipoValor.TEXTO)
        dr("IN01_CEP") = ProBanco(IN01_CEP, eTipoValor.CHAVE)
        dr("IN01_CIDADE") = ProBanco(IN01_CIDADE, eTipoValor.TEXTO)
        dr("IN01_UF_ENDERECO") = ProBanco(IN01_UF_ENDERECO, eTipoValor.TEXTO)
        dr("IN01_DES_INFRACAO") = ProBanco(IN01_DES_INFRACAO, eTipoValor.TEXTO)
        dr("IN01_ARTIGO") = ProBanco(IN01_ARTIGO, eTipoValor.TEXTO)
        dr("IN01_VEL_AFERIDA") = ProBanco(IN01_VEL_AFERIDA, eTipoValor.TEXTO)
        dr("IN01_VEL_PERMITIDA") = ProBanco(IN01_VEL_PERMITIDA, eTipoValor.TEXTO)
        dr("IN01_VEL_CONSIDERADA") = ProBanco(IN01_VEL_CONSIDERADA, eTipoValor.TEXTO)
        dr("IN01_PENALIDADE") = ProBanco(IN01_PENALIDADE, eTipoValor.TEXTO)
        dr("IN01_VALOR_INFRACAO") = ProBanco(IN01_VALOR_INFRACAO, eTipoValor.NUMERO_DECIMAL)
        dr("IN01_COD_MUNICIPIO") = ProBanco(IN01_COD_MUNICIPIO, eTipoValor.CHAVE)
        dr("IN01_DATA_EMISSAO") = ProBanco(IN01_DATA_EMISSAO, eTipoValor.DATA)
        dr("IN01_DATA_VENCIMENTO") = ProBanco(IN01_DATA_VENCIMENTO, eTipoValor.DATA)
        dr("IN01_NUM_CONTROLE") = ProBanco(IN01_NUM_CONTROLE, eTipoValor.TEXTO)
        dr("IN01_VALOR_DA_BARRA") = ProBanco(IN01_VALOR_DA_BARRA, eTipoValor.TEXTO)
        dr("IN01_CODIDO_BARRAS") = ProBanco(IN01_CODIDO_BARRAS, eTipoValor.TEXTO)
        dr("IN01_PRONTUARIO") = ProBanco(IN01_PRONTUARIO, eTipoValor.TEXTO)
        dr("IN01_UF_PRONTUARIO") = ProBanco(IN01_UF_PRONTUARIO, eTipoValor.TEXTO)
        dr("IN01_CODIGO_RETORNO") = ProBanco(IN01_CODIGO_RETORNO, eTipoValor.TEXTO)
        dr("IN01_SEQUENCIAL") = ProBanco(IN01_SEQUENCIAL, eTipoValor.TEXTO)
        dr("IN01_NUMERO_PONTOS") = ProBanco(IN01_NUMERO_PONTOS, eTipoValor.CHAVE)
        dr("IN01_COD_INFRAEST") = ProBanco(IN01_COD_INFRAEST, eTipoValor.TEXTO)
        dr("IN01_COD_INFRACAO") = ProBanco(IN01_COD_INFRACAO, eTipoValor.TEXTO)
        dr("IN01_ESPECIE_VEICULO") = ProBanco(IN01_ESPECIE_VEICULO, eTipoValor.TEXTO)
        dr("IN01_PROCESSADO") = ProBanco(IN01_PROCESSADO, eTipoValor.BOOLEANO)
        dr("IN01_DH_PROCESSADO") = ProBanco(IN01_DH_PROCESSADO, eTipoValor.DATA_COMPLETA)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing


        cnn = Nothing
    End Sub
    Public Sub SalvarProcessados(ByVal Cliente As Integer, ByVal NatNip As Integer)
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" update IN01_TABELAO_INFRACAO ")
        strSQL.Append(" Set IN01_PROCESSADO = 1, IN01_DH_PROCESSADO = GETDATE() ")
        strSQL.Append(" From IN01_TABELAO_INFRACAO  ")
        strSQL.Append(" Left Join IN03_CABECALHO on IN03_COD_CABECALHO = FKIN01IN03_COD_CABECALHO ")
        strSQL.Append(" Left Join IN04_NAT_NIP on IN04_COD_NAT_NIP = FKIN03IN04_COD_NAT_NIP ")
        strSQL.Append(" where FKIN04IN05_COD_CLIENTE = " & Cliente)
        strSQL.Append(" And IN04_COD_NAT_NIP = " & NatNip)

        cnn.EditarDataTable(strSQL.ToString)

        cnn = Nothing

    End Sub
    Public Sub Obter(ByVal CodTabelaoInfracao As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select * ")
        strSQL.Append(" from IN01_TABELAO_INFRACAO")
        strSQL.Append(" where IN01_COD_TABELAO_INFRACAO = " & CodTabelaoInfracao)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            IN01_COD_TABELAO_INFRACAO = DoBanco(dr("IN01_COD_TABELAO_INFRACAO"), eTipoValor.CHAVE)
            FKIN01IN03_COD_CABECALHO = DoBanco(dr("FKIN01IN03_COD_CABECALHO"), eTipoValor.CHAVE)
            IN01_TIPO_INFRACAO = DoBanco(dr("IN01_TIPO_INFRACAO"), eTipoValor.CHAVE)
            IN01_TipoRegistro = DoBanco(dr("IN01_TipoRegistro"), eTipoValor.CHAVE)
            IN01_COD_LOCAL_OCORRENCIA = DoBanco(dr("IN01_COD_LOCAL_OCORRENCIA"), eTipoValor.TEXTO)
            IN01_NUM_REMESSA = DoBanco(dr("IN01_NUM_REMESSA"), eTipoValor.CHAVE)
            IN01_DATA_REMESSA = DoBanco(dr("IN01_DATA_REMESSA"), eTipoValor.DATA)
            IN01_COD_ORGAO_AUTUADOR = DoBanco(dr("IN01_COD_ORGAO_AUTUADOR"), eTipoValor.CHAVE)
            IN01_DES_ORGAO_AUTUADOR = DoBanco(dr("IN01_DES_ORGAO_AUTUADOR"), eTipoValor.TEXTO)
            IN01_AUTO_INFRACAO = DoBanco(dr("IN01_AUTO_INFRACAO"), eTipoValor.TEXTO)
            IN01_DATA_HORA_COMETIMENTO = DoBanco(dr("IN01_DATA_COMETIMENTO"), eTipoValor.DATA)
            IN01_LOCAL_COMETIMENTO = DoBanco(dr("IN01_LOCAL_COMETIMENTO"), eTipoValor.TEXTO)
            IN01_PLACA_VEICULO = DoBanco(dr("IN01_PLACA_VEICULO"), eTipoValor.TEXTO)
            IN01_UF_PLACA = DoBanco(dr("IN01_UF_PLACA"), eTipoValor.TEXTO)
            IN01_IDENTIFICACAO_AGENTE = DoBanco(dr("IN01_IDENTIFICACAO_AGENTE"), eTipoValor.TEXTO)
            IN01_DES_MODELO = DoBanco(dr("IN01_DES_MODELO"), eTipoValor.TEXTO)
            IN01_CATEGORIA_VEICULO = DoBanco(dr("IN01_CATEGORIA_VEICULO"), eTipoValor.TEXTO)
            IN01_TIPO_VEICULO = DoBanco(dr("IN01_TIPO_VEICULO"), eTipoValor.TEXTO)
            IN01_COR_VEICULO = DoBanco(dr("IN01_COR_VEICULO"), eTipoValor.TEXTO)
            IN01_DATA_AFERICAO = DoBanco(dr("IN01_DATA_AFERICAO"), eTipoValor.DATA)
            IN01_PROPRIETARIO = DoBanco(dr("IN01_PROPRIETARIO"), eTipoValor.TEXTO)
            IN01_ENDERECO = DoBanco(dr("IN01_ENDERECO"), eTipoValor.TEXTO)
            IN01_COMPLEMENTO_BAIRRO = DoBanco(dr("IN01_COMPLEMENTO_BAIRRO"), eTipoValor.TEXTO)
            IN01_CEP = DoBanco(dr("IN01_CEP"), eTipoValor.CHAVE)
            IN01_CIDADE = DoBanco(dr("IN01_CIDADE"), eTipoValor.TEXTO)
            IN01_UF_ENDERECO = DoBanco(dr("IN01_UF_ENDERECO"), eTipoValor.TEXTO)
            IN01_DES_INFRACAO = DoBanco(dr("IN01_DES_INFRACAO"), eTipoValor.TEXTO)
            IN01_ARTIGO = DoBanco(dr("IN01_ARTIGO"), eTipoValor.TEXTO)
            IN01_VEL_AFERIDA = DoBanco(dr("IN01_VEL_AFERIDA"), eTipoValor.TEXTO)
            IN01_VEL_PERMITIDA = DoBanco(dr("IN01_VEL_PERMITIDA"), eTipoValor.TEXTO)
            IN01_VEL_CONSIDERADA = DoBanco(dr("IN01_VEL_CONSIDERADA"), eTipoValor.TEXTO)
            IN01_PENALIDADE = DoBanco(dr("IN01_PENALIDADE"), eTipoValor.TEXTO)
            IN01_VALOR_INFRACAO = DoBanco(dr("IN01_VALOR_INFRACAO"), eTipoValor.NUMERO_DECIMAL)
            IN01_COD_MUNICIPIO = DoBanco(dr("IN01_COD_MUNICIPIO"), eTipoValor.CHAVE)
            IN01_DATA_EMISSAO = DoBanco(dr("IN01_DATA_EMISSAO"), eTipoValor.DATA)
            IN01_DATA_VENCIMENTO = DoBanco(dr("IN01_DATA_VENCIMENTO"), eTipoValor.DATA)
            IN01_NUM_CONTROLE = DoBanco(dr("IN01_NUM_CONTROLE"), eTipoValor.TEXTO)
            IN01_VALOR_DA_BARRA = DoBanco(dr("IN01_VALOR_DA_BARRA"), eTipoValor.TEXTO)
            IN01_CODIDO_BARRAS = DoBanco(dr("IN01_CODIDO_BARRAS"), eTipoValor.TEXTO)
            IN01_PRONTUARIO = DoBanco(dr("IN01_PRONTUARIO"), eTipoValor.TEXTO)
            IN01_UF_PRONTUARIO = DoBanco(dr("IN01_UF_PRONTUARIO"), eTipoValor.TEXTO)
            IN01_CODIGO_RETORNO = DoBanco(dr("IN01_CODIGO_RETORNO"), eTipoValor.TEXTO)
            IN01_SEQUENCIAL = DoBanco(dr("IN01_SEQUENCIAL"), eTipoValor.TEXTO)
            IN01_NUMERO_PONTOS = DoBanco(dr("IN01_NUMERO_PONTOS"), eTipoValor.CHAVE)
            IN01_COD_INFRAEST = DoBanco(dr("IN01_COD_INFRAEST"), eTipoValor.TEXTO)
            IN01_COD_INFRACAO = DoBanco(dr("IN01_COD_INFRACAO"), eTipoValor.TEXTO)
            IN01_ESPECIE_VEICULO = DoBanco(dr("IN01_ESPECIE_VEICULO"), eTipoValor.TEXTO)
            IN01_PROCESSADO = DoBanco(dr("IN01_PROCESSADO"), eTipoValor.BOOLEANO)
            IN01_DH_PROCESSADO = DoBanco(dr("IN01_DH_PROCESSADO"), eTipoValor.DATA_COMPLETA)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional CodTabelaoInfracao As Integer = 0,
                              Optional TipoRegistro As Integer = 0,
                              Optional Placa As String = "",
                              Optional Proprietario As String = "",
                              Optional Cliente As Integer = 0,
                              Optional NatNip As Integer = 0) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append("  Select in01.*, in04.*, in05.* From IN01_TABELAO_INFRACAO As in01  ")
        strSQL.Append(" Left Join IN03_CABECALHO As in03 On IN03_COD_CABECALHO = FKIN01IN03_COD_CABECALHO ")
        strSQL.Append(" left Join IN04_NAT_NIP As in04 On IN04_COD_NAT_NIP = FKIN03IN04_COD_NAT_NIP")
        strSQL.Append(" left Join IN05_CLIENTE As in05 On IN05_COD_CLIENTE = FKIN04IN05_COD_CLIENTE")
        strSQL.Append(" Where IN01_COD_TABELAO_INFRACAO Is Not null")


        If CodTabelaoInfracao > 0 Then
            strSQL.Append(" And IN01_COD_TABELAO_INFRACAO = " & CodTabelaoInfracao)
        End If

        If TipoRegistro > 0 Then
            strSQL.Append(" And IN01_TipoRegistro = " & TipoRegistro)
        End If

        If Placa <> "" Then
            strSQL.Append(" And IN01_PLACA_VEICULO like '%" & Placa.ToUpper & "%'")
        End If

        If Proprietario <> "" Then
            strSQL.Append(" And IN01_PROPRIETARIO like '%" & Proprietario.ToUpper & "%'")
        End If

        If Cliente > 0 Then
            strSQL.Append(" And IN05_COD_CLIENTE = " & Cliente)
        End If

        If NatNip > 0 Then
            strSQL.Append(" And IN04_COD_NAT_NIP = " & NatNip)
        End If

        strSQL.Append(" And IN01_PROCESSADO = 0")
        strSQL.Append(" and IN03_COD_CABECALHO_1 is null")

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function GerarExportacao(ByVal Cliente As Integer, ByVal NatNip As Integer, ByVal Remessa As Integer) As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" Declare @NumeroRemessa varchar(4) ")
        strSQL.Append(" Set @NumeroRemessa =  " & Remessa)

        'strSQL.Append(" Set @NumeroRemessa =  (Select distinct top 1 IN03_NUMERO_REMESSA ")
        'strSQL.Append("         From IN01_TABELAO_INFRACAO ")
        'strSQL.Append("         Left Join IN03_CABECALHO On IN03_COD_CABECALHO = FKIN01IN03_COD_CABECALHO  ")
        'strSQL.Append("         Left Join IN04_NAT_NIP On IN04_COD_NAT_NIP = FKIN03IN04_COD_NAT_NIP ")
        'strSQL.Append("         where FKIN04IN05_COD_CLIENTE = " & Cliente)
        'strSQL.Append("         And IN04_COD_NAT_NIP = " & NatNip)
        'strSQL.Append(" And  IN03_COD_CABECALHO_1 Is null ) ")


        strSQL.Append(" Select  ")
        strSQL.Append("  cast(IN01_TipoRegistro As varchar) ")
        strSQL.Append(" +'|' + IN01_COD_LOCAL_OCORRENCIA ")
        strSQL.Append(" +'|' + @NumeroRemessa ")
        strSQL.Append(" +'|' + isnull(cast(IN01_DATA_REMESSA as varchar), '0000-00-00') ")
        strSQL.Append(" +'|' + cast(IN01_COD_ORGAO_AUTUADOR as varchar)  ")
        strSQL.Append(" +'|' + IN01_DES_ORGAO_AUTUADOR + replicate(' ', (40-len(IN01_DES_ORGAO_AUTUADOR))) ")
        strSQL.Append(" +'|' + IN01_AUTO_INFRACAO + replicate(' ', (10-len(IN01_AUTO_INFRACAO))) ")
        strSQL.Append(" +'|' + cast(cast(IN01_DATA_HORA_COMETIMENTO as date) as varchar) + ' ' + cast(left(cast(IN01_DATA_HORA_COMETIMENTO as time),5) as varchar) ")
        strSQL.Append(" +'|' + IN01_LOCAL_COMETIMENTO + replicate(' ', (60-len(IN01_LOCAL_COMETIMENTO))) ")
        strSQL.Append(" +'|' + IN01_PLACA_VEICULO ")
        strSQL.Append(" +'|' + IN01_UF_PLACA ")
        strSQL.Append(" +'|' + IN01_IDENTIFICACAO_AGENTE + replicate(' ', (11-len(IN01_IDENTIFICACAO_AGENTE))) ")
        strSQL.Append(" +'|' + IN01_DES_MODELO + replicate(' ', (45-len(IN01_DES_MODELO))) ")
        strSQL.Append(" +'|' + IN01_CATEGORIA_VEICULO + replicate(' ', (30-len(IN01_CATEGORIA_VEICULO))) ")
        strSQL.Append(" +'|' + IN01_TIPO_VEICULO + replicate(' ', (16-len(IN01_TIPO_VEICULO))) ")
        strSQL.Append(" +'|' + IN01_COR_VEICULO + replicate(' ', (10-len(IN01_COR_VEICULO))) ")
        strSQL.Append(" +'|' + isnull(cast(IN01_DATA_AFERICAO as varchar),'0000-00-00')")
        strSQL.Append(" +'|' + IN01_PROPRIETARIO + replicate(' ', (44-len(IN01_PROPRIETARIO))) ")
        strSQL.Append(" +'|' + IN01_ENDERECO + replicate(' ', (40-len(IN01_ENDERECO))) ")
        strSQL.Append(" +'|' + IN01_COMPLEMENTO_BAIRRO + replicate(' ', (40-len(IN01_COMPLEMENTO_BAIRRO))) ")
        strSQL.Append(" +'|' + replicate('0', 8 - len(cast(IN01_CEP as varchar))) + cast(IN01_CEP as varchar)")
        strSQL.Append(" +'|' + IN01_CIDADE + replicate(' ', (20-len(IN01_CIDADE)))  ")
        strSQL.Append(" +'|' + IN01_UF_ENDERECO ")
        strSQL.Append(" +'|' + IN01_DES_INFRACAO + replicate(' ', (50-len(IN01_DES_INFRACAO))) ")
        strSQL.Append(" +'|' + IN01_ARTIGO + replicate(' ', (19-len(IN01_ARTIGO)))  ")
        strSQL.Append(" +'|' + IN01_VEL_AFERIDA ")
        strSQL.Append(" +'|' + IN01_VEL_PERMITIDA ")
        strSQL.Append(" +'|' + IN01_VEL_CONSIDERADA ")
        strSQL.Append(" +'|' + IN01_PENALIDADE + replicate(' ', (8-len(IN01_PENALIDADE))) ")
        strSQL.Append(" +'|' + replicate('0', (9-len(replace(cast(IN01_VALOR_INFRACAO as varchar),'.', '')))) + replace(cast(IN01_VALOR_INFRACAO as varchar),'.', '') ")
        strSQL.Append(" +'|' + replicate('0', 5 - len(cast(IN01_COD_MUNICIPIO as varchar))) + cast(IN01_COD_MUNICIPIO as varchar) ")
        strSQL.Append(" +'|' + isnull(cast(IN01_DATA_EMISSAO as varchar),'0000-00-00') ")
        strSQL.Append(" +'|' + isnull(cast(IN01_DATA_VENCIMENTO as varchar), '0000-00-00') ")
        strSQL.Append(" +'|' + IN01_NUM_CONTROLE ")
        strSQL.Append(" +'|' + IN01_VALOR_DA_BARRA ")
        strSQL.Append(" +'|' + IN01_CODIDO_BARRAS + replicate(' ', (48-len(IN01_CODIDO_BARRAS)))  ")
        strSQL.Append(" +'|' + IN01_PRONTUARIO ")
        strSQL.Append(" +'|' + IN01_UF_PRONTUARIO + replicate(' ', (2-len(IN01_UF_PRONTUARIO)))  ")
        strSQL.Append(" +'|' + IN01_CODIGO_RETORNO ")
        strSQL.Append(" +'|' + IN01_SEQUENCIAL + replicate(' ', (6-len(IN01_SEQUENCIAL))) ")
        strSQL.Append(" +'|' + replicate('0', 4 - len(cast(IN01_NUMERO_PONTOS as varchar))) + cast(IN01_NUMERO_PONTOS as varchar) ")
        strSQL.Append(" +'|' + replicate('0', 11 - len(IN01_COD_INFRAEST)) + IN01_COD_INFRAEST ")
        strSQL.Append(" +'|' + IN01_COD_INFRACAO ")
        strSQL.Append(" +'|' + IN01_ESPECIE_VEICULO + replicate(' ', (15-len(IN01_ESPECIE_VEICULO))) ")

        strSQL.Append(" +'|' + IN04_CARTAO_POSTAGEM ")
        strSQL.Append(" +'|' + IN04_NUMERO_CONTRATO ")
        strSQL.Append(" +'|' + IN04_SERVICO_ADICIONAL ")
        strSQL.Append(" +'|' + IN04_IDENTIFIC_ARQ_SPOOL ")
        strSQL.Append(" +'|' + IN04_NOME_ARQ_SPOOL ")
        strSQL.Append(" +'|' + IN04_IDENTIFIC_ARQ_COMPLEM ")
        strSQL.Append(" +'|' + IN04_NOME_ARQ_COMPLEM ")
        strSQL.Append(" +'|' + IN04_NUM_END_DESTINATARIO ")
        strSQL.Append(" +'|' + IN04_COMPLEM_END_DESTINATARIO ")
        strSQL.Append(" +'[' as LINHA ")

        strSQL.Append(" From IN01_TABELAO_INFRACAO ")
        strSQL.Append(" Left Join IN03_CABECALHO On IN03_COD_CABECALHO = FKIN01IN03_COD_CABECALHO ")
        strSQL.Append(" Left Join IN04_NAT_NIP On IN04_COD_NAT_NIP = FKIN03IN04_COD_NAT_NIP ")
        strSQL.Append(" where FKIN04IN05_COD_CLIENTE = " & Cliente)
        strSQL.Append(" And IN04_COD_NAT_NIP = " & NatNip)
        strSQL.Append(" and IN01_PROCESSADO = 0 ")
        strSQL.Append(" and IN03_COD_CABECALHO_1 is null ")


        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" Select IN01_COD_TABELAO_INFRACAO As CODIGO, IN01_COD_LOCAL_OCORRENCIA As DESCRICAO")
        strSQL.Append(" from IN01_TABELAO_INFRACAO")
        strSQL.Append(" order by 2 ")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" Select max(IN01_COD_TABELAO_INFRACAO) from IN01_TABELAO_INFRACAO")

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
    Public Function Excluir(ByVal CodTabelaoInfracao As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from IN01_TABELAO_INFRACAO")
        strSQL.Append(" where IN01_COD_TABELAO_INFRACAO = " & CodTabelaoInfracao)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        cnn = Nothing

        Return LinhasAfetadas
    End Function

End Class

