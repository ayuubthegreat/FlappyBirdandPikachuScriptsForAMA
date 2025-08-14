using UnityEngine;
using System.Collections;


public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D b2d;
    public float speed = 10f;
    public float jumpForce = 100f;
    public float jumpduration = 1; // Duration of the jump in seconds
    public bool isMovable = true;
    public float xInput;
    public float yInput;
    public Vector2 knockbackForce;
    public bool canBeKnocked;
    public bool isknocked;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        b2d = GetComponent<BoxCollider2D>();

        // Set gravity scale to 1 for normal gravity
    }

    // Update is called once per frame
    void Update()
    {
        yInput = rb.linearVelocity.y;
        if (isMovable)
        {
            rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y); 
        }

        if (Input.GetKeyDown(KeyCode.Space) && isMovable)
        {
            StopAllCoroutines();
            StartCoroutine(JumpVariables());
            JumpRotation();
            gameManager.instance.audioSource.PlayOneShot(gameManager.instance.jumpSound);
            rb.linearVelocity = new Vector3(speed, 0); // Reset X velocity to speed
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        JumpRotation();
        if (!gameManager.instance.gameOver)
        {
            b2d.enabled = true;
        }
        else
        {
            b2d.enabled = false;
            
        


        }


    }
    private IEnumerator JumpVariables()
    {
        isMovable = false;
        yield return new WaitForSeconds(jumpduration);
        isMovable = true;
    }
    private void JumpRotation()
    {
        if (yInput > -1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 60), 0.05f);
        }
        else if (yInput < 1)
        {
            if (isknocked)
            {
                gameManager.instance.audioSource.PlayOneShot(gameManager.instance.fallingSound);
                isknocked = false; 
            }
            
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), 0.05f);
        }
    }
    public void KnockBack()
    {

        rb.linearVelocity = Vector2.zero;
        
        if (isknocked)
        {
            return;
        }
        StartCoroutine(canbeKnocked());
        gameManager.instance.audioSource.PlayOneShot(gameManager.instance.hitSound);
        rb.AddForce(knockbackForce, ForceMode2D.Impulse);
        
    }

    public IEnumerator canbeKnocked()
    {
        canBeKnocked = false;
        isknocked = true;
        yield return new WaitForSeconds(1);
        isknocked = false;
        canBeKnocked = true;
        

    }
}
