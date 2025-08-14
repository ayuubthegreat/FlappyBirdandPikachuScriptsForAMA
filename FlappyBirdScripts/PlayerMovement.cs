using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
[Header("REFERENCES")]
[SerializeField] private GameObject leftTrail;
[SerializeField] private GameObject rightTrail;
[SerializeField] private GameObject jumpTrail;

[Header("VALUES")]
[SerializeField] private byte speed;
[SerializeField] private float jumpForce;
[SerializeField] private bool isGrounded;

private Rigidbody2D rb;

private void Awake()
{
    rb = GetComponent<Rigidbody2D>();
}

private void Reset()
{
    speed = 3;
    jumpForce = 6.5f;
    isGrounded = true;
    leftTrail = GameObject.Find("LeftTransform");
    rightTrail = GameObject.Find("RightTransform");
    jumpTrail = GameObject.Find("JumpTransform");
}

private void Start()
{
    leftTrail.SetActive(false);
    rightTrail.SetActive(false);
}

private void Update()
{
    if(Input.GetKey(KeyCode.A))
    {
    transform.Translate(-speed*Time.deltaTime,0f,0f);
    TrailState(rightTrail,leftTrail,jumpTrail);
    }

    else if(Input.GetKey(KeyCode.D))
    {
    transform.Translate(speed*Time.deltaTime,0f,0f);
    TrailState(leftTrail,rightTrail,jumpTrail);
    }

    else if(Input.GetKeyDown(KeyCode.Space) && !isGrounded)
    {
     rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
     TrailState(jumpTrail,rightTrail,leftTrail);
    }
}

private void OnCollisionEnter2D(Collision2D col)
{
if(col.gameObject.CompareTag("Ground"))
{
isGrounded = false;
}
}

private void OnCollisionExit2D(Collision2D col)
{
if(col.gameObject.CompareTag("Ground"))
{
isGrounded = true;
}
}

private void TrailState(GameObject check,GameObject unCheck,GameObject jump)
{
check.SetActive(true);
unCheck.SetActive(false);
jump.SetActive(false);
}


}

