using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour {

    int WaterLevel = 0;
    [SerializeField] GameObject Rotator;
    [SerializeField] float waitspeed;
    [SerializeField] Material water0;
    [SerializeField] Material water25;
    [SerializeField] Material water50;
    [SerializeField] Material water75;
    [SerializeField] Material water100;

    private void OnEnable() {
        Rotator.GetComponent<MeshRenderer>().material = water0;
        WaterLevel = 0;

    }

    public void FullRotate() {
        if (WaterLevel != 100) {
            WaterLevel += WaterLevel + 25;
            if (WaterLevel == 25) {
                Rotator.GetComponent<MeshRenderer>().material = water25;
            }
            if (WaterLevel == 50) {
                Rotator.GetComponent<MeshRenderer>().material = water50;
            }
            if (WaterLevel == 75) {
                Rotator.GetComponent<MeshRenderer>().material = water75;
            }
        }
        else {
            Rotator.GetComponent<MeshRenderer>().material = water100;
            Rotator.GetComponent<Rigidbody>().freezeRotation = true;
            BroadcastMessage("WaterWheelDone");
        }
    }

    IEnumerator WhileRotate() {
        yield return new WaitForSeconds(waitspeed);
        FullRotate();
        yield return new WaitForSeconds(waitspeed);
        FullRotate();
        yield return new WaitForSeconds(waitspeed);
        FullRotate();
        yield return new WaitForSeconds(waitspeed);
        FullRotate();

    }

    public void NotFullRotate() {
        if (WaterLevel == 100) {
            return;
        }
        else {
            WaterLevel = 0;
            Rotator.GetComponent<MeshRenderer>().material = water0;
        }
    }


}
