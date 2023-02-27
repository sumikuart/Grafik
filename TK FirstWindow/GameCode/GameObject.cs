using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_FirstWindow.GameCode.Object_Scripts;

namespace TK_FirstWindow.GameCode
{
    public class GameObject
    {

        public Transform transform;
        public Renderer render;

        private GameWindow gameWindow;

        List<Behavior> behaviors = new List<Behavior>();


        public GameObject(Renderer renderer, GameWindow gameWindow)
        {
            this.render = renderer;
            this.gameWindow = gameWindow;

            transform = new Transform();
        }

        public T GetComponent<T>() where T : Behavior
        {

            foreach(Behavior behavior in behaviors)
            {
                T componentAsT = behavior as T;
                if (componentAsT != null) return componentAsT;
            }

            return null;
        }

        public void AddCOmponent<T>() where T: Behavior
        {
            behaviors.Add(Activator.CreateInstance(typeof(T),this,gameWindow) as T);
        }


        public void Update(FrameEventArgs args)
        {

        }

        public void Draw(Matrix4 vp)
        {
            render.Draw(transform.CalculateModel() * vp); 
        }

    }
}
