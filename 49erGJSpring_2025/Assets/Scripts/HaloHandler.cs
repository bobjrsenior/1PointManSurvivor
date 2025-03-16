using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HaloHandler : MonoBehaviour
{
    public Vector2 initialScale;
    public float explosionTime;
    private float explosionTimer;

    void Awake()
    {
        transform.localScale = initialScale;   
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer += Time.deltaTime;

        transform.localScale = Vector2.Lerp(initialScale, Vector2.one, (explosionTimer / explosionTime));
        if (explosionTimer >= explosionTime)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
