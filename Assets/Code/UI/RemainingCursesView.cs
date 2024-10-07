using DG.Tweening;
using TMPro;
using UnityEngine;

namespace ClearCursesProto.UI
{
    public class RemainingCursesView : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _view;

        [SerializeField]
        private TextMeshProUGUI _remainingCursesNumber;

        [Header("Animations")]
        [SerializeField]
        private Vector2 _showPosition;

        [SerializeField]
        private Vector2 _hidePosition;

        [SerializeField]
        private float _showSpeed = 1f;

        public void Show()
        {
            _view.gameObject.SetActive(true);

            _view.DOAnchorPos(_showPosition, _showSpeed);
        }

        public void UpdateNumber(string remainingCursesNumber)
        {
            _remainingCursesNumber.text = remainingCursesNumber;
        }

        public void Hide()
        {
            _view.DOAnchorPos(_hidePosition, _showSpeed);
            _view.gameObject.SetActive(false);
        }
    }
}