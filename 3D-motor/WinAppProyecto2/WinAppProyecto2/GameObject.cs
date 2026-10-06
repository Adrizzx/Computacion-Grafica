using OpenTK;
using System;
using System.Drawing;

namespace WinAppProyecto2
{
    public enum ShapeType
    {
        Cube,
        Sphere,
        Pyramid,
        Cylinder,
        Cone,
        Light // Objeto tipo Luz
    }

    public class GameObject
    {
        public string Name { get; set; }
        public ShapeType Type { get; set; }

        // Transformaciones
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; } // Grados
        public Vector3 Scale { get; set; }

        // Respaldo
        public Vector3 BackupPosition { get; set; }
        public Vector3 BackupRotation { get; set; }
        public Vector3 BackupScale { get; set; }

        // Propiedades Visuales
        public Color ObjectColor { get; set; }
        public bool IsSelected { get; set; }
        public float Shininess { get; set; }
        public float SpecularStrength { get; set; }
        public float Opacity { get; set; } // NUEVO: 0.0 (Invisible) a 1.0 (Sólido)

        // Propiedades de Luz
        public float LightIntensity { get; set; }
        public float LightRange { get; set; }

        public GameObject(string name, ShapeType type)
        {
            Name = name;
            Type = type;
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;

            ObjectColor = Color.Blue;
            Opacity = 0.9f; // Totalmente opaco por defecto

            if (type == ShapeType.Light)
            {
                ObjectColor = Color.White;
                LightIntensity = 1.0f;
                LightRange = 20.0f;
            }

            IsSelected = false;
            Shininess = 32.0f;
            SpecularStrength = 0.5f;
        }

        public void BackupTransform()
        {
            BackupPosition = Position;
            BackupRotation = Rotation;
            BackupScale = Scale;
        }

        public void RestoreTransform()
        {
            Position = BackupPosition;
            Rotation = BackupRotation;
            Scale = BackupScale;
        }

        public float GetBoundingRadius()
        {
            float maxScale = Math.Max(Scale.X, Math.Max(Scale.Y, Scale.Z));
            return 1.5f * maxScale;
        }
    }
}