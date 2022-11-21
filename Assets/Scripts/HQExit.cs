using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQExit : MonoBehaviour
{
    private bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            StartCoroutine(TurnPowerOff());
            triggered = true;
        }
    }

    IEnumerator TurnPowerOff()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.PowerOn = false;
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
