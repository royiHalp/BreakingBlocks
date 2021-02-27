using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float launchVelocityX = 2f;
    [SerializeField] private float launchVelocityY = 15f;
    [SerializeField] private AudioClip[] ballSounds;

    [SerializeField] private float randomVelocityFactor = 0.5f;
    // state
    private Vector2 paddleToBallVector;
    private bool gameStarted = false;
    
    // cached component references
    private AudioSource ballAudioSource;
    private Rigidbody2D BallRigidBody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
        BallRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LockBallToPaddle();
        LaunchOnMouseClick();
    }

    private void LockBallToPaddle()
    {
        if (!gameStarted)
        {
            Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePosition + paddleToBallVector;       
        }
    }

    void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            BallRigidBody.velocity = new Vector2(launchVelocityX, launchVelocityY);
            gameStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomVelocityFactor),
            Random.Range(0f, randomVelocityFactor));
        if (gameStarted)
        {
            if (ballSounds.Length > 0)
            {
                AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
                ballAudioSource.PlayOneShot(clip);
                BallRigidBody.velocity += velocityTweak;
            }
        }
    }
}
