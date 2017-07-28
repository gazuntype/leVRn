using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour {
	[HideInInspector]
	public static Theme backgroundTheme = Theme.black;

	[HideInInspector]
	public static Theme textTheme = Theme.black;

	[HideInInspector]
	public static Theme buttonTheme = Theme.white;

	public static Material change;
	public Image[] background;

	[Header("Materials")]
	public Material textMaterial;
	public Material buttonMaterial;
	public Material backgroundMaterial;
	public Material titleMaterial;
	public Material changeButton;

	[Header("Preview Objects")]
	public Text previewTitle;
	public Image previewBackground;
	public Text previewText;
	public Image previewButton;

	void Start()
	{
		change = changeButton;
		textMaterial.color = ThemeConverter(textTheme);
		buttonMaterial.color = ThemeConverter(buttonTheme);
		backgroundMaterial.color = ThemeConverter(backgroundTheme);
		titleMaterial.color = ThemeConverter(Theme.white);
	}


	public void ChangeTheme(Theme colour, GameObject child = null)
	{
		if (child.transform.parent.name == "Background")
		{
			backgroundTheme = colour;
			previewBackground.color = ThemeConverter(backgroundTheme);
			if (backgroundTheme == Theme.white)
			{
				previewTitle.color = ThemeConverter(Theme.black);
			}
			else
			{
				previewTitle.color = ThemeConverter(Theme.white);
			}
		}
		else if (child.transform.parent.name == "Buttons")
		{
			buttonTheme = colour;
			Debug.Log("I was called");
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
		if (backgroundTheme == Theme.white)
		{
			titleMaterial.color = ThemeConverter(Theme.black);
		}
		else
		{
			titleMaterial.color = ThemeConverter(Theme.white);
		}
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
