using ClearCursesProto.Game;
using ClearCursesProto.UI;
using UnityEngine;
using UnityEngine.UI;


namespace ClearCursesProto.Controllers
{
    public class StartGameObserver : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private ComicsView _startComicsView;

        [SerializeField]
        private ComicsView _endComicsView;

        [SerializeField]
        private CurseOrderView _curseOrderView;

        [SerializeField]
        private PotionsPanelView _potionsPanelView;

        [SerializeField]
        private Button _finishGameBtn;

        [SerializeField]
        private AfterEndComicsView _afterEndComicsView;

        private void OnEnable()
        {
            _gameManager.OnStartGame += OnStartGame;
        }

        private void OnDisable()
        {
            _gameManager.OnStartGame -= OnStartGame;
        }

        private void OnStartGame()
        {
            _startComicsView.Show();
            _endComicsView.HideAllPages();
            _endComicsView.Hide();
            _curseOrderView.Hide();
            _potionsPanelView.Hide();
            _finishGameBtn.gameObject.SetActive(false);
            _afterEndComicsView.HideImmediate();
        }
    }
}