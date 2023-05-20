using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSliceable : MenuSliceable
{

    [SerializeField] private GameManager.GameDifficulty difficulty = GameManager.GameDifficulty.Easy;

    public override void SliceBehaviour()
    {
        base.SliceBehaviour();
        GameManager.current.StartGame(difficulty);
    }

    public override void DestroyBehaviour()
    {
    }
}
