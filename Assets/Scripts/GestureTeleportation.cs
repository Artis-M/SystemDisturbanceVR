using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GestureTeleportation : MonoBehaviour
{
    public Transform handBase;
    public LineRenderer lineRender;
    public String[] layersToTPstrings  = {"TeleportationLayer", "Default"};
    private int teleportableLayers;
    private int wallLayer;
    public bool isDrawingLine = true;
    RaycastHit teleportationHit;
    public GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        teleportableLayers = LayerMask.GetMask(layersToTPstrings);
        wallLayer = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update()
    {
        if(isDrawingLine)
        {


            if (Physics.Raycast(handBase.position, handBase.right, out teleportationHit, 10, teleportableLayers))
            {
                if (wallLayer ==  teleportationHit.collider.gameObject.layer)
                {
                    return;
                }
                lineRender.SetPosition(0, handBase.position);
                lineRender.SetPosition(1, teleportationHit.point);
            }
            else
            {
                lineRender.SetPosition(0, Vector3.zero);
                lineRender.SetPosition(1, Vector3.zero);
            }
        }
    }


    public void GestureFound()
    {
        if (isDrawingLine)
        {
            body.transform.position = teleportationHit.point;
            StopDrawingTeleportationLine();
        }
        else
        {
            DrawTeleportationLine();
        }
    }
    
    void DrawTeleportationLine()
    {
        isDrawingLine = true;
        lineRender.enabled = true;
    }

    void StopDrawingTeleportationLine()
    {
        isDrawingLine = false;
        lineRender.enabled = false;
    }
    void OnTeleportGesture(){
        
    }
}