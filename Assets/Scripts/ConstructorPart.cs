using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConstructorPart : MonoBehaviour
{
    public GameObject MissingPart;
    private MeshRenderer _mesh;
    public UnityEvent WhenFound;

    private int _deltaScale = 5;
    private float _deltaZRotate = 0.053f;
    private float deltaXScale;

    // Start is called before the first frame update
    void Start()
    {
        _mesh = gameObject.GetComponent<MeshRenderer>();
        _mesh.enabled = false;
        CapsuleCollider thisCollider = gameObject.AddComponent<CapsuleCollider>();
        thisCollider.isTrigger = true;

        deltaXScale = Math.Abs(gameObject.transform.localScale.x * _deltaScale / 100);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == MissingPart)
        {
            if (CheckFit(gameObject, other.gameObject))
            {
                Destroy(MissingPart);
                _mesh.enabled = true;
                WhenFound.Invoke();    
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CheckFit(GameObject thisPart, GameObject missingPart)
    {
        var thisTransform = thisPart.transform;
        var missTransform = missingPart.transform;
        
        float thisXScale = thisTransform.localScale.x;
        float missXScale = missTransform.localScale.x;

        float thisZRot = thisTransform.rotation.z;
        float missZRot = missTransform.rotation.z;

        bool scaleFit = missXScale > thisXScale - deltaXScale && missXScale < thisXScale + deltaXScale;
        bool rotatFit = thisZRot > missZRot - _deltaZRotate && thisZRot < missZRot + _deltaZRotate;

        Debug.Log(thisZRot + " vs " + missZRot);
        return (rotatFit && scaleFit);
    }
}
