using UnityEngine;
using System.Collections;

public class Scissor : Usable
{

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("hasScissor", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void doAction()
    {
        PlayerPrefs.SetInt("hasScissor", 1);
        gameObject.SetActive(false);
    }
}
