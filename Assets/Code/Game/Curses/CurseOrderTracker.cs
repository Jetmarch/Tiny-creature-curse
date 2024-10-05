using System;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class CurseOrderTracker : MonoBehaviour
    {
        public event Action OnOrderCompleted;
        public event Action OnCompleteGame;

        [SerializeField]
        private int _ordersToCompleteGame = 3;

        [SerializeField]
        private CurseOrderCreator _creator;

        [SerializeField]
        private CurseOrderChecker _checker;

        [SerializeField]
        private CurseOrder _currentCurseOrder;

        [SerializeField]
        private Creature _creature;

        private int _currentCompletedOrders;

        public void OnStartGame()
        {
            _currentCompletedOrders = 0;

            AffectCreatureWithRandomCurses();

            _currentCurseOrder = _creator.CreateOrder();
        }

        public void OnPotionApplied()
        {
            if (!_checker.IsCurseOrderCompleted(_creature, _currentCurseOrder))
            {
                return;
            }

            OnOrderCompleted?.Invoke();
            Debug.Log("Order completed!");

            _currentCompletedOrders++;

            if (_currentCompletedOrders >= _ordersToCompleteGame)
            {
                OnCompleteGame?.Invoke();
                Debug.Log("Game completed!");
                _currentCompletedOrders = 0;
            }

            _currentCurseOrder = _creator.CreateOrder();
        }

        [ContextMenu("Create order")]
        public void CreateOrder()
        {
            _currentCurseOrder = _creator.CreateOrder();
        }

        private void AffectCreatureWithRandomCurses()
        {
            var randomCurses = _creator.GetRandomCurses();
            foreach (var curses in randomCurses)
            {
                _creature.AddCurse(curses);
            }
            _creature.UpdateCurses();
        }
    }
}