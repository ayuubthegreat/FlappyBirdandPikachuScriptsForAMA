using UnityEngine;


public class pipe : MonoBehaviour
{
    public BoxCollider2D b2d;
    public bool isTopPipe;
    public bool isBottomPipe;
    public float randomOffset;
    public float randomValue;
    public float startRandomOffset;
    [Tooltip("Will be excluded from range")]
    public float endRandomOffset;
    public Vector3 originalposition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalposition = transform.position;
        AssignTransforms();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<player>())
        {
            gameManager.instance.player.KnockBack();
            gameManager.instance.player.isMovable = false;
            gameManager.instance.gameOver = true;


        }
    }
    public void AssignTransforms()
    {
        randomOffset = Random.Range(3f, 4.5f);
        if (isBottomPipe)
        {
            randomOffset = -randomOffset;
        }
        transform.position = originalposition + new Vector3(0, randomOffset);
    }
    
}
