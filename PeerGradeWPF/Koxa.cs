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
    class Koxa:figure
    {
        
        public Koxa(int depth, Canvas canvas) : base(depth, canvas)
        {

        }
        /// <summary>
        /// Метод вызова рекурсивной отрисовки
        /// </summary>
        internal override void Drow()
        {
            DrowLine(-200, 200, 300, 200, 1);   
            
        }
        /// <summary>
        /// Метод отрисовки линии по кординатам начала и конца
        /// еслди не достигнут уровень максимальной прорисовки, то делит прямую на 4 отрезка 
        /// и вызывает себя же с их кординатами
        /// </summary>
        /// <param name="x">начальный х</param>
        /// <param name="y">начальный у</param>
        /// <param name="xOld">конечный х</param>
        /// <param name="yOld">конечный у</param>
        /// <param name="nowDepth">номер уровень прорисовки</param>
        private void DrowLine(double x ,double y ,double xOld, double yOld, int nowDepth)
        {
            double dopAngle = 1;
            if (nowDepth <= depth)
            {
                nowDepth++;
                double leng = Math.Sqrt((xOld - x) * (xOld - x) + (yOld - y) * (yOld - y));
                if ((xOld>x&&yOld<y)||(xOld<x&&yOld<y))
                {
                    dopAngle = Math.PI;
                }
                else
                {
                    dopAngle = 0;
                }
                DrowLine(x + (-x + xOld) / 3,  y + (-y + yOld) / 3, x + (-x + xOld) / 2+ leng /3* Math.Cos(Math.Atan(1 / ((yOld - y) / (xOld - x)))+ dopAngle), 
                    y + (-y + yOld) / 2 +  (leng / 3* -Math.Sin(Math.Atan(1 /( (yOld - y) / (xOld - x)))+ dopAngle)), nowDepth);
                DrowLine(x + (-x + xOld) / 2 + (leng / 3 * Math.Cos(Math.Atan(1 / ((yOld - y) / (xOld - x)))+ dopAngle)), (
                    y + (-y + yOld) / 2 + leng / 3 * -Math.Sin(Math.Atan(1 / ((yOld - y) / (xOld - x)))+ dopAngle)), x + 2*(-x + xOld) / 3, y + 2*(-y + yOld) / 3, nowDepth);
                DrowLine(x, y, x + (-x + xOld) / 3, y + (-y + yOld) / 3, nowDepth);
                DrowLine(x + 2 * (-x + xOld) / 3, y + 2 * (-y + yOld) / 3, xOld, yOld, nowDepth);             
            }
            else
            {
                Line line3 = new Line();
                Thickness thickness3 = new Thickness(300, 60, 100, 20);
                line3.Margin = thickness3;
                line3.Visibility = System.Windows.Visibility.Visible;
                line3.StrokeThickness = 1;
                line3.Stroke = new SolidColorBrush(Color.FromRgb((byte)(int)endColorRGBRed,
                0, (byte)(int)endColorRGBBlue));
                line3.X1 = x;
                line3.X2 = xOld;
                line3.Y1 = y;
                line3.Y2 = yOld;
                canvas.Children.Add(line3);
            }
        }
    }

        


}

