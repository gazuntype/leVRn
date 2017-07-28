using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour {
	[HideInInspector]
	public static Theme backgroundTheme;

	[HideInInspector]
	public static Theme textTheme;

	[HideInInspector]
	public static Theme buttonTheme;

	public Image[] background;

	public Material textMaterial, buttonMaterial, backgroundMaterial;

	[Header("Preview Objects")]
	public Image previewBackground;
	public Text previewText;
	public Image previewButton;


	public void ChangeTheme(Theme colour, GameObject child = null)
	{
		if (child.transform.parent.name == "Background")
		{
			backgroundTheme = colour;
			previewBackground.color = ThemeConverter(backgroundTheme);
		}
		else if (child.transform.parent.name == "Buttons")
		{
			buttonTheme = colour;
			previewButton.color = ThemeConverter(buttonTheme);
		}
		else if (child.transform.parent.name == "Text")
		{
			textTheme = colour;
			previewText.color = ThemeConverter(textTheme);
		}
	}

	public void ApplySettings()
	{
		foreach (Image back in background)
		{
			back.color = ThemeConverter(backgroundTheme);
		}
		buttonMaterial.color = ThemeConverter(buttonTheme);
		textMaterial.color = ThemeConverter(textTheme);
	}


	public static Color ThemeConverter(Theme color)
	{
		Color correctColor;
		switch (color)
		{
			case Theme.red:
				correctColor = Color.red;
				break;
			case Theme.blue:
				Color blue;
				blue = new Vector4(0, 255, 244, 255);
				correctColor = blue;
				break;
			case Theme.pink:
				Color pink;
				pink = new Vector4(255, 0, 248, 255);
				correctColor = pink;
				break;
			case Theme.black:
				correctColor = Color.black;
				break;
			case Theme.white:
				correctColor = Color.white;
				break;
			default:
				correctColor = Color.black;
				break;
		}
		return correctColor;
	}

	public enum Theme { blue, red, black, white, pink }
}
