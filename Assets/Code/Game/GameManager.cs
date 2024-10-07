using System;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnStartGame;


        [ContextMenu("Start game")]
        public void StartGame()
        {
            OnStartGame?.Invoke();
        }
    }
}