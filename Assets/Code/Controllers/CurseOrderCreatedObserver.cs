using ClearCursesProto.Game;
using ClearCursesProto.UI;
using System.Linq;
using UnityEngine;

namespace ClearCursesProto.Controllers
{
    public class CurseOrderCreatedObserver : MonoBehaviour
    {
        [SerializeField]
        private CurseOrderTracker _curseOrderTracker;

        [SerializeField]
        private CurseOrderView _curseOrderView;

        private void OnEnable()
        {
            _curseOrderTracker.OnOrderCreated += OnOrderCreated;
        }

        private void OnDisable()
        {
            _curseOrderTracker.OnOrderCreated -= OnOrderCreated;
        }

        private void OnOrderCreated(CurseOrder order)
        {
            _curseOrderView.Show(order.MustHaveCurses.ToList());
        }
    }
}