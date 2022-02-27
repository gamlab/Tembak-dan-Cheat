using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 100;

    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        healthSlider.value = hp;
        if (hp <= 0)
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
