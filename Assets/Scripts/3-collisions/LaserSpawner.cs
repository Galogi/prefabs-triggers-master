using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;

    [SerializeField] float spawnInterval = 3f;
    [SerializeField] float minX = -7f;
    [SerializeField] float maxX = 7f;

    GameObject currentLaser;   

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
         
            if (currentLaser != null)
            {
                Destroy(currentLaser);
            }

        
            float x = Random.Range(minX, maxX);
            Vector3 pos = new Vector3(x, transform.position.y, 0f);

            currentLaser = Instantiate(laserPrefab, pos, Quaternion.identity);

           
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
