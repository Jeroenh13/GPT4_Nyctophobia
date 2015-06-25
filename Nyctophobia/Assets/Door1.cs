using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Door1 : Usable
{


    public override void doAction()
    {
        if (PlayerPrefs.GetInt("hasKeyHallway") == 1)
        {
            transform.DORotate(new Vector3(0, 450, 0), 1f);
            setActive(false);
        }
        
    }

}
