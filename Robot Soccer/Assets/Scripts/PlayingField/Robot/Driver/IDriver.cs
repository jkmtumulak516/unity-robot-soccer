using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PlayingField.Robot.Driver
{
    interface IDriver
    {
        void Process(float destX, float destY);
    }
}
