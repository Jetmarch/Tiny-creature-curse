using TMPro;
using UnityEngine;

namespace ClearCursesProto.UI
{
    public class TextPopupView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _popupObject;

        [SerializeField]
        private TextMeshProUGUI _popupText;

        public void ShowPopup(string text)
        {
            _popupObject.SetActive(true);
            _popupText.text = text;
        }

        public void HidePopup()
        {
            _popupObject.SetActive(false);
            _popupText.text = string.Empty;
        }
    }
}