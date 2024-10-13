using DG.Tweening;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class RotateObjectAnimation : MonoBehaviour
    {
        [SerializeField]
        private float _rotateDuration = 1f;

        [SerializeField]
        private float _rotateStrength = 5f;

        [ContextMenu("ShowAnimation")]
        public void ShowAnimation()
        {
            transform.DOBlendableRotateBy(Vector3.up * _rotateStrength, _rotateDuration, RotateMode.FastBeyond360);
        }
    }
}