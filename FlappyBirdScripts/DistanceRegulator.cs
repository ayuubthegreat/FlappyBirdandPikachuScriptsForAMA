using System.IO.Pipes;
using UnityEngine;

public class DistanceRegulator : MonoBehaviour
{
    public int randomOffset;
    public int randomValue;
    public pipe[] pipes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AssignTransforms();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AssignTransforms()
    {
        randomOffset = Random.Range(2, 8);
        randomValue = Random.Range(0, 2);
        if (randomValue > 1) {
            randomOffset = -randomOffset;
        }
        transform.position += new Vector3(0, randomOffset);
        pipes = GetComponentsInChildren<pipe>();
    }
}  
