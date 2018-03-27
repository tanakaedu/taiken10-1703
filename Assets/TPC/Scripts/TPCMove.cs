using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1.TPCMove
{
    public class TPCMove : MonoBehaviour
    {
        [Header("動きの設定")]
        [TooltipAttribute("歩く速度を秒速で指定します。"), SerializeField]
        private float walkSpeed = 1f;
        [TooltipAttribute("走る速度を秒速で指定します。"), SerializeField]
        private float runSpeed = 2f;
        [TooltipAttribute("ジャンプ力をm/秒でしていします。"), SerializeField]
        private float jumpPower = 4f;
        [TooltipAttribute("回転する速度を度/秒で指定します。"), SerializeField]
        private float angularVelocity = 1080f;

        [Header("操作設定")]
        [TooltipAttribute("ジャンプキー"), SerializeField]
        private string jumpKey = "z";
        [TooltipAttribute("アクションキー"), SerializeField]
        private string actionKey = "x";
        [TooltipAttribute("走るキー"), SerializeField]
        private string runKey = "left shift";

        [Header("アニメーション調整")]
        [TooltipAttribute("歩き速度とアニメの係数"), SerializeField]
        private float walkSpeed2Anim = 1.1f / 1.0f;
        [TooltipAttribute("走り速度とアニメの係数"), SerializeField]
        private float runSpeed2Anim = 1.0f / 2.0f;

        [Header("ワープ関連")]
        [TooltipAttribute("ワープ完了時に発生させるパーティクルのプレハブ")]
        private GameObject warpParticle;

        /** 停止とみなす速度。これ以下の時は回転させない*/
        private const float STOP_SPEED = 0.05f;

        private CharacterController chr;
        private Vector3 velocity;
        private float lastVelocityY;
        private Animator anim;
        // 最初の子ども
        private Transform transChild;

        private int animWalk = Animator.StringToHash("Walking@loop");
        private int animRun = Animator.StringToHash("Running@loop");

        private void Awake()
        {
            chr = GetComponent<CharacterController>();
            velocity = Vector3.zero;
            anim = GetComponentInChildren<Animator>();
            transChild = transform.GetChild(0);
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameManager.IsControllable)
            {
                return;
            }

            lastVelocityY = velocity.y;

            Vector3 move = velocity;
            if (chr.isGrounded)
            {
                // 地面
                move.x = Input.GetAxisRaw("Horizontal");
                move.y = 0f;
                velocity.y = 0f;
                move.z = Input.GetAxisRaw("Vertical");
                if (Input.GetKey(runKey))
                {
                    // ダッシュ中
                    move = move.normalized * runSpeed;
                }
                else
                {
                    // 歩き中
                    move = move.normalized * walkSpeed;
                }

                // ジャンプ
                if (Input.GetKeyDown(jumpKey) || Input.GetButtonDown("Jump"))
                {
                    velocity.y = jumpPower;
                    anim.SetTrigger("Jump");
                }
            }
            else
            {
                // 空中

            }

            // 重力加速
            velocity.y += Physics.gravity.y * Time.deltaTime;
            move.y = velocity.y;
            velocity = move;
            chr.Move(move * Time.deltaTime);

            // 向きの調整
            move.y = 0f;
            if (move.magnitude >= STOP_SPEED)
            {
                float step = angularVelocity * Mathf.Deg2Rad * Time.deltaTime;
                Vector3 newforward = Vector3.RotateTowards(
                    transChild.forward,
                    move,
                    step, 0F
                );
                transChild.forward = newforward;
            }

            // アニメーション
            anim.SetBool("IsGrounded", chr.isGrounded);
            anim.SetFloat("Speed", move.magnitude);
            anim.SetFloat("VelocityY", velocity.y);
            anim.speed = 1f;

            AnimatorTransitionInfo trinfo = anim.GetAnimatorTransitionInfo(0);
            if (trinfo.fullPathHash == 0)
            {
                AnimatorStateInfo animinfo = anim.GetCurrentAnimatorStateInfo(0);
                if (animinfo.shortNameHash == animWalk)
                {
                    anim.speed = move.magnitude * walkSpeed2Anim;
                }
                else if (animinfo.shortNameHash == animRun)
                {
                    anim.speed = move.magnitude * runSpeed2Anim;
                }
                anim.speed = Mathf.Max(anim.speed, 0.1f);
            }
        }

        public void Warp(Vector3 pos)
        {
            transform.position = pos;
            GetComponent<FallOutDetector>().SetStartTarget(pos);
            if (warpParticle != null)
            {
                Instantiate(warpParticle, pos, Quaternion.identity);
            }
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            // 移動可能ブロック
            if (hit.gameObject.CompareTag("MovableBlock"))
            {
                // 横方向の確認
                if ( Mathf.Approximately(hit.moveDirection.y, 0f))
                {
                    pushBlock(hit.collider);
                }
            }
            // 破壊可能ブロック
            else if (hit.gameObject.CompareTag("BreakableBlock"))
            {
                // 上下方向の確認
                if ((hit.controller.collisionFlags & (CollisionFlags.Above | CollisionFlags.Below)) != 0) {
                    hit.gameObject.GetComponent<BreakableBlock>().Attack(lastVelocityY);
                }
            }
        }

        private void pushBlock(Collider col)
        {
            Vector3 move = velocity;
            move.y = 0f;
            col.GetComponent<MovableBlock>().Push(move);
        }
    }
}

