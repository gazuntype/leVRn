using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterTent : MonoBehaviour {

	[HideInInspector]
	public static bool animationComplete;

	[Tooltip("Total time of the animation.")]
	public float animationTime;

	[Range(0, 10)]
	[Tooltip("The amount of time to delay before beginning the animation.")]
	public float initialDelay = 5;

	[Tooltip("The UI Text component that shall display the animation.")]
	public Text textComponent;

	[TextArea]
	[Tooltip("The string that should be animated")]
	public string text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowInstruction()
	{
		StartCoroutine(AnimateText());
	}

	public IEnumerator AnimateText()
	{
		animationComplete = false;
		for (int i = 0; i < text.Length; i++)
		{
			if (i == 0)
			{
				textComponent.text = text[i].ToString();
			}
			else
			{
				textComponent.text += text[i];
			}
			yield return new WaitForSeconds(animationTime / text.Length);
		}
		animationComplete = true;
	}
}
