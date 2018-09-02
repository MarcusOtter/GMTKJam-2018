using UnityEngine;

namespace Scripts
{
    public class StartMenu : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            SceneController.Instance.TryLoadScene(1);
        }
    }
}
