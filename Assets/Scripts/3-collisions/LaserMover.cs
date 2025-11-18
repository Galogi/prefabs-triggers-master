using UnityEngine;

public class LaserMover : MonoBehaviour
{
    [SerializeField] float speed = 2f;   
    [SerializeField] float range = 3f;   

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        
        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);

       
        if (transform.position.y > startPos.y + range)
        {
            direction = -1;
        }
        else if (transform.position.y < startPos.y - range)
        {
            direction = 1;
        }
    }
}

