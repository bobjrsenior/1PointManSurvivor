using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public float dodgeRollSpeed;
    public float movementSpeedMultiplier = 1.0f;
    public float dodgeRollTime;
    private float dodgeRollTimer;

    public Sprite idleSprite;
    public Sprite walkingSprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public GameObject haloPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ScoreHandler.instance.runTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            Debug.Log("Jump");
            if(curPlayerState == PlayerStates.IDLE || curPlayerState == PlayerStates.WALKING)
                ChangeState(PlayerStates.DODGE_ROLL);
        }
        else if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (curPlayerState == PlayerStates.IDLE)
                ChangeState(PlayerStates.WALKING);
        }
        else{
            if (curPlayerState == PlayerStates.WALKING)
                ChangeState(PlayerStates.IDLE);
        }
        if(curPlayerState == PlayerStates.WALKING)
        {
            if(Input.GetButton("Horizontal"))
            { 
                transform.position += (Vector3)(Vector2.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime);
            }
            if(Input.GetButton("Vertical"))
            {
                transform.position += (Vector3)(Vector2.up * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
            }
        }
        else if(curPlayerState == PlayerStates.DODGE_ROLL)
        {
            dodgeRollTimer -= Time.deltaTime;
            if(dodgeRollTimer <= 0.0f)
            {
                // Exit Dodge Roll
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                    ChangeState(PlayerStates.WALKING);
                else
                    ChangeState(PlayerStates.IDLE);
            }
            else {
                Vector2 direction = (Vector2.right * Input.GetAxis("Horizontal")) + (Vector2.up * Input.GetAxis("Vertical"));
                transform.position += (Vector3)(direction * dodgeRollSpeed * Time.deltaTime);
            }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(haloPrefab, transform.position, Quaternion.identity);
        }
    }

    void ChangeState(PlayerStates state)
    {
        curPlayerState = state;
        switch(state)
        {
            case PlayerStates.IDLE:
                animator.SetBool("DodgeRoll", false);
                animator.SetBool("Walking", false);
            break;
            case PlayerStates.WALKING:
                animator.SetBool("DodgeRoll", false);
                animator.SetBool("Walking", true);
                break;
            case PlayerStates.DODGE_ROLL:
                animator.SetBool("DodgeRoll", true);
                animator.SetBool("Walking", false);
                dodgeRollTimer = dodgeRollTime;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag .Equals("Halo"))
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag.Equals("Enemy") && curPlayerState != PlayerStates.DODGE_ROLL)
        {
            ScoreHandler.instance.runTimer = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
