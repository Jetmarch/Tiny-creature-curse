using ClearCursesProto.Game;
using ClearCursesProto.UI;
using UnityEngine;

namespace ClearCursesProto.Controllers
{
    public class RemainingCursesController : MonoBehaviour
    {
        [SerializeField]
        private CurseOrderTracker _tracker;

        [SerializeField]
        private RemainingCursesView _view;

        private void OnEnable()
        {
            _tracker.OnOrderCompleted += OnOrderCompleted;
            OnOrderCompleted();
        }

        private void OnDisable()
        {
            _tracker.OnOrderCompleted -= OnOrderCompleted;
        }

        private void OnOrderCompleted()
        {
            _view.UpdateNumber(_tracker.RemainingOrders.ToString());
        }
    }
}