using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle_Jump.Map
{

    public class BonusInMap : ObjectInMap
    {
        private uint BonusJump = 0;   //если игрок прыгает на бонус, то этой переменное присваивается значение 10
        private int Height;
        private int Width;
        public BonusInMap(float _coordX, float _coordY, uint _type, bool _leftFlag)
        {
            if ((_type == 0) || (_type == 1))
            {
                CoordX = _coordX;
                CoordY = _coordY;
                Type = _type;
                LeftFlag = _leftFlag;
                height = 14;
                width = 17;
            }

            if ((_type == 2) || (_type == 3))
            {
                CoordX = _coordX;
                CoordY = _coordY;
                Type = _type;
                LeftFlag = _leftFlag;
                height = 22;
                width = 56;
            }
            if ((_type == 4))
            {
                CoordX = _coordX;
                CoordY = _coordY;
                Type = _type;
                LeftFlag = _leftFlag;
                height = 20;
                width = 32;
            }


        }

        public uint bonusJump
        {
            get { return BonusJump; }
            set { BonusJump = value; }
        }
        public int height
        {
            get { return Height; }
            set { Height = value; }
        }
        public int width
        {
            get { return Width; }
            set { Width = value; }
        }
    }
}
