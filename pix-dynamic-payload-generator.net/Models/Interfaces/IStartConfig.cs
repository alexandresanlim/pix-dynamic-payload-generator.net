using System.Security.Cryptography.X509Certificates;

namespace pix_dynamic_payload_generator.net.Models.Interfaces
{
    public interface IStartConfig
    {
        /// <summary>
        /// Setar a Url base do seu PSP, ex:
        /// HML: https://api-seupsp-h.gerencianet.com.br
        /// PROD: https://api-seupsp.gerencianet.com.br
        /// </summary>
        string BaseURL { get; }

        string ClientId { get; }

        string ClientSecret { get; }

        X509Certificate2 Certificate { get; }
    }
}
