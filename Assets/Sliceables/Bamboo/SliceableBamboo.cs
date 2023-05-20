using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableBamboo : SliceableRigidbody
{
    public override void SliceBehaviour()
    {
        GameManager.current.AddScore(5, transform.position);
    }

    public override void DestroyBehaviour()
    {
        GameManager.current.AddScore(-3, transform.position);
        GameManager.current.RemoveLife();
    }
}
