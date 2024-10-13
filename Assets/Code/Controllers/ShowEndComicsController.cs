using ClearCursesProto.UI;
using UnityEngine;

namespace ClearCursesProto.Controllers
{
    public class ShowEndComicsController : MonoBehaviour
    {
        [SerializeField]
        private FinishGameUIView _finishGameView;

        [SerializeField]
        private ComicsView _endComicsView;

        private void OnEnable()
        {
            _finishGameView.OnFinishGameBtnClick += OnFinishGame;
        }

        private void OnDisable()
        {
            _finishGameView.OnFinishGameBtnClick -= OnFinishGame;
        }

        private void OnFinishGame()
        {
            _finishGameView.Hide();
            _endComicsView.Show();
        }
    }
}