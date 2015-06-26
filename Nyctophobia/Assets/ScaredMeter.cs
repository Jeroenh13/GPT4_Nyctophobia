using UnityEngine;
using System.Collections;

public class ScaredMeter : MonoBehaviour {

    public AstarAI ai;
    private int lastTime;

	// Use this for initialization
	void Start () {
        lastTime = 200;
	}
	
	// Update is called once per frame
	void Update () {
        lastTime++;
	}

    void OnTriggerEnter(Collider other)
    {
        if (lastTime > 500)
        {
            if (other.gameObject.tag == "Child")
            {
                ai.scaredmeter += 25;
            }
        }
    }
}
