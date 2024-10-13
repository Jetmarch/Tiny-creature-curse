using System;
using UnityEngine;
using UnityEngine.UI;

namespace ClearCursesProto.UI
{
    public class FinishGameUIView : MonoBehaviour
    {
        public event Action OnFinishGameBtnClick;

        [SerializeField]
        private GameObject _view;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private Button _finishGameBtn;

        private void Start()
        {
            _finishGameBtn.onClick.AddListener(FinishGameBtnClick);
        }

        private void FinishGameBtnClick()
        {
            OnFinishGameBtnClick?.Invoke();
        }

        public void Show()
        {
            _view.SetActive(true);
            _canvasGroup.alpha = 1f;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0f;
            _view.SetActive(false);
        }
    }
}