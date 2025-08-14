using Unity.Mathematics;
using UnityEngine;

public class pipesGenerator : MonoBehaviour
{
    public BoxCollider2D b2d;

    void Start()
    {
        b2d = GetComponent<BoxCollider2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<player>() != null)
        {
            Debug.Log("More pipes were generated.");
            Instantiate(gameManager.instance.pipePrefab, new Vector3(transform.position.x + 73, 16, 0), Quaternion.identity);
            b2d.enabled = false;

        }
    }
}
