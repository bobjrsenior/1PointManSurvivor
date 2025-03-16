using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerController : MonoBehaviour
{
    public enum PlayerStates
    {
        IDLE,
        WALKING,
        DODGE_ROLL,
        LONG_JUMP,
    };
    public PlayerStates curPlayerState = PlayerStates.IDLE;
    public float movementSpeed = 0.0f;

    public Sprite idleSprite;
    public Sprite walkingSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (curPlayerState == PlayerStates.IDLE)
                ChangeState(PlayerStates.WALKING);
        }
        else{
            if (curPlayerState == PlayerStates.WALKING)
                ChangeState(PlayerStates.IDLE);
        }
        if(Input.GetButton("Horizontal"))
        { 
            transform.position += (Vector3)(Vector2.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime);
        }
        if(Input.GetButton("Vertical"))
        {
            transform.position += (Vector3)(Vector2.up * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        }
    }

    void ChangeState(PlayerStates state)
    {
        curPlayerState = state;
        switch(state)
        {
            case PlayerStates.IDLE:
                spriteRenderer.sprite = idleSprite;
                animator.SetBool("Walking", false);
            break;
            case PlayerStates.WALKING:
                spriteRenderer.sprite = walkingSprite;
                animator.SetBool("Walking", true);
                break;
        }
    }
}
