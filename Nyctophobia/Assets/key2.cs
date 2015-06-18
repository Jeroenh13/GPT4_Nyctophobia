using UnityEngine;
using System.Collections;

public class key2 : Usable
{
    public GameObject ropePiece;

    void Start()
    {
        setActive(false);
        PlayerPrefs.SetInt("hasKey2", 0);
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("hasScissor") == 1)
        {
            setActive(true);
        }
    }

    public override void doAction()
    {
        HingeJoint h = ropePiece.GetComponent<HingeJoint>();
        h.gameObject.SetActive(false);
        PlayerPrefs.SetInt("hasKey2", 1);
        gameObject.SetActive(false);
    }
}
