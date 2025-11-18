using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag))
            return;

  
        PlayerShield shield = other.GetComponent<PlayerShield>();
        if (shield != null)
        {
            shield.ActivateShield();
        }

        Destroy(gameObject);
    }
}
