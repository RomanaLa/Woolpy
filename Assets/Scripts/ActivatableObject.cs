using UnityEngine;
using System.Collections;

public abstract class ActivatableObject : MonoBehaviour {

    public abstract void activate();

    public abstract void deactivate();

    public abstract bool isActive();
}
