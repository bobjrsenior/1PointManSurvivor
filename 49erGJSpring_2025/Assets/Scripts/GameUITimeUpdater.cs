using TMPro;
using UnityEngine;

public class GameUITimeUpdater : MonoBehaviour
{
    private TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (((int)(ScoreHandler.instance.timeSurvived * 100)) / 100.0f) + "";
    }
}
