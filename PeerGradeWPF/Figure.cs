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
    internal abstract class figure
    {
        public int depth;
        public Canvas canvas;
        public int nowDepth = 1;
        protected System.Windows.Media.SolidColorBrush startColor =  new SolidColorBrush(Color.FromRgb(0, 0, 255));
        protected System.Windows.Media.SolidColorBrush endColor = new SolidColorBrush(Color.FromRgb(0, 0, 255));
        static internal double startColorRGBRed = 0;
        static internal double startColorRGBBlue = 255;
        static internal double endColorRGBRed = 0;
        static internal double endColorRGBBlue = 255;
        /// <summary>
        /// Конструктор фракталов
        /// </summary>
        /// <param name="depth">глубина прорисовки</param>
        /// <param name="canvas">конвас на котором изображается фрактал</param>
        public figure(int depth, Canvas canvas)
        {
            this.depth = depth;
            this.canvas = canvas;
        }


        internal abstract void Drow();
        
    }
}
