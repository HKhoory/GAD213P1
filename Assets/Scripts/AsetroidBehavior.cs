using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsetroidBehavior : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float randomSpeed;
    [SerializeField] private float speed1;
    [SerializeField] private float speed2;

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(speed1, speed2);
    }

    // Update is called once per frame
    void Update()
    {
        _rb2D.velocity = new Vector2(randomSpeed * -1, 0);

        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
