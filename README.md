# Pix - Dynamic Payload Generator .net


<img width='200' src='https://user-images.githubusercontent.com/5353685/101644586-233eb080-3a14-11eb-9cec-2172586abfde.png'/>

[![Nuget](https://img.shields.io/nuget/dt/pix-dynamic-payload-generator.net)](https://www.nuget.org/packages/pix-dynamic-payload-generator.net)
[![Nuget](https://img.shields.io/nuget/v/pix-dynamic-payload-generator.net)](https://www.nuget.org/packages/pix-dynamic-payload-generator.net)

Este pacote auxilia na geração de payloads para usar em QRCode estático ou dinâmico PIX (Sistema de pagamento instântaneo do Brasil)

# ⚠ Informações importantes e limitações
Antes de começar, entenda um pouco sobre as diferenças dos dois tipos de geração de QrCodes disponibilizadas pelo Bacen ("QrCode estático" e "QrCode dinâmico")

## QrCode Dinâmico
Ideal para sistemas ERP e ou onde necessita do acompanhamento do status de cada cobrança, vinculo com pedidos, inclusão de multas e juros e outros.
Este carrega as características de uma fatura de cobrança.

#### ✅ Pontos fortes:
- É possível recuperar informações do status de pagamento
- É possível usar todos os serviços da [api oficial do pix](https://bacen.github.io/pix-api/#/Pix/get_pix) disponibilizadas pelo seu PSP

#### ❌ Pontos fracos:
- Requer um PSP
- Necessita de autenticação
- Necessita de conexão com a internet

<details>
   <summary> Como Gerar?</summary>

### Instale [este pacote](https://www.nuget.org/packages/pix-dynamic-payload-generator.net) na sua aplicação.

1 - Crie uma cobrança

```csharp
var cob = new CobRequest(_chave: "1b0e2743-0769-4f21-b0b7-9cfddb2a5a2b")
{
    Calendario = new Calendario
    {
        Expiracao = 3600
    },
    Devedor = new Devedor
    {
        Cpf = "12345678909",
        Nome = "Francisco da Silva",
    },
    Valor = new Valor
    {
        Original = "1.00"
    },
    SolicitacaoPagador = "Serviço realizado.",
    InfoAdicionais = new System.Collections.Generic.List<InfoAdicional>
    {
        new InfoAdicional
        {
            Nome = "Campo 1",
            Valor = "Informação Adicional1 do PSP-Recebedor"
        },
        new InfoAdicional
        {
            Nome = "Campo 2",
            Valor = "Informação Adicional2 do PSP-Recebedor"
        }
    }
};

var cobRequest = new CobRequestService();

var cb = await cobRequest.Create(System.Guid.NewGuid().ToString("N"), cob);
```

2 - Consultar a cobrança gerada

```csharp
var cobRequest = new CobRequestService();

var cob = await cobRequest.GetByTxId("496b0fd872ba49a0ad5b55572debdabf");

var payload = cob.ToPayload(new Merchant("Alexandre Lima", "Presidente Prudente"));

var stringToQrCode = payload.GenerateStringToQrCode();

```

2 - Gerar o Payload a partir da cobrança criada
```csharp
 var payload = cob.ToPayload(new Merchant("Alexandre Lima", "Presidente Prudente"));
```

3 - Pegar uma string para setar em um QrCode a aprtir do Payload gerado

```csharp
 var stringToQrCode = payload.GenerateStringToQrCode();
```

Retornará uma string como esta:

```
00020126880014br.gov.bcb.pix2566qrcodes-pix.gerencianet.com.br/v2/47cfcf6092c342e7bf2a24036d03ca9952040000530398654041.005802BR5914Alexandre Lima6019Presidente Prudente62290525496b0fd872ba49a0ad5b55572630459AE
```

4 - Por fim, basta setar em um QRCode! ;)

</details>



## QrCode Estático
Ideal para cobranças simples, sem a necessidade do acompanhamento de status ou outros tipos de registros.
Este carrega as característica da maquininha de cartão

#### ✅ Pontos fortes:
- Não necessita de conexão com a internet
- Não necessita de autenticação
- Não requer um PSP

#### ❌ Pontos fracos:
- Não é possível recuperar informações do status de pagamento
- Não é possiíel usar quaisquer serviços da [api oficial do pix](https://bacen.github.io/pix-api/#/Pix/get_pix)

<details>
   <summary> Como Gerar?</summary>

### Instale [este pacote](https://www.nuget.org/packages/pix-dynamic-payload-generator.net) na sua aplicação.

1 - Crie uma instância de Cobrança usando como parâmetros a chave pix, em seguida converta para um Payload passando como parâmetro o id de identificação da transação e informações do títular da conta.

```csharp
var cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1");
```

#### Você pode optar por adicionar mais algumas informações (não obrigatório):
- Valor (Caso não informado, ficará livre para o pagador digitar o valor);
- Descriçao (Caso informado, aparecerá no momento do pagamento).

Exemplo, definindo o valor de R$ 15,00 e descrição "Pagamento do pedido X":
```csharp
Cobranca cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1")
{
    SolicitacaoPagador = "Pagamento do Pedido X",
    Valor = new Valor
    {
        Original = "15.00"
    }
};

```

2 - Gerar o Payload a partir da cobrança criada
```csharp
var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"));
```

3 - Pegar uma string para setar em um QrCode a aprtir do Payload gerado

```csharp
var stringToQrCode = payload.GenerateStringToQrCode();
```

Retornará uma string como esta:

```
00020126580014br.gov.bcb.pix0136bee05743-4291-4f3c-9259-595df1307ba1520400005303986540510.005802BR5914Alexandre Lima6019Presidente Prudente62180514Um-Id-Qualquer6304D475
```

4 - Por fim, basta setar em um QRCode! ;)

<img src='https://dyn-qrcode.vercel.app/api?url=00020126580014br.gov.bcb.pix0136bee05743-4291-4f3c-9259-595df1307ba1520400005303986540510.005802BR5914Alexandre%20Lima6019Presidente%20Prudente62180514Um-Id-Qualquer6304D475' />

</details>

# Informações Extra

- Caso necessite somente das funções apresentadas em QrCode estático, apenas [este pacote](https://github.com/alexandresanlim/pix-payload-generator.net) será o suficiente.
- Você pode usar [este site](https://pix.nascent.com.br/tools/pix-qr-decoder/) para validar e visualizar o QrCode gerado
