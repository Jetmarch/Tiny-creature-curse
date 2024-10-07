using ClearCursesProto.Game;
using DG.Tweening;
using RotaryHeart.Lib.SerializableDictionary;
using System.Collections.Generic;
using UnityEngine;

namespace ClearCursesProto.UI
{
    public class CurseOrderView : MonoBehaviour
    {
        [SerializeField]
        private SerializableDictionaryBase<LilFrogCurse, GameObject> _curseImageMap;

        [SerializeField]
        private RectTransform _view;

        [Header("Animations")]
        [SerializeField]
        private float _showShakeAnimationDuration = 0.5f;

        [SerializeField]
        private float _showShakeAnimationScale = 0.5f;

        [SerializeField]
        private float _changePositionDuration = 1f;

        [SerializeField]
        private Vector2 _showPosition = Vector2.zero;

        [SerializeField]
        private Vector2 _hidePosition = new(450f, 450f);

        public void Show(List<LilFrogCurse> curses)
        {
            _view.gameObject.SetActive(true);

            _view.DOShakeRotation(_showShakeAnimationDuration, _showShakeAnimationScale);

            //Hide view, apply curses, then show view
            _view.DOAnchorPos(_hidePosition, _changePositionDuration).OnComplete(() =>
                { 
                    ApplyCurses(curses);
                    _view.DOAnchorPos(_showPosition, _changePositionDuration);
                });
        }

        private void ApplyCurses(List<LilFrogCurse> curses)
        {
            foreach (var curseAttr in _curseImageMap.Values)
            {
                curseAttr.SetActive(false);
            }

            foreach (var curse in curses)
            {
                _curseImageMap[curse].SetActive(true);
            }
        }

        public void Hide()
        {
            _view.gameObject.SetActive(false);
        }
    }
}