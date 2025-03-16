using UnityEngine;

public class MainGameCameraHandler : MonoBehaviour
{
    public Transform toFollow;

    // Update is called once per frame
    void Update()
    {
        if(toFollow != null)
            transform.position = toFollow.transform.position + (transform.position.z * Vector3.forward);
    }
}
