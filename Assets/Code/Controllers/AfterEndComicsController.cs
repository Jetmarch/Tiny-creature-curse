using ClearCursesProto.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClearCursesProto.Controllers
{
    public class AfterEndComicsController : MonoBehaviour
    {
        [SerializeField]
        private AfterEndComicsView _view;

        private void OnEnable()
        {
            _view.OnRestartGame += OnRestartGame;
            _view.OnExitGame += OnExitGame;
        }

        private void OnDisable()
        {
            _view.OnRestartGame -= OnRestartGame;
            _view.OnExitGame -= OnExitGame;
        }

        private void OnRestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void OnExitGame()
        {
            Application.Quit();
        }
    }
}