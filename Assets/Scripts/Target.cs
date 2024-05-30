using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnDestroy()
    {
        FindObjectOfType<Flashback>().TargetDestroyed();
    }
}