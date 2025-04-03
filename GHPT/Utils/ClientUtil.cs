using GHPT.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

using GHPT.Configs;

namespace GHPT.Utils
{
	public static class ClientUtil
	{
		public static async Task<ResponsePayload> Ask(GPTConfig config, string prompt, double temperature = 0.7, string? reasoningEffort = null)
		{
			var url = "https://api.openai.com/v1/chat/completions";

			AskPayload payload = config.Version switch {
				GPTVersion.GPTO3_MINI or GPTVersion.GPTO3_MINI_HIGH => new(
					config.Model,
					prompt,
					reasoningEffort
				),
				_ => new(
					config.Model,
					prompt,
					temperature
				)
			};
			var client = new HttpClient();
			client.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.Token}");

			var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));

			int statusCode = (int)response.StatusCode;
			if (statusCode < 200 || statusCode >= 300)
				throw new System.Exception($"Error: {response.StatusCode} {response.ReasonPhrase} {await response.Content.ReadAsStringAsync()}");

			var result = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<ResponsePayload>(result);
		}
	}
}
