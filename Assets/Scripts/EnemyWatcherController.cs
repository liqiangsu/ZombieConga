using UnityEngine;
using System.Collections;

public class EnemyWatcherController : MonoBehaviour
{
    public Collider2D Colider;
    public bool IsZombieFound = false;
    public float SearchRotationSpeed;

    private EnemyFollowController followCOntroller;


	// Use this for initialization
	void Start ()
	{
	    followCOntroller = GetComponent<EnemyFollowController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (IsZombieFound)
	    {
	        followCOntroller.Follow();
	    }
	    else
	    {
	        Search();
	    }
	}

    void Search()
    {
        transform.rotation = this.transform.rotation * Quaternion.Euler(0, 0, SearchRotationSpeed * Time.deltaTime);
    }

    Vector3  RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3  angles ) {
       var dir = point - pivot; // get point direction relative to pivot
       dir = Quaternion.Euler(angles) * dir; // rotate it
       point = dir + pivot; // calculate rotated point
       return point; // return it
     }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            Debug.Log("engther");

            IsZombieFound = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            Debug.Log("exit");

            IsZombieFound = false;
        }
    }
}
