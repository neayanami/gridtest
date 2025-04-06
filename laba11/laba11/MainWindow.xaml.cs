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
using System.Windows.Threading;

namespace laba11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();
        private readonly List<Leaf> _leaves = new List<Leaf>();
        private readonly DispatcherTimer _animationTimer;
        private readonly List<Brush> _leafColors = new List<Brush>
        {
            Brushes.Gold,
            Brushes.Orange,
            Brushes.OrangeRed,
            Brushes.DarkGoldenrod,
            Brushes.Firebrick,
            Brushes.DarkOrange
        };

        public MainWindow()
        {
            InitializeComponent();

            _animationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(20)
            };
            _animationTimer.Tick += AnimateLeaves;
            _animationTimer.Start();

            // Создаем начальные листья
            for (int i = 0; i < 15; i++)
            {
                CreateLeaf();
            }

            // Таймер для добавления новых листьев
            var leafCreationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1.5)
            };
            leafCreationTimer.Tick += (s, e) => CreateLeaf();
            leafCreationTimer.Start();
        }

        private void CreateLeaf()
        {
            // Случайная позиция в верхней части экрана (крона дерева)
            double startX = _random.Next(50, 550);
            double startY = _random.Next(100, 250);

            var leaf = new Leaf
            {
                Shape = new Path
                {
                    Data = Geometry.Parse("M 0,0 L 5,2 L 10,0 L 8,5 L 10,10 L 5,8 L 0,10 L 2,5 Z"),
                    Fill = _leafColors[_random.Next(_leafColors.Count)],
                    RenderTransform = new RotateTransform()
                },
                X = startX,
                Y = startY,
                Rotation = _random.Next(360),
                RotationSpeed = (_random.NextDouble() - 0.5) * 4,
                HorizontalSpeed = (_random.NextDouble() - 0.5) * 2,
                VerticalSpeed = _random.NextDouble() * 0.5 + 0.5,
                WindInfluence = _random.NextDouble() * 0.3,
                WobbleX = _random.NextDouble() * 0.1,
                WobbleY = _random.NextDouble() * 0.1,
                WobbleSpeed = _random.NextDouble() * 0.05 + 0.02,
                TimeOffset = _random.NextDouble() * 100
            };

            MainCanvas.Children.Add(leaf.Shape);
            _leaves.Add(leaf);
        }

        private void AnimateLeaves(object sender, EventArgs e)
        {
            double windStrength = Math.Sin(DateTime.Now.Ticks * 0.0000001) * 3;

            for (int i = _leaves.Count - 1; i >= 0; i--)
            {
                var leaf = _leaves[i];

                // Обновляем позицию с учетом ветра и колебаний
                leaf.TimeOffset += leaf.WobbleSpeed;
                double wobbleX = Math.Sin(leaf.TimeOffset) * leaf.WobbleX;
                double wobbleY = Math.Cos(leaf.TimeOffset * 1.3) * leaf.WobbleY;

                leaf.X += leaf.HorizontalSpeed + windStrength * leaf.WindInfluence + wobbleX;
                leaf.Y += leaf.VerticalSpeed + wobbleY;
                leaf.Rotation += leaf.RotationSpeed;

                // Применяем трансформации
                Canvas.SetLeft(leaf.Shape, leaf.X);
                Canvas.SetTop(leaf.Shape, leaf.Y);
                ((RotateTransform)leaf.Shape.RenderTransform).Angle = leaf.Rotation;

                // Если лист упал за пределы экрана, удаляем его
                if (leaf.Y > MainCanvas.ActualHeight + 20 ||
                    leaf.X < -20 ||
                    leaf.X > MainCanvas.ActualWidth + 20)
                {
                    MainCanvas.Children.Remove(leaf.Shape);
                    _leaves.RemoveAt(i);
                    // Можно создать новый лист вместо удаленного
                    if (_random.NextDouble() > 0.3) CreateLeaf();
                }
            }
        }
    }

    public class Leaf
    {
        public Path Shape { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Rotation { get; set; }
        public double RotationSpeed { get; set; }
        public double HorizontalSpeed { get; set; }
        public double VerticalSpeed { get; set; }
        public double WindInfluence { get; set; }
        public double WobbleX { get; set; }
        public double WobbleY { get; set; }
        public double WobbleSpeed { get; set; }
        public double TimeOffset { get; set; }
    }
}
