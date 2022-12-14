using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Oculus.Interaction.PoseDetection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SelfDestructionPuzzleScript : MonoBehaviour
{
    
    [Serializable]
    public struct MaterialNamed
    {
        public Material Material;
        public String Name;
    }
    
    public List<String> gestureNames = new List<string>();

    public List<String> gestureOrder = new List<string>();

    public List<Light> warningLights = new List<Light>();

    public int lenght = 5;
    
    public List<MaterialNamed> MaterialNameds;
    
    private Dictionary<String, Material> materials = new Dictionary<string, Material>();

    public GameObject display;

    private Renderer displayRender;

    private bool isPlaying = false;

    private float seconds;

    private float minutes;

    public float timeRemaining = 6000;

    public TextMeshPro timerText;

    public GameObject warningText;

    public AudioSource alarmSound;

    // Start is called before the first frame update
    void Start()
    {
        displayRender = display.GetComponent<Renderer>();
        foreach (var mat in MaterialNameds)
        {
            materials.Add(mat.Name, mat.Material);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            startSequence();
        }

        if (GameManager.isSelfDestruct)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = $"{Mathf.FloorToInt(timeRemaining / 60)}:{Mathf.FloorToInt(timeRemaining % 60)}";

            if (timeRemaining < 0)
            {
                Application.Quit();
            }
        }
    }

    void StartDestructionCountdown()
    {
        displayRender.gameObject.SetActive(false);
        warningText.gameObject.SetActive(true);
        GameManager.isSelfDestruct = true;
        alarmSound.Play();
    }
    
    public void startSequence()
    {
        if (!GameManager._ReadyForSelfDestruct)
        {
            //reset the game

            SceneManager.LoadScene("FULL2");
        }
        createOrder();
        StartCoroutine(displaySequence());
    }

    void createOrder()
    {
        for (int i = 0; i < lenght; i++)
        {
  
            String newName = gestureNames[Random.Range(0, gestureNames.Count)];
            if (gestureOrder.Count > 0)
            {
                if (!newName.Equals(gestureOrder.Last()))
                {
                    gestureOrder.Add(newName);
                }
                else
                {
                    i--;
                }   
            }
            else
            {
                gestureOrder.Add(newName);
            }

        }
    }

    private IEnumerator displaySequence()
    {
        foreach (var light in warningLights)
        {
            light.range = 0.1f;
        }
        
        foreach (var gestureVar in gestureOrder)
        {
            displayRender.material = materials[gestureVar];
            yield return new WaitForSeconds(3f);
        }
        displayRender.material = materials["questionMark"];
        isPlaying = true;
        yield return null;
    }
    
    public void CheckGesture(String name)
    {
        if (!isPlaying) return;
        if (gestureOrder.Count > 0)
        {
            if (name.Equals(gestureOrder.First()))
            {
                gestureOrder.RemoveAt(0);
                if (gestureOrder.Count > 0)
                {
                    warningLights.First().color = Color.green;
                    warningLights.RemoveAt(0);
                }
                else
                {
                    warningLights.First().color = Color.green;
                    warningLights.RemoveAt(0);
                    StartDestructionCountdown();
                }
                
            }
        }
        else
        {
            warningLights.First().color = Color.green;
            warningLights.RemoveAt(0);
            StartDestructionCountdown();
        }
        
        Debug.LogError(name);
    }
}
