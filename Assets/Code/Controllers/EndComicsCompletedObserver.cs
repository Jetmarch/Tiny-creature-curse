using ClearCursesProto.UI;
using UnityEngine;

namespace ClearCursesProto.Controllers
{
    public class EndComicsCompletedObserver : MonoBehaviour
    {
        [SerializeField]
        private ComicsView _endComicsView;

        [SerializeField]
        private AfterEndComicsView _afterEndComicsView;

        private void OnEnable()
        {
            _endComicsView.OnComicsEnd += FinishComicsCompleted;
        }

        private void OnDisable()
        {
            _endComicsView.OnComicsEnd -= FinishComicsCompleted;
        }

        private void FinishComicsCompleted()
        {
            _afterEndComicsView.Show();
        }
    }
}