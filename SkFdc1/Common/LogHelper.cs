using log4net;
using log4net.Config;
using System.Reflection;

namespace SkFdc1.Common
{
	public static class LogHelper
	{
		// 호출한 클래스명으로 Logger 자동 생성
		private static ILog GetLogger()
		{
			// 호출 스택에서 실제 호출한 클래스 찾기
			var frame = new System.Diagnostics.StackFrame(2, false);
			var method = frame.GetMethod();
			var type = method?.DeclaringType ?? typeof(LogHelper);
			return LogManager.GetLogger(type);
		}

		// ────────────────────────────────────
		// 초기화 - Program.cs에서 1회 호출
		// ────────────────────────────────────
		public static void Init()
		{
			var repo = LogManager.GetRepository(Assembly.GetEntryAssembly());
			var configFile = new FileInfo("log4net.config");
			XmlConfigurator.Configure(repo, configFile);
		}

		// ────────────────────────────────────
		// 로그 레벨별 메서드
		// ────────────────────────────────────

		/// <summary>디버그 (개발 시 상세 추적용)</summary>
		public static void Debug(string message)
			=> GetLogger().Debug(message);

		/// <summary>정보 (정상 흐름 기록)</summary>
		public static void Info(string message)
			=> GetLogger().Info(message);

		/// <summary>경고 (처리는 됐지만 주의 필요)</summary>
		public static void Warn(string message)
			=> GetLogger().Warn(message);

		/// <summary>에러 (Exception 없이)</summary>
		public static void Error(string message)
			=> GetLogger().Error(message);

		/// <summary>에러 (Exception 포함) - 스택트레이스까지 기록</summary>
		public static void Error(string message, Exception ex)
			=> GetLogger().Error(message, ex);

		/// <summary>치명적 오류 (앱 중단 수준)</summary>
		public static void Fatal(string message, Exception ex)
			=> GetLogger().Fatal(message, ex);
	}
}