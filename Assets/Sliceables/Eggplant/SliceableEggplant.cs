using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableEggplant : SliceableRigidbody
{
    public override void SliceBehaviour()
    {
        GameManager.current.AddScore(15, transform.position);
    }

    public override void DestroyBehaviour()
    {
        GameManager.current.AddScore(-5, transform.position);
    }
}
