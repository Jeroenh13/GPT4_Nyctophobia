using UnityEngine;
using System.Collections;

public class WateringCan : Usable
{

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("hasWateringCan", 0);
    }

    public override void doAction()
    {
        PlayerPrefs.SetInt("hasWateringCan", 1);
        gameObject.SetActive(false);
    }
}
