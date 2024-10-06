using ClearCursesProto.Game;
using ClearCursesProto.UI;
using UnityEngine;


namespace ClearCursesProto.Controllers
{
    public class PotionButtonClickedObserver : MonoBehaviour
    {
        [SerializeField]
        private PotionsPanelView _potionButtonsManager;

        [SerializeField]
        private PotionApplier _curseCaster;


        private void OnEnable()
        {
            _potionButtonsManager.OnPotionButtonClicked += _curseCaster.ApplyPotion;
        }

        private void OnDisable()
        {
            _potionButtonsManager.OnPotionButtonClicked -= _curseCaster.ApplyPotion;
        }
    }
}