using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Cors;
using System.Text.Json.Serialization;
using OpenAI_API.Completions;
using OpenAI_API;
using Microsoft.AspNetCore.DataProtection.KeyManagement;


namespace ContractQuestionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class ContractController : ControllerBase
    {
        private readonly ILogger<ContractController> _logger;

        public ContractController(ILogger<ContractController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile contract, string question)
        {
            try
            {
                // Extraction du texte du contrat
                string contractText = ExtractTextFromPdf(contract);

                // Envoi de la question et du texte du contrat à l'API de ChatGPT
                string response = await SendChatGPTRequest3(question, contractText);

       
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'appel à l'API de ChatGPT");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private string ExtractTextFromPdf(IFormFile contract)
        {
            using (var reader = new PdfReader(contract.OpenReadStream()))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
                return sb.ToString();
            }
        }

        private async Task<string> SendChatGPTRequest3(string question, string contractText)
        {
            //your OpenAI API key
            string apiKey = "Your KEY";
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);

            var rep = "";

            CompletionRequest completion2 = new CompletionRequest();
            var d = new StringContent("{\"prompt\": \"" + question + "\",\"contract_text\": \"" + contractText + "\"}", Encoding.UTF8, "application/json");
            completion2.Prompt = string.Format("{0} ? Contract: {1}", question, contractText);
            completion2.Model = "text-davinci-003";
            completion2.MaxTokens = 100;
            completion2.Temperature = 1;
            var result2 = openai.Completions.CreateCompletionAsync(completion2);
            if (result2 != null)
            {
                foreach (var item in result2.Result.Completions)
                {
                    rep = item.Text;
                }
                return rep;
            }
            else
            {
                return "";
            }
        }

    }

}
