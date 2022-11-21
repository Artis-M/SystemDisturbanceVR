using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EmergencyPower_S : MonoBehaviour
{

    public List<Light> lights;
    private static List<Light> _lights;
    
    [SerializeField] private float EventAngle = 45;
    [SerializeField] private float SpawnAngle = 0;
    public GameObject light;
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;
    public GameObject switch5;
    public GameObject switch6;
    public GameObject switch7;
    public List<LineRenderer> lines;


    private void Awake()
    {
        _lights = lights;
        light.SetActive(false);
        //Debug.Log("light "+light.name + light.activeSelf);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void ToggleLights(bool onOff)
    {
        float intensity = 0;
        if (onOff)
        {
            intensity = 1;
        }
        else
        {
            intensity = 0.05f;
        }

        foreach (Light light in _lights)
        {
            light.intensity = intensity;
        }
    }

    void Update()
    {
        var color = Color.yellow;
        var cond1 = switch1.transform.position.y > 1f;
        var cond2 = switch2.transform.position.y < 1f;
        var cond3 = switch3.transform.position.y > 1f;
        var cond4 = switch4.transform.position.y > 1f;
        var cond5 = switch5.transform.position.y > 1f;
        var cond6 = switch6.transform.position.y < 1f;
        var cond7 = switch7.transform.position.y > 1f;
        if (cond1 && cond2 && cond3 && cond4 && cond5 && cond6 && cond7)
        {
            //Debug.Log(switch5.transform.position.y);
            light.SetActive(true);
            GameManager.PowerOn = true;
            lines[16].startColor = color;
            lines[16].endColor = color;
        }
        else
        {
            light.SetActive(false);
            lines[16].startColor = Color.white;
            lines[16].endColor = Color.white;
        }
        if (cond1)
        {
            lines[0].startColor = color;
            lines[0].endColor = color;
            lines[7].startColor = Color.white;
            lines[7].endColor = Color.white;
            if (cond2)
            {
                lines[2].startColor = Color.white;
                lines[2].endColor = Color.white;
            }
            if (cond3)
            {
                lines[12].startColor = color;
                lines[12].endColor = color;
                lines[7].startColor = Color.white;
                lines[7].endColor = Color.white;

                if (cond5 && cond4)
                {
                    lines[14].startColor = color;
                    lines[14].endColor = color;
                }
            }
        }
        else
        {
            lines[7].startColor = color;
            lines[7].endColor = color;
            lines[0].startColor = Color.white;
            lines[0].endColor = Color.white;
        }
        if (cond2)
        {
            lines[1].startColor = Color.white;
            lines[1].endColor = Color.white;
            lines[8].startColor = Color.white;
            lines[8].endColor = Color.white;
        }
        else
        {
            lines[1].startColor = color;
            lines[1].endColor = color;
            lines[8].startColor = color;
            lines[8].endColor = color;
        }
        if (cond2 || !cond3)
        {
            lines[11].startColor = color;
            lines[11].endColor = color;
        }
        if (cond3)
        {
            lines[2].startColor = color;
            lines[2].endColor = color;
            lines[9].startColor = Color.white;
            lines[9].endColor = Color.white;
        }
        else
        {
            lines[9].startColor = color;
            lines[9].endColor = color;
            lines[2].startColor = Color.white;
            lines[2].endColor = Color.white;
        }
        if (cond4)
        {
            lines[3].startColor = color;
            lines[3].endColor = color;
            if (cond5)
            {
                lines[13].startColor = color;
                lines[13].endColor = color;
            }
            else
            {
                lines[13].startColor = Color.white;
                lines[13].endColor = Color.white;
            }
        }
        else
        {
            lines[3].startColor = Color.white;
            lines[3].endColor = Color.white;
        }
        if (cond5)
        {
            lines[4].startColor = color;
            lines[4].endColor = color;
        }
        else
        {
            lines[4].startColor = Color.white;
            lines[4].endColor = Color.white; 
        }
        if (cond6)
        {
            lines[5].startColor = Color.white;
            lines[5].endColor = Color.white;
            lines[10].startColor = color;
            lines[10].endColor = color;
        }
        else
        {
            lines[5].startColor = color;
            lines[5].endColor = color;
            lines[10].startColor = Color.white;
            lines[10].endColor = Color.white;
        }
        if (cond7)
        {
            lines[6].startColor = color;
            lines[6].endColor = color;
            if (cond6)
            {
                lines[15].startColor = color;
                lines[15].endColor = color;
            }
            else
            {
                lines[15].startColor = Color.white;
                lines[15].endColor = Color.white;
            }
        }
        else
        {
            lines[6].startColor = Color.white;
            lines[6].endColor = Color.white;
        }
    }
}
