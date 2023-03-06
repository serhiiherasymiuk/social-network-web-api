using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        IOpenAIService openAIService;
        public OpenAIController(IOpenAIService openAIService)
        {
            this.openAIService = openAIService;
        }
    }
}
