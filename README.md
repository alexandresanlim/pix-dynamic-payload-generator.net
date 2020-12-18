# Pix - Dynamic Payload Generator .net


<img width='200' src='https://user-images.githubusercontent.com/5353685/101644586-233eb080-3a14-11eb-9cec-2172586abfde.png'/>

[![Nuget](https://img.shields.io/nuget/dt/pix-dynamic-payload-generator.net)](https://www.nuget.org/packages/pix-dynamic-payload-generator.net)
[![Nuget](https://img.shields.io/nuget/v/pix-dynamic-payload-generator.net)](https://www.nuget.org/packages/pix-dynamic-payload-generator.net)

Este pacote auxilia na geração de payloads para usar em QRCode estático ou dinâmico PIX (Sistema de pagamento instântaneo do Brasil)

# ⚠ Informações importantes e limitações
Antes de começar, entenda um pouco sobre as diferenças dos dois tipos de geração de QrCodes disponibilizadas pelo Bacen ("QrCode estático" e "QrCode dinâmico")

## QrCode dinâmico
Ideal para sistemas ERP e ou onde necessita do acompanhamento do status de cada cobrança, vinculo com pedidos, inclusão de multas e juros e outros.
Este carrega as características de uma fatura de cobrança.

#### ✅ Pontos fortes:
- É possível recuperar informações do status de pagamento
- É possível usar todos os serviços da [api oficial do pix](https://bacen.github.io/pix-api/#/Pix/get_pix) disponibilizadas pelo seu PSP

#### ❌ Pontos fracos:
- Requer um PSP
- Necessita de autenticação
- Necessita de conexão com a internet


## QrCode estático
Ideal para cobranças simples, sem a necessidade do acompanhamento de status ou outros tipos de registros.
Este carrega as característica da maquininha de cartão

#### ✅ Pontos fortes:
- Não necessita de conexão com a internet
- Não necessita de autenticação
- Não requer um PSP

#### ❌ Pontos fracos:
- Não é possível recuperar informações do status de pagamento
- Não é possiíel usar quaisquer serviços da [api oficial do pix](https://bacen.github.io/pix-api/#/Pix/get_pix)

Caso necessite somente das funções apresentadas em QrCode estático, apenas [este pacote](https://github.com/alexandresanlim/pix-payload-generator.net) será suficiente.

<details>
   <summary> Como Gerar?</summary>

### Instale [este pacote](https://www.nuget.org/packages/pix-dynamic-payload-generator.net) na sua aplicação.

# Gerandor QrCode Estático

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

