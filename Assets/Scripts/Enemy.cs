using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 100;

    public Slider healthSlider;



    [SerializeField]
    private float lerpDuration;
    Vector2 startValue;
    
    [SerializeField]
    private Vector2 endValue;
    Vector2 valueToLerp;

    // Start is called before the first frame update
    void Start()
    {
        startValue = transform.position;
        healthSlider.maxValue = hp;
        StartCoroutine(LerpFunction());

        Debug.Log(Random.Range(1, 5));
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

    IEnumerator LerpFunction()
    {
        Debug.Log("Start");
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            //Debug.Log("While");
            valueToLerp = Vector2.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            transform.position = valueToLerp;
            yield return new WaitForEndOfFrame();
        }
        valueToLerp = endValue;
        transform.position = valueToLerp;

        transform.Rotate(0f, 180f, 0f);
        endValue = startValue;
        startValue = transform.position;
        StartCoroutine(LerpFunction());
    }
}
