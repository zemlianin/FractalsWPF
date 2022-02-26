using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PeerGradeWPF
{
    class Serpinskiy:figure
    {
        public Serpinskiy(int depth, Canvas canvas) : base(depth, canvas)
        {

        }
        /// <summary>
        /// Рисуем фон
        /// </summary>
        internal override void Drow()
        {
            nowDepth = -1;
            Rectangle rect = new Rectangle();
            rect.Width = 300;
            rect.Height = 300;
            rect.Fill = new SolidColorBrush(Colors.Black);
            //добавляем
            canvas.Children.Add(rect);
            //устанавливаем расположение
            Canvas.SetTop(rect, 30);
            Canvas.SetLeft(rect, 220);

            DrowRestangle(30, 220, 300, 300, nowDepth);
           
            
 
        }
        /// <summary>
        /// Метод рисует большой квадрат и вызывает сам себя
        /// </summary>
        /// <param name="x">Расположение х</param>
        /// <param name="y">Расположение у</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        /// <param name="nowDepth">Уровень прорисовки сейчас</param>
        internal void DrowRestangle(double x, double y, double width, double height,int nowDepth)
        {
            if (nowDepth <= depth-2)
            {
                nowDepth++;
                Rectangle rect = new Rectangle();
                rect.Width = width/3;
                rect.Height = height/3;
                rect.Fill = new SolidColorBrush(Color.FromRgb((byte)(startColorRGBRed + (endColorRGBRed - startColorRGBRed) / depth * (nowDepth)),
                    0, (byte)(startColorRGBBlue + (endColorRGBBlue - startColorRGBBlue) / depth * (nowDepth))));
                canvas.Children.Add(rect);
                //устанавливаем расположение
                Canvas.SetTop(rect, x+ width / 3);
                Canvas.SetLeft(rect, y+height / 3);

                DrowRestangle(x, y, width / 3, height / 3, nowDepth);
                DrowRestangle(x+width/3, y, width / 3, height / 3, nowDepth);
                DrowRestangle(x + 2*width / 3, y, width / 3, height / 3, nowDepth);
                DrowRestangle(x + 2 * width / 3, y + height / 3, width / 3, height / 3, nowDepth);
                DrowRestangle(x + 2 * width / 3, y + 2*height / 3, width / 3, height / 3, nowDepth);
                DrowRestangle(x + width / 3, y + 2 * height / 3, width / 3, height / 3, nowDepth);
                DrowRestangle(x , y + 2 * height / 3, width / 3, height / 3, nowDepth);
                DrowRestangle(x, y + height / 3, width / 3, height / 3, nowDepth);
            }
            
        }
    }
}
