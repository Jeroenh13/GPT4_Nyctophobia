using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Door1 : Usable
{


    public override void doAction()
    {
        if(PlayerPrefs.GetInt("hasKey1") == 1)
        {
            transform.DORotate(new Vector3(1.525f, -400, -360), 1f);
            setActive(false);
        }
        
    }

}
