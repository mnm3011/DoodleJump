using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle_Jump.Map
{
    public class ObjectInMap
    {
        private float x;
        private float y;
        private uint type;
        private bool leftFlag;

        public float CoordX
        {
            get { return x; }
            set { x = value; }
        }

        public float CoordY
        {
            get { return y; }
            set { y = value; }
        }

        public uint Type
        {
            get { return type; }
            set { type = value; }
        }
        public bool LeftFlag
        {
            get { return leftFlag; }
            set { leftFlag = value; }
        }
    }
}
