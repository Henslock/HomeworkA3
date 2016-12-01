using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    /*
    Excel Level Assignment - Player control script that includes basic movement and jumping. Also manages checkpoints, death, and spawning.

    Josh Bellyk - 100526009
    Owen Meier  - 100538643    
    */
    [System.Serializable]
    public class PlayerMovement
    {
        public float runSpeed = 4.0f;
        public float inAirControlAcceleration = 1.0f;

        [System.NonSerialized]
        public Vector3 direction = Vector3.zero;

        [System.NonSerialized]
        public Vector3 velocity;

    }

    [System.Serializable]
    public class PlayerJumping
    {
        public bool enabled = true;
        public float height = 6.5f;

        [System.NonSerialized]
        public bool jumping = false;

        [System.NonSerialized]
        public bool grounded = true;
    }

    public Transform SpawnPos;

    private CapsuleCollider body;
    private Rigidbody rb;

    public PlayerMovement movement;
    public PlayerJumping jump;

    public Vector3 CheckpointCoords;

    public bool playerControl = true;
    public bool isDead = false;
    private float t = 0.0f;
    private float respawnTimer = 2.0f;
    public bool activeCheckpoint = false;

    void Start()
    {
        transform.position = SpawnPos.transform.position;

        rb = GetComponent<Rigidbody>();
        body = GetComponent<CapsuleCollider>();

        movement = new PlayerMovement();
        jump = new PlayerJumping();
        movement.direction = transform.TransformDirection(Vector3.forward);
        Spawn();
	}

    void FixedUpdate()
    {
        if(playerControl)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, (body.height / 2.0f) + 0.15f))
            {
                jump.grounded = true;
            }
            else
            {
                jump.grounded = false;
            }

        }

        float h = Input.GetAxisRaw("Horizontal");

        if (!playerControl)
        {
            h = 0.0f;
        }

        if (jump.jumping)
        {
            jump.jumping = false;
            Jump();
        }

        rb.velocity = new Vector3(h * movement.runSpeed, rb.velocity.y, 0);

        //Keep the player at z = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);

        if(Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(0, 275, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
    }

    public void Jump()
    {
        movement.velocity = rb.velocity;
        movement.velocity.y = 0.0f;
        rb.AddForce(Vector3.up * jump.height, ForceMode.VelocityChange);
    }

    void Update()
    {
        if (playerControl)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jump.grounded)
            {
                jump.jumping = true;
            }
        }
        //Death wait
        if(isDead)
        {
            t += Time.deltaTime;
            if(t >= respawnTimer)
            {
                t = 0.0f;
                isDead = false;
                Spawn();
            }
        }
    }

    public void Death()
    {
        playerControl = false;
        print("You have died!");
        isDead = true;
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, 0);
    }

    void Spawn()
    {
        transform.localScale = new Vector3(1, 1, 1);
        rb.useGravity = true;
        playerControl = true;
        if(activeCheckpoint)
        {
            transform.position = CheckpointCoords;
        }
        else
        {
           transform.position = SpawnPos.transform.position;
        }
    }

}
