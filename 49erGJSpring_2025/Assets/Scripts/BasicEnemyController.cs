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
        if (playerTransform != null)
            transform.position += (playerTransform.position - transform.position).normalized * movementSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag .Equals("Halo"))
        {
            ScoreHandler.instance.addToSlainCount();
            Destroy(this.gameObject);
        }
    }
}
