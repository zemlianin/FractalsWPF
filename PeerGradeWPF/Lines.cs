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
    class Lines : figure
    {
        //расстояние между прямыми
        internal static double height = 20;
        public Lines(int depth, Canvas canvas) : base(depth, canvas)
        {
            
        }
        /// <summary>
        /// Метод рисующий первую прямую
        /// </summary>
        internal override void Drow()
        {
            Line line = new Line();
            Thickness thickness = new Thickness(300, 60, 100, 20);
            line.Margin = thickness;
            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 5;
            line.Stroke = new SolidColorBrush( Color.FromRgb((byte)(int)startColorRGBRed,
                0, (byte)(int)(startColorRGBBlue)));
            line.X1 = -100;
            line.X2 = 200;
            line.Y1 = 000;
            line.Y2 = 000;
            canvas.Children.Add(line);
            nowDepth ++;
            DrowLines(line.X1, line.Y1, line.X2, line.Y2, nowDepth);
        }
        /// <summary>
        /// Метод рисующий два отрезка ниже заданного
        /// </summary>
        /// <param name="x1">Начальный х</param>
        /// <param name="y1">Начальный у</param>
        /// <param name="x2">Конечный х</param>
        /// <param name="y2">Конечный у</param>
        /// <param name="nowDepth">глубина прорисовки </param>
        private void DrowLines(double x1,double y1,double x2,double y2,int nowDepth)
        {
            if (nowDepth <= depth)
            {
                nowDepth++;
                Line line = new Line();
                Thickness thickness = new Thickness(300, 60, 100, 20);
                line.Margin = thickness;
                line.Visibility = System.Windows.Visibility.Visible;
                line.StrokeThickness = 5;
                line.Stroke = new SolidColorBrush(Color.FromRgb((byte)(startColorRGBRed+(endColorRGBRed - startColorRGBRed) / depth * (nowDepth - 1)),
                    0, (byte)(startColorRGBBlue+(endColorRGBBlue - startColorRGBBlue) / depth * (nowDepth - 1))));
                line.X1 = x1;
                line.X2 = x1+(x2 - x1) / 3;
                line.Y1 = y1 + height;
                line.Y2 = y2 + height;
                canvas.Children.Add(line);
                DrowLines(line.X1, line.Y1, line.X2, line.Y2, nowDepth);


                Line line2 = new Line();
                Thickness thickness2 = new Thickness(300, 60, 100, 20);
                line2.Margin = thickness;
                line2.Visibility = System.Windows.Visibility.Visible;
                line2.StrokeThickness = 5;
                line2.Stroke = new SolidColorBrush(Color.FromRgb((byte)(startColorRGBRed + (endColorRGBRed - startColorRGBRed) / depth * (nowDepth - 1)),
                    0, (byte)(startColorRGBBlue + (endColorRGBBlue - startColorRGBBlue) / depth * (nowDepth - 1)))); ;
                line2.X1 = x1+2*(x2 - x1) / 3;
                line2.X2 = x2;
                line2.Y1 = y1 + height;
                line2.Y2 = y2 + height;
                canvas.Children.Add(line2);
                DrowLines(line2.X1, line2.Y1, line2.X2, line2.Y2, nowDepth);
            }
        }
    }
}
