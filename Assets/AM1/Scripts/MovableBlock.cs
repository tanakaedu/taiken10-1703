using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1
{
    public class MovableBlock : MonoBehaviour
    {

        private BoxCollider myCollider;
        private Rigidbody rb;
        private Vector3 myVelocity;
        private Vector3 halfSize;

        private void Awake()
        {
            myCollider = GetComponent<BoxCollider>();
            rb = GetComponent<Rigidbody>();
            myVelocity = Vector3.zero;
            halfSize = new Vector3(
                myCollider.size.x * transform.localScale.x,
                myCollider.size.y * transform.localScale.y,
                myCollider.size.z * transform.localScale.z
            ) * 0.5f;
        }

        /**
         * 指定の速度で押せるかを判定。
         * 着地していないと押せない
         * 移動先に何もなければ、指定の速度で移動して、trueを返す。
         * 上に移動可能なブロックがあれば、それも動かす。
         * 移動先に何かあったら動かず、falseを返す。
         */
        public bool Push(Vector3 move)
        {
            RaycastHit hitInfo;

            bool ishit = Physics.BoxCast(
                transform.position + myCollider.center,
                halfSize,
                move.normalized,
                out hitInfo,
                Quaternion.identity,
                move.magnitude * Time.deltaTime);
            if (!ishit)
            {
                // 移動可能
                transform.Translate(move * Time.deltaTime);
                myVelocity = move;
                return true;
            }

            return false;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
