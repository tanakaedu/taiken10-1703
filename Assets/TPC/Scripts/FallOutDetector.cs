using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1.TPCMove
{
    public class FallOutDetector : MonoBehaviour
    {

        [TooltipAttribute("落下したとみなす高さ"), SerializeField]
        private float FallOutHeight = -2f;

        [TooltipAttribute("落下した時の復活場所。指定しなかった場合は最初の座標。"), SerializeField]
        private Transform startTarget;

        private Vector3 startPosition = Vector3.zero;
        private TPCMove tpcMove;

        public void SetStartTarget(Vector3 target)
        {
            startPosition = target;
        }

        private void Awake()
        {
            if (startTarget != null)
            {
                startPosition = startTarget.position;
            }
            else
            {
                startPosition = transform.position;
            }

            tpcMove = GetComponent<TPCMove>();
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < FallOutHeight)
            {

                if (tpcMove != null)
                {
                    GetComponent<TPCMove>().Warp(startPosition);
                }
                else
                {
                    transform.position = startPosition;
                }
            }
        }
    }
}
