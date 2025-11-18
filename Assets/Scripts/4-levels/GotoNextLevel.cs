using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour
{
    [SerializeField] string triggeringTag;   
    [SerializeField]
    [Tooltip("Name of scene to move to when triggering the given tag")]
    string sceneName;                        

    [SerializeField] int hitsToGameOver = 3; 
    int currentHits = 0;                     

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag))
        {
            currentHits++;
            Debug.Log("Enemy hit number: " + currentHits);

            if (currentHits >= hitsToGameOver)
            {
                Debug.Log("Game Over!");
               
                this.transform.position = Vector3.zero;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
