using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxComponent : HPComponent
{
    public override void OnDestroy()
    {
        Destroy(gameObject);
    }
}


