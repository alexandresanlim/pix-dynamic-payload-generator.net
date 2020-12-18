# Pix - Dynamic Payload Generator .net


<img width='200' src='https://user-images.githubusercontent.com/5353685/101644586-233eb080-3a14-11eb-9cec-2172586abfde.png'/>

[![Nuget](https://img.shields.io/nuget/dt/pix-dynamic-payload-generator.net)](https://www.nuget.org/packages/pix-dynamic-payload-generator.net)
[![Nuget](https://img.shields.io/nuget/v/pix-dynamic-payload-generator.net)](https://www.nuget.org/packages/pix-dynamic-payload-generator.net)

Este pacote auxilia na geração de payloads para usar em QRCode estático ou dinâmico PIX (Sistema de pagamento instântaneo do Brasil)

# ⚠ Informações importantes (limitações)

### Para a geração de QrCode dinâmico:
- Requer um PSP
- Necessita de autenticação
- Necessita de conexão com a internet

### Para a geração de QrCode estático:
- Não é possivel recuperar informações do status de pagamento
- Não é possivel usar qualquer serviço da [api oficial do pix](https://bacen.github.io/pix-api/#/Pix/get_pix)

# Como usar?

### 1 - Instale [este pacote](https://www.nuget.org/packages/pix-dynamic-payload-generator.net) na sua aplicação.
