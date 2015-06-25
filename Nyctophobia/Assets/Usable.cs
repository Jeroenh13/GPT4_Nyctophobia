using UnityEngine;
using System.Collections;
using System.Reflection;

public abstract class Usable : MonoBehaviour
{
    private bool active = true; //When false, the item does not light up when hovered over, nor does it fire the doAction() on use.
    private bool highlighted = false;
    public string itemName;

    public abstract void doAction();

    public bool isActive()
    {
        return active;
    }

    public void setActive(bool active)
    {
        this.active = active;
    }


    public void highlight()
    {
        highlighted = true;
    }

    void OnGUI()
    {
        if (highlighted && active && itemName.Trim().ToString().Length > 0)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
            GUI.Box(new Rect(Screen.width / 2 - 75, Screen.height / 2, 150, 25), itemName);
            GUI.Box(new Rect(Screen.width / 2 - 75, Screen.height / 2 + 25, 150, 150), Resources.Load("plaatje") as Texture);
        }
    }

    public void restoreTexture()
    {
        highlighted = false;
    }
}
