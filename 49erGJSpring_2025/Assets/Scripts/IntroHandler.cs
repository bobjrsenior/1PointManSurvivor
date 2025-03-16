using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroHandler : MonoBehaviour
{
    public int currentIndex = 0;
    public AudioClip[] audioClips;
    public Sprite[] backgroundSprites;

    public AudioSource audioSource;
    public Image backgroundImage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = audioClips[currentIndex];
        backgroundImage.sprite = backgroundSprites[currentIndex];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            currentIndex += 1;
            if(currentIndex < audioClips.Length)
            {
                audioSource.clip = audioClips[currentIndex];
                backgroundImage.sprite = backgroundSprites[currentIndex];
                audioSource.Play();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
