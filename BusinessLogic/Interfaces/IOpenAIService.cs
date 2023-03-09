namespace Core.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GenerateResponse(string question);
    }
}
