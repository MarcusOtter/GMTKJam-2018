using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    [RequireComponent(typeof(Animator))]
    public class SceneController : MonoBehaviour
    {
        internal static SceneController Instance { get; private set; }

        internal static float BestScore;
        internal static float LatestScore;

        private Animator _animator;

        private int _engageLoadAnimationHash;
        private int _disengageLoadAnimationHash;
        private IEnumerator _ongoingCoroutine;

        private void Awake()
        {
            SingletonCheck();
            _animator = GetComponent<Animator>();
            _engageLoadAnimationHash = Animator.StringToHash("Engage");
            _disengageLoadAnimationHash = Animator.StringToHash("Disengage");
            _animator.SetTrigger(_disengageLoadAnimationHash);
        }

        public void TryLoadScene(int sceneIndex)
        {
            if (_ongoingCoroutine != null) return;

            if (sceneIndex == 2)
            {
                LatestScore = FindObjectOfType<ScoreController>().TimeAlive;

                if (LatestScore > BestScore) BestScore = LatestScore;
            }

            _ongoingCoroutine = LoadSceneWithAnim(sceneIndex);
            StartCoroutine(_ongoingCoroutine);
        }

        private IEnumerator LoadSceneWithAnim(int sceneIndex)
        {
            _animator.SetTrigger(_engageLoadAnimationHash);

            // Wait for engage animation to completely finish.
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(sceneIndex);

            yield return new WaitForSeconds(1);
            _animator.SetTrigger(_disengageLoadAnimationHash);

            // Wait for disengage animation to completely finish.
            yield return new WaitForSeconds(1);

            _ongoingCoroutine = null;
        }

        private void SingletonCheck()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
