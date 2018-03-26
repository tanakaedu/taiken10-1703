using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1.TPCMove
{
    public class Warp : MonoBehaviour
    {

        [TooltipAttribute("ワープ先のオブジェクトのTransform。デフォルトはStartPoint"), SerializeField]
        private Transform warpTarget;

        private void Awake()
        {
            if (warpTarget == null)
            {
                warpTarget = GameObject.Find("StartPosition").transform;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<TPCMove>().Warp(warpTarget.position);
            }
        }
    }
}
