using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmergencyPower_S : MonoBehaviour
{

    [SerializeField] private float EventAngle = 45;
    [SerializeField] private float SpawnAngle = 0;
    public GameObject light;
    public GameObject light2;
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;
    public GameObject switch5;
    public GameObject switch6;
    public GameObject switch7;


    private void Awake()
    {
        light.SetActive(false);
        light2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
        var cond1 = switch1.transform.position.y > 1f;
        var cond2 = switch2.transform.position.y < 1f;
        var cond3 = switch3.transform.position.y > 1f;
        var cond4 = switch4.transform.position.y > 1f;
        var cond5 = switch5.transform.position.y > 1f;
        var cond6 = switch6.transform.position.y < 1f;
        var cond7 = switch7.transform.position.y > 1f;
  
        if (cond1 && cond2 && cond3 && cond4 && cond5 && cond6 && cond7)
        {
            Debug.Log(switch5.transform.position.y);
            light.SetActive(true);
            light2.SetActive(true);
        }
        else
        {
            light.SetActive(false);
            light2.SetActive(false); 
        }
    }

    /*private void OnTransformChildrenChanged()
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
    }*/

}
