using Microsoft.AspNetCore.Mvc;
using MyMLApp; // Namespace onde está sua classe SentimentModel

namespace MySentimentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SentimentController : ControllerBase
    {
        // Método para prever o sentimento a partir do texto fornecido
        [HttpPost]
        [Route("predict")]
        public ActionResult<string> Predict([FromBody] SentimentModel.ModelInput input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.Col0))
            {
                return BadRequest("Invalid input");
            }

            // Realiza a previsão
            var result = SentimentModel.Predict(input);

            // Verifica se a previsão é positiva ou negativa
            var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";

            // Retorna o resultado
            return Ok($"Text: {input.Col0}\nSentiment: {sentiment}");
        }
    }
}
