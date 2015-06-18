using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Candle1 : Usable {

    public GameObject doorToRotate;
    public GameObject canvasToRemove;
    public ParticleSystem flame;
    public override void doAction()
    {
        doorToRotate.transform.DORotate(new Vector3(0, -116, 270), 1);
        canvasToRemove.gameObject.SetActive(false);
        flame.gameObject.SetActive(false);
        setActive(false);
    }
}
