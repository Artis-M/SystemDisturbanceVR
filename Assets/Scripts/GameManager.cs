using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private static bool _isPowerOn = true;
    public static bool isSelfDestruct = false;
    public static bool _ReadyForSelfDestruct = false;
    public static bool PowerOn
    {
        get { return _isPowerOn; }
        set
        {
            _isPowerOn = value;
            _ReadyForSelfDestruct = value;
            EmergencyPower_S.ToggleLights(value);
            KeyPad.PowerSupplyUpdate();
           
        }

        
    }
  
    
    public static void FinishGame()
    {
        if (PowerOn && isSelfDestruct)
        {
            SceneManager.LoadScene("EndGameCutScene");
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
