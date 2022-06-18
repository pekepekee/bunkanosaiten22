using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class ScoreBasic : Score
    {
        private int baseValue;
        private int count;

        public ScoreBasic(int baseValue)
        {
            this.baseValue = baseValue;
        }

        public override int GetValue()
        {
            return baseValue * count;
        }

        public void AddCount(int value)
        {
            count += value;
        }
    }
}
