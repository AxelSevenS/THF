using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableNegi : SliceableRigidbody
{
    public override void SliceBehaviour()
    {
        GameManager.current.AddScore(10, transform.position);
    }

    public override void DestroyBehaviour()
    {
        GameManager.current.AddScore(-4, transform.position);
    }
}
