using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using pix_dynamic_payload_generator.net.Responses;
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
            return await GetAsync<Pix>("/" + e2eid);
        }

        /// <summary>
        /// Consultar lista de PIX
        /// </summary>
        /// <param name="startDate">Data de início</param>
        /// <param name="endDate">Até (se não informado, por padrão será adicionado 24 horas a partir do startdate)</param>
        /// <returns></returns>
        public async Task<PixConsultaResponse> GetByPeriod(DateTime startDate, DateTime? endDate = null)
        {
            endDate = endDate ?? startDate.AddHours(24);

            return await GetAsync<PixConsultaResponse>("?inicio=" + startDate.ToString("u") + "&fim=" + endDate.Value.ToString("u"));
        }
    }
}
