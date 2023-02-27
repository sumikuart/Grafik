using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using TK_FirstWindow.GameCode.Object_Scripts;
using TK_FirstWindow.GameCode.ShapeMesh;

namespace TK_FirstWindow.GameCode
{
    public class Game : GameWindow
    {
        public int VertexBufferObject;
        public int VertexArrayObject;
        public int ElementBufferObject;

        public TextureClass wallTex;
        public TextureClass wallArg;
  

        private int sizeX = 0;
        private int sizeY = 0;

        public float RotationDegree = 0;

        private List<GameObject> gameObjects = new List<GameObject>();   

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) {

            sizeX = width;
            sizeY = height;
        }


        //En kode der køre en gang når vinduet laves. 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            wallArg = new TextureClass(@"..\..\GameCode/Assets/AragonTexUdenBaggrund.png");
            wallTex = new TextureClass(@"..\..\GameCode/Assets/wall.jpg");

            Dictionary<string,object> uniforms = new Dictionary<string,object>();

            uniforms.Add("texture0",wallArg);
            uniforms.Add("texture1", wallTex);

            Material mat = new Material(@"..\..\GameCode/Shaders/shader.vert", @"..\..\GameCode/Shaders/shader.frag", uniforms);

            Renderer rendTri = new Renderer(mat,new TriangleMesh());
            Renderer rendCub = new Renderer(mat, new CubeMesh());

            GameObject triangle = new GameObject(rendTri,this);
            GameObject cube = new GameObject(rendCub, this);

            cube.transform.Position = new Vector3(1, 0, 0);

            gameObjects.Add(triangle);
            gameObjects.Add(cube);

            
        }


        //En metode der kaldes når en frame renders
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
             

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60.0f),(float)sizeX / (float)sizeY, 0.3f,1000.0f);

            gameObjects.ForEach(x => x.Draw(view * projection));


            Context.SwapBuffers();
        }


        //Denne kode køre hvert update frame.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState input = Keyboard.GetState();


            gameObjects.ForEach(x => x.Update(e));

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }





   

    }
}
