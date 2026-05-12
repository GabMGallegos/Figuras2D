using System;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras2D.Helpers
{
    public class Transformacion2D
    {
        public float DesplazamientoX { get; private set; } = 0f;
        public float DesplazamientoY { get; private set; } = 0f;
        public float FactorEscala { get; private set; } = 1f;
        public float AnguloRotacion { get; private set; } = 0f;

        public PointF Aplicar(PointF punto, PointF centro)
        {
            // 1. Escalado respecto al centro
            float xEscalado = centro.X + (punto.X - centro.X) * FactorEscala;
            float yEscalado = centro.Y + (punto.Y - centro.Y) * FactorEscala;

            // 2. Rotación respecto al centro
            double radianes = AnguloRotacion * Math.PI / 180.0;

            float xRelativo = xEscalado - centro.X;
            float yRelativo = yEscalado - centro.Y;

            float xRotado = (float)(xRelativo * Math.Cos(radianes) - yRelativo * Math.Sin(radianes));
            float yRotado = (float)(xRelativo * Math.Sin(radianes) + yRelativo * Math.Cos(radianes));

            // 3. Traslación final
            float xFinal = centro.X + xRotado + DesplazamientoX;
            float yFinal = centro.Y + yRotado + DesplazamientoY;

            return new PointF(xFinal, yFinal);
        }

        public void MoverArriba(float paso)
        {
            DesplazamientoY -= paso;
        }

        public void MoverAbajo(float paso)
        {
            DesplazamientoY += paso;
        }

        public void MoverIzquierda(float paso)
        {
            DesplazamientoX -= paso;
        }

        public void MoverDerecha(float paso)
        {
            DesplazamientoX += paso;
        }

        public void AumentarEscala(float factor)
        {
            FactorEscala *= factor;
        }

        public void ReducirEscala(float factor)
        {
            FactorEscala /= factor;
        }

        public void RotarAntihorario(float grados)
        {
            AnguloRotacion -= grados;
        }

        public void RotarHorario(float grados)
        {
            AnguloRotacion += grados;
        }

        public void Reiniciar()
        {
            DesplazamientoX = 0f;
            DesplazamientoY = 0f;
            FactorEscala = 1f;
            AnguloRotacion = 0f;
        }

        public bool ProcesarTecla(Keys tecla, float pasoTraslacion, float pasoEscala, float pasoRotacion)
        {
            if (tecla == Keys.Up)
            {
                MoverArriba(pasoTraslacion);
            }
            else if (tecla == Keys.Down)
            {
                MoverAbajo(pasoTraslacion);
            }
            else if (tecla == Keys.Left)
            {
                MoverIzquierda(pasoTraslacion);
            }
            else if (tecla == Keys.Right)
            {
                MoverDerecha(pasoTraslacion);
            }
            else if (tecla == Keys.A)
            {
                RotarAntihorario(pasoRotacion);
            }
            else if (tecla == Keys.D)
            {
                RotarHorario(pasoRotacion);
            }
            else if (tecla == Keys.R)
            {
                Reiniciar();
            }
            else
            {
                return false;
            }

            return true;
        }
        public void EstablecerEscala(float escala)
        {
            FactorEscala = escala;
        }
    }
}