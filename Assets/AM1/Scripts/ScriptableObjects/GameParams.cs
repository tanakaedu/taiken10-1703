using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AM1/Create Game Params")]
public class GameParams : ScriptableObject {

    [TooltipAttribute("ステージ名ではないシーン名のリスト")]
    public List<string> ignoreStageNames = new List<string>();

}
