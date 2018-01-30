using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace MGEx.Common
{
    public class Cube
    {
        private const float Radius = 10.0f;

        private static readonly Vector3[] vertexPositions =
        {
            // Front
            new Vector3(-Radius, -Radius, Radius),
            new Vector3(Radius, -Radius, Radius),
            new Vector3(Radius, Radius, Radius),
            new Vector3(-Radius, Radius, Radius), 
            // Back
            new Vector3(-Radius, -Radius, -Radius),
            new Vector3(Radius, -Radius, -Radius),
            new Vector3(Radius, Radius, -Radius),
            new Vector3(-Radius, Radius, -Radius),
        };
        private static readonly short[] indices =
        {
            // front
            0, 1, 2,
            2, 3, 0,
            // top
            1, 5, 6,
            6, 2, 1,
            // back
            7, 6, 5,
            5, 4, 7,
            // bottom
            4, 0, 3,
            3, 7, 4,
            // left
            4, 5, 1,
            1, 0, 4,
            // right
            3, 2, 6,
            6, 7, 3,
        };

        private readonly VertexBuffer vertexBuffer;
        private readonly IndexBuffer indexBuffer;
        private readonly Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
        private readonly Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 1000f);

        private float angle = 0.0f;

        public Cube(GraphicsDevice graphicsDevice) : this(graphicsDevice, Color.White)
        {
        }

        public Cube(GraphicsDevice graphicsDevice, Color color)
        {
            VertexPositionColorNormal[] vertices = vertexPositions
                .Select(position => new VertexPositionColorNormal(position, color))
                .ToArray();
            VertexPositionColorNormal.CalculateNormals(vertices, indices);

            vertexBuffer = new VertexBuffer(graphicsDevice, VertexPositionColorNormal.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(vertices);
            indexBuffer = new IndexBuffer(graphicsDevice, typeof(short), indices.Length, BufferUsage.WriteOnly);
            indexBuffer.SetData(indices);
        }

        public void Update(GameTime gameTime)
        {
            angle += gameTime.ElapsedGameTime.Milliseconds * 0.001f;
        }

        public void Draw(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            graphicsDevice.SetVertexBuffer(vertexBuffer);
            graphicsDevice.Indices = indexBuffer;

            var cameraPosition = Vector3.Transform(new Vector3(100, 25, 0), Matrix.CreateRotationY(angle));
            effect.View = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 0), Vector3.UnitY);
            effect.World = world;
            effect.Projection = projection;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, indexBuffer.IndexCount / 3);
            }
        }
    }
}
