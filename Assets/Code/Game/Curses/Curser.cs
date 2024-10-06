using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class Curser : MonoBehaviour
    {
        public void AffectCreatureWithRandomCurses(Creature creature)
        {
            var randomCurses = GetRandomCurses(creature.MinCountOfCurses, creature.MaxCountOfCurses);
            foreach (var curses in randomCurses)
            {
                creature.AddCurse(curses);
            }
            creature.UpdateCurses();
        }

        public void CleanCreature(Creature creature)
        {
            var cursesCache = new List<LilFrogCurse>(creature.ActiveCurses);
            foreach (var curses in cursesCache)
            {
                creature.RemoveCurse(curses);
            }
            creature.UpdateCurses();
        }

        public List<LilFrogCurse> GetRandomCurses(int minCountOfCurses, int maxCountOfCurses)
        {
            var countOfCurses = UnityEngine.Random.Range(minCountOfCurses, maxCountOfCurses);
            var curses = new List<LilFrogCurse>();
            var possibleCurses = Enum.GetValues(typeof(LilFrogCurse));

            for (var i = 0; i < countOfCurses; i++)
            {
                var newCurse = (LilFrogCurse)possibleCurses.GetValue(UnityEngine.Random.Range(0, possibleCurses.Length));

                while (curses.Contains(newCurse))
                {
                    newCurse = (LilFrogCurse)possibleCurses.GetValue(UnityEngine.Random.Range(0, possibleCurses.Length));
                }

                curses.Add(newCurse);
            }


            return curses;
        }
    }
}