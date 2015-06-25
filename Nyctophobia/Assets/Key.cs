using UnityEngine;
using System.Collections;

public class Key : Usable
{

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("hasKey1", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void doAction()
    {
        PlayerPrefs.SetInt("hasKey1", 1);
        gameObject.SetActive(false);
    }

}
