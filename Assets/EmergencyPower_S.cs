using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmergencyPower_S : MonoBehaviour
{

    [SerializeField] private float EventAngle = 45;
    [SerializeField] private float SpawnAngle = 0;
    private GameObject rotator;
    
    // Start is called before the first frame update
    void Start()
    {
        rotator = GameObject.Find("rotator");
        GetComponentInChildren(typeof(GameObject)).transform.Rotate(0,SpawnAngle,0);
    }

    private void OnTransformChildrenChanged()
    {
        if(rotator.gameObject.transform.up.y == EventAngle)
        {
            rotator.gameObject.BroadcastMessage("AllFiredUp", SendMessageOptions.RequireReceiver);
        }
    }

}
