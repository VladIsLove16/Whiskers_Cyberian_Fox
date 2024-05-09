using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static readonly UnityEvent OnBerryPickup = new UnityEvent();
    public static readonly UnityEvent OnPortalPickup = new UnityEvent();

}
