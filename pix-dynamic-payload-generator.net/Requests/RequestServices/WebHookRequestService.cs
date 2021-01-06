using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices
{
    /// <summary>
    /// Reúne endpoints para gerenciamento de notificações por parte do PSP recebedor ao usuário recebedor.
    /// </summary>
    public class WebHookRequestService : RequestBase
    {
        public WebHookRequestService()
        {
            SetRoute("webhook");
        }

        /// <summary>
        /// Endpoint para configuração do serviço de notificações acerca de Pix recebidos. Somente Pix associados a um txid serão notificados.
        /// </summary>
        /// <param name="cob"></param>
        /// <returns></returns>
        public async Task<bool> Create(string key, WebHookRequest request)
        {
            return await PutAsync<bool>(key, request);
        }

        /// <summary>
        /// Consultar cobrança imediata usando o txId
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        public async Task<Webhook> GetByKey(string key)
        {
            return await GetAsync<Webhook>("/" + key);
        }
    }
}
