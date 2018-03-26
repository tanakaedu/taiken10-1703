using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AM1
{
    public class ClickToStart : MonoBehaviour
    {
        public float WaitTime = 2f;

        private void Start()
        {
            StartCoroutine(clickToStart());
        }

        IEnumerator clickToStart()
        {
            yield return new WaitForSeconds(WaitTime);
            while (true)
            {
                if (Input.anyKeyDown)
                {
                    break;
                }
                yield return null;
            }
            GameManager.SceneChange("Stage1");
        }

    }
}
