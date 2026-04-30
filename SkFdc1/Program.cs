using SkFdc1.Common;
using SkFdc1.Controllers;
using SkFdc1.Repositories.Implementations;
using SkFdc1.Services;
using SkFdc1.Services.Implementations;
using SkFdc1.Repositories;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // 1. 최하위 계층부터 생성 (공통 API 클라이언트)
            var apiClient = new ApiClient();

            // 2. 레포지토리 생성     
            var sensorRepo = new SensorRepository(apiClient);

            // 3. 서비스 생성
            var lotService = new LotService();
            var sensorService = new SensorService(sensorRepo);

            // 4. 컨트롤러 생성
            var lotController = new LotController();
            var sensorController = new SensorController(sensorService);

            Application.Run(new frmJang(sensorController, lotController));
        }
    }
}