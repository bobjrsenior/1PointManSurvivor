using UnityEngine;
using UnityEngine.SceneManagement;

public class goNextOnClipEnd : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
