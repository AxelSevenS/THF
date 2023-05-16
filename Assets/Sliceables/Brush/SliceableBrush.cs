using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableBrush : Sliceable
{
    public override void SliceBehaviour()
    {
        SliceManager.sliceables.Remove(this);
        foreach (Sliceable sliceable in SliceManager.sliceables)
        {
            sliceable?.Slice();
        }
    }

    public override void DestroyBehaviour()
    {
        
    }
}