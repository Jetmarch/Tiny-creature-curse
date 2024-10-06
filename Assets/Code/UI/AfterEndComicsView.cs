using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClearCursesProto.UI
{
    public class AfterEndComicsView : MonoBehaviour
    {
        public event Action OnRestartGame;
        public event Action OnExitGame;

        [SerializeField]
        private CanvasGroup _view;

        [SerializeField]
        private float _toggleViewSpeed = 1f;

        [SerializeField]
        private Button _restartGameBtn;

        [SerializeField]
        private Button _exitGameBtn;

        private void Start()
        {
            _restartGameBtn.onClick.AddListener(RestartGame);
            _exitGameBtn.onClick.AddListener(ExitGame);
        }

        public void Show()
        {
            _view.DOFade(1f, _toggleViewSpeed);
        }

        public void Hide()
        {
            _view.DOFade(0f, _toggleViewSpeed);
        }

        private void RestartGame()
        {
            OnRestartGame?.Invoke();
        }

        private void ExitGame()
        {
            OnExitGame?.Invoke();
        }
    }
}