using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    bool lookRight = true;

    public Rigidbody2D myBody;

    public float velocity, maxVelocity;

    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float forceX = 0f;
        float currentVel = Mathf.Abs(myBody.velocity.x);
        myAnim.SetFloat("velocityX", currentVel);
        if (Input.GetKey(KeyCode.A))
        {
            if (currentVel < maxVelocity)
            {
                forceX = -velocity;
            }
            if (lookRight)
            {
                Flip();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (currentVel < maxVelocity)
            {
                forceX = velocity;
            }
            if (!lookRight)
            {
                Flip();
            }
        }

        Vector2 force = new Vector2(forceX, 0);
        myBody.AddForce(force);
    }

    void Flip()
    {
        lookRight = !lookRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
