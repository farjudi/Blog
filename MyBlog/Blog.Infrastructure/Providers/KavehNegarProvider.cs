using Blog.Application.Interfaces;
using Blog.Domain;
using Kavenegar;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Blog.Infrastructure.Providers
{
    public class KavehNegarProvider : ISmsProvider
    {

        private readonly KavehNegarSettings _settings;
        public KavehNegarProvider(IOptions<AppSettings> options)
        {
            _settings = options.Value.Modules.Sms.KavehNegar;
        }


        public async Task SendAsync(string phoneNumber, string message)
        {
            try
            {


                var api = new KavenegarApi(_settings.ApiKey);
                var result = await api.Send(_settings.SenderNumber, phoneNumber, message);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
