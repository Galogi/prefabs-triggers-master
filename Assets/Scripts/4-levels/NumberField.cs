using TMPro;
using UnityEngine;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */
[RequireComponent(typeof(TextMeshPro))]
public class NumberField : MonoBehaviour
{
    private int number;

    [SerializeField] int killEvery = 20;  

    public int GetNumber()
    {
        return this.number;
    }

    public void SetNumber(int newNumber)
    {
        this.number = newNumber;
        GetComponent<TextMeshPro>().text = newNumber.ToString();
    }

    public void AddNumber(int toAdd)
    {
        SetNumber(this.number + toAdd);

        
        if (number > 0 && number % killEvery == 0)
        {
            KillEnemiesInCamera();
        }
    }

    private void KillEnemiesInCamera()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

       
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            
            Vector3 viewPos = cam.WorldToViewportPoint(enemy.transform.position);

          
            if (viewPos.z > 0 &&
                viewPos.x >= 0f && viewPos.x <= 1f &&
                viewPos.y >= 0f && viewPos.y <= 1f)
            {
                Destroy(enemy);
            }
        }
    }
}

