using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle_Jump.Map
{
    public class PanelInMap : ObjectInMap
    {
        public PanelInMap(float _coordX, float _coordY, uint _type, bool _leftFlag)
        {
            CoordX = _coordX;
            CoordY = _coordY;
            Type = _type;
            LeftFlag = _leftFlag;

        }
    }
}
