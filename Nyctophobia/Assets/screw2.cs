using UnityEngine;
using System.Collections;
using DG.Tweening;

public class screw2 : Usable
{

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("screw2", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void doAction()
    {
        if (PlayerPrefs.GetInt("screwdriverGet") == 1)
        {
            setActive(false);
            transform.DORotate(new Vector3(0, 90, 180), 2).OnComplete(() => uit());
            transform.DOMoveX(-45.81f, 2);
        }
    }

    void uit()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        PlayerPrefs.SetInt("screw2", 1);
    }
}
