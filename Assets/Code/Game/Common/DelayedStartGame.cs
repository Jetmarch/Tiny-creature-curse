using System.Collections;
using UnityEngine;

namespace ClearCursesProto.Game
{
    /// <summary>
    /// There is a bug with loading scene and event system interaction
    /// </summary>
    public class DelayedStartGame : MonoBehaviour
    {
        [SerializeField]
        private float _delay = 0.1f;

        [SerializeField]
        private GameManager _gameManager;
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_delay);
            _gameManager.StartGame();
        }
    }
}