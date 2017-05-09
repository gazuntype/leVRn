using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NetworkControl : MonoBehaviour
{

	#region Public Variables Declaration
	public EventTrigger tentEventTrigger;

	[Header("Network Setup")]
	public GameObject startServer;
	public GameObject startClient;
	public GameObject createRoom;
	public GameObject joinRoom;
	public GameObject ipText;
	public GameObject inputField;
	public GameObject explore;
	public GameObject back;
	public GameObject begin;

	[Header("Dynamic Texts")]
	public Text title;
	public Text subTitle;
	public Text leftTitle;
	public Text leftInformation;
	public Text rightTitle;
	public Text rightInformation;

	[Header("Canvas")]
	public GameObject curvedCanvas;
	public GameObject titleCanvas;

	[HideInInspector]
	public static bool isExploring = false;

	private string[,] instructionText = new string[4,2];
	private string[,] titleText = new string[2, 2];
	#endregion

	#region TextSetUp
	void Awake()
	{
		titleText[0, 0] = "leVRn";
		titleText[1, 0] = "set up your leap motion";
		titleText[0, 1] = "leVRn";
		titleText[1, 1] = "Go out! Explore.";

		instructionText[0, 0] = "Mobile Setup";
		instructionText[1, 0] = "PC SETUP";
		instructionText[2, 0] = "Select Server\nRead out the displayed IP Address\nCreate Room\n\nps: selections are made by gazing at the button to be selected and clicking.";
		instructionText[3, 0] = "Select client\nFill in the IP Address of the server (mobile phone)\nAfter a room has been created by the server, select join room\n\nps: selections are made by gazing at the button to be selected and clicking.";

		instructionText[0, 1] = "Explore!";
		instructionText[1, 1] = "Navigation Instructions";
		instructionText[2, 1] = "Feel free to explore the world \n There are a lot of things to learn \n Visit the other tents and enjoy \n \n To connect your Leap Motion controller which allows you partake in certain learning exercises, come back to this tent.";
		instructionText[3,1] = "To move around, locate a teleportation pad. They are scattered around the area \n Look in the direction of a pad and when it glows up, click your headset to teleport to where the pad is. \n Go out and explore the world of learning!";
	}

	#endregion

	#region Network Set-Up
	NetworkManager manager;
	// Use this for initialization
	void Start()
	{
		tentEventTrigger.enabled = false;
		manager = GetComponent<NetworkManager>();
		createRoom.SetActive(false);
		joinRoom.SetActive(false);
		ipText.SetActive(false);
		inputField.SetActive(false);
		back.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartServer()
	{
		startServer.SetActive(false);
		startClient.SetActive(false);
		explore.SetActive(false);
		back.SetActive(true);
		createRoom.SetActive(true);
		ipText.SetActive(true);
	}

	public void StartClient()
	{
		startServer.SetActive(false);
		startClient.SetActive(false);
		explore.SetActive(false);
		back.SetActive(true);
		joinRoom.SetActive(true);
		inputField.SetActive(true);
	}

	public void Back()
	{
		startServer.SetActive(true);
		startClient.SetActive(true);
		explore.SetActive(true);
		joinRoom.SetActive(false);
		inputField.SetActive(false);
		createRoom.SetActive(false);
		ipText.SetActive(false);
		back.SetActive(false);
	}

	public void CreateRoom()
	{
		if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
		{
			manager.StartServer();
		}
	}

	public void JoinRoom()
	{
		if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
		{
			manager.StartClient();
		}
	}
	#endregion

	#region Explore
	public void Explore()
	{
		begin.SetActive(true);
		startServer.SetActive(false);
		startClient.SetActive(false);
		explore.SetActive(false);
		subTitle.text = titleText[1, 1];
		leftTitle.text = instructionText[0, 1];
		leftInformation.text = instructionText[2, 1];
		rightTitle.text = instructionText[1, 1];
		rightInformation.text = instructionText[3, 1];
	}

	public void Begin()
	{
		isExploring = true;
		subTitle.text = titleText[1, 0];
		leftTitle.text = instructionText[0, 0];
		leftInformation.text = instructionText[2, 0];
		rightTitle.text = instructionText[1, 0];
		rightInformation.text = instructionText[3, 0];
		curvedCanvas.SetActive(false);
		titleCanvas.SetActive(true);
		tentEventTrigger.enabled = true;

		startServer.SetActive(true);
		startClient.SetActive(true);
		explore.SetActive(true);
		begin.SetActive(false);
	}
	#endregion
}
