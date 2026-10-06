using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppVelocimetro
{
    public partial class Form1 : Form
    {
        // 1. Variables de configuración y estado
        private int centroX;
        private int centroY;
        private int radio = 180; // Radio del velocímetro
        private float velocidadActual = 0f;
        private const float MAX_VELOCIDAD = 180f;

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Establecer el punto central del dibujo
            centroX = this.ClientSize.Width / 2;
            centroY = this.ClientSize.Height / 2;
            // Desactivar el Timer para usar el control de teclado
            timerVelocimetro.Enabled = false;
        }

        // --- Evento de Pintado (Dibujo Principal) ---
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            // Recalcular el centro
            centroX = this.ClientSize.Width / 2;
            centroY = this.ClientSize.Height / 2;

            // 2. Dibujar el Borde (Círculo completo)
            Pen penBorde = new Pen(Color.Gray, 5);
            g.DrawEllipse(penBorde, centroX - radio, centroY - radio, radio * 2, radio * 2);

            // Relleno Interior
            g.FillEllipse(new SolidBrush(Color.FromArgb(20, 20, 20)), centroX - radio + 2, centroY - radio + 2, radio * 2 - 4, radio * 2 - 4);

            // 3. Dibujar la Escala (Semicírculo)
            DibujarSemicirculoEscala(g);

            // 4. Dibujar la Aguja
            DibujarAguja(g);

            // 5. Mostrar la Velocidad Digital
            MostrarVelocidadDigital(g);

            // 6. ¡Nuevo! Dibujar el mini gráfico del carro
            DibujarCarroIndicador(g);

            // Texto de Instrucción
            Font fuenteInstruccion = new Font("Arial", 10, FontStyle.Regular);
            g.DrawString("Usar ↑ y ↓ para controlar la velocidad", fuenteInstruccion, Brushes.DarkGray, 10, this.ClientSize.Height - 30);
        }

        // --- Método para Dibujar el Semicírculo de la Escala ---
        private void DibujarSemicirculoEscala(Graphics g)
        {
            const float inicioAngulo = 180f; // 0 km/h en la izquierda horizontal
            const float rangoAngulo = 180f;  // 180 km/h en la derecha horizontal

            // Dibujar Arco de la escala
            Pen penEscala = new Pen(Color.Cyan, 3);
            g.DrawArc(penEscala, centroX - radio + 10, centroY - radio + 10, (radio - 10) * 2, (radio - 10) * 2, inicioAngulo, -rangoAngulo);

            // Bucle para dibujar Marcas y Números
            for (int i = 0; i <= MAX_VELOCIDAD; i += 10)
            {
                float anguloActual = 180f - ((float)i / MAX_VELOCIDAD) * rangoAngulo;
                double radianes = anguloActual * Math.PI / 180.0;

                bool esPrincipal = (i % 20 == 0);
                int longitudMarca = esPrincipal ? 20 : 10;
                Pen penMarca = esPrincipal ? new Pen(Color.Red, 3) : new Pen(Color.White, 1);

                int radioExterior = radio - 10;
                int radioInterior = radioExterior - longitudMarca;

                // Coordenadas de la marca (Línea)
                int x1 = (int)(centroX + radioExterior * Math.Cos(radianes));
                int y1 = (int)(centroY - radioExterior * Math.Sin(radianes));
                int x2 = (int)(centroX + radioInterior * Math.Cos(radianes));
                int y2 = (int)(centroY - radioInterior * Math.Sin(radianes));

                g.DrawLine(penMarca, x1, y1, x2, y2);

                // Dibujar el texto (solo para marcas principales)
                if (esPrincipal)
                {
                    int radioTexto = radio - 40;
                    int xT = (int)(centroX + radioTexto * Math.Cos(radianes));
                    int yT = (int)(centroY - radioTexto * Math.Sin(radianes));

                    string texto = i.ToString();
                    Font fuente = new Font("Arial", 12, FontStyle.Bold);
                    SizeF textSize = g.MeasureString(texto, fuente);

                    g.DrawString(texto, fuente, Brushes.White, xT - textSize.Width / 2, yT - textSize.Height / 2);
                }
            }
        }

        private void DibujarAguja(Graphics g)
        {
            // Mapear el valor (0-180) al ángulo (180 a 0 grados)
            float anguloActual = 180f - (velocidadActual / MAX_VELOCIDAD) * 180f;
            double radianes = anguloActual * Math.PI / 180.0;

            int longitudAguja = radio - 30;

            // Coordenadas del extremo de la aguja (Línea)
            int xAguja = (int)(centroX + longitudAguja * Math.Cos(radianes));
            int yAguja = (int)(centroY - longitudAguja * Math.Sin(radianes));

            // Dibujar la aguja
            Pen penAguja = new Pen(Color.OrangeRed, 5);
            g.DrawLine(penAguja, centroX, centroY, xAguja, yAguja);

            // Dibujar círculo central
            int radioTapa = 10;
            g.FillEllipse(Brushes.Red, centroX - radioTapa, centroY - radioTapa, radioTapa * 2, radioTapa * 2);
            g.DrawEllipse(Pens.Black, centroX - radioTapa, centroY - radioTapa, radioTapa * 2, radioTapa * 2);
        }

        private void MostrarVelocidadDigital(Graphics g)
        {
            // Velocidad Digital (Número grande)
            string velocidadStr = ((int)velocidadActual).ToString("000");
            Font fuenteVel = new Font("Digital-7", 48, FontStyle.Bold);
            SizeF tamanoVel = g.MeasureString(velocidadStr, fuenteVel);

            float xVel = centroX - tamanoVel.Width / 2;
            float yVel = centroY + 40;

            g.DrawString(velocidadStr, fuenteVel, Brushes.LimeGreen, xVel, yVel);

            // Unidad "km/h"
            string unidadStr = "km/h";
            Font fuenteUnidad = new Font("Arial", 14, FontStyle.Regular);
            SizeF tamanoUnidad = g.MeasureString(unidadStr, fuenteUnidad);

            float xUnidad = centroX - tamanoUnidad.Width / 2;
            float yUnidad = yVel + tamanoVel.Height - 10;

            g.DrawString(unidadStr, fuenteUnidad, Brushes.White, xUnidad, yUnidad);
        }

        // --- Nuevo: Mini Gráfico de Carro Vertical ---
        private void DibujarCarroIndicador(Graphics g)
        {
            // Parámetros de posición y tamaño
            int anchoContenedor = 80;
            int altoContenedor = 150;
            int xBase = centroX + radio + 30; // Posición a la derecha del velocímetro
            int yBase = centroY - altoContenedor / 2;

            // 1. Dibujar el contenedor (Marco de la pista)
            Pen penPista = new Pen(Color.DimGray, 2);
            g.DrawRectangle(penPista, xBase, yBase, anchoContenedor, altoContenedor);

            // 2. Calcular la posición vertical del carro
            // Mapear velocidadActual (0-180) a la altura (altoContenedor)
            float porcentajeVel = velocidadActual / MAX_VELOCIDAD;

            // La posición Y se calcula de forma inversa (0% velocidad = abajo; 100% velocidad = arriba)
            float yCarro = yBase + altoContenedor - (porcentajeVel * altoContenedor);

            // 3. Dibujar la representación del carro (Polígono simple y Círculos)
            int anchoCarro = 40;
            int altoCarro = 20;

            // Ajustar Y para que el carro quede centrado en su altura
            int xCarro = xBase + (anchoContenedor - anchoCarro) / 2;
            int yCarroAjustado = (int)yCarro - altoCarro / 2;

            // Relleno del cuerpo (Primitiva Polígono - Cuadrilátero)
            Point[] carroBody = new Point[]
            {
                new Point(xCarro, yCarroAjustado + altoCarro),
                new Point(xCarro + anchoCarro, yCarroAjustado + altoCarro),
                new Point(xCarro + anchoCarro, yCarroAjustado),
                new Point(xCarro, yCarroAjustado)
            };

            // Usar un color que cambie con la velocidad (de verde a rojo)
            int r = (int)(255 * porcentajeVel);
            int gColor = (int)(255 * (1 - porcentajeVel));
            Color colorCarro = Color.FromArgb(r, gColor, 0); // Transición de verde a rojo

            g.FillPolygon(new SolidBrush(colorCarro), carroBody);

            // Borde del carro (Primitiva Línea/Polígono)
            g.DrawPolygon(Pens.White, carroBody);

            // Ruedas (Primitiva Círculo/Elipse)
            int radioRueda = 5;
            // Rueda trasera
            g.FillEllipse(Brushes.Gray, xCarro + 5 - radioRueda, yCarroAjustado + altoCarro - radioRueda, radioRueda * 2, radioRueda * 2);
            g.DrawEllipse(Pens.Black, xCarro + 5 - radioRueda, yCarroAjustado + altoCarro - radioRueda, radioRueda * 2, radioRueda * 2);
            // Rueda delantera
            g.FillEllipse(Brushes.Gray, xCarro + anchoCarro - 5 - radioRueda, yCarroAjustado + altoCarro - radioRueda, radioRueda * 2, radioRueda * 2);
            g.DrawEllipse(Pens.Black, xCarro + anchoCarro - 5 - radioRueda, yCarroAjustado + altoCarro - radioRueda, radioRueda * 2, radioRueda * 2);

            // Etiqueta del indicador
            Font fuenteLabel = new Font("Arial", 9);
            g.DrawString("Indicador", fuenteLabel, Brushes.White, xBase + 5, yBase - 20);
        }

        // --- Evento de Teclado (Control de Velocidad) ---
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            const float incremento = 5f; // Cantidad de cambio de velocidad por pulsación

            if (e.KeyCode == Keys.Up) // Flecha arriba: Acelerar
            {
                velocidadActual += incremento;
            }
            else if (e.KeyCode == Keys.Down) // Flecha abajo: Desacelerar
            {
                velocidadActual -= incremento;
            }

            // Asegurarse de que la velocidad esté en el rango [0, 180]
            if (velocidadActual < 0) velocidadActual = 0;
            if (velocidadActual > MAX_VELOCIDAD) velocidadActual = MAX_VELOCIDAD;

            // Forzar el redibujo para actualizar el velocímetro y el indicador
            this.Invalidate();
        }

        // El Tick del Timer se deja vacío ya que el control es manual por teclado
        private void timerVelocimetro_Tick(object sender, EventArgs e) { }
    }
}