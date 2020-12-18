using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices
{
    /// <summary>
    /// Reúne endpoints destinados a lidar com gerenciamento de Pix recebidos.
    /// </summary>
    public class PixRequestService : RequestBase
    {
        public PixRequestService()
        {
            SetRoute("pix");
        }

        /// <summary>
        /// Endpoint para consultar um Pix através de um e2eid.
        /// </summary>
        /// <param name="e2eid"></param>
        /// <returns></returns>
        public async Task<Pix> GetByE2eid(string e2eid)
        {
            return await GetAsync<Pix>(e2eid);
        }
    }
}
