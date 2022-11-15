using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SmartLock : MonoBehaviour
{
    public Trigerable trigerable;
    public GameObject lockKey;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == lockKey)
        {
            Debug.Log("Triggered!");
            trigerable.onTrigger.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
