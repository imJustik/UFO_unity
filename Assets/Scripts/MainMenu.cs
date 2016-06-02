using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public bool play = false;
	public bool settings = false;
	public bool auther = false;
	public bool exit = false;
	public Camera mainCamera;
	public Camera camera1;
	// Use this for initialization
	void OnMouseEnter() {
        GetComponent<Renderer>().material.color = Color.red;
    }

	void OnMouseExit() {
		GetComponent<Renderer>().material.color =  Color.white;
	}

	void Start () {
		
	}
	void OnMouseUp() {
		if (play == true) {
			Debug.Log("Now: " + Manager.Instance.liveCounts);
			Manager.Instance.liveCounts = Manager.Instance.liveCounts - 1;
			Debug.Log("Minus one. Now: " + Manager.Instance.liveCounts);
			PlayerPrefs.SetInt("gusCount", + Manager.Instance.liveCounts);

			// Manager.Instance.quitTime = System.DateTime.Now.ToBinary().ToString();
			// PlayerPrefs.SetString("sysTime", Manager.Instance.quitTime);

			Application.LoadLevel(1);
			// camera1.enabled = false;
			// mainCamera.enabled  = true;
		}
		if (exit == true) {
			Manager.Instance.liveCounts = 5;
			PlayerPrefs.SetInt("gusCount", Manager.Instance.liveCounts);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
