#pragma strict
import UnityEngine.Networking;

private var ipText : TextMesh;
private var ipAddress : String;

function Start () {
	ipText = GetComponent(TextMesh);
}

function Update () {
	ipAddress = Network.player.ipAddress;
	ipText.text = "IP Address: " + ipAddress;
}
