using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{

    public Text ScoreText;
    public GameObject Zombie;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
	    int score = Zombie.GetComponent<ZombieController>().Score;
	    ScoreText.text = "" + score;
	}
}
