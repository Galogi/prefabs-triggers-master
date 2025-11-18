using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyOnTrigger2D : MonoBehaviour
{
    [Header("Damage Settings")]
    [Tooltip("Any object with this tag will damage this object")]
    [SerializeField] string damagingTag = "Enemy";   

    [Header("Lives")]
    [SerializeField] int startingLives = 3;         
    int currentLives;

    [Header("UI (optional)")]
    [SerializeField] Text livesText;
    [SerializeField] string gameOverSceneName;

    [Header("Shield (optional)")]
    [SerializeField] PlayerShield playerShield;     

    public event System.Action onHit;

    private void Start()
    {
        currentLives = startingLives;
        UpdateLivesUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled || !other.CompareTag(damagingTag))
            return;

       
        if (playerShield != null && playerShield.TryBlockHit())
        {
            Debug.Log("Hit absorbed by shield!");
          
            return;
        }

       
        currentLives--;
        Debug.Log($"{name} was hit! lives = {currentLives}");
        onHit?.Invoke();

        Destroy(other.gameObject);

        UpdateLivesUI();

        if (currentLives <= 0)
        {
            Debug.Log("Game Over");

            if (!string.IsNullOrEmpty(gameOverSceneName))
            {
                SceneManager.LoadScene(gameOverSceneName);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void AddLife(int amount = 1)
    {
        currentLives += amount;
        UpdateLivesUI();
        Debug.Log($"{name} got a heart! lives = {currentLives}");
    }

    private void Update()
    {
        
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            int displayLives = Mathf.Max(0, currentLives);
            livesText.text = displayLives.ToString();
        }
    }
}
