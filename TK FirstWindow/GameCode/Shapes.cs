using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_FirstWindow.GameCode
{
    internal class Shapes
    {
        public float[] TVertices = {
                            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
                            0.5f, -0.5f, 0.0f, //Bottom-right vertex
                            0.0f,  0.5f, 0.0f  //Top vertex
        };

        // index 0 - 2 Position. 3-5 farver.
        public float[] SVertices = {
                            0.2f,  0.2f, 0.0f, 1.0f, 0.0f, 0.0f, // top right
                            0.2f, -0.2f, 0.0f, 0.0f, 1.0f, 0.0f, // bottom right
                            -0.2f, -0.2f, 0.0f,0.0f, 0.0f, 1.0f,  // bottom left
                            -0.2f,  0.2f, 0.0f, 0.0f, 0.0f, 0.0f // top left
        };

        // index 0 - 2 Position. 3-2 Uv.
        public float[] AVertices = {
                            0.5f,  0.5f, 0.0f, 1.0f, 1.0f, // top right
                            0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // bottom right
                            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f,  // bottom left
                            -0.5f,  0.5f, 0.0f, 0.0f, 1.0f // top left
        };

        public uint[] indices = {  // note that we start from 0!
                         0, 1, 3,   // first triangle
                         1, 2, 3    // second triangle
                         };


        public float[] GetShape(int id)
        {
            switch (id)
            {
                case 0:
                    return TVertices;
                     

                case 1:
                    return SVertices;

                case 2:
                    return AVertices;

            }

            return null;
        }
    }
}
