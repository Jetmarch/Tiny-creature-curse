using ClearCursesProto.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ClearCursesProto.Controllers
{
    public class ShowEndComicsController : MonoBehaviour
    {
        [SerializeField]
        private Button _finishGameBtn;

        [SerializeField]
        private ComicsView _endComicsView;

        private void OnEnable()
        {
            _finishGameBtn.onClick.AddListener(OnFinishGame);
        }

        private void OnDisable()
        {
            _finishGameBtn.onClick.RemoveListener(OnFinishGame);
        }

        private void OnFinishGame()
        {
            _endComicsView.Show();
            _finishGameBtn.gameObject.SetActive(false);
        }
    }
}