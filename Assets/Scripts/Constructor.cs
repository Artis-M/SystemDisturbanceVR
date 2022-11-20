using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor : MonoBehaviour
{
    public List<ConstructorPart> MissingParts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PartFound(ConstructorPart part)
    {
        if (MissingParts.Contains(part))
        {
            MissingParts.Remove(part);
            if (MissingParts.Count == 0)
            {
                Debug.Log("HOORAY");
                GameManager.FinishGame();
            }
        }
    }
}
