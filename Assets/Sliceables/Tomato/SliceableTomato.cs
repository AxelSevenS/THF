using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableTomato : Sliceable
{
    public override void SliceBehaviour()
    {
        GameManager.current.AddScore(1, transform.position);
    }
}
