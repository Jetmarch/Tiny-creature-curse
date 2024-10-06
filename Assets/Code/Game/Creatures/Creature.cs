using RotaryHeart.Lib.SerializableDictionary;
using System.Collections.Generic;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class Creature : MonoBehaviour
    {
        public int MinCountOfCurses { get { return _minCountOfCurses; } }
        public int MaxCountOfCurses { get { return _maxCountOfCurses; } }

        [SerializeField]
        private int _minCountOfCurses = 1;
        [SerializeField]
        private int _maxCountOfCurses = 3;
        public List<LilFrogCurse> ActiveCurses { get { return _activeCurses; } }

        [SerializeField]
        private List<LilFrogCurse> _activeCurses;

        [SerializeField]
        private SerializableDictionaryBase<LilFrogCurse, GameObject> _curseAttribute;

        public void AddCurse(LilFrogCurse curse)
        {
            if(_activeCurses.Contains(curse))
            {
                return;
            }

            _activeCurses.Add(curse);
            
        }

        public void RemoveCurse(LilFrogCurse curse)
        {
            if(!_activeCurses.Contains(curse))
            {
                return;
            }

            _activeCurses.Remove(curse);
        }


        [ContextMenu("Update curses")]
        public void UpdateCurses()
        {
            foreach (var curseAttr in _curseAttribute.Values)
            {
                if(curseAttr == null)
                {
                    continue;
                }

                curseAttr.SetActive(false);
            }

            foreach(var curse in _activeCurses)
            {
                var go = _curseAttribute[curse];
                if (go == null)
                {
                    throw new System.Exception($"Game object for curse attribute {curse} is null!");
                }

                go.SetActive(true);
            }
        }
    }
}