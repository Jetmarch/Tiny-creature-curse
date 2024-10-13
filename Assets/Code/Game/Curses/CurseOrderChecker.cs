using UnityEngine;

namespace ClearCursesProto.Game
{
    public class CurseOrderChecker : MonoBehaviour
    {
        public bool IsCurseOrderCompleted(Creature creature, CurseOrder currentCurseOrder)
        {
            var activeCurses = creature.ActiveCurses;
            var mustHaveCurses = currentCurseOrder.MustHaveCurses;

            if (activeCurses.Count != mustHaveCurses.Count)
            {
                return false;
            }

            foreach (var activeCurse in activeCurses)
            {
                bool isCurseFinded = false;
                foreach (var mustHaveCurse in mustHaveCurses)
                {
                    if (mustHaveCurse == activeCurse)
                    {
                        isCurseFinded = true;
                    }
                }

                if (!isCurseFinded)
                {
                    return false;
                }
            }

            return true;
        }
    }
}