using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Oculus.Interaction.PoseDetection;
using UnityEngine;
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

    public bool isValidToStart = false;
    
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
        
    }

    void StartDestructionCountdown()
    {
        //Yes
    }

    void setValidToStart(bool yesno)
    {
        isValidToStart = yesno;
    }
    public void startSequence()
    {
        if (isValidToStart)
        {
            //play sound
            return;
        }
        createOrder();
        displaySequence();
        displayRender.material = materials["questionMark"];
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
        
        displayRender.material = materials["questionMark"];
    }

    private IEnumerator displaySequence()
    {
        foreach (var gestureVar in gestureOrder)
        {
            displayRender.material = materials[gestureVar];
            yield return new WaitForSeconds(1f);
        }
        displayRender.material = materials[gestureOrder.First()];
        yield return null;
    }
    
    public void CheckGesture(String name)
    {
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
                    displayRender.material = materials["done"];
                    StartDestructionCountdown();
                }
                
            }
        }
        else
        {
            displayRender.material = materials["done"];
            StartDestructionCountdown();
        }
        
        Debug.LogError(name);
    }
}
