using System.Drawing;

namespace PSS.pgr866.Practica_03
{
    public class Ficha
    {
        private ColorEnum _color;
        public ColorEnum Color { get { return _color; } }

        public Ficha()
        {
            _color = ColorEnum.SinColor;
        }
        public Ficha(ColorEnum color)
        {
            _color = color;
        }
    }

    public enum ColorEnum
    {
        SinColor, Rojo, Azul
    }
}