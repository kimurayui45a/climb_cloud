using UnityEngine;

public class CoinMover : MonoBehaviour
{
    float startY;
    public float moveRange = 0.7f;
    public float speed = 2f;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * speed) * moveRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
