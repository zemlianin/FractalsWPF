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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        int depth = 6;
        delegate void FigureNow(object sender, RoutedEventArgs e);
        FigureNow figureNow;
        /// <summary>
        /// Создание окна
        /// </summary>
        public MainWindow()
        {
            try
            {
                MinWidth = SystemParameters.PrimaryScreenWidth / 2;
                MinHeight = SystemParameters.PrimaryScreenHeight / 2;
                //присваиваем делегату пустой метод(тк на конвасе ничего нет)
                figureNow = new FigureNow(ClearFunction);
                InitializeComponent();
            }
            catch (Exception)
            {
                MessageBox.Show("Что то пошло не так");
            }
            
        }
        /// <summary>
        /// Пустой фрактал, нужен для записи в делегат при запуске, когда  на конвасе ничего нет
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void ClearFunction(object sender, RoutedEventArgs e)
        {
           
        }
        /// <summary>
        /// событие отрисовки дерева
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>

        private void Koxa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                canvas.Children.Clear();
                Koxa koxa = new Koxa(depth, canvas);
                koxa.Drow();
                figureNow = Koxa_Click;
            }
            catch (Exception)
            {
                MessageBox.Show("Что то пошло не так");
            }
            
        }
        /// <summary>
        /// Событие отрисовки ковра Серпинского
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void Serpinsky_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                canvas.Children.Clear();
                Serpinskiy serpinskiy = new Serpinskiy(depth, canvas);
                serpinskiy.Drow();
                figureNow = Serpinsky_Click;
            }
            catch (Exception)
            {
                MessageBox.Show("Что то пошло не так");
            }
            
        }
        /// <summary>
        /// Событие отрисовки треугольника
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void Triangulum_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                canvas.Children.Clear();
                Triangulum triangulum = new Triangulum(depth, canvas);
                triangulum.Drow();
                figureNow = Triangulum_Click;
            }
            catch (Exception)
            {
                MessageBox.Show("Что то пошло не так");
            }
            
        }
        /// <summary>
        /// Событие отрисовки линий
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void lines_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                canvas.Children.Clear();
                Lines lines = new Lines(depth, canvas);
                lines.Drow();
                figureNow = lines_Click;
            }
            catch (Exception)
            {
                MessageBox.Show("Что то пошло не так"); ;
            }
            
        }
        /// <summary>
        /// Событие изменения значения слайдера отвечающего за глубину рекурсии
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                depth = (int)slider.Value;
                figureNow(sender, new RoutedEventArgs());
            }
            catch (Exception)
            {
                MessageBox.Show("Что то пошло не так");
            }
            
        }
        /// <summary>
        /// Событие изменения значения слайдера отвечающего за расстояние между разными уровнями прорисовки линий
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                Lines.height = sliderH.Value;
                if (figureNow == lines_Click)
                {
                    figureNow(sender, new RoutedEventArgs());
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Что то пошло не так");
            }
            
        }
        /// <summary>
        /// Событие изменения значения слайдера отвечающего за угол отклонения первой прямой разветвления в дереве
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void SliderAlfa_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                Tree.alfa1 = SliderAlfa.Value;
                if (figureNow == clickTree)
                {
                    figureNow(sender, new RoutedEventArgs());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что то пошло не так");

            }
            
      
        }
        /// <summary>
        /// Событие изменения значения слайдера отвечающего за отношение длин веток разных уровней прорисовки в дереве
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void sliderK_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                Tree.relationship = sliderK.Value;
                if (figureNow == clickTree)
                {
                    figureNow(sender, new RoutedEventArgs());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что то пошло не так");
            }
            
        }
        /// <summary>
        /// Событие нажатия клавиши сохранения конваса
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void SaveCanvas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rect rect = new Rect(canvas.RenderSize);
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,
                  (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                rtb.Render(canvas);
                //endcode as PNG
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                //save to memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);
                ms.Close();
                System.IO.File.WriteAllBytes("SaveCanvas\\"+linkTextBox.Text+".png", ms.ToArray());
                MessageBox.Show("Файл успешно сохранен в папке: PeerGradeWPF\\bin\\Debug\\net5.0-windows\\SaveCanvas");
            }
            catch
            {
                MessageBox.Show("Некоректное имя файла");
  
               
            }
        }
        /// <summary>
        /// Событие изменения стартого цвета
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void StartRed_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                StartBlue.IsChecked = false;
                figure.startColorRGBRed = 255;
                figure.startColorRGBBlue = 0;
                figureNow(sender, new RoutedEventArgs());
            }
            catch (Exception)
            {

                MessageBox.Show("Некоректное имя файла");
            }
            
        }
        /// <summary>
        /// Событие изменения стартого цвета
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void StartBlue_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                StartRed.IsChecked = false;
                figure.startColorRGBRed = 0;
                figure.startColorRGBBlue = 255;
                figureNow(sender, new RoutedEventArgs());
            }
            catch (Exception)
            {

                MessageBox.Show("Некоректное имя файла");
            }
            
        }

        /// <summary>
        /// Событие изменения конечного цвета
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void EndRed_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                EndBlue.IsChecked = false;
                figure.endColorRGBRed = 255;
                figure.endColorRGBBlue = 0;
                figureNow(sender, new RoutedEventArgs());
            }

            catch (Exception)
            {
                MessageBox.Show("Некоректное имя файла");
            }
        }   
        /// <summary>
        /// Событие изменения конечного цвета
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void EndBlue_Checked(object sender, RoutedEventArgs e)
        {

            try
            {
                EndRed.IsChecked = false;
                figure.endColorRGBRed = 0;
                figure.endColorRGBBlue = 255;
                figureNow(sender, new RoutedEventArgs());

            }
            catch (Exception)
            {
                MessageBox.Show("Некоректное имя файла");
            }
            
        }
        /// <summary>
        /// Событие изменения значения слайдера отвечающего за угол отклонения второй прямой разветвления в дереве
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void sliderAlfa2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                Tree.alfa2 = sliderAlfa2.Value;
                if (figureNow == clickTree)
                {
                    figureNow(sender, new RoutedEventArgs());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некоректное имя файла");
            }
            
        }
        /// <summary>
        /// Собите отвечающее за отрисовку дерева
        /// </summary>
        /// <param name="sender">издатель</param>
        /// <param name="e">информация о событии</param>
        private void clickTree(object sender, RoutedEventArgs e)
        {
            try
            {
                canvas.Children.Clear();
                Tree tree = new Tree(depth, canvas);
                tree.Drow();
                figureNow = clickTree;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Некоректное имя файла");
            }
           
        }
    } 
  


}
