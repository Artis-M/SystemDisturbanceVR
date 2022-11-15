using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class Wire_S : MonoBehaviour
{

    private Vector3 OriginalPosition1;
    private Vector3 OriginalPosition2;

    public GameObject obj1;
    public GameObject obj2;

    public int ObjectsConnected { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition1 = obj1.transform.right;
        OriginalPosition2 = obj2.transform.right;
        ObjectsConnected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 otp = obj1.transform.position;
        Vector3 newPos = otp - OriginalPosition1;
        Vector3 newScale = new(0.1f, otp.y - OriginalPosition1.y, 0.1f);
        obj1.transform.localScale = newScale;

        Vector3 scale2 = new(0.1f, obj2.transform.position.y - OriginalPosition2.y, 0.1f);
        obj2.transform.localScale = scale2;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "WireCol")
        {
            obj1.GetComponentInParent<HandGrabInteractable>().enabled = false;
            obj1.GetComponentInParent<Grabbable>().enabled = false;
            ObjectsConnected++;
        } 
        else if (other.gameObject.name == "WireCol2")
        {
            obj2.GetComponentInParent<HandGrabInteractable>().enabled = false;
            obj2.GetComponentInParent<Grabbable>().enabled = false;
            ObjectsConnected++;
        }
    }
}
