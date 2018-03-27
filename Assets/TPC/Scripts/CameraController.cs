using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1.TPCMove
{
    public class CameraController : MonoBehaviour
    {
        [TooltipAttribute("カメラ位置を補正する際のLerp係数。deltaTimeを掛けて利用。"), SerializeField]
        private float cameraRate = 10f;
        [TooltipAttribute("カメラが追う対象"), SerializeField]
        private Transform targetTransform;

        private Vector3 offset;

        private void Awake()
        {
            if (targetTransform == null)
            {
                targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
            offset = targetTransform.position - transform.position;
        }

        // Camera制御
        void LateUpdate()
        {
            Vector3 targetPos = targetTransform.position - offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, cameraRate * Time.deltaTime);
        }
    }
}
