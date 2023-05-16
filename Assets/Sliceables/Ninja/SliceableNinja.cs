using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableNinja : Sliceable
{
    public override void SliceBehaviour()
    {
        
    }

    public override void DestroyBehaviour()
    {
        SliceManager.current.enabled = false;
        
    }
}