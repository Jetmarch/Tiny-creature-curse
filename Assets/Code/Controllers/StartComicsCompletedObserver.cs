using ClearCursesProto.Game;
using ClearCursesProto.UI;
using UnityEngine;

namespace ClearCursesProto.Controllers
{
    public class StartComicsCompletedObserver : MonoBehaviour
    {
        [SerializeField]
        private ComicsView _comicsView;

        [SerializeField]
        private CurseOrderTracker _curseOrderTracker;

        [SerializeField]
        private GameUIView _gameUIView;

        private void OnEnable()
        {
            _comicsView.OnComicsEnd += OnComicsEnd;
        }

        private void OnDisable()
        {
            _comicsView.OnComicsEnd -= OnComicsEnd;
        }

        private void OnComicsEnd()
        {
            _gameUIView.Show();
            _curseOrderTracker.StartOrders();
        }
    }
}