using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SkFdc1.Models;

namespace SkFdc1.Common
{
	public class ApiClient
	{
        // 버전 1.1
        // 버전 1.2
        // ✅ static으로 선언 → 앱 전체에서 단 하나의 인스턴스만 사용
        private static readonly HttpClient _client;

        // ✅ static 생성자 → 최초 1회만 실행됨
        static ApiClient()
		{
			_client = new HttpClient
			{
				BaseAddress = new Uri("http://localhost:8080/api/fdc/"),
				Timeout = TimeSpan.FromSeconds(300)
			};

		}

		// Get
		public async Task<T> GetAsync<T>(string url)
		{
			try
			{
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(json);
            }
			catch (HttpRequestException ex)
			{
				LogHelper.Error($"[GET] API 통신 오류 : {url}", ex);
				throw new Exception($"[Get] API 통신 오류 : {url}\n{ex.Message}", ex);
			}
			catch (TaskCanceledException)
			{
				LogHelper.Warn($"[GET] 요청 시간 초과 : {url}");
				throw new Exception($"[GET] 요청시간 초과 : {url}");
			}			
		}

		// Post
		public async Task<string> PostAsync<T>(string url, T data)
		{
			try
			{
				string jsonData = JsonConvert.SerializeObject(data);
				StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

				HttpResponseMessage response = await _client.PostAsync(url, content);
				response.EnsureSuccessStatusCode();

				return await response.Content.ReadAsStringAsync();
			}
			catch (HttpRequestException ex)
			{
				throw new Exception($"[POST] API 통신 오류: {url}\n{ex.Message}", ex);
			}
			catch (TaskCanceledException)
			{
				throw new Exception($"[POST] 요청 시간 초과: {url}");

			}
		}

		// Post result 클래스
		public class ApiPostResult
		{
			public bool Success { get; set; } = false;
			public string Message { get; set; } = "";
		}



		// ============================================================
		// 0) 센서 기존 유무 확인 (CheckDuplicateAsync)
		// ============================================================
		public async Task<bool> CheckDuplicateAsync(string sensorID)
        {
			var json = JsonConvert.SerializeObject(new { sensorID });
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.PostAsync($"{_client.BaseAddress}/Sensor/dupl", content);

			return false;
        }

        // ============================================================
        // 1) 트랜잭션 시작(CreateTransactionLog)
        // ============================================================
        public async Task<string> CreateTransactionLogAsync(SensorDto dto)
		{
			var json = JsonConvert.SerializeObject(dto);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.PostAsync($"{_client.BaseAddress}/transaction/begin", content);
			if(!response.IsSuccessStatusCode)
			{
				return null;
			}
			var responseJson = await response.Content.ReadAsStringAsync();

			//서버가 {"txtID": "..."} 형태로 준다고 가정
			var result = JsonConvert.DeserializeObject<TransactionResponse>(responseJson);

			return result?.TxId;
        }

        // ============================================================
        // 2) 트랜잭션 커밋(CommitTransaction)
        // ============================================================
		public async Task<bool> CommitTransactionAsync(string txId)
		{
			var json = JsonConvert.SerializeObject(new { txId });
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.PostAsync($"{_client.BaseAddress}/transactio/commit", content);

			return response.IsSuccessStatusCode;
		}

        // ============================================================
        // 3) 트랜잭션 롤백(RollbackTransaction)
        // ============================================================
		public async Task<bool> RollbackTransactionAsync(string txId)
		{
			var json = JsonConvert.SerializeObject(new {txId});
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.PostAsync($"{_client.BaseAddress}/transaction/rollback", content);

			return response.IsSuccessStatusCode;
		}

        // ============================================================
        // 4) 센서 저장
        // ============================================================
        public async Task<bool> SaveSensorAsync(SensorDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_client.BaseAddress}/Sensor/save", content);
            return response.IsSuccessStatusCode;
        }


    }

    // =======================================
    // 공통 응답 모델
    // =======================================
	public class TransactionResponse
	{
        [JsonProperty("txID")]
        public string TxId { get; set; }
    }
}
