using UnityEngine;
using System.Collections;

public class MenuSpawn : MonoBehaviour {
	public Transform[] menuButtons;
	public Transform menuPlacer;
	public Transform mainCamera;
	Transform dataTracker;
	Vector3 trackedTransform;
	int trackedData;
	// Use this for initialization
	void Start () {
		dataTracker = GameObject.Find("DataTracker").GetComponent<Transform>();
		foreach (Transform g in menuButtons){
			g.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		trackedTransform = dataTracker.position;
		trackedData = (int)trackedTransform.x;
		if (trackedData == 1){
			foreach (Transform g in menuButtons){
				g.gameObject.SetActive(true);
			}
			for (int i = 0; i < 5; i++){
				float spacingX = 0.03f;
				float spacingY = 0.01f;
				menuButtons[i].position = menuPlacer.position + new Vector3(spacingX * i, -(spacingY * i * i), 0);
				menuButtons[i].LookAt(mainCamera);
			}
		}
		else{
			foreach (Transform g in menuButtons){
				g.gameObject.SetActive(false);
			}
		}
	}
}
