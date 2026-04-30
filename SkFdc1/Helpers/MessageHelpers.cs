using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Helpers
{
	public static class MessageHelper
	{
		private const string AppTitle = "SK FDC";

		// ────────────────────────────────────
		// 기본 메시지
		// ────────────────────────────────────

		public static void ShowInfo(string message)
			=> MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

		public static void ShowWarning(string message)
			=> MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

		public static void ShowError(string message)
			=> MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);


		// ────────────────────────────────────
		// 확인/취소가 필요한 메시지
		// ────────────────────────────────────

		/// <summary>
		/// 확인/취소 다이얼로그
		/// <para>확인 → true / 취소 → false</para>
		/// </summary>
		public static bool Confirm(string message)
		{
			DialogResult result = MessageBox.Show(message, AppTitle,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			return result == DialogResult.Yes;
		}

		/// <summary>
		/// 삭제 확인 (메시지 고정)
		/// </summary>
		public static bool ConfirmDelete(string targetName = "")
		{
			string msg = string.IsNullOrEmpty(targetName)
				? "정말 삭제하시겠습니까?"
				: $"[{targetName}] 을(를) 삭제하시겠습니까?";

			return Confirm(msg);
		}

		// ────────────────────────────────────
		// 저장/처리 결과 메시지
		// ────────────────────────────────────

		/// <summary>저장 성공</summary>
		public static void ShowSaveSuccess()
			=> ShowInfo("저장되었습니다.");

		/// <summary>삭제 성공</summary>
		public static void ShowDeleteSuccess()
			=> ShowInfo("삭제되었습니다.");

		/// <summary>처리 성공</summary>
		public static void ShowSuccess(string message)
			=> ShowInfo(message);

		// ────────────────────────────────────
		// 유효성 검사 메시지
		// ────────────────────────────────────

		/// <summary>필수값 미입력 안내</summary>
		public static void ShowRequired(string fieldName)
			=> ShowWarning($"[{fieldName}] 은(는) 필수 입력값입니다.");

		/// <summary>선택 항목 없음 안내</summary>
		public static void ShowNoSelection(string targetName = "항목")
			=> ShowWarning($"{targetName}을(를) 선택해주세요.");

	}
}
