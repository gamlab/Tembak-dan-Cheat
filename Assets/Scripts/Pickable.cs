using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    public GameObject itemFeedback;

    public AnimationClip animFeedback;

    public int scoreGet;

    public bool negativPick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (negativPick)
            {
                collision.GetComponent<PlayerControll>().ChangeScore(-scoreGet);
            }
            else
            {
                collision.GetComponent<PlayerControll>().ChangeScore(scoreGet);
            }

            GameObject itemFeedbackPrefab = Instantiate(itemFeedback, transform.position, Quaternion.identity);
            Destroy(itemFeedbackPrefab, animFeedback.length);
            Destroy(gameObject);
        }
    }
}
