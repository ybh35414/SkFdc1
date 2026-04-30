using SkFdc1.Common;
using SkFdc1.Controllers;
using SkFdc1.Repositories;
using SkFdc1.Repositories.Implementations;
using SkFdc1.Services;
using SkFdc1.Services.Implementations;

namespace SkFdc1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			// Log4Net 초기화
			LogHelper.Init();
			LogHelper.Info("=== SK FDC 시작 ===");

            try
            {
				// To customize application configuration such as set high DPI settings or default font,
				// see https://aka.ms/applicationconfiguration.
				ApplicationConfiguration.Initialize();

				// 1. 최하위 계층부터 생성 (공통 API 클라이언트)
				var apiClient = new ApiClient();

				// 2. 레포지토리 생성     
				var sensorRepo = new SensorRepository(apiClient);
				var LotRepo = new LotRepository(apiClient);

				// 3. 서비스 생성
				var lotService = new LotService(LotRepo);
				var sensorService = new SensorService(sensorRepo);

				// 4. 컨트롤러 생성
				var lotController = new LotController(lotService);
				var sensorController = new SensorController(sensorService);

				//Application.Run(new frmJang(sensorController, lotController));
				Application.Run(new MainForm(lotController));
			}
            catch (Exception ex)
            {
				LogHelper.Fatal("앱 실행 중 치명적 오류 발생", ex);
				MessageHelper.ShowError("시스템 오류가 발생했습니다.\n관리자에게 문의하세요.");
			}
			finally
			{
				LogHelper.Info("=== SK FDC 종료 ===");
			}

		}
	}
}