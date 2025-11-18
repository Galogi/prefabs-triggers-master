using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    [SerializeField] GameObject shieldPrefab;
    [SerializeField] float spawnInterval = 15f;  
    [SerializeField] float shieldLifeTime = 10f; 

    float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnShield();
        }
    }

    void SpawnShield()
    {
        if (shieldPrefab == null)
        {
            Debug.LogWarning("ShieldSpawner: shieldPrefab is not set!");
            return;
        }

        Camera cam = Camera.main;
        if (cam == null)
            return;

        float vx = Random.Range(0.1f, 0.9f);
        float vy = Random.Range(0.2f, 0.8f);

        Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(vx, vy, cam.nearClipPlane));
        worldPos.z = 0f;

        GameObject shield = Instantiate(shieldPrefab, worldPos, Quaternion.identity);

        if (shieldLifeTime > 0f)
        {
            Destroy(shield, shieldLifeTime);
        }
    }
}
