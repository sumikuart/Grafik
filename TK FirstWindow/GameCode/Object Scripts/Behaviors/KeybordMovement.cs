using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_FirstWindow.GameCode.Object_Scripts.Behaviors
{
    internal class KeybordMovement : Behavior
    {
        private float movementSpeed = 1.0f;

        public KeybordMovement(float movementSpeed, GameObject obj, Game window) : base(obj, window) { 
        
        this.movementSpeed = movementSpeed;

        }

        public override void update(FrameEventArgs e)
        {


            throw new NotImplementedException();
        }
    }
}
