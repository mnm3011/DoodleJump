using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle_Jump.Map
{
    public class MonsterInMap : ObjectInMap
    {
        private uint armor = 0;
        private int height = 0;
        private int width = 0;
        private uint pEvent = 0;

        public MonsterInMap(float _coordX, float _coordY, uint _type, bool _leftFlag)
        {

            if (_type == 1)
            {
                LeftFlag = _leftFlag;
                armor = 5;
                width = 104;
                height = 64;
                CoordX = _coordX;
                CoordY = _coordY;
                Type = _type;
            }
            if (_type == 2)
            {
                LeftFlag = _leftFlag;
                armor = 1;
                width = 58;
                height = 50;
                CoordX = _coordX;
                CoordY = _coordY;
                Type = _type;
            }
            if (_type == 3)
            {
                LeftFlag = _leftFlag;
                armor = 1;
                width = 38;
                height = 50;
                CoordX = _coordX;
                CoordY = _coordY;
                Type = _type;
            }
            if (_type == 4)
            {
                LeftFlag = _leftFlag;
                armor = 999;
                width = 74;
                height = 64;
                CoordX = _coordX;
                CoordY = _coordY;
                Type = _type;
            }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        
        public uint Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public uint PEvent
        {
            get { return pEvent; }
            set { pEvent = value; }
        }
    }
}
