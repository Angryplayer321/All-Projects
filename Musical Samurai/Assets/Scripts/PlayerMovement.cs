using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 15;

    [SerializeField] private float jumpForce = 5;

    [SerializeField] Rigidbody2D playersRigidBody;

    private Animator playerAnimator;

    private SpriteRenderer playerSprite;

    private float horizontalInput;

    private float verticalInput;

    private bool rightDirection=true;

    //Is player on level scene or not?

    public static bool isPlaying = false;

    // Has player started the level or not?

    public static bool hasStarted = false;

    private  Vector3 movementDistance;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (isPlaying == true)
        {
            Debug.Log("Player is playing");
            if (Input.anyKey) hasStarted = true;
            if (hasStarted == true)
            {
                Debug.Log("Player has started.");
                horizontalInput = 1f;
            }
            else horizontalInput = 0;
        }
        // Controllong the dircetion of Character

        if (horizontalInput < 0)

            rightDirection = false;

        else if (horizontalInput > 0)

            rightDirection = true;

        if (rightDirection)

            transform.rotation = Quaternion.Euler(0, 0, 0);

        else
            transform.rotation = Quaternion.Euler(0, 180, 0);

        // Updating animator variable value

        playerAnimator.SetFloat("Horizontal", Mathf.Abs(horizontalInput));

        // Movement

        movementDistance = new Vector3(horizontalInput, 0, 0) * Time.deltaTime * playerSpeed;

        transform.position += movementDistance;

        // Jumping mechanics and animation

        if (Input.GetButtonDown("Jump") && Mathf.Abs(playersRigidBody.velocity.y) < 0.001 )
        {
            playersRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (playersRigidBody.velocity.y > 0.01)

            playerAnimator.SetBool("isJump", true);

        else

            playerAnimator.SetBool("isJump", false);

        if (playersRigidBody.velocity.y < -0.01)

            playerAnimator.SetBool("isFalling", true);

        else

            playerAnimator.SetBool("isFalling", false);
        
    }
    //Getter of displacement for notes
    public Vector3 GetMovementDistant()
    {
        return movementDistance;
    }
}
