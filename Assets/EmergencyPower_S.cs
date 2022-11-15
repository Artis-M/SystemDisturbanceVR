using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmergencyPower_S : MonoBehaviour
{

    [SerializeField] private float EventAngle = 45;
    [SerializeField] private float SpawnAngle = 0;
    public Light light;
    public Light light2;
    private GameObject rotator;
    private Wire_S wires;
    
    // Start is called before the first frame update
    void Start()
    {
        rotator = GameObject.Find("rotatoBaser");
        GetComponentInChildren(typeof(GameObject)).transform.Rotate(0,SpawnAngle,0);
    }

    private void OnTransformChildrenChanged()
    {
        if(rotator.transform.up.y == EventAngle && wires.ObjectsConnected > 1)
        {
            light.enabled = true;

            light2.color = new Color(241, 212, 133);
        }
        else if (rotator.transform.up.y == -45 && wires.ObjectsConnected > 1)
        {
            light.enabled = false;
            light2.color = new Color(115, 115, 113);
        }
    }

}
