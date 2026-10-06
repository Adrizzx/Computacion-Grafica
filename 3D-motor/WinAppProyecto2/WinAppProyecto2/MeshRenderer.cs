using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace WinAppProyecto2
{
    public static class MeshRenderer
    {
        public static void SetupLights(List<GameObject> objects)
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Enable(EnableCap.Normalize);

            // Transparencia
            GL.Enable(EnableCap.Blend);
            // CORRECCIÓN: Usar 'BlendingFactor' en lugar de Src/Dest específicos
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            int lightIndex = 0;
            for (int i = 0; i < objects.Count && lightIndex < 8; i++)
            {
                if (objects[i].Type == ShapeType.Light)
                {
                    SetupSingleLight(LightName.Light0 + lightIndex, objects[i]);
                    lightIndex++;
                }
            }

            for (int i = lightIndex; i < 8; i++)
            {
                GL.Disable((EnableCap)((int)(LightName.Light0 + i)));
            }

            if (lightIndex == 0)
                GL.LightModel(LightModelParameter.LightModelAmbient, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
            else
                GL.LightModel(LightModelParameter.LightModelAmbient, new float[] { 0.1f, 0.1f, 0.1f, 1.0f });
        }

        private static void SetupSingleLight(LightName name, GameObject lightObj)
        {
            GL.Enable((EnableCap)((int)name));

            float r = lightObj.ObjectColor.R / 255f;
            float g = lightObj.ObjectColor.G / 255f;
            float b = lightObj.ObjectColor.B / 255f;
            float intensity = lightObj.LightIntensity;

            float[] position = { lightObj.Position.X, lightObj.Position.Y, lightObj.Position.Z, 1.0f };
            float[] ambient = { r * 0.1f * intensity, g * 0.1f * intensity, b * 0.1f * intensity, 1.0f };
            float[] diffuse = { r * 0.8f * intensity, g * 0.8f * intensity, b * 0.8f * intensity, 1.0f };
            float[] specular = { r * intensity, g * intensity, b * intensity, 1.0f };

            GL.Light(name, LightParameter.Position, position);
            GL.Light(name, LightParameter.Ambient, ambient);
            GL.Light(name, LightParameter.Diffuse, diffuse);
            GL.Light(name, LightParameter.Specular, specular);

            float range = Math.Max(0.1f, lightObj.LightRange);
            GL.Light(name, LightParameter.ConstantAttenuation, 1.0f);
            GL.Light(name, LightParameter.LinearAttenuation, 0.05f / (range / 10f));
            GL.Light(name, LightParameter.QuadraticAttenuation, 0.0f);
        }

        public static void RenderObject(GameObject obj)
        {
            GL.PushMatrix();
            GL.Translate(obj.Position);

            GL.Rotate(obj.Rotation.Z, 0.0f, 0.0f, 1.0f);
            GL.Rotate(obj.Rotation.Y, 0.0f, 1.0f, 0.0f);
            GL.Rotate(obj.Rotation.X, 1.0f, 0.0f, 0.0f);

            GL.Scale(obj.Scale);

            if (obj.Type == ShapeType.Light)
            {
                GL.Disable(EnableCap.Lighting);
                GL.Color3(obj.ObjectColor);
                DrawDiamond();
                if (obj.IsSelected)
                {
                    GL.Scale(1.2f, 1.2f, 1.2f);
                    GL.Color3(Color.Orange);
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                    DrawDiamond();
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                }
                GL.Enable(EnableCap.Lighting);
                GL.PopMatrix();
                return;
            }

            float[] matSpecular = { obj.SpecularStrength, obj.SpecularStrength, obj.SpecularStrength, 1.0f };
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, matSpecular);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, obj.Shininess);

            // Usar Alpha para opacidad
            GL.Color4(obj.ObjectColor.R, obj.ObjectColor.G, obj.ObjectColor.B, (byte)(obj.Opacity * 255));

            if (obj.Opacity < 1.0f)
            {
                GL.Disable(EnableCap.CullFace);
                GL.DepthMask(false);
            }
            else
            {
                GL.Enable(EnableCap.CullFace);
                GL.DepthMask(true);
            }

            DrawGeometry(obj.Type);

            GL.Enable(EnableCap.CullFace);
            GL.DepthMask(true);

            if (obj.IsSelected)
            {
                GL.Disable(EnableCap.Lighting);
                GL.Disable(EnableCap.DepthTest);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                GL.LineWidth(2.0f);
                GL.Color3(Color.Orange);
                GL.Scale(1.02f, 1.02f, 1.02f);
                DrawGeometry(obj.Type);
                GL.LineWidth(1.0f);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                GL.Enable(EnableCap.DepthTest);
                GL.Enable(EnableCap.Lighting);
            }
            GL.PopMatrix();
        }

        private static void DrawGeometry(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Cube: DrawCube(); break;
                case ShapeType.Sphere: DrawSphere(1.0, 20, 20); break;
                case ShapeType.Pyramid: DrawPyramid(); break;
                case ShapeType.Cylinder: DrawCylinder(1.0, 2.0, 20); break;
                case ShapeType.Cone: DrawCone(1.0, 2.0, 20); break;
            }
        }

        private static void DrawDiamond()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(0, 0, 1); GL.Vertex3(-0.5f, 0, 0); GL.Vertex3(0, -0.5f, 0);
            GL.Vertex3(0, 0, 1); GL.Vertex3(0, -0.5f, 0); GL.Vertex3(0.5f, 0, 0);
            GL.Vertex3(0, 0, 1); GL.Vertex3(0.5f, 0, 0); GL.Vertex3(0, 0.5f, 0);
            GL.Vertex3(0, 0, 1); GL.Vertex3(0, 0.5f, 0); GL.Vertex3(-0.5f, 0, 0);
            GL.Vertex3(0, 0, -1); GL.Vertex3(-0.5f, 0, 0); GL.Vertex3(0, 0.5f, 0);
            GL.Vertex3(0, 0, -1); GL.Vertex3(0, 0.5f, 0); GL.Vertex3(0.5f, 0, 0);
            GL.Vertex3(0, 0, -1); GL.Vertex3(0.5f, 0, 0); GL.Vertex3(0, -0.5f, 0);
            GL.Vertex3(0, 0, -1); GL.Vertex3(0, -0.5f, 0); GL.Vertex3(-0.5f, 0, 0);
            GL.End();
        }

        private static void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0, 0, 1); GL.Vertex3(-1, 1, 1); GL.Vertex3(1, 1, 1); GL.Vertex3(1, -1, 1); GL.Vertex3(-1, -1, 1);
            GL.Normal3(0, 0, -1); GL.Vertex3(-1, -1, -1); GL.Vertex3(1, -1, -1); GL.Vertex3(1, 1, -1); GL.Vertex3(-1, 1, -1);
            GL.Normal3(0, -1, 0); GL.Vertex3(-1, -1, 1); GL.Vertex3(1, -1, 1); GL.Vertex3(1, -1, -1); GL.Vertex3(-1, -1, -1);
            GL.Normal3(0, 1, 0); GL.Vertex3(1, 1, 1); GL.Vertex3(-1, 1, 1); GL.Vertex3(-1, 1, -1); GL.Vertex3(1, 1, -1);
            GL.Normal3(1, 0, 0); GL.Vertex3(1, -1, 1); GL.Vertex3(1, 1, 1); GL.Vertex3(1, 1, -1); GL.Vertex3(1, -1, -1);
            GL.Normal3(-1, 0, 0); GL.Vertex3(-1, 1, 1); GL.Vertex3(-1, -1, 1); GL.Vertex3(-1, -1, -1); GL.Vertex3(-1, 1, -1);
            GL.End();
        }

        private static void DrawPyramid()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Normal3(0.0f, 0.5f, 0.5f); GL.Vertex3(0.0f, 0.0f, 1.0f); GL.Vertex3(-1.0f, -1.0f, -1.0f); GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Normal3(0.5f, 0.0f, 0.5f); GL.Vertex3(0.0f, 0.0f, 1.0f); GL.Vertex3(1.0f, -1.0f, -1.0f); GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Normal3(0.0f, -0.5f, 0.5f); GL.Vertex3(0.0f, 0.0f, 1.0f); GL.Vertex3(1.0f, 1.0f, -1.0f); GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Normal3(-0.5f, 0.0f, 0.5f); GL.Vertex3(0.0f, 0.0f, 1.0f); GL.Vertex3(-1.0f, 1.0f, -1.0f); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.End();
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, 0.0f, -1.0f); GL.Vertex3(-1.0f, 1.0f, -1.0f); GL.Vertex3(1.0f, 1.0f, -1.0f); GL.Vertex3(1.0f, -1.0f, -1.0f); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.End();
        }

        private static void DrawSphere(double r, int lats, int longs)
        {
            for (int i = 0; i <= lats; i++)
            {
                double lat0 = Math.PI * (-0.5 + (double)(i - 1) / lats);
                double z0 = Math.Sin(lat0); double zr0 = Math.Cos(lat0);
                double lat1 = Math.PI * (-0.5 + (double)i / lats);
                double z1 = Math.Sin(lat1); double zr1 = Math.Cos(lat1);
                GL.Begin(PrimitiveType.QuadStrip);
                for (int j = 0; j <= longs; j++)
                {
                    double lng = 2 * Math.PI * (double)(j - 1) / longs;
                    double x = Math.Cos(lng); double y = Math.Sin(lng);
                    GL.Normal3(x * zr0, y * zr0, z0); GL.Vertex3(r * x * zr0, r * y * zr0, r * z0);
                    GL.Normal3(x * zr1, y * zr1, z1); GL.Vertex3(r * x * zr1, r * y * zr1, r * z1);
                }
                GL.End();
            }
        }

        private static void DrawCylinder(double radius, double height, int segments)
        {
            double halfH = height / 2.0;
            GL.Begin(PrimitiveType.QuadStrip);
            for (int i = 0; i <= segments; i++)
            {
                double angle = 2.0 * Math.PI * i / segments;
                double x = Math.Cos(angle) * radius; double y = Math.Sin(angle) * radius;
                GL.Normal3(Math.Cos(angle), Math.Sin(angle), 0);
                GL.Vertex3(x, y, halfH); GL.Vertex3(x, y, -halfH);
            }
            GL.End();
            GL.Begin(PrimitiveType.Polygon); GL.Normal3(0, 0, 1); for (int i = 0; i < segments; i++) { double a = 2.0 * Math.PI * i / segments; GL.Vertex3(Math.Cos(a) * radius, Math.Sin(a) * radius, halfH); }
            GL.End();
            GL.Begin(PrimitiveType.Polygon); GL.Normal3(0, 0, -1); for (int i = 0; i < segments; i++) { double a = 2.0 * Math.PI * i / segments; GL.Vertex3(Math.Cos(a) * radius, Math.Sin(a) * radius, -halfH); }
            GL.End();
        }

        private static void DrawCone(double radius, double height, int segments)
        {
            double halfH = height / 2.0;
            GL.Begin(PrimitiveType.TriangleFan); GL.Normal3(0, 0, 1); GL.Vertex3(0, 0, halfH);
            for (int i = 0; i <= segments; i++)
            {
                double angle = 2.0 * Math.PI * i / segments; double x = Math.Cos(angle) * radius; double y = Math.Sin(angle) * radius;
                GL.Normal3(x, y, 0.5); GL.Vertex3(x, y, -halfH);
            }
            GL.End();
            GL.Begin(PrimitiveType.Polygon); GL.Normal3(0, 0, -1); for (int i = 0; i < segments; i++) { double a = 2.0 * Math.PI * i / segments; GL.Vertex3(Math.Cos(a) * radius, Math.Sin(a) * radius, -halfH); }
            GL.End();
        }

        public static void DrawGrid(int size)
        {
            GL.Disable(EnableCap.Lighting);
            GL.LineWidth(1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.FromArgb(60, 60, 60));
            for (int i = -size; i <= size; i++)
            {
                GL.Vertex3(-size, i, 0); GL.Vertex3(size, i, 0);
                GL.Vertex3(i, -size, 0); GL.Vertex3(i, size, 0);
            }
            GL.LineWidth(2.0f);
            GL.Color3(Color.Red); GL.Vertex3(0, 0, 0); GL.Vertex3(size, 0, 0);
            GL.Color3(Color.Green); GL.Vertex3(0, 0, 0); GL.Vertex3(0, size, 0);
            GL.Color3(Color.Blue); GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, size);
            GL.End();
            GL.LineWidth(1.0f);
            GL.Enable(EnableCap.Lighting);
        }

        public static Vector3 GetWorldPoint(float mouseX, float mouseY, float zDepth, int screenW, int screenH, Matrix4 view, Matrix4 projection)
        {
            float x = (2.0f * mouseX) / screenW - 1.0f;
            float y = 1.0f - (2.0f * mouseY) / screenH;
            Vector4 vecClip = new Vector4(x, y, zDepth, 1.0f);
            Matrix4 invViewProj = Matrix4.Invert(view * projection);
            Vector4 vecWorld = Vector4.Transform(vecClip, invViewProj);
            if (vecWorld.W != 0) vecWorld /= vecWorld.W;
            return vecWorld.Xyz;
        }
    }
}