using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_payload_generator.net.Models.Attributes.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace pix_dynamic_payload_generator.net.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DevedorRequestAttribute : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if(obj is DevedorRequest devedorRequest)
            {
                var rxCpf = new Regex(@"/^\d{11}$/", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var rxCnpj = new Regex(@"/^\d{14}$/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (!string.IsNullOrWhiteSpace(devedorRequest?.Cpf))
                    return rxCpf.IsMatch(devedorRequest.Cpf);

                if (!string.IsNullOrWhiteSpace(devedorRequest?.Cnpj))
                    return rxCnpj.IsMatch(devedorRequest.Cnpj);
            }

            return true;
        }
    }
}
