using BusinessLogic.Interfaces;
using Database.Entities;
using Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class OpenAIService : IOpenAIService
    {
        public async Task<string> GenerateResponse(string question)
        {
            var api = new OpenAI_API.OpenAIAPI("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");
            var result = await api.Completions.GetCompletion(question);
            return result;
        }
    }
}
