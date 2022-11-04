using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class DiceInfo
    {
        public int Index { get; set; }
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
    }

    public static class Extensions
    {
        private static Random rnd = new Random();

        public static void Shuffle<T>(this IList<T> values)
        {
            for (int i = values.Count - 1; i > 0; --i)
            {
                int k = rnd.Next(i + 1);
                T val = values[k];
                values[k] = values[i];
                values[i] = val;
            }
        }
    }

    public class RollDice
    {
        private int _face = 0;
        private int _factor = 0;
        private int _numOfRolls = 0;

        public RollDice(int face, int factor, int numOfRolls)
        {
            _face = face;
            _factor = factor;
            _numOfRolls = numOfRolls;
        }

        public List<DiceInfo> RollMyCice()
        {
            if (_numOfRolls == 0)
                return null;

            List<int> lstFaces = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Random rnd = new Random();
            List<DiceInfo> result = new List<DiceInfo>();

            if (_face > 0)
            {
                for (int i = 0; i < _factor; ++i)
                {
                    lstFaces.Add(_face);
                }
            }

            lstFaces.Shuffle();

            for (int i = 1; i <= _numOfRolls; ++i)
            {
                int idx = rnd.Next(1, lstFaces.Count);
                int d1 = lstFaces[idx];

                idx = rnd.Next(1, lstFaces.Count);
                int d2 = lstFaces[idx];

                DiceInfo info = new DiceInfo { Index = i, Dice1 = d1, Dice2 = d2 };
                result.Add(info);
            }

            return result;
        }
    }

}
