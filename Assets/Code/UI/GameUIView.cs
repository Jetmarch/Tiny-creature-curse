using UnityEngine;

namespace ClearCursesProto.UI
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _view;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private PotionsPanelView _potionsPanel;

        [SerializeField]
        private TextPopupView _potionsPopup;

        [SerializeField]
        private CurseOrderView _curseOrder;

        [SerializeField]
        private RemainingCursesView _remainingCurses;

        public void Show()
        {
            _view.SetActive(true);
            _canvasGroup.alpha = 1f;
            _potionsPanel.Show();
            _remainingCurses.Show();
        }

        public void Hide()
        {
            _curseOrder.Hide();
            _potionsPanel.Hide();
            _potionsPopup.HidePopup();
            _remainingCurses.Hide();
            _canvasGroup.alpha = 0f;
            _view.SetActive(false);
        }
    }
}