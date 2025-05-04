using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace RayTracingApp
{
    public class View
    {
        private int BasicProgramID;
        private int vbo_position;
        private Vector3[] vertdata;
        private int uCameraPositionLoc;
        private int uCameraViewLoc;
        private int uCameraUpLoc;
        private int uCameraSideLoc;
        private int uCameraScaleLoc;

        public void SetCameraUniforms(Vector3 position, Vector3 view, Vector3 up, Vector3 side, Vector2 scale)
        {
            GL.Uniform3(uCameraPositionLoc, position);
            GL.Uniform3(uCameraViewLoc, view);
            GL.Uniform3(uCameraUpLoc, up);
            GL.Uniform3(uCameraSideLoc, side);
            GL.Uniform2(uCameraScaleLoc, scale);
        }

        public void SetupView(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1, 1, -1, 1, -1, 1); // Пример ортографической проекции
            GL.Viewport(0, 0, width, height);
        }

        public void InitShaders()
        {
            BasicProgramID = GL.CreateProgram();
            LoadShader("raytracing.vert", ShaderType.VertexShader, BasicProgramID, out uint vertexShader);
            LoadShader("raytracing.frag", ShaderType.FragmentShader, BasicProgramID, out uint fragmentShader);
            GL.LinkProgram(BasicProgramID);
            GL.UseProgram(BasicProgramID);
                    uCameraPositionLoc = GL.GetUniformLocation(BasicProgramID, "uCamera.Position");
        uCameraViewLoc = GL.GetUniformLocation(BasicProgramID, "uCamera.View");
        uCameraUpLoc = GL.GetUniformLocation(BasicProgramID, "uCamera.Up");
        uCameraSideLoc = GL.GetUniformLocation(BasicProgramID, "uCamera.Side");
        uCameraScaleLoc = GL.GetUniformLocation(BasicProgramID, "uCamera.Scale");
        }

        private void LoadShader(string filename, ShaderType type, int program, out uint shader)
        {
            shader = (uint)GL.CreateShader(type);
            using (var sr = new StreamReader(filename))
            {
                GL.ShaderSource((int)shader, sr.ReadToEnd());
            }
            GL.CompileShader((int)shader);
            GL.AttachShader(program, (int)shader);
        }

        public void InitBuffer()
        {
            vertdata = new Vector3[]
            {
                new Vector3(-1f, -1f, 0f),
                new Vector3(1f, -1f, 0f),
                new Vector3(1f, 1f, 0f),
                new Vector3(-1f, 1f, 0f)
            };

            GL.GenBuffers(1, out vbo_position);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
            GL.BufferData(BufferTarget.ArrayBuffer, vertdata.Length * Vector3.SizeInBytes, vertdata, BufferUsageHint.StaticDraw);
        }

        public void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);
            GL.DisableVertexAttribArray(0);
        }
    }
}