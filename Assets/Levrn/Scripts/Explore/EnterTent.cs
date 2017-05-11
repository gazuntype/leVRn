using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class EnterTent : MonoBehaviour
{
	public GameObject player;

	[Header("Tent Entering Properties")]
	public GameObject titleCanvas;

	[Tooltip("The canvas that contains the curved canvas of the tent.")]
	public GameObject curvedCanvas;

	[Tooltip("The name of the teleport pad in front of this particular tent.")]
	public string teleportPadName;

	[Tooltip("The Vector3 position data for when the user is inside the tent.")]
	public Vector3 insideTent;


	[HideInInspector]
	public static bool animationComplete;

	[Header("Animate Instruction Text Properties")]
	[Tooltip("Total time of the animation in seconds.")]
	public float animationTime;

	[Range(0, 10)]
	[Tooltip("The amount of time to delay before beginning the animation.")]
	public float initialDelay = 5;

	[Tooltip("The UI Text component that shall display the animation for the instruction.")]
	public Text textComponent;

	[TextArea]
	[Tooltip("The string that should be animated as instruction.")]
	public string text;

	private EventTrigger tentEventTrigger;

	// Use this for initialization
	void Start () {
		tentEventTrigger = GetComponent<EventTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Teleportation.isOutside)
		{
			OutsideTentProperties();
		}
		else
		{
			InsideTentProperties();
		}
	}

	void LateUpdate()
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
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
		animationComplete = true;
		textComponent.text = "";
	}

	public void EnterTentOnClick()
	{
		player.transform.position = insideTent;
		Teleportation.isOutside = false;
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

	void OutsideTentProperties()
	{
		if (!titleCanvas.activeSelf)
		{
			titleCanvas.SetActive(true);
		}
		if (!tentEventTrigger.enabled)
		{
			tentEventTrigger.enabled = true;
		}
		if (curvedCanvas.activeSelf)
		{
			curvedCanvas.SetActive(false);
		}
	}

	void InsideTentProperties()
	{
		if (titleCanvas.activeSelf)
		{
			titleCanvas.SetActive(false);
		}
		if (tentEventTrigger.enabled)
		{
			tentEventTrigger.enabled = false;
		}
		if (!curvedCanvas.activeSelf)
		{
			curvedCanvas.SetActive(true);
		}
	}
}
