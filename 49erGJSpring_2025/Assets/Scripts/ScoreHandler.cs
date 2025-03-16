using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler instance;
    public float timeSurvived;
    public float enemiesSlain;

    public bool runTimer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Init()
    {
        timeSurvived = 0.0f;
        enemiesSlain = 0.0f;
    }

    public void addToSlainCount()
    {
        enemiesSlain += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(runTimer)
        {
            timeSurvived += Time.deltaTime;
        }
    }
}
