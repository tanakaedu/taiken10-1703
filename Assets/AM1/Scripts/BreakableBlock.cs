using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1
{
    public class BreakableBlock : MonoBehaviour
    {
        [TooltipAttribute("壊れる時に発生させるパーティクル。指定しない場合は何もしない。"), SerializeField]
        private GameObject breakParticle;
        [TooltipAttribute("ゲームパラメーター"), SerializeField]
        private GameParams gameParams;

        /** 上下からプレイヤーと衝突した時に、その時のY速度を指定して呼び出される*/
        public void Attack(float speedY)
        {
            if (    (speedY <= gameParams.BreakSpeedUp)
                ||  (speedY >= gameParams.BreakSpeedDown))
            {
                if (breakParticle != null)
                {
                    Instantiate(breakParticle, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
        }
    }
}
