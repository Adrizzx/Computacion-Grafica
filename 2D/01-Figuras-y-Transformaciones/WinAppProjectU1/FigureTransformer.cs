using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinAppProjectU1
{
    public class FigureTransformer
    {
        // --- PROPIEDADES DE ESTADO ---

        // El punto central sobre el cual rotar y escalar
        public PointF Center { get; set; }

        // Cantidad de traslación (movimiento)
        public float OffsetX { get; private set; }
        public float OffsetY { get; private set; }

        // Ángulo de rotación en grados
        public float RotationAngle { get; private set; }

        // Factor de escala (1.0 = 100%, 1.5 = 150%)
        public float Scale { get; private set; }

        // --- CONSTRUCTOR ---

        public FigureTransformer()
        {
            // Inicializa todo en el estado "por defecto"
            Reset();
        }

        // --- MÉTODOS DE CONTROL ---

        /// <summary>
        /// Resetea todas las transformaciones a su estado original.
        /// </summary>
        public void Reset()
        {
            OffsetX = 0f;
            OffsetY = 0f;
            RotationAngle = 0f;
            Scale = 1.0f;
            Center = PointF.Empty; // Se establecerá al dibujar
        }

        /// <summary>
        /// Añade un desplazamiento (movimiento) a la figura.
        /// </summary>
        public void Translate(float dx, float dy)
        {
            OffsetX += dx;
            OffsetY += dy;
        }

        /// <summary>
        /// Añade una rotación (en grados) a la figura.
        /// </summary>
        public void Rotate(float angle)
        {
            RotationAngle += angle;
        }

        /// <summary>
        /// Establece la escala absoluta de la figura.
        /// </summary>
        public void SetScale(float scale)
        {
            // Validación: No permitir escala de cero o negativa
            if (scale > 0.01f)
            {
                Scale = scale;
            }
        }

        // --- MÉTODO PRINCIPAL ---

        /// <summary>
        /// Aplica todas las transformaciones (Traslación, Rotación, Escala)
        /// al objeto Graphics ANTES de que se dibuje nada.
        /// </summary>
        public void ApplyTransform(Graphics g)
        {
            if (g == null || Center.IsEmpty)
                return;

            // El orden de las transformaciones es importante.
            // Generalmente es: Escala -> Rotación -> Traslación.
            // Para que la rotación y escala ocurran "alrededor" del centro:

            // 1. Mueve el "origen" (0,0) de Graphics al centro de nuestra figura + el offset
            g.TranslateTransform(Center.X + OffsetX, Center.Y + OffsetY);

            // 2. Rota alrededor de ese nuevo origen
            g.RotateTransform(RotationAngle);

            // 3. Escala desde ese nuevo origen
            g.ScaleTransform(Scale, Scale);

            // 4. Mueve el origen de vuelta a donde estaba
            //    (para que el código de dibujo original funcione)
            g.TranslateTransform(-Center.X, -Center.Y);
        }
    }
}