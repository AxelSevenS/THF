using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableBrush : SliceableRigidbody
{
    public override void SliceBehaviour()
    {
        SliceManager.sliceables.Remove(this);
        Sliceable[] sliceables = SliceManager.sliceables.ToArray();
        foreach (Sliceable sliceable in sliceables)
        {
            sliceable?.Slice();
        }
    }

    public override void DestroyBehaviour()
    {
        
    }
}