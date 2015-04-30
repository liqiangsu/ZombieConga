using UnityEngine;
using UnityEngine.UI;

public class UILevelName : MonoBehaviour
{
    private Text text;

	// Use this for initialization
	void Start ()
	{
	    text = GetComponent<Text>();
	    text.text = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
