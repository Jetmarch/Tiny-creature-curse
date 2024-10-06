using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ClearCursesProto.Game
{
    /// <summary>
    /// There is a bug with loading scene and event system interaction
    /// </summary>
    public class DelayedEventSystemActivator : MonoBehaviour
    {
        [SerializeField]
        private EventSystem _eventSystem;
        private IEnumerator Start()
        {
            _eventSystem.enabled = false;
            yield return new WaitForSeconds(0.5f);
            _eventSystem.enabled = true;
        }
    }
}