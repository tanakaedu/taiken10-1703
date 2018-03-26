using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AM1
{
    public class GameManager : MonoBehaviour
    {
        [TooltipAttribute("フェードイン・アウトのデフォルト秒数"), SerializeField]
        private float fadeTime = 0.5f;

        [TooltipAttribute("ゲームパラメーターのScriptableObjectを渡します"), SerializeField]
        private GameParams gameParams;

        public static bool IsControllable
        {
            get;
            private set;
        }

        private static GameManager _instance = null;

        public static GameManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = FindObjectOfType<GameManager>();
                if (_instance != null)
                {
                    return _instance;
                }

                return Create();
            }
        }

        private static GameManager Create()
        {
            GameObject go = new GameObject("GameManager");
            _instance = go.AddComponent<GameManager>();

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

            // ゲーム開始
            StartCoroutine(sceneStart());
        }

        private IEnumerator sceneStart()
        {
            IsControllable = false;
            yield return FadeSystem.FadeIn(fadeTime);
            IsControllable = true;
        }

        public static void SceneChange(string name)
        {
            _instance.StartCoroutine(changeScene(name));
        }

        private static IEnumerator changeScene(string sc)
        {
            // 操作不能にする
            IsControllable = false;

            // フェードアウト
            yield return FadeSystem.FadeOut(_instance.fadeTime);

            // シーン切り替え
            yield return SceneManager.LoadSceneAsync(sc);

            // シーン開始
            yield return _instance.sceneStart();
        }
    }
}
