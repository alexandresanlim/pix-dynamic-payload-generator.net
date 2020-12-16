using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.Base
{
    public interface IRequestBase : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        string GetBaseURI();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(object data);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<T> PostAsync<T>(object data, Dictionary<string, string> headers);
    }
}
