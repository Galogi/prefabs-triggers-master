using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [Header("Shield Visual")]
    [SerializeField] SpriteRenderer shieldRenderer; 
    [SerializeField] float shieldDuration = 5f;     

    float remainingTime = 0f;
    bool isActive = false;

    private void Start()
    {
        if (shieldRenderer != null)
        {
            shieldRenderer.enabled = false; 
        }
    }

    private void Update()
    {
        if (!isActive)
            return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            DeactivateShield();
            return;
        }

       
        if (shieldRenderer != null)
        {
            float t = remainingTime / shieldDuration; 
            Color c = shieldRenderer.color;
            c.a = t;           
            shieldRenderer.color = c;
        }
    }

    public void ActivateShield()
    {
        isActive = true;
        remainingTime = shieldDuration;

        if (shieldRenderer != null)
        {
            shieldRenderer.enabled = true;

          
            Color c = shieldRenderer.color;
            c.a = 1f;
            shieldRenderer.color = c;
        }
    }

    public void DeactivateShield()
    {
        isActive = false;

        if (shieldRenderer != null)
        {
            shieldRenderer.enabled = false;
        }
    }

    public bool TryBlockHit()
    {
        if (!isActive)
            return false;

      

        return true;
    }
}
