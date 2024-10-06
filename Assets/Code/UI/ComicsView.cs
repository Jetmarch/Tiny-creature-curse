using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ClearCursesProto.UI
{
    public class ComicsView : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnComicsEnd;

        [SerializeField]
        private List<Image> _comicsPages;

        [SerializeField]
        private CanvasGroup _view;

        [SerializeField]
        private float _showPageSpeed = 0.5f;

        [SerializeField]
        private float _toggleViewSpeed = 1f;

        private int _currentPage;

        private bool _isShowComics;

        [ContextMenu("Show")]
        public void Show()
        {
            _view.DOFade(1f, _toggleViewSpeed);
            _view.interactable = true;
            _view.blocksRaycasts = true;
            HideAllPages();
            _currentPage = 0;
            _isShowComics = true;
            ShowNextPage();
        }

        [ContextMenu("Show next page")]
        public void ShowNextPage()
        {
            if (!_isShowComics) return;

            if(_currentPage >= _comicsPages.Count)
            {
                Hide();
                OnComicsEnd?.Invoke();
                return;
            }

            var page = _comicsPages[_currentPage];
            page.DOColor(new Color(1f, 1f, 1f, 1f), _showPageSpeed);

            _currentPage++;
        }

        public void Hide()
        {
            _view.DOFade(0f, _toggleViewSpeed);
            _isShowComics = false;
            _view.interactable = false;
            _view.blocksRaycasts = false;
        }

        [ContextMenu("Hide all pages")]
        private void HideAllPages()
        {
            foreach(var page in _comicsPages)
            {
                page.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ShowNextPage();
        }
    }
}