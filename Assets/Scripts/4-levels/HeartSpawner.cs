using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    [Header("What to spawn")]
    [SerializeField] GameObject heartPrefab;     

    [Header("Timing")]
    [SerializeField] float spawnInterval = 10f;  
    [SerializeField] float heartLifetime = 5f;   

    [Header("Limit")]
    [SerializeField] int maxHeartsOnScreen = 1; 

    float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            TrySpawnHeart();
        }
    }

    void TrySpawnHeart()
    {
        if (heartPrefab == null)
        {
            Debug.LogWarning("HeartSpawner: heartPrefab is not set!");
            return;
        }

     
        if (maxHeartsOnScreen > 0)
        {
            GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
            if (hearts.Length >= maxHeartsOnScreen)
                return;
        }

        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogWarning("HeartSpawner: No main camera found!");
            return;
        }

        float vx = Random.Range(0.1f, 0.9f);   
        float vy = Random.Range(0.2f, 0.8f);

        Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(vx, vy, cam.nearClipPlane));
        worldPos.z = 0f; 

        GameObject heart = Instantiate(heartPrefab, worldPos, Quaternion.identity);

        if (heartLifetime > 0f)
        {
            Destroy(heart, heartLifetime);
        }
    }
}
