using UnityEngine;
using TMPro;

namespace Scripts
{
    public class ScoreController : MonoBehaviour
    {
        internal float TimeAlive { get; private set; }

        [SerializeField] private TMP_Text _timeAliveText;

        private void Update()
        {
            TimeAlive += Time.deltaTime;
            _timeAliveText.text = TimeAlive.ToString("00.00");
        }
    }
}

