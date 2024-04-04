using SedisBackend.Core.Application.Dtos.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Services
{
    public interface IEmailServices
    {
        Task SendAsync(EmailRequest request);
    }
}
