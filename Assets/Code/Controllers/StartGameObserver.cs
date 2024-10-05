using ClearCursesProto.Game;
using UnityEngine;


namespace ClearCursesProto.Controllers
{
    public class StartGameObserver : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private CurseOrderTracker _curseOrderTracker;

        private void OnEnable()
        {
            _gameManager.OnStartGame += _curseOrderTracker.OnStartGame;
        }

        private void OnDisable()
        {
            _gameManager.OnStartGame -= _curseOrderTracker.OnStartGame;
        }
    }
}