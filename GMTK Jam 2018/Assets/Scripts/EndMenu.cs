using TMPro;
using UnityEngine;

namespace Scripts
{
    public class EndMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _latestScore;
        [SerializeField] private TMP_Text _bestScore;

        private void Start()
        {
            _latestScore.text = _latestScore.text.Replace("x", SceneController.LatestScore.ToString("00.##"));
            _bestScore.text = _bestScore.text.Replace("x", SceneController.BestScore.ToString("00.##"));
        }
    }
}
