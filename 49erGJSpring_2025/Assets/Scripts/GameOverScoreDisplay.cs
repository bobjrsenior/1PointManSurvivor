using TMPro;
using UnityEngine;

public class GameOverScoreDisplay : MonoBehaviour
{
    private TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void Start()
    {
        if(ScoreHandler.instance.enemiesSlain > 0)
        {
            text.text = "Time Survived: " + (int) ScoreHandler.instance.timeSurvived + " Seconds\nEnemies Slain: " + ScoreHandler.instance.enemiesSlain;
        }
        else
        {
            text.text = "Time Survived: " + (int) ScoreHandler.instance.timeSurvived + " Seconds\nDead before you could use the grenade";
        }
    }
}
