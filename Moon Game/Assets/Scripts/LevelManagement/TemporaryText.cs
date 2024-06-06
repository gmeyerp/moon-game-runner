using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryText : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
}
