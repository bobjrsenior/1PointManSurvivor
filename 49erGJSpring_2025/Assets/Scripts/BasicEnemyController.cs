using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    public float movementSpeed;
    public Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (playerTransform.position - transform.position).normalized * movementSpeed * Time.deltaTime;
    }
}
