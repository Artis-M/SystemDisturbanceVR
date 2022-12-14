using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public GameObject display;
    public Trigerable Trigerable;
    public string code;
    
    private TextMeshPro displayText;
    private static bool PowerStatusUpd = false;
    private static bool PowerOn = GameManager.PowerOn;

    public static void PowerSupplyUpdate()
    {
        if (GameManager.PowerOn != PowerOn)
        {
            PowerStatusUpd = true;
            PowerOn = GameManager.PowerOn;
        }
    }

    private void Update()
    {
        if (PowerStatusUpd)
        {
            if (GameManager.PowerOn)
            {
                SetText("00000");
            }
            else
            {
                SetText("POWER");
            }
            PowerStatusUpd = false;
        }
        
        
    }

    private void SetText(string text)
    {
        displayText.text = text;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        displayText = display.GetComponent<TextMeshPro>();
    }
    
    private void AppendNr(int nr)
    {
        Debug.Log("append"+nr);
        if (GameManager.PowerOn)
        {
            Debug.Log("WORKS");
            string text = displayText.text;
            string newText = text.Substring(1) +""+nr;
            SetText(newText);
            if (newText == code)
            {
                Trigerable.onTrigger.Invoke();
            }    
        }
    }

    public void OnPress1()
    {
        AppendNr(1);
    }
    
    public void OnPress2()
    {
        AppendNr(2);
    }
    
    public void OnPress3()
    {
        AppendNr(3);
    }
    
    public void OnPress4()
    {
        AppendNr(4);
    }
    
    public void OnPress5()
    {
        AppendNr(5);
    }
    
    public void OnPress6()
    {
        AppendNr(6);
    }
    
    public void OnPress7()
    {
        AppendNr(7);
    }
    
    public void OnPress8()
    {
        AppendNr(8);
    }
    
    public void OnPress9()
    {
        AppendNr(9);
    }
    
    public void OnPress0()
    {
        AppendNr(0);
    }
}
