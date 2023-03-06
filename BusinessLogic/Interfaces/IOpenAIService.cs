using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GenerateResponse(string question);
    }
}
