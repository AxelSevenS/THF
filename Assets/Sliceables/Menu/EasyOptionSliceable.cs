using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyOptionSliceable : MenuSliceable
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
