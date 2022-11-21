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
    public static bool PowerOn
    {
        get { return _isPowerOn; }
        set
        {
            _isPowerOn = value;
            EmergencyPower_S.ToggleLights(value);
        }

        
    }
    public static bool isSelfDestruct;
    
    public static void FinishGame()
    {
        if (PowerOn)
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
