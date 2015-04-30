using UnityEngine;
using System.Collections;

public class UIRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restart()
    {
        int lastLevel = PlayerPrefs.GetInt("LastLevel");
        Application.LoadLevel(lastLevel);
    }
}
