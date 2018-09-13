using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Playmode.Application
{
    public class MainController : MonoBehaviour
    {
        private const string SCENE_GAME = "Game";
        
        private void Start()
        {
            LoadGameScene();
        }

        private void LoadGameScene()
        {
            StartCoroutine(LoadGameSceneRoutine());
        }

        public void ReloadGameScene()
        {
            StartCoroutine(ReloadGameSceneRoutine());
        }

        private static IEnumerator LoadGameSceneRoutine()
        {
            if (!SceneManager.GetSceneByName(SCENE_GAME).isLoaded)
                yield return SceneManager.LoadSceneAsync(SCENE_GAME, LoadSceneMode.Additive);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SCENE_GAME));
        }

        private static IEnumerator UnloadGameSceneRoutine()
        {
            if (SceneManager.GetSceneByName(SCENE_GAME).isLoaded)
                yield return SceneManager.UnloadSceneAsync(SCENE_GAME);
        }

        private static IEnumerator ReloadGameSceneRoutine()
        {
            yield return UnloadGameSceneRoutine();
            yield return LoadGameSceneRoutine();
        }
    }
}