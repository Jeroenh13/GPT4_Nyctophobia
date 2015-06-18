using UnityEngine;
using System.Collections;
using DG.Tweening;

public class plantpot : Usable
{
    public override void doAction()
    {
        transform.DOMoveZ(6.5f, 1f);
        //transform.position += new Vector3(0, 0, -1);
        setActive(false);
    }
}