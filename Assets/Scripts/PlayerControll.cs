using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    bool lookRight = true;

    private Rigidbody2D myBody;

    public float velocity, maxVelocity;

    public Animator myAnim;

    public float jumpForce;

    public BoxCollider2D myBoxCollider;

    public float distance;
    public LayerMask groundLayer;

    bool isGrounded = true;

    public GameObject peluru;
    public Transform firingPoint;

    public float deltaTime;
    bool canShoot = true;

    public int scorePlayer = 0;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myBody.AddForce(new Vector2(0f, jumpForce));
        }
        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
        //y frame sebelumnya
    }

    private void LateUpdate()
    {
        //y frame saat ini apakah lebih rendah dari y frame sebelumnya
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Instantiate(peluru, firingPoint.position, firingPoint.rotation);
        yield return new WaitForSeconds(deltaTime);
        canShoot = true;
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

    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(myBoxCollider.bounds.center, myBoxCollider.bounds.size, 0f, Vector2.down, distance , groundLayer);
        Color rayColor;
        if(hit.collider != null)
        {
            isGrounded = true;
            rayColor = Color.green;
        }
        else
        {
            isGrounded = false;
            rayColor = Color.red;
        }
        myAnim.SetBool("isGrounded", isGrounded);
        Debug.DrawRay(myBoxCollider.bounds.center + new Vector3(myBoxCollider.bounds.extents.x, 0), Vector2.down * (myBoxCollider.bounds.extents.y + distance), Color.blue);
        Debug.DrawRay(myBoxCollider.bounds.center - new Vector3(myBoxCollider.bounds.extents.x, 0), Vector2.down * (myBoxCollider.bounds.extents.y + distance), Color.yellow);
        Debug.DrawRay(myBoxCollider.bounds.center - new Vector3(myBoxCollider.bounds.extents.x, myBoxCollider.bounds.extents.y + distance), Vector2.right * (distance * 2), rayColor);
    }

    public void ChangeScore(int score)
    {
        scorePlayer += score;

        scorePlayer = Mathf.Clamp(scorePlayer, 0, 100);

        //if(scorePlayer < 0)
        //{
        //    scorePlayer = 0;
        //}
        //else if(scorePlayer > 100)
        //{
        //    scorePlayer = 100;
        //}
    }
}
