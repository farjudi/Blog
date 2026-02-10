using Blog.Application.DTOs.SmsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Sms
{
    public class SendSmsUseCase
    {
        private readonly ISmsProvider _smsProvider;
        public SendSmsUseCase(ISmsProvider smsProvider)
        {
            _smsProvider = smsProvider;
            
        }

        public async Task ExecuteAsync(SendSmsDto Dto)
        {
            if(string.IsNullOrWhiteSpace(Dto.PhoneNumber))
                throw new ArgumentException("Phone number is required");

            await _smsProvider.SendAsync(
                Dto.PhoneNumber,
                Dto.Message
                );
        }
    }
}
