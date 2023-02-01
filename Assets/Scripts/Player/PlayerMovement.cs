using UnityEngine;

//Controls the players horizontal movement, jumping, and flipping of the level
public class PlayerMovement : MonoBehaviour
{

    public float movementForce;
    public float terminalVelocity;
    public float jumpForce;
    public int flipDirection = 1;

    GameManager gm;
    [SerializeField] LayerMask platformLayerMask;
    Rigidbody2D rb;
    PlayerInput playerInput;
    public Transform feetPosDown;
    public Transform feetPosUp;
    Transform feetPos;
    Animator animator;
    SpriteRenderer spriteRenderer;
    DayNightManager dayNightManager; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        gm = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dayNightManager = FindObjectOfType<DayNightManager>();

        feetPos = feetPosDown;
    }

    private void Update()
    {
        
        if (playerInput.flipInput && IsGrounded())
        {

            FlipGravity();

        }

    }

    void FixedUpdate()
    {
      
        rb.AddForce(Vector2.right * movementForce * playerInput.rollingInput);

        if (IsGrounded() && playerInput.jumpInput)
        {
         
            rb.AddForce(Vector2.up * jumpForce * flipDirection, ForceMode2D.Impulse);

        }

        ClampTerminalVelocity();

        animator.SetFloat("ratSpeed", (Mathf.Abs(playerInput.rollingInput) + (rb.velocity.x / terminalVelocity * playerInput.rollingInput))/2);

        if (playerInput.rollingInput > 0)
        {

            spriteRenderer.flipX = false;

        }
        else if (playerInput.rollingInput < 0)
        {

            spriteRenderer.flipX = true;

        }
    }

    public void FlipGravity()
    {
      
            if (flipDirection == -1)
            {

                feetPos = feetPosDown;
                flipDirection = 1;
                gm.flipped = false;
                spriteRenderer.flipY = false;
        
        }
            else
            {

                feetPos = feetPosUp;
                flipDirection = -1;
                gm.flipped = true;
                spriteRenderer.flipY = true;

        }

        dayNightManager.SwitchTime();
        rb.gravityScale = flipDirection;

    }

    void ClampTerminalVelocity()
    {

        if (rb.velocity.x > terminalVelocity)
        {
            rb.velocity = new Vector2(terminalVelocity, rb.velocity.y);
        }

        if (flipDirection == -1)
        {

            if (rb.velocity.y > terminalVelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, terminalVelocity);
            }

        }
        else
        {

            if (rb.velocity.y < -terminalVelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, -terminalVelocity);
            }

        }
       

        if (rb.velocity.x < -terminalVelocity)
        {
            rb.velocity = new Vector2(-terminalVelocity, rb.velocity.y);
        }

    }

    bool IsGrounded()
    {

        bool isGrounded = Physics2D.OverlapCircle(feetPos.position, 0.1f, platformLayerMask);
        return isGrounded;

    }
}
