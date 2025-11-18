using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";  
    [SerializeField] int lifeAmount = 1;           

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something touched the HEART: " + other.name);

        
        if (!other.CompareTag(playerTag))
            return;

       
        DestroyOnTrigger2D lifeScript = other.GetComponent<DestroyOnTrigger2D>();
        if (lifeScript != null)
        {
            lifeScript.AddLife(lifeAmount);  
            Debug.Log("Heart collected! Added life to " + other.name);
        }
        else
        {
            Debug.LogWarning("No DestroyOnTrigger2D found on " + other.name);
        }

    
        Destroy(gameObject);
    }
}

