using UnityEngine;
using System.Collections;
using DG.Tweening;

public class fireplace : Usable {

    public ParticleSystem vuur;
    public AudioSource ouchSound;
    public AudioSource extinguishSound;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("VuurGedooft", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void doAction()
    {
        if (PlayerPrefs.GetInt("FiredingGet") == 1)
        {
            PlayerPrefs.SetInt("VuurGedooft", 1);

            extinguishSound.Play();
            DOTween.To(()=>vuur.startSize, x=> vuur.startSize = x, 0.0F, 1f);
            BoxCollider b = gameObject.GetComponent<BoxCollider>();
            b.enabled = false;
            this.setActive(false);
        }
        else
        {
            if (!ouchSound.isPlaying)
            {
                ouchSound.Play();
            }
        }
    }
}
