using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTarget;

    public Vector3 offset;

    //private void Awake()
    //{
    //    Debug.Log("Awake");
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    Debug.Log("Start");
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Debug.Log("Update");
        
    //}

    //private void LateUpdate()
    //{
    //    Debug.Log("LateUpdate");
        
    //}

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
        Vector3 targetPosition = new Vector3(playerTarget.position.x, 0f, playerTarget.position.z);
        Vector3 offsetPosition = targetPosition + offset;
        transform.position = offsetPosition;
    }

    //private void OnEnable()
    //{
    //    Debug.Log("OnEnable");
    //}

    //private void OnDisable()
    //{
    //    Debug.Log("OnDisable");
    //}

    //private void OnDestroy()
    //{

    //    Debug.Log("OnDestroy");
    //}
}
