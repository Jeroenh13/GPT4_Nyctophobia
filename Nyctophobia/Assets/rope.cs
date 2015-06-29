using UnityEngine;
using System.Collections;

public class rope : Usable {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("ropeKnipped", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void doAction()
    {
        if (PlayerPrefs.GetInt("hasScissor") == 1)
        {
            HingeJoint hj = this.GetComponent<HingeJoint>();
            Destroy(hj);
            this.setActive(false);
            PlayerPrefs.SetInt("ropeKnipped", 1);
        }
    }
}
