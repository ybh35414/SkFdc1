using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SkFdc1.Common
{
	public class ApiClient
	{
		// 버전 1.1
		private readonly HttpClient _client;

		public ApiClient()
		{
			_client = new HttpClient();
			_client.BaseAddress = new Uri("http://localhost:8080/api/fdc/");
		}

		// Get
		public async Task<T> GetAsync<T>(string url)
		{
			HttpResponseMessage response = await _client.GetAsync(url);
			response.EnsureSuccessStatusCode();

			string json = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(json);
		}

		// Post
		public async Task<string> PostAsync<T>(string url, T data)
		{
			string jsonData = JsonConvert.SerializeObject(data);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await _client.PostAsync(url, content);
			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsStringAsync();
		}
	}
}
