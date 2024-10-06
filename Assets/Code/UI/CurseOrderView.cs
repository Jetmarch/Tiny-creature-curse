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

        [SerializeField]
        private float _showShakeAnimationDuration = 0.5f;

        [SerializeField]
        private float _showShakeAnimationScale = 0.5f;

        public void Show(List<LilFrogCurse> curses)
        {
            _view.gameObject.SetActive(true);

            foreach(var curseAttr in _curseImageMap.Values)
            {
                curseAttr.SetActive(false);
            }

            foreach(var curse in curses)
            {
                _curseImageMap[curse].SetActive(true);
            }

            _view.DOShakeRotation(_showShakeAnimationDuration, _showShakeAnimationScale);
        }

        [ContextMenu("Punch")]
        private void Punch()
        {
            _view.DOShakeRotation(_showShakeAnimationDuration, _showShakeAnimationScale);
        }

        public void Hide()
        {
            _view.gameObject.SetActive(false);
        }
    }
}