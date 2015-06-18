using UnityEngine;
using System.Collections;

public class ActionButtonScript : MonoBehaviour
{

    private RaycastHit hit;
    private bool keyState = false;
    private bool prevKeyState = false;
    private GameObject obj = null;
    public GameObject raycastOrigin;

    void Start()
    {
    }

    void Update()
    {
        keyState = Input.GetKey(KeyCode.E);
        Transform cam = raycastOrigin.transform;
        if (Physics.Raycast(cam.position, cam.forward, out hit, 3F))
        {
            if (hit.transform.gameObject.tag != "usable")
            {
                highlightObject(obj, Color.white);
            }
            obj = hit.transform.gameObject;


            if (obj.tag == "usable")
            {
                Usable u = obj.GetComponent<Usable>();
                if (u.isActive())
                {
                    highlightObject(obj, Color.yellow);
                    if (keyState && !prevKeyState) //Button is pressed once
                    {
                        u.doAction();
                    }
                }



            }
        }
        else
        {
            if (obj != null)
            {
                highlightObject(obj, Color.white);
            }
        }

        prevKeyState = keyState;
    }

    private void highlightObject(GameObject obj, Color color)
    {
        if (obj != null)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.SetColor("_Color", color);
            }
            Renderer[] renderList = obj.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderList)
            {
                foreach (Material m in r.materials)
                {
                    m.SetColor("_Color", color);
                }
            }
        }
    }
}
