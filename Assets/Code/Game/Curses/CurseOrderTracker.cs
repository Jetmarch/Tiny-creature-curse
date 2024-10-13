using System;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class CurseOrderTracker : MonoBehaviour
    {
        public event Action OnOrderCompleted;
        public event Action OnCompleteGame;
        public event Action<CurseOrder> OnOrderCreated;

        public int OrdersToCompleteGame { get { return _ordersToCompleteGame; } }
        public int CurrentCompletedOrders { get { return _currentCompletedOrders; } }

        public int RemainingOrders { get { return OrdersToCompleteGame - CurrentCompletedOrders; } }

        [SerializeField]
        private int _ordersToCompleteGame = 3;

        [SerializeField]
        private CurseOrderCreator _orderCreator;

        [SerializeField]
        private CurseOrderChecker _orderChecker;

        [SerializeField]
        private Curser _curser;

        [SerializeField]
        private CurseOrder _currentCurseOrder;

        [SerializeField]
        private Creature _creature;

        private int _currentCompletedOrders;

        public void StartOrders()
        {
            _currentCompletedOrders = 0;

            _curser.AffectCreatureWithRandomCurses(_creature);

            CreateOrder();
        }

        public void OnPotionApplied()
        {
            if (!_orderChecker.IsCurseOrderCompleted(_creature, _currentCurseOrder))
            {
                return;
            }
            _currentCompletedOrders++;

            if (_currentCompletedOrders >= _ordersToCompleteGame)
            {
                OnCompleteGame?.Invoke();
                _currentCompletedOrders = 0;
                return;
            }

            OnOrderCompleted?.Invoke();

            CreateOrder();
        }

        [ContextMenu("Create order")]
        public void CreateOrder()
        {
            _currentCurseOrder = _orderCreator.CreateOrder(_creature);
            OnOrderCreated?.Invoke(_currentCurseOrder);
        }

        [ContextMenu("Complete game")]
        private void CompleteGame()
        {
            OnCompleteGame?.Invoke();
        }
    }
}