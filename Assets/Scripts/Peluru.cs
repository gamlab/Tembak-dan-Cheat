using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peluru : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myBody;

    public float peluruLivetime;

    // Start is called before the first frame update
    void Start()
    {
        myBody.velocity = transform.right * new Vector2(speed, 0f);
        Destroy(gameObject, peluruLivetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
