using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float speed;
    [SerializeField] private GameObject placeholder;
    [SerializeField] private GameObject bullet;
    [SerializeField] private bool isMoving;
    [SerializeField] private float bulletTimer;
    private float timerHolder;

    [SerializeField] private static float direction;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timerHolder = bulletTimer;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (xAxis != 0 || yAxis != 0)
        {
            isMoving = true;
            direction = Mathf.Sqrt(xAxis * xAxis + yAxis * yAxis);
        }
        else
        {
            isMoving = false;
        }

        _rb2D.velocity = new Vector2(xAxis * speed, yAxis * speed);

        if (Input.GetKeyDown(KeyCode.Space) && bulletTimer <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            bulletTimer = timerHolder;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player has collided with something
        //die
        if (!(collision.CompareTag("Bullet")))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + direction, transform.position.y + direction));
    }

}
