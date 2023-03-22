using Core.Interfaces;
using OpenAI_API.Completions;

namespace Core.Services
{
    public class OpenAIService : IOpenAIService
    {
        public async Task<string> GenerateResponse(string question)
        {
            var api = new OpenAI_API.OpenAIAPI("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");
            var result = await api.Completions.CreateCompletionAsync(question, temperature: 0.1, max_tokens: 3000);
            return result.ToString();
        }
    }
}