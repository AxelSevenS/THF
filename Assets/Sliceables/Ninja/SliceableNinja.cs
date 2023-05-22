using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableNinja : Sliceable
{

    public override bool isPenalty => true;

    public override void SliceBehaviour()
    {
        GameManager.current.RemoveLife(3);
    }

    public override void DestroyBehaviour()
    {
        
    }
}