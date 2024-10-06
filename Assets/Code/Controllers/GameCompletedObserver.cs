using ClearCursesProto.Game;
using ClearCursesProto.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ClearCursesProto.Controllers
{
    public class GameCompletedObserver : MonoBehaviour
    {
        [SerializeField]
        private CurseOrderTracker _orderTracker;

        [SerializeField]
        private Curser _curser;

        [SerializeField]
        private Creature _creature;

        [SerializeField]
        private PotionsPanelView _potionPanelView;

        [SerializeField]
        private CurseOrderView _curseOrderView;

        [SerializeField]
        private Button _finishGameBtn;

        private void OnEnable()
        {
            _orderTracker.OnCompleteGame += OnCompleteGame;
        }

        private void OnDisable()
        {
            _orderTracker.OnCompleteGame -= OnCompleteGame;
        }

        private void OnCompleteGame()
        {
            _curser.CleanCreature(_creature);
            _potionPanelView.Hide();
            _curseOrderView.Hide();

            //TODO: Show final comics with clean creature
            _finishGameBtn.gameObject.SetActive(true);
        }
    }
}