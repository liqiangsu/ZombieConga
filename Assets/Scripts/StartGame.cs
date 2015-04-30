using UnityEngine;

public class StartGame : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	public void LoadLevel() {
		Application.LoadLevel("CongaScene");
	}
}