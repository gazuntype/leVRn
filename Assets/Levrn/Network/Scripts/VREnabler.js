#pragma strict
import UnityEngine.VR;
import UnityEngine.SceneManagement;


function Start () {
	if (SceneManager.GetActiveScene().name == "Online Scene"){
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		VRSettings.enabled = true;
	}
	else if (SceneManager.GetActiveScene().name == "Offline Scene"){
		VRSettings.enabled = false;
	}
}

function Update () {

}