using UnityEngine;
using UnityEngine.SceneManagement;

public class GrenadeCutscenePlayer : MonoBehaviour
{

    public float timerToGrenade;
    public float movementSpeed;
    public AudioClip[] audioClips;
    private int clipPlaying = -1;

    private Animator animator;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        animator.SetBool("Walking", true);   
    }

    // Update is called once per frame
    void Update()
    {
        timerToGrenade -= Time.deltaTime;
        if (timerToGrenade <= 0.0f)
        {
            if(!audioSource.isPlaying)
            {
                clipPlaying += 1;
                if(clipPlaying > audioClips.Length)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    audioSource.clip = audioClips[clipPlaying];
                    audioSource.Play();
                }
            }
        }
        else
        {
            transform.position += (Vector3)(Vector2.one * movementSpeed * Time.deltaTime);
        }
    }
}
