using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Common
{
	public static class Util
	{
		/// <summary>
		/// Textbox 체크 및 메세지 박스 처리
		/// </summary>
		/// <param name="blMsgbox"></param>
		/// <param name="items"></param>
		/// <returns></returns>
		public static bool ValidateRequired(bool blMsgbox
			, params(TextBox textBox, string fieldName)[] items)
		{
			foreach (var item in items)
			{
				if (string.IsNullOrWhiteSpace(item.textBox.Text))
				{
					if (blMsgbox)
						MessageHelper.ShowRequired(item.fieldName);
					item.textBox.Focus();
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// TextBpx Clear
		/// </summary>
		/// <param name="textboxs">param TextBox</param>
		public static void ClearTextBox(params TextBox[] textboxs)
		{
			foreach (TextBox item in textboxs)
			{
				item.Text = "";
			}
		}

		/// <summary>
		/// T[]중에 Value가 포함되어 있는지 체크
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <param name="items"></param>
		/// <returns></returns>
		public static bool IsOneOf<T>(this T value, params T[] items)
		{

			for (int i = 0; i < items.Length; ++i)
			{
				if (items[i].Equals(value))
					return true;
			}

			return false;
		}
	}
}
