using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderLaserScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            playerMovement.losePanel.SetActive(true);
            Cursor.visible = true;
        }
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        }
  
}
