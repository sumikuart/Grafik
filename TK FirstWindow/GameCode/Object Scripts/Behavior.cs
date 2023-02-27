using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_FirstWindow.GameCode.Object_Scripts
{
    public abstract class Behavior
    {
        protected GameObject gameObject;
        protected Game window;

        public Behavior(GameObject obj, Game window) { 
        
            this .gameObject = obj;
            this .window = window;
        }

        public abstract void update(FrameEventArgs e);
    }
}
