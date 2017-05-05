using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class NetworkControl : MonoBehaviour
{

	#region Public Variables Declaration
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


	[HideInInspector]
	public static bool isExploring = false;
	#endregion

	#region Network Set-Up
	NetworkManager manager;
	// Use this for initialization
	void Start()
	{
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
		subTitle.text = "Go out! Explore.";
		leftTitle.text = "Explore!";
		leftInformation.text = "Feel free to explore the world \n" +
			"There are a lot of things to learn \n" +
			"Visit the other tents and enjoy \n \n" +
			"To connect your Leap Motion controller which allows you partake in certain learning exercises, come back to this tent.";
		rightTitle.text = "Navigation Instructions";
		rightInformation.text = "To move around, locate a teleportation pad. They are scattered around the area \n" +
			"Look in the direction of a pad and when it glows up, click your headset to teleport to where the pad is. \n" +
			"Go out and explore the world of learning!";
	}

	public void Begin()
	{
		isExploring = true;
		curvedCanvas.SetActive(false);
	}
	#endregion
}
