using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class Wire_S : MonoBehaviour
{

    private Vector3 OriginalPosition;

    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Wire").transform.right = OriginalPosition;
        obj = GameObject.Find("Wire");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 otp = obj.transform.position;
        Vector3 newPos = otp - OriginalPosition;
        Vector3 newScale = new Vector3(0.1f, otp.y - OriginalPosition.y, 0.1f);
        obj.transform.localScale = newScale;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "WireCol")
        {
            obj.GetComponentInParent<HandGrabInteractable>().enabled = false;
            obj.GetComponentInParent<Grabbable>().enabled = false;
            obj.gameObject.BroadcastMessage("FlipTheSwitch");
        }
    }
}
