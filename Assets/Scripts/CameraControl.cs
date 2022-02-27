using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTarget;

    public Vector3 offset;

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
        Vector3 targetPosition = new Vector3(playerTarget.position.x, 0f, playerTarget.position.z);
        Vector3 offsetPosition = targetPosition + offset;
        transform.position = offsetPosition;
    }
}
