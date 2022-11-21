using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    public GameObject model;

    private static readonly int DoorOpen = Animator.StringToHash("DoorOpen");

    // Start is called before the first frame update
    void Start()
    {
        _animator = model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        //Destroy(model); // LAME
        _animator.SetTrigger(DoorOpen);
    }
}
