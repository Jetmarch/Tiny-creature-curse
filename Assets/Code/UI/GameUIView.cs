using UnityEngine;

namespace ClearCursesProto.UI
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField]
        private PotionsPanelView _potionsPanel;

        [SerializeField]
        private TextPopupView _potionsPopup;

        [SerializeField]
        private CurseOrderView _curseOrder;

        [SerializeField]
        private GameObject _view;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        public void Show()
        {
            _view.SetActive(true);
            _canvasGroup.alpha = 1f;
            _potionsPanel.Show();
        }

        public void Hide()
        {
            _curseOrder.Hide();
            _potionsPanel.Hide();
            _potionsPopup.HidePopup();
            _canvasGroup.alpha = 0f;
            _view.SetActive(false);
        }
    }
}