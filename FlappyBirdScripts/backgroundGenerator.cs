using Unity.Mathematics;
using UnityEngine;

public class backgroundGenerator : MonoBehaviour
{
    public BoxCollider2D b2d;

    void Start()
    {
        b2d = GetComponent<BoxCollider2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        player player = collision.gameObject.GetComponent<player>();
        if (player != null)
        {
            Instantiate(gameManager.instance.backgroundPrefab, transform.position + new Vector3(40, transform.position.y), Quaternion.identity);
            b2d.enabled = false;
        }
    }
}
