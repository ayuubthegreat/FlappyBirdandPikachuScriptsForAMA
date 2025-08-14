using UnityEngine;

public class Score : MonoBehaviour
{
    public BoxCollider2D b2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        b2d = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<player>())
        {
            
            gameManager.instance.audioSource.PlayOneShot(gameManager.instance.coinSound);
            gameManager.instance.score++;
            b2d.enabled = false;
        }
    }
}
