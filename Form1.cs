using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace RayTracingApp
{
    public partial class Form1 : Form
    {
        private View view;
        private Vector3 campos = new Vector3(0, 0, -8);
        private Vector3 camView = new Vector3(0, 0, 1);
        private Vector3 camUp = new Vector3(0, 1, 0);
        private Vector3 camSide = new Vector3(1, 0, 0);
        private Vector2 camScale;
        public Form1()
        {
            InitializeComponent();
            view = new View();
            glControl1.Paint += GlControl1_Paint;
            glControl1.Load += GlControl1_Load;
            camScale = new Vector2(1, (float)glControl1.Height / glControl1.Width);
        }

        private void GlControl1_Load(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();
            view.InitShaders();
            view.InitBuffer();
            view.SetupView(glControl1.Width, glControl1.Height);
            view.SetCameraUniforms(campos, camView, camUp, camSide, camScale);

        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            view.Draw();
            glControl1.SwapBuffers();
        }
    }
}