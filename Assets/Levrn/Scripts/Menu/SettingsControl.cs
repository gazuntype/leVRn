using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour {
	public Theme theme;

	public Image[] background;

	public void ChangeTheme(Theme colour)
	{
		theme = colour;
		switch (theme)
		{
			case Theme.red:
				foreach (Image back in background)
				{
					back.color = Color.red;
				}
				break;
			case Theme.blue:
				foreach (Image back in background)
				{
					back.color = Color.blue;
				}
				break;
			case Theme.pink:
				foreach (Image back in background)
				{
					Color pink;
					pink = new Vector4(255, 0, 248, 255);
					back.color = pink;
				}
				break;
			case Theme.white:
				foreach (Image back in background)
				{
					back.color = Color.white;
				}
				break;
		}
	}

	public enum Theme { blue, red, black, white, pink }
}
