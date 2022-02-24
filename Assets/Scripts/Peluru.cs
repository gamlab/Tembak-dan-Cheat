using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peluru : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myBody;

    public int damagePeluru;

    // Start is called before the first frame update
    void Start()
    {
        myBody.velocity = transform.right * new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damagePeluru);
        }

        Destroy(gameObject);
    }
}
