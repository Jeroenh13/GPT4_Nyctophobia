using UnityEngine;
using System.Collections;

public class Key3 : Usable {
    public GameObject panelToRemove;

    void Start () 
    {
        PlayerPrefs.SetInt("Key3Get", 0);
	}
	

    public override void doAction()
    {
        PlayerPrefs.SetInt("Key3Get", 1);
        panelToRemove.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
