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
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private GameObject _view;

        [SerializeField]
        private float _showPageSpeed = 0.5f;

        [SerializeField]
        private float _toggleViewSpeed = 1f;

        private int _currentPage;

        private bool _isShowComics;

        [ContextMenu("Show")]
        public void Show()
        {
            _view.SetActive(true);
            _canvasGroup.DOFade(1f, _toggleViewSpeed);
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
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
            _canvasGroup.DOFade(0f, _toggleViewSpeed);
            _isShowComics = false;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _view.SetActive(false);
        }

        [ContextMenu("Hide all pages")]
        public void HideAllPages()
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