using UnityEngine;

public class CloudMover : MonoBehaviour
{
    float startX;
    public float moveRange = 0.8f;
    public float speed = 1.5f;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float newX = startX + Mathf.Sin(Time.time * speed) * moveRange;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
