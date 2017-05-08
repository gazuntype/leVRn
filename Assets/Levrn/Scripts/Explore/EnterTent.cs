using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterTent : MonoBehaviour {
	[Header("Tent Entering Properties")]
	public GameObject titleCanvas;

	public string teleportPadName;

	[HideInInspector]
	public static bool animationComplete;

	[Header("Animate Text Properties")]
	[Tooltip("Total time of the animation in seconds.")]
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
		if (Teleportation.currentTeleportPad == null && !titleCanvas.activeSelf)
		{
			titleCanvas.SetActive(true);
		}
	}

	public void ShowInstruction()
	{
		if (Teleportation.currentTeleportPad == teleportPadName)
		{
			StartCoroutine(AnimateText());
		}
	}

	public void RemoveInstruction()
	{
		textComponent.text = "";
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
