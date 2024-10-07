using ClearCursesProto.Game;
using ClearCursesProto.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ClearCursesProto.Controllers
{
    public class GameCompletedObserver : MonoBehaviour
    {
        [SerializeField]
        private CurseOrderTracker _orderTracker;

        [SerializeField]
        private Curser _curser;

        [SerializeField]
        private Creature _creature;

        [SerializeField]
        private GameUIView _gameUIView;

        [SerializeField]
        private FinishGameUIView _finishGameView;

        private void OnEnable()
        {
            _orderTracker.OnCompleteGame += OnCompleteGame;
        }

        private void OnDisable()
        {
            _orderTracker.OnCompleteGame -= OnCompleteGame;
        }

        private void OnCompleteGame()
        {
            _curser.CleanCreature(_creature);
            _gameUIView.Hide();

            _finishGameView.Show();
        }
    }
}