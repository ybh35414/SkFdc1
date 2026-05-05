using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// 콤보박스 DTO
/// </summary>
public class ComboItem
{
	public string Value { get; set; }
	public string Text { get; set; }

	public ComboItem(string value, string text)
	{
		Value = value;
		Text = text;
	}
}

public class ComboItemI
{
	public int? Value { get; set; }
	public string Text { get; set; }

	public ComboItemI(int? value, string text)
	{
		Value = value;
		Text = text;
	}
}

/// <summary>
/// 콥보박스 유틸
/// </summary>
public static class ComboBoxHelper
{
	/// <summary>
	/// 콤보박스 바인딩
	/// </summary>
	public static void Bind(ComboBox combo, List<ComboItem> items, bool addEmpty = false)
	{
		if (addEmpty)
		{
			items.Insert(0, new ComboItem("", "선택"));
		}

		combo.DataSource = null;
		combo.DataSource = items;
		combo.DisplayMember = "Text";
		combo.ValueMember = "Value";
	}

	/// <summary>
	/// 콤보박스 바인딩
	/// </summary>
	public static void Bind(ComboBox combo, List<ComboItemI> items, bool addEmpty = false)
	{
		if (addEmpty)
		{
			items.Insert(0, new ComboItemI(null, "선택"));
		}

		combo.DataSource = null;
		combo.DataSource = items;
		combo.DisplayMember = "Text";
		combo.ValueMember = "Value";
	}


	/// <summary>
	/// 선택값 가져오기
	/// </summary>
	public static string GetValue(ComboBox combo)
	{
		if (combo.SelectedValue?.GetType().ToString() == "ComboItem")
			return ((ComboItem)combo.SelectedValue).Value?.ToString() ?? "";
		else
			return combo.SelectedValue?.ToString() ?? "";
	}

	public static int GetValueI(ComboBox combo)
	{
		if (combo.SelectedValue?.GetType().ToString() == "ComboItem")
			return Convert.ToInt32(((ComboItem)combo.SelectedValue).Value?.ToString());
		else
			return Convert.ToInt32(combo.SelectedValue?.ToString());
	}

	/// <summary>
	/// 선택 텍스트 가져오기
	/// </summary>
	public static string GetText(ComboBox combo)
	{
		return combo.Text;
	}

	/// <summary>
	/// 값으로 선택
	/// </summary>
	public static void SetValue(ComboBox combo, string value)
	{
		combo.SelectedValue = value;
	}

	public static void SetText(ComboBox combo, string text)
	{
		combo.SelectedText = text;
	}

	public static void SetIndex(ComboBox combo, int idx)
	{
		combo.SelectedIndex = idx;
	}

	/// <summary>
	/// 초기화
	/// </summary>
	public static void Clear(ComboBox combo)
	{
		combo.DataSource = null;
		combo.Items.Clear();
		combo.Text = "";
	}

	// ********************************** ENUM 사용

	/// <summary>
	/// ENUM 바인딩
	/// </summary>
	/// <typeparam name="T">ENUM</typeparam>
	/// <param name="combo">combobox</param>
	/// <param name="addEmpty">빈값 추가 여부</param>
	public static void BindEnum<T>(ComboBox combo, bool addEmpty = false) where T : Enum
	{
		var list = Enum.GetValues(typeof(T))
					   .Cast<T>()
					   .Select(e => new ComboItem(e.ToString(), e.ToString()))
					   .ToList();

		if (addEmpty)
		{
			list.Insert(0, new ComboItem("", "선택"));
		}

		combo.DataSource = null;
		combo.DataSource = list;
		combo.DisplayMember = "Text";
		combo.ValueMember = "Value";
	}

	public static T GetEnumValue<T>(ComboBox combo) where T : struct, Enum
	{
		if (Enum.TryParse<T>(combo.SelectedValue?.ToString(), out var result))
			return result;

		return default;
	}


	public static void SetEnumValue<T>(ComboBox combo, object value) where T : Enum
	{
		if (value == null) return;

		if (Enum.TryParse(typeof(T), value.ToString(), true, out var enumValue))
		{
			combo.SelectedValue = enumValue.ToString();
		}
	}
}
