using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClearCursesProto.Game
{
    [Serializable]
    public class CurseOrder
    {
        public IReadOnlyCollection<LilFrogCurse> MustHaveCurses { get { return _mustHaveCurses; } }

        [SerializeField]
        private List<LilFrogCurse> _mustHaveCurses;

        public CurseOrder(List<LilFrogCurse> mustHaveCurses)
        {
            _mustHaveCurses = mustHaveCurses;
        }
    }
}