using System;
using UnityEngine;

public class GestureTeleportationV2 : MonoBehaviour
{
    public Transform handBase;
    RaycastHit teleportationHit;
    public float TeleportDistance = 0.5f;
    public String[] layersToTPstrings  = {"TeleportationLayer", "Default"};
    private int wallLayer;
    private int teleportableLayers;
    public GameObject body;

    
    void Start()
    {
        teleportableLayers = LayerMask.GetMask(layersToTPstrings);
        wallLayer = LayerMask.GetMask("Default");
    }
    
    private void Update()
    {
        Vector3 direction = new Vector3(handBase.forward.x, 0, handBase.forward.z).normalized;
        if (Physics.Raycast(handBase.position, direction, out teleportationHit, TeleportDistance, teleportableLayers))
        {
            
        }
    }

    public void GestureFound()
    {
        Vector3 direction = new Vector3(handBase.forward.x, 0, handBase.forward.z).normalized;
        if (Physics.Raycast(handBase.position, direction, out teleportationHit, TeleportDistance))
        {
            if (Vector3.Distance(teleportationHit.transform.position, body.transform.position * 0.5f) <
                TeleportDistance / 3)
            {
                Vector3 directionForward = new Vector3(handBase.forward.x, 0, handBase.forward.z).normalized;
                body.transform.position += directionForward * Mathf.Clamp(Vector3.Distance(teleportationHit.transform.position, handBase.transform.position * 0.5f),
                    0f,TeleportDistance / 3f);
            }
        }
        else
        {
            Vector3 directionForward = new Vector3(handBase.forward.x, 0, handBase.forward.z).normalized;
            body.transform.position += directionForward * TeleportDistance;
        }
    }
}