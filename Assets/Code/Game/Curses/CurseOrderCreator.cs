using System;
using System.Collections.Generic;
using UnityEngine;


namespace ClearCursesProto.Game
{
    public class CurseOrderCreator : MonoBehaviour
    {
        [SerializeField]
        private int _minCountOfCurses = 1;
        [SerializeField] 
        private int _maxCountOfCurses = 3;

        public CurseOrder CreateOrder()
        {
            var curses = GetRandomCurses();
            return new CurseOrder(curses);
        }

        public List<LilFrogCurse> GetRandomCurses()
        {
            var countOfCurses = UnityEngine.Random.Range(_minCountOfCurses, _maxCountOfCurses);
            var curses = new List<LilFrogCurse>();
            var possibleCurses = Enum.GetValues(typeof(LilFrogCurse));

            //TODO: Fix possible curse duplicates
            for (var i = 0; i < countOfCurses; i++)
            {
                var newCurse = (LilFrogCurse)possibleCurses.GetValue(UnityEngine.Random.Range(0, possibleCurses.Length));

                curses.Add(newCurse);
            }


            return curses;
        }
    }
}