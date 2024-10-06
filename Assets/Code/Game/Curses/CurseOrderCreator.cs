using UnityEngine;


namespace ClearCursesProto.Game
{
    public class CurseOrderCreator : MonoBehaviour
    {
        [SerializeField]
        private Curser _curser;

        public CurseOrder CreateOrder(Creature creature)
        {
            var curses = _curser.GetRandomCurses(creature.MinCountOfCurses, creature.MaxCountOfCurses);
            return new CurseOrder(curses);
        }
    }
}