using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WinAppProyecto2
{
    public enum TransformMode { None, Grab, Rotate, Scale }
    public enum AxisConstraint { None, X, Y, Z }

    public partial class MainForm : Form
    {
        private GLControl glMain;
        private GLControl glPreview;

        private List<GameObject> objects = new List<GameObject>();
        private GameObject selectedObject = null;

        private ShapeType previewType = ShapeType.Cube;

        private bool isUpdatingUI = false;

        private Vector3 camTarget = Vector3.Zero;
        private float camDist = 20f;
        private float camYaw = -MathHelper.PiOver4;
        private float camPitch = 0.5f;
        private Point lastMousePos;
        private bool isMouseDrag = false;

        private TransformMode currentMode = TransformMode.None;
        private AxisConstraint axisConstraint = AxisConstraint.None;
        private Matrix4 matView = Matrix4.Identity;
        private Matrix4 matProj = Matrix4.Identity;

        public MainForm()
        {
            InitializeComponent();
            InitializeGLControls();

            var light = new GameObject("Sun", ShapeType.Light);
            light.Position = new Vector3(10, 10, 20);
            objects.Add(light);
            lstObjects.Items.Add(light.Name);

            SetupLogicEvents();
            SetupKeyboardShortcuts();
            UpdateStatusLabel();

            Timer t = new Timer { Interval = 16 };
            t.Tick += (s, e) => {
                if (glMain != null && !glMain.IsDisposed && glMain.Visible) glMain.Invalidate();
                if (glPreview != null && !glPreview.IsDisposed && glPreview.Visible) glPreview.Invalidate();
            };
            t.Start();
        }

        private void InitializeGLControls()
        {
            glMain = new GLControl(new GraphicsMode(32, 24, 0, 8));
            glMain.Dock = DockStyle.Fill;
            glMain.BackColor = Color.FromArgb(20, 20, 20);
            glMain.VSync = true;
            splitContainer1.Panel2.Controls.Add(glMain);

            glMain.Load += (s, e) => SetupGL(glMain);
            glMain.Paint += GlMain_Paint;
            glMain.Resize += (s, e) => { if (glMain.ClientSize.Width > 0) glMain.Invalidate(); };
            glMain.MouseDown += GlMain_MouseDown;
            glMain.MouseMove += GlMain_MouseMove;
            glMain.MouseUp += (s, e) => isMouseDrag = false;
            glMain.MouseWheel += GlMain_MouseWheel;

            glPreview = new GLControl(new GraphicsMode(32, 24, 0, 8));
            glPreview.Dock = DockStyle.Fill;
            glPreview.BackColor = Color.FromArgb(30, 30, 30);
            pnlPreviewContainer.Controls.Add(glPreview);

            glPreview.Load += (s, e) => SetupGL(glPreview);
            glPreview.Paint += GlPreview_Paint;
            glPreview.Resize += (s, e) => glPreview.Invalidate();
        }

        private void SetupGL(GLControl control)
        {
            if (control.InvokeRequired) return;
            control.MakeCurrent();
            GL.ClearColor(control.BackColor);
            GL.Enable(EnableCap.DepthTest);

            // CORRECCIÓN: HABILITAR CULL FACE PARA QUE SEAN SÓLIDOS
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            GL.ShadeModel(ShadingModel.Smooth);
        }

        private void GlMain_Paint(object sender, PaintEventArgs e)
        {
            if (!glMain.Context.IsCurrent) glMain.MakeCurrent();
            GL.Viewport(0, 0, glMain.Width, glMain.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            float aspect = (float)glMain.Width / Math.Max(1, glMain.Height);
            matProj = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), aspect, 0.1f, 1000f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref matProj);

            float z = camDist * (float)Math.Sin(camPitch);
            float hDist = camDist * (float)Math.Cos(camPitch);
            float x = hDist * (float)Math.Cos(camYaw);
            float y = hDist * (float)Math.Sin(camYaw);

            Vector3 camPos = new Vector3(x, y, z) + camTarget;
            matView = Matrix4.LookAt(camPos, camTarget, Vector3.UnitZ);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref matView);

            MeshRenderer.SetupLights(objects);
            MeshRenderer.DrawGrid(20);

            foreach (var obj in objects)
            {
                MeshRenderer.RenderObject(obj);
            }

            glMain.SwapBuffers();
        }

        private void GlPreview_Paint(object sender, PaintEventArgs e)
        {
            glPreview.MakeCurrent();
            GL.Viewport(0, 0, glPreview.Width, glPreview.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            float aspect = (float)glPreview.Width / Math.Max(1, glPreview.Height);
            Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), aspect, 0.1f, 100f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref proj);

            Matrix4 view = Matrix4.LookAt(new Vector3(4f, -4f, 4f), Vector3.Zero, Vector3.UnitZ);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref view);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.LightModel(LightModelParameter.LightModelAmbient, new float[] { 0.6f, 0.6f, 0.6f, 1.0f });

            GL.Enable(EnableCap.Light0);
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 5, -5, 10, 1 });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 0.8f, 0.8f, 0.8f, 1 });

            GameObject temp = new GameObject("preview", previewType);
            temp.Rotation = Vector3.Zero;
            temp.Scale = new Vector3(1.2f, 1.2f, 1.2f);
            temp.ObjectColor = Color.CornflowerBlue;
            // OPACIDAD SOLICITADA 0.75
            temp.Opacity = 0.75f;

            if (previewType == ShapeType.Light)
            {
                temp.ObjectColor = Color.Yellow;
                temp.Scale = new Vector3(2f, 2f, 2f);
                temp.Opacity = 1.0f; // La luz mejor sólida
            }
            MeshRenderer.RenderObject(temp);

            glPreview.SwapBuffers();
        }

        private void GlMain_MouseDown(object sender, MouseEventArgs e)
        {
            lastMousePos = e.Location;
            isMouseDrag = true;

            if (e.Button == MouseButtons.Left && currentMode == TransformMode.None)
                PerformPicking(e.X, e.Y, Control.ModifierKeys == Keys.Shift);
            if (e.Button == MouseButtons.Left && currentMode != TransformMode.None)
                ConfirmTransform();
            if (e.Button == MouseButtons.Right && currentMode != TransformMode.None)
                CancelTransform();
        }

        private void GlMain_MouseMove(object sender, MouseEventArgs e)
        {
            float deltaX = e.X - lastMousePos.X;
            float deltaY = e.Y - lastMousePos.Y;

            if (isMouseDrag)
            {
                if (e.Button == MouseButtons.Middle && Control.ModifierKeys == Keys.None)
                {
                    camYaw += deltaX * 0.01f;
                    camPitch -= deltaY * 0.01f;
                    camPitch = MathHelper.Clamp(camPitch, -MathHelper.PiOver2 + 0.01f, MathHelper.PiOver2 - 0.01f);
                }
                else if (e.Button == MouseButtons.Middle && Control.ModifierKeys == Keys.Shift)
                {
                    Vector3 forward = (camTarget - GetCameraPos()).Normalized();
                    Vector3 right = Vector3.Cross(forward, Vector3.UnitZ).Normalized();
                    Vector3 upReal = Vector3.Cross(right, forward).Normalized();
                    camTarget -= right * (deltaX * 0.05f);
                    camTarget += upReal * (deltaY * 0.05f);
                }
            }

            if (currentMode != TransformMode.None && selectedObject != null)
                ApplyTransformLogic(deltaX, deltaY);

            lastMousePos = e.Location;
        }

        private void GlMain_MouseWheel(object sender, MouseEventArgs e)
        {
            camDist -= e.Delta * 0.02f;
            camDist = Math.Max(1.0f, camDist);
        }

        private void ApplyTransformLogic(float dx, float dy)
        {
            float sensitivity = 0.05f;
            if (Control.ModifierKeys == Keys.Shift) sensitivity = 0.005f;
            float val = (dx + -dy) * sensitivity;

            if (currentMode == TransformMode.Grab)
            {
                Vector3 moveDir = Vector3.Zero;
                if (axisConstraint == AxisConstraint.None)
                {
                    Vector3 forward = (camTarget - GetCameraPos()).Normalized();
                    Vector3 right = Vector3.Cross(forward, Vector3.UnitZ).Normalized();
                    Vector3 up = Vector3.Cross(right, forward).Normalized();
                    moveDir = right * dx * 0.05f + up * -dy * 0.05f;
                }
                else
                {
                    if (axisConstraint == AxisConstraint.X) moveDir = new Vector3(val, 0, 0);
                    if (axisConstraint == AxisConstraint.Y) moveDir = new Vector3(0, val, 0);
                    if (axisConstraint == AxisConstraint.Z) moveDir = new Vector3(0, 0, val);
                }
                selectedObject.Position += moveDir;
            }
            else if (currentMode == TransformMode.Rotate)
            {
                float rotVal = val * 50.0f;
                if (axisConstraint == AxisConstraint.None)
                    selectedObject.Rotation += new Vector3(0, 0, -dx);
                else
                {
                    if (axisConstraint == AxisConstraint.X) selectedObject.Rotation += new Vector3(rotVal, 0, 0);
                    if (axisConstraint == AxisConstraint.Y) selectedObject.Rotation += new Vector3(0, rotVal, 0);
                    if (axisConstraint == AxisConstraint.Z) selectedObject.Rotation += new Vector3(0, 0, rotVal);
                }
            }
            else if (currentMode == TransformMode.Scale)
            {
                float scaleVal = val;
                Vector3 s = selectedObject.Scale;
                if (axisConstraint == AxisConstraint.None) s += new Vector3(scaleVal);
                else if (axisConstraint == AxisConstraint.X) s.X += scaleVal;
                else if (axisConstraint == AxisConstraint.Y) s.Y += scaleVal;
                else if (axisConstraint == AxisConstraint.Z) s.Z += scaleVal;

                if (s.X < 0.01f) s.X = 0.01f;
                if (s.Y < 0.01f) s.Y = 0.01f;
                if (s.Z < 0.01f) s.Z = 0.01f;
                selectedObject.Scale = s;
            }
            UpdateUIFromObject();
        }

        private Vector3 GetCameraPos()
        {
            float z = camDist * (float)Math.Sin(camPitch);
            float hDist = camDist * (float)Math.Cos(camPitch);
            float x = hDist * (float)Math.Cos(camYaw);
            float y = hDist * (float)Math.Sin(camYaw);
            return new Vector3(x, y, z) + camTarget;
        }

        private void PerformPicking(int mouseX, int mouseY, bool multiSelect)
        {
            if (glMain.Width == 0 || glMain.Height == 0) return;
            if (!multiSelect) { foreach (var o in objects) o.IsSelected = false; selectedObject = null; }

            Vector3 near = MeshRenderer.GetWorldPoint(mouseX, mouseY, 0.0f, glMain.Width, glMain.Height, matView, matProj);
            Vector3 far = MeshRenderer.GetWorldPoint(mouseX, mouseY, 1.0f, glMain.Width, glMain.Height, matView, matProj);
            Vector3 dir = (far - near).Normalized();

            GameObject closest = null;
            float minDistance = float.MaxValue;

            foreach (var obj in objects)
            {
                Vector3 oc = obj.Position - near;
                float t = Vector3.Dot(oc, dir);
                Vector3 closestPointOnLine = near + dir * t;
                float distToCenter = (obj.Position - closestPointOnLine).Length;

                if (distToCenter < obj.GetBoundingRadius())
                {
                    float distToCam = (obj.Position - near).Length;
                    if (distToCam < minDistance) { minDistance = distToCam; closest = obj; }
                }
            }

            if (closest != null) SelectObject(closest);
            else if (!multiSelect) { lstObjects.ClearSelected(); selectedObject = null; UpdateUIFromObject(); }
            glMain.Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (glMain.Focused || this.Focused || glMain.ContainsFocus)
            {
                switch (keyData)
                {
                    case Keys.G: StartTransform(TransformMode.Grab); return true;
                    case Keys.R: StartTransform(TransformMode.Rotate); return true;
                    case Keys.S: StartTransform(TransformMode.Scale); return true;
                    case Keys.X: SetAxis(AxisConstraint.X); return true;
                    case Keys.Y: SetAxis(AxisConstraint.Y); return true;
                    case Keys.Z: SetAxis(AxisConstraint.Z); return true;
                    case Keys.Escape: CancelTransform(); return true;
                    case Keys.Enter: ConfirmTransform(); return true;
                    case Keys.Delete: DeleteSelected(); return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void StartTransform(TransformMode mode)
        {
            if (selectedObject == null) return;
            currentMode = mode;
            selectedObject.BackupTransform();

            // Todos los modos (G, R, S) inician en Eje X
            if (mode == TransformMode.Grab || mode == TransformMode.Scale || mode == TransformMode.Rotate)
                axisConstraint = AxisConstraint.X;
            else
                axisConstraint = AxisConstraint.None;

            UpdateStatusLabel();
        }

        private void SetAxis(AxisConstraint axis)
        {
            if (currentMode == TransformMode.None) return;
            if (axisConstraint == axis) axisConstraint = AxisConstraint.None;
            else axisConstraint = axis;
            selectedObject.RestoreTransform();
            UpdateStatusLabel();
        }

        private void ConfirmTransform() { currentMode = TransformMode.None; axisConstraint = AxisConstraint.None; UpdateStatusLabel(); }

        private void CancelTransform()
        {
            if (currentMode != TransformMode.None && selectedObject != null)
            {
                selectedObject.RestoreTransform();
                UpdateUIFromObject();
            }
            currentMode = TransformMode.None;
            axisConstraint = AxisConstraint.None;
            UpdateStatusLabel();
            glMain.Invalidate();
        }

        private void DeleteSelected()
        {
            if (selectedObject == null) return;
            objects.Remove(selectedObject);
            lstObjects.Items.Remove(selectedObject.Name);
            selectedObject = null;
            lstObjects.ClearSelected();
            UpdateUIFromObject();
            glMain.Invalidate();
        }

        private void UpdateStatusLabel()
        {
            if (currentMode == TransformMode.None)
            {
                lblStatusAction.BackColor = Color.Transparent;
                lblStatusAction.ForeColor = Color.White;
                lblStatusAction.Text = "LISTO";
                lblStatusHelp.Text = "MOVER: Click Medio (Orbitar), Shift+Medio (Panear) | SELECCION: Click Izq | ACCIONES: [G] Mover, [R] Rotar, [S] Escalar, [Supr] Borrar";
            }
            else
            {
                lblStatusAction.BackColor = Color.OrangeRed;
                lblStatusAction.ForeColor = Color.Yellow;

                string modeStr = "";
                if (currentMode == TransformMode.Grab) modeStr = "MOVIENDO";
                if (currentMode == TransformMode.Rotate) modeStr = "ROTANDO";
                if (currentMode == TransformMode.Scale) modeStr = "ESCALANDO";

                string axisStr = axisConstraint == AxisConstraint.None ? "LIBRE (VISTA)" : "EJE " + axisConstraint.ToString();

                lblStatusAction.Text = $"{modeStr} [{axisStr}]";
                lblStatusHelp.Text = $"CAMBIAR EJE: [X] [Y] [Z] (Pulsa de nuevo para liberar) | CONFIRMAR: Click Izq / Enter | CANCELAR: Click Der / Esc";
            }
        }

        private void SetupLogicEvents()
        {
            btnPreCube.Click += (s, e) => SetPreview(ShapeType.Cube, "Cubo");
            btnPreSphere.Click += (s, e) => SetPreview(ShapeType.Sphere, "Esfera");
            btnPrePyramid.Click += (s, e) => SetPreview(ShapeType.Pyramid, "Pirámide");
            btnPreCylinder.Click += (s, e) => SetPreview(ShapeType.Cylinder, "Cilindro");
            btnPreCone.Click += (s, e) => SetPreview(ShapeType.Cone, "Cono");
            btnPreLight.Click += (s, e) => SetPreview(ShapeType.Light, "Luz");

            btnAddToScene.Click += (s, e) => {
                string name = previewType == ShapeType.Light ? $"Light_{objects.Count}" : $"{previewType}_{objects.Count}";
                var obj = new GameObject(name, previewType);
                if (previewType == ShapeType.Light) obj.Position = new Vector3(0, 0, 5);
                objects.Add(obj);
                lstObjects.Items.Add(obj.Name);
                SelectObject(obj);
            };

            btnDelete.Click += (s, e) => DeleteSelected();

            lstObjects.SelectedIndexChanged += (s, e) => {
                if (lstObjects.SelectedIndex < 0) return;
                string name = lstObjects.SelectedItem.ToString();
                var obj = objects.Find(x => x.Name == name);
                if (obj != null) SelectObject(obj);
            };

            EventHandler updateTrans = (s, e) => {
                if (selectedObject == null || isUpdatingUI) return;
                selectedObject.Position = new Vector3((float)numPosX.Value, (float)numPosY.Value, (float)numPosZ.Value);
                selectedObject.Rotation = new Vector3((float)numRotX.Value, (float)numRotY.Value, (float)numRotZ.Value);
                selectedObject.Scale = new Vector3((float)numSclX.Value, (float)numSclY.Value, (float)numSclZ.Value);
                glMain.Invalidate();
            };

            var nums = new[] { numPosX, numPosY, numPosZ, numRotX, numRotY, numRotZ, numSclX, numSclY, numSclZ };
            foreach (var n in nums) n.ValueChanged += updateTrans;

            // Luz
            EventHandler updateLight = (s, e) => {
                if (selectedObject == null || isUpdatingUI || selectedObject.Type != ShapeType.Light) return;
                selectedObject.LightIntensity = (float)numLightInt.Value;
                selectedObject.LightRange = (float)numLightRange.Value;
                glMain.Invalidate();
            };
            numLightInt.ValueChanged += updateLight;
            numLightRange.ValueChanged += updateLight;

            btnLightColorProp.Click += (s, e) => {
                if (selectedObject == null || selectedObject.Type != ShapeType.Light) return;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedObject.ObjectColor = colorDialog1.Color;
                    btnLightColorProp.BackColor = colorDialog1.Color;
                    glMain.Invalidate();
                }
            };

            // Material
            btnColorPick.Click += (s, e) => {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    btnColorPick.BackColor = colorDialog1.Color;
                    if (selectedObject != null)
                    {
                        selectedObject.ObjectColor = colorDialog1.Color;
                        glMain.Invalidate();
                    }
                }
            };
            trkRoughness.Scroll += (s, e) => { if (selectedObject != null) selectedObject.Shininess = trkRoughness.Value; };
            trkSpecular.Scroll += (s, e) => { if (selectedObject != null) selectedObject.SpecularStrength = trkSpecular.Value / 100.0f; };
            trkOpacity.Scroll += (s, e) => { if (selectedObject != null) selectedObject.Opacity = trkOpacity.Value / 100.0f; };
        }

        private void SelectObject(GameObject obj)
        {
            if (Control.ModifierKeys != Keys.Shift) foreach (var o in objects) o.IsSelected = false;
            obj.IsSelected = true;
            selectedObject = obj;
            for (int i = 0; i < lstObjects.Items.Count; i++) if (lstObjects.Items[i].ToString() == obj.Name) lstObjects.SelectedIndex = i;
            UpdateUIFromObject();
            glMain.Invalidate();
        }

        private void SetupKeyboardShortcuts() { this.KeyPreview = true; }
        private void SetPreview(ShapeType type, string title) { previewType = type; lblPreviewTitle.Text = "Vista Previa: " + title; glPreview.Invalidate(); }

        private void UpdateUIFromObject()
        {
            if (selectedObject == null) return;

            isUpdatingUI = true;

            numPosX.Value = (decimal)selectedObject.Position.X;
            numPosY.Value = (decimal)selectedObject.Position.Y;
            numPosZ.Value = (decimal)selectedObject.Position.Z;
            numRotX.Value = (decimal)selectedObject.Rotation.X;
            numRotY.Value = (decimal)selectedObject.Rotation.Y;
            numRotZ.Value = (decimal)selectedObject.Rotation.Z;
            numSclX.Value = (decimal)selectedObject.Scale.X;
            numSclY.Value = (decimal)selectedObject.Scale.Y;
            numSclZ.Value = (decimal)selectedObject.Scale.Z;

            // Configurar UI según tipo
            if (selectedObject.Type == ShapeType.Light)
            {
                grpMaterial.Visible = false;
                grpLightProps.Visible = true;

                numLightInt.Value = (decimal)selectedObject.LightIntensity;
                numLightRange.Value = (decimal)selectedObject.LightRange;
                btnLightColorProp.BackColor = selectedObject.ObjectColor;
            }
            else
            {
                grpMaterial.Visible = true;
                grpLightProps.Visible = false;

                btnColorPick.BackColor = selectedObject.ObjectColor;
                trkRoughness.Value = (int)Math.Min(100, Math.Max(0, selectedObject.Shininess));
                trkSpecular.Value = (int)Math.Min(100, Math.Max(0, selectedObject.SpecularStrength * 100));
                trkOpacity.Value = (int)Math.Min(100, Math.Max(0, selectedObject.Opacity * 100));
            }

            if (tabMenu.SelectedTab != tabProperties && tabMenu.SelectedTab != tabList)
                tabMenu.SelectedTab = tabProperties;

            isUpdatingUI = false;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}