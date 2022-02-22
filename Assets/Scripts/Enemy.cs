using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        // Spawn death animation atau ngelakuin apapun
        Destroy(gameObject);
    }
}
