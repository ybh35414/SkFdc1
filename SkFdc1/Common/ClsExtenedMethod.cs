using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkFdc1.Common
{
	public static class clsExtenedMethod
	{

		public static int? ToNullableInt(this object value)
		{
			if (value == null) return null;

			return int.TryParse(value.ToString(), out int result)
				? result
				: (int?)null;
		}

		public static double? ToNullableDouble(this object value)
		{
			if (value == null) return null;

			return double.TryParse(value.ToString(), out double result)
				? result
				: (int?)null;
		}
	}


	/// <summary>
	/// combobox 확장 메서드 
	/// </summary>
	public static class ComboBoxExtensions
	{
		public static string GetValue(this ComboBox combo)
		{
			return combo.SelectedValue?.ToString() ?? "";
		}

		public static int GetValueI(this ComboBox combo)
		{
			return Convert.ToInt32(combo.SelectedValue?.ToString());
		}

		public static string GetTextValue(this ComboBox combo)
		{
			return combo.Text;
		}

		public static void SetValue(this ComboBox combo, string value)
		{
			combo.SelectedValue = value;
		}

		public static void ClearItems(this ComboBox combo)
		{
			combo.DataSource = null;
			combo.Items.Clear();
			combo.Text = "";
		}
	}

}
