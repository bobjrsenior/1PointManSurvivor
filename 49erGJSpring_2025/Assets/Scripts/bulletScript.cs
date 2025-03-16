using UnityEngine;

public class bulletScript : MonoBehaviour
{
    Transform playerTransform;
    Vector3 direction;
    [SerializeField]
    float movementSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        direction = (playerTransform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
        if(transform.position.x > 40)
        {
            Destroy(this);
        }
        if (transform.position.x < -40)
        {
            Destroy(this);
        }
        if (transform.position.y > 40)
        {
            Destroy(this);
        }
        if (transform.position.y < -40)
        {
            Destroy(this);
        }
    }
}
