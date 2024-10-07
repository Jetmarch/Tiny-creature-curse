using System;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class MouseClickOnObject : MonoBehaviour
    {
        public event Action OnClick;

        private void OnMouseDown()
        {
            OnClick?.Invoke();
        }
    }
}