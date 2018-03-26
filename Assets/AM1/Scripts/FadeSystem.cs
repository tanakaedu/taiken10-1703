using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AM1
{
    public class FadeSystem : MonoBehaviour
    {
        private static FadeSystem _instance;

        public static FadeSystem Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = FindObjectOfType<FadeSystem>();
                if (_instance != null)
                {
                    return _instance;
                }
                return Create();
            }
        }

        private Image fadeCover;

        private static FadeSystem Create()
        {
            GameObject go = new GameObject("FadeSystem");
            _instance = go.AddComponent<FadeSystem>();
            return _instance;
        }

        private void Awake()
        {
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            for (int i=0; i<transform.childCount; i++)
            {
                if (transform.GetChild(i).name == "FadeCover")
                {
                    fadeCover = transform.GetChild(i).GetComponent<Image>();
                }
            }
        }

        public static IEnumerator FadeOut(float time)
        {
            _instance.fadeCover.enabled = true;
            return _instance.fade(1f, time);
        }

        public static IEnumerator FadeIn(float time)
        {
            while ((_instance == null) || (_instance.fadeCover == null))
            {
                yield return null;
            }
            _instance.fadeCover.enabled = true;
            yield return _instance.fade(0f, time);
            _instance.fadeCover.enabled = false;
        }

        private IEnumerator fade(float to, float time)
        {
            float from = 1f - to;
            float keika = 0f;
            Color col = fadeCover.color;
            for (keika=0f; keika<time; keika+=Time.deltaTime)
            {
                col.a = Mathf.Lerp(from, to, keika / time);
                fadeCover.color = col;
                yield return null;
            }

            col.a = to;
            fadeCover.color = col;
        }

    }
}
