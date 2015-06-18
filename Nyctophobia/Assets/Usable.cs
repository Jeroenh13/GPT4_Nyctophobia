using UnityEngine;
using System.Collections;

public abstract class Usable : MonoBehaviour
{
    private bool active = true; //When false, the item does not light up when hovered over, nor does it fire the doAction() on use.

    public abstract void doAction();

    public bool isActive()
    {
        return active;
    }

    public void setActive(bool active)
    {
        this.active = active;
    }
}
