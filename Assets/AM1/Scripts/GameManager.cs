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

        // 現在のレベル
        public static int levelIndex = 0;

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
            levelIndex = 0;
            StartCoroutine(sceneStart());
        }

        private IEnumerator sceneStart()
        {
            IsControllable = false;
            yield return FadeSystem.FadeIn(fadeTime);
            IsControllable = true;
        }

        public static void NextLevel()
        {
            int index = -1;
            for (int i=0; i<2 && index==-1;i++)
            {
                for (int j = levelIndex; j < SceneManager.sceneCount; j++)
                {
                    Scene sc = SceneManager.GetSceneAt(j);
                    if (_instance.gameParams.ignoreStageNames.IndexOf(sc.name) != -1)
                    {
                        index = j;
                        break;
                    }
                }

                if (index == -1)
                {
                    levelIndex = 0;
                }
            }

            if (index == -1)
            {
                print("ゲーム用のシーンが見当たりません。");
                return;
            }

            // レベルを更新しておく
            levelIndex = index + 1;
            levelIndex = levelIndex >= SceneManager.sceneCount ? 0 : levelIndex;

            // シーンを切り替える
            _instance.StartCoroutine(changeScene(SceneManager.GetSceneAt(index)));
        }

        private static IEnumerator changeScene(Scene sc)
        {
            // 操作不能にする
            IsControllable = false;

            // フェードアウト
            FadeSystem.FadeOut(_instance.fadeTime);

            // シーン切り替え
            yield return SceneManager.LoadSceneAsync(sc.name);

            // シーン開始
            yield return _instance.sceneStart();
        }


    }
}
