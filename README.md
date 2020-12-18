# Pix - Dynamic Payload Generator .net


<img width='200' src='https://user-images.githubusercontent.com/5353685/101644586-233eb080-3a14-11eb-9cec-2172586abfde.png'/>

[![Nuget](https://img.shields.io/nuget/dt/pix-dynamic-payload-generator.net)](https://www.nuget.org/packages/pix-dynamic-payload-generator.net)
[![Nuget](https://img.shields.io/nuget/v/pix-dynamic-payload-generator.net)](https://www.nuget.org/packages/pix-dynamic-payload-generator.net)

Este pacote auxilia na geração de payloads para usar em QRCode estático ou dinâmico PIX (Sistema de pagamento instântaneo do Brasil)

# ⚠ Informações importantes e limitações

## QrCode dinâmico
Ideal para sistemas ERP e ou onde necessita do acompanhamento do status de cada cobrança, vinculo com pedidos, inclusão de multas e juros e outros.
Este carrega as características de um boleto de cobrança.

#### ✅ Pontos fortes:
- É possível recuperar informações do status de pagamento
- É possiíel usar serviços da [api oficial do pix](https://bacen.github.io/pix-api/#/Pix/get_pix)

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
- Não é possiíel usar serviços da [api oficial do pix](https://bacen.github.io/pix-api/#/Pix/get_pix)

# Como usar?

### 1 - Instale [este pacote](https://www.nuget.org/packages/pix-dynamic-payload-generator.net) na sua aplicação.
