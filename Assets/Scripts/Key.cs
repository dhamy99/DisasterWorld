using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractuable
{
    public void Interact()
    {
        Destroy(gameObject);
    }

}
