using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1
{
    public class ClearPoint : MonoBehaviour
    {
        [TooltipAttribute("次のステージのシーン名。最終ステージの場合はClearにする"), SerializeField]
        private string nextStageName = "Clear";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.SceneChange(nextStageName);
            }
        }
    }
}
