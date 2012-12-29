using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle_Jump.Doodler
{
    public class Shot
    {
        private float x;
        private float y;
        private float speed = 15.0f;
        public Shot(float _coordX, float _coordY)
        {
            x = _coordX;
            y = _coordY;
        }

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
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

    }
}
