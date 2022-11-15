using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class DrawerContent : MonoBehaviour
{
    public void OnTriggerExit(Collider other)
    {
        GameObject theOther = other.gameObject;
        
        if (theOther.GetComponent<Grabbable>() != null)
        {
            Rigidbody rb = theOther.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }

            Destroy(theOther.GetComponent<ParentConstraint>());
        }
    }
}

