using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour
{
    public float MinSpawnTime;
    public float MaxSpawnTime;
    public GameObject EnemyPrefab;
    public GameObject WarningPrefab;
	// Use this for initialization
	void Start ()
	{
        Invoke("SpawnEnemy", 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemy()
    {
        // 1
        Camera camera = Camera.main;
        Vector3 cameraPos = camera.transform.position;
        float xMax = camera.aspect * camera.orthographicSize;
        float xRange = camera.aspect * camera.orthographicSize * 1.75f;
        float yMax = camera.orthographicSize - 0.5f;

        // 2
        Vector3 pos =
            new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax),
                        Random.Range(-yMax, yMax),
                        EnemyPrefab.transform.position.z);

        // 3
        var warning = Instantiate(WarningPrefab, pos, Quaternion.identity) as GameObject;
        StartCoroutine(CreateEnemy(pos, 1.5f, warning));
        Invoke("SpawnEnemy", Random.Range(MinSpawnTime, MaxSpawnTime));
    }

    IEnumerator CreateEnemy(Vector3 pos, float delaySecond, GameObject sign)
    {
        yield return new WaitForSeconds(delaySecond);
        Destroy(sign);
        var enemy = Instantiate(EnemyPrefab, pos, Quaternion.identity * Quaternion.Euler(0,0,Random.Range(0,360))) as GameObject;
        //random rotation direction
        if (enemy)
        {
            enemy.GetComponent<EnemyWatcherController>().SearchRotationSpeed *= Random.Range(0, 1) * 2 - 1;
            Debug.Log(Random.Range(0, 1) * 2 - 1);
        }
    }

}
