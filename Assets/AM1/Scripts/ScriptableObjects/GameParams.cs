using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AM1/Create Game Params")]
public class GameParams : ScriptableObject {

    [TooltipAttribute("ステージ名ではないシーン名のリスト")]
    public List<string> IgnoreStageNames = new List<string>();
    [TooltipAttribute("BreakableBlockが壊れる上からの落下速度")]
    public float BreakSpeedUp = -0.5f;
    [TooltipAttribute("BreakableBlockが壊れる下からの速度")]
    public float BreakSpeedDown = 0.1f;

}
