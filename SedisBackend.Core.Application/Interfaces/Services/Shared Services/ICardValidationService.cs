using SedisBackend.Core.Application.Dtos.Shared_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Services.Shared_Services
{
    public interface ICardValidationService
    {
        public Task<IdVerificationDto> VerifyCardId(string IdCard);
    }
}
