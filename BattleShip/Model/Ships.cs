using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Ships
    {
        public Ships()
        {
            OneEngine = new List<bool[]>(4);
            TwoEngine = new List<bool[]>(3);
            ThreeEngine = new List<bool[]>(2);
            FourEngine = new List<bool[]>(1);
        }

        public List<bool[]> OneEngine;
        public List<bool[]> TwoEngine;
        public List<bool[]> ThreeEngine;
        public List<bool[]> FourEngine; 

    }
}
