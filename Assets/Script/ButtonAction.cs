using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ButtonAction : MonoBehaviour
    {
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                                    Application.Quit();
#endif
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
        public void LoadInstruction()
        {
            SceneManager.LoadScene("Instruction");
        }
        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}