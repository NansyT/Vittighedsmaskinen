using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vittighedsmaskinen.ApiKeyFolder
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}
