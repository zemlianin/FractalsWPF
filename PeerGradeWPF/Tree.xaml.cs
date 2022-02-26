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
    class Tree:figure
    {
        
        internal double leng = 100;
        internal static double alfa1=  45 / 57.3;
        internal static double alfa2 =  45 / 57.3;
        internal static double relationship = 1 / 1.5;
        public Tree(int depth, Canvas canvas) : base(depth, canvas)
        {
            
        }
        /// <summary>
        /// Метод рисует первую прямую
        /// </summary>
        internal override void Drow()
        {
            
            depth = depth * 2;
            Line line = new Line();
            Thickness thickness = new Thickness(300, 60, 100, 20);
            line.Margin = thickness;
            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 1;
            line.Stroke = new SolidColorBrush(Color.FromRgb((byte)(int)startColorRGBRed,
                0, (byte)(int)(startColorRGBBlue)));
            line.X1 = 100;
            line.X2 = 100;
            line.Y1 = 200;
            line.Y2 = 200 + 100;
            canvas.Children.Add(line);
            nowDepth++;
            Div(line.X1, line.Y1, nowDepth, 90/57.3);
        }
        /// <summary>
        /// Отрисовка двух линий
        /// </summary>
        /// <param name="Xend">конец предыдущего отрезкам х</param>
        /// <param name="Yend">конец предыдущего отрезка у</param>
        /// <param name="nowDepth">глубина рекурсии сейчас</param>
        /// <param name="alfa">угол наклона предидущего отрезка</param>
        private void Div( double Xend, double Yend, int nowDepth, double alfa)
        {
            
            if (nowDepth <= depth)
            {
                alfa = alfa - alfa1;
                Line line = new Line();
                Thickness thickness = new Thickness(300, 60, 100, 20);
                line.Margin = thickness;
                line.Visibility = System.Windows.Visibility.Visible;
                line.StrokeThickness = 1;
                line.Stroke = new SolidColorBrush(Color.FromRgb((byte)(startColorRGBRed + (endColorRGBRed - startColorRGBRed) / depth * (nowDepth - 1)),
                    0, (byte)(startColorRGBBlue + (endColorRGBBlue - startColorRGBBlue) / depth * (nowDepth - 1)))); ;
                line.X1 = Xend;
                line.X2 = Xend + Math.Cos(alfa)*(leng/Math.Pow(relationship, nowDepth));
                line.Y1 = Yend;
                line.Y2 = Yend - Math.Sin(alfa ) * (leng / Math.Pow(relationship, nowDepth));
                canvas.Children.Add(line);
                nowDepth++;
                Div(line.X2, line.Y2, nowDepth, alfa);
                alfa = alfa + alfa1+ alfa2;
                Line line2 = new Line();
                Thickness thickness2 = new Thickness(300, 60, 100, 20);
                line2.Margin = thickness;
                line2.Visibility = System.Windows.Visibility.Visible;
                line2.StrokeThickness = 1;
                line2.Stroke = new SolidColorBrush(Color.FromRgb((byte)(startColorRGBRed + (endColorRGBRed - startColorRGBRed) / depth * (nowDepth - 2)),
                    0, (byte)(startColorRGBBlue + (endColorRGBBlue - startColorRGBBlue) / depth * (nowDepth - 2)))); ;
                line2.X1 = Xend;
                line2.X2 = Xend + Math.Cos(alfa ) * (leng/ Math.Pow(relationship, nowDepth - 1));
                line2.Y1 = Yend;
                line2.Y2 = Yend - Math.Sin(alfa ) * (leng /  Math.Pow(relationship, nowDepth - 1));
                canvas.Children.Add(line2);
                Div(line2.X2, line2.Y2, nowDepth, alfa);
            }
        }
    }
}
