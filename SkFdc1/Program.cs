using SkFdc1.Common;
using SkFdc1.Controllers;
using SkFdc1.Repositories;
using SkFdc1.Repositories.Implementations;
using SkFdc1.Services;
using SkFdc1.Services.Implementations;
using SkFdc1.Services.Interfaces;

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
			// v1.1
			// v1.2 - API 통신 로직 개선, 트랜잭션 처리 추가

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
				var LotRepo = new StatusRepository(apiClient);
				var manageRepo = new ManageRepository(apiClient);

				// 3. 서비스 생성
				var lotService = new StatusService(LotRepo);
				var sensorService = new SensorService(sensorRepo);
				var manageService = new ManagaeService(manageRepo);

				// 4. 컨트롤러 생성
				var lotController = new StatusController(lotService);
				var sensorController = new SensorController(sensorService);
				var manageController = new ManageController(manageService);

				//Application.Run(new frmJang(sensorController, lotController));
				Application.Run(new frmFdcMain(lotController, manageController));
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