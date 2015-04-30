using UnityEngine;
using System.Collections;

public class EnemyFollowController : MonoBehaviour
{

    public GameObject Zombie;
    public float MovementSpeed;
    public float RotationSpeed;
	// Use this for initialization
	void Start () {
	    Zombie = GameObject.FindGameObjectWithTag("zombie");
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    public void Follow()
    {
        var direction = Zombie.transform.position - transform.position;
        direction.z = 0;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle + 180), RotationSpeed * Time.deltaTime);

        this.transform.position = Vector3.MoveTowards(this.transform.position,
            Zombie.transform.position, MovementSpeed * Time.deltaTime);
    }
}
