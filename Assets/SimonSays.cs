using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour {

    [SerializeField] GameObject[] Buttons;
    [SerializeField] GameObject[] LightArray;
    [SerializeField] GameObject[] RowLights;
    [SerializeField] int[] clickOrder;
    int level = 0;
    int buttonsClicked = 0;
    int colorOrderRunCount = 0;
    bool passed = false;
    bool won = false;
    [SerializeField] Material red;
    [SerializeField] Material green;
    [SerializeField] Material invis;
    [SerializeField] Material white;
    public float waitspeed;

    private void OnEnable() {
        level = 0;
        buttonsClicked = 0;
        colorOrderRunCount = -1;
        won = false;
        for(int i = 0; i < clickOrder.Length; i++) {
            clickOrder[i] = (Random.Range(0, 8)); 
        }
        for(int i = 0; i < RowLights.Length; i++) {
            RowLights[i].GetComponent<MeshRenderer>().material = white;
        }
        level = 1;
        StartCoroutine(ColourOrder());
    }

    public void ButtonClickOrder(int button) {
        buttonsClicked++;
        if (button == clickOrder[buttonsClicked - 1]) {
            passed = true;
        }
        else {
            won = false;
            passed = false;
            StartCoroutine(ColourBlink(red));
        }
        if (buttonsClicked == level && passed == true && buttonsClicked != 5) {
            level++;
            passed = false;
            StartCoroutine(ColourOrder());
        }
        if (buttonsClicked == level && passed == true && buttonsClicked == 5) {
            won = true;
            StartCoroutine(ColourBlink(green));

        }
    }

    IEnumerator ColourBlink(Material colourToBlink) {
        DisableInteractableButtons();
        for (int j = 0; j < 3; j++) {
            //blink with colour
            for (int i = 0; i < Buttons.Length; i++) {
                Buttons[i].GetComponent<MeshRenderer>().material = colourToBlink;
            }
            for (int i = 5; i < RowLights.Length; i++) {
                RowLights[i].GetComponent<MeshRenderer>().material = colourToBlink;
            }
            yield return new WaitForSeconds(.5f);
            //back to base
            for (int i = 0; i < Buttons.Length; i++) {
                Buttons[i].GetComponent<MeshRenderer>().material = white;
            }
            for (int i = 5; i < RowLights.Length; i++) {
                RowLights[i].GetComponent<MeshRenderer>().material = white;
            }
            yield return new WaitForSeconds(.5f);

        }
        if (won == true) {
            BroadcastMessage("SimonSaysCorrect");
        }
        EnableInteractableButtons();
        OnEnable();
    }
    
    IEnumerator ColourOrder() {
        buttonsClicked = 0;
        colorOrderRunCount++;
        DisableInteractableButtons();
        for (int i = 0; i <= colorOrderRunCount; i++) {
            if (level >= colorOrderRunCount) {
                LightArray[clickOrder[i]].GetComponent<MeshRenderer>().material = invis;
                yield return new WaitForSeconds(waitspeed);
                LightArray[clickOrder[i]].GetComponent<MeshRenderer>().material = green;
                yield return new WaitForSeconds(waitspeed);
                LightArray[clickOrder[i]].GetComponent<MeshRenderer>().material = invis;
                RowLights[i].GetComponent<MeshRenderer>().material = green;
            }
        }
        EnableInteractableButtons();
    }

    void DisableInteractableButtons() {
        for (int i = 0; i < Buttons.Length; i++) {
            Buttons[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    void EnableInteractableButtons() {
        for (int i = 0; i < Buttons.Length; i++) {
            Buttons[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

}
