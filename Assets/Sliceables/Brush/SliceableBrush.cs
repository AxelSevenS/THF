using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableBrush : Sliceable
{
    public override void SliceBehaviour()
    {
        SliceManager.sliceables.Remove(this);
        Sliceable[] sliceables = SliceManager.sliceables.ToArray();
        foreach (Sliceable sliceable in sliceables)
        {
            if ( !sliceable.isPenalty )
                sliceable?.Slice();
        }
    }

    public override void DestroyBehaviour()
    {
        
    }
}