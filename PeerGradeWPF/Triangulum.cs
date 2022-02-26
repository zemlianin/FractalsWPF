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
    class Triangulum:figure
    {
        public Triangulum(int depth, Canvas canvas) : base(depth, canvas)
        {

        }
        /// <summary>
        /// отрисовка первого треугольника
        /// </summary>
        internal override void Drow()
        {
           
            int nowDepth = 0;
            Polygon triangle = new Polygon();
            triangle.Stroke = new SolidColorBrush(Color.FromRgb((byte)(int)startColorRGBRed,
                0, (byte)(int)(startColorRGBBlue)));

            triangle.StrokeThickness = 1;
            triangle.HorizontalAlignment = HorizontalAlignment.Left;
            triangle.VerticalAlignment = VerticalAlignment.Center;
            triangle.Points = new PointCollection() { new Point(300, 300), new Point(500, 300), new Point(400, 100) };
           
            canvas.Children.Add(triangle);

            DrowTriangle(300, 300, 500, 300, 400, 100, nowDepth);
        }
        /// <summary>
        /// Отрисовка треугольника внутри переданного
        /// </summary>
        /// <param name="x1">кордината первой точки</param>
        /// <param name="y1">кордината первой точки</param>
        /// <param name="x2">кордината второй точки</param>
        /// <param name="y2">кордината второй точки</param>
        /// <param name="x3">кордината третьей точки</param>
        /// <param name="y3">кордината третьей точки</param>
        /// <param name="nowDepth">глубина прорисовки в данный момент</param>
        private void DrowTriangle(double x1,double y1,double x2, double y2,double x3, double y3,int nowDepth)
        {
            if (nowDepth < depth)
            {
                nowDepth++;
                Polygon triangle = new Polygon();
                triangle.Stroke = new SolidColorBrush(Color.FromRgb((byte)(startColorRGBRed + (endColorRGBRed - startColorRGBRed) / depth * (nowDepth)), 0,
                    (byte)(startColorRGBBlue + (endColorRGBBlue - startColorRGBBlue) / depth * (nowDepth)))) ;
                triangle.StrokeThickness = 1;
                triangle.HorizontalAlignment = HorizontalAlignment.Left;
                triangle.VerticalAlignment = VerticalAlignment.Center;
                triangle.Points = new PointCollection() { new Point((x1 + x2) / 2, (y1 + y2) / 2), new Point((x2 + x3) / 2, (y2 + y3) / 2), new Point((x3 + x1) / 2, (y3 + y1) / 2) };
                canvas.Children.Add(triangle);
                DrowTriangle(x1, y1, (x1 + x2) / 2, (y1 + y2) / 2, (x3 + x1) / 2, (y3 + y1) / 2, nowDepth);
                DrowTriangle((x1 + x2) / 2, (y1 + y2) / 2, x2, y2, (x2 + x3) / 2, (y2 + y3) / 2, nowDepth);
                DrowTriangle((x3 + x1) / 2, (y3 + y1) / 2, (x2 + x3) / 2, (y2 + y3) / 2, x3, y3, nowDepth);
            }
        }
    }
}
