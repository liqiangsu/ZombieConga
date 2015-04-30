using UnityEngine;
using System.Collections;

public class UILives : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject LiveIcon;
    public GameObject LiveIconGroup;
    private GameObject[] livesIcons;
    private int lives;
	// Use this for initialization
	void Start ()
	{
	    lives = Zombie.GetComponent<ZombieController>().Lives;
        livesIcons = new GameObject[lives];
	    for (int i = 0; i < livesIcons.Length; i++)
	    {
            var icon = Instantiate(LiveIcon);
            livesIcons[i] = icon;
	        icon.transform.parent = LiveIconGroup.transform;
            icon.transform.localScale = new Vector3(1,1,1);

	        var rect = icon.GetComponent<RectTransform>();
            icon.transform.localPosition = new Vector3(i * rect.rect.width , 0,0);
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
        
        lives = Zombie.GetComponent<ZombieController>().Lives;
	    if (lives > livesIcons.Length)
	        return;
	    for (int i = 0; i < livesIcons.Length; i++)
	    {
	        livesIcons[i].GetComponent<CanvasRenderer>().SetAlpha(i < lives? 1f: 0f);
	    }
	}
}
