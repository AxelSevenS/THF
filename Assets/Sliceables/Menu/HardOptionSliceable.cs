using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardOptionSliceable : MenuSliceable
{

    public override void SliceBehaviour()
    {
        base.SliceBehaviour();
        GameManager.current.StartGame();
    }

    public override void DestroyBehaviour()
    {
    }
}
