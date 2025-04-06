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

namespace laba9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawShapes();
        }

        private void DrawShapes()
        {
            mainCanvas.Children.Clear();

            // 1. Линии с разными стилями
            DrawLine(new Point(10, 10), new Point(200, 10), Brushes.Red, 2, new DoubleCollection { 1, 0 }); // Solid
            DrawLine(new Point(10, 30), new Point(200, 30), Brushes.Green, 2, new DoubleCollection { 2, 1 }); // Dash
            DrawLine(new Point(10, 50), new Point(200, 50), Brushes.Blue, 2, new DoubleCollection { 0, 1 }); // Dot
            DrawLine(new Point(10, 70), new Point(200, 70), Brushes.Purple, 2, new DoubleCollection { 2, 1, 0, 1 }); // DashDot
            DrawLine(new Point(10, 90), new Point(200, 90), Brushes.Orange, 2, new DoubleCollection { 2, 1, 0, 1, 0, 1 }); // DashDotDot

            // 2. Прямоугольники (закрашенные и нет)
            DrawRectangle(new Rect(220, 10, 80, 60), Brushes.Black, 1, new DoubleCollection { 1, 0 }, null);
            DrawRectangle(new Rect(320, 10, 80, 60), Brushes.Transparent, 2, new DoubleCollection { 2, 1 }, Brushes.LightBlue);
            DrawRectangle(new Rect(420, 10, 80, 60), Brushes.Transparent, 3, new DoubleCollection { 0, 1 }, Brushes.LightGreen);

            // 3. Эллипсы (закрашенные и нет)
            DrawEllipse(new Point(260, 150), 40, 30, Brushes.Black, 1, new DoubleCollection { 1, 0 }, null);
            DrawEllipse(new Point(360, 150), 40, 30, Brushes.Black, 2, new DoubleCollection { 2, 1 }, Brushes.Pink);
            DrawEllipse(new Point(460, 150), 40, 30, Brushes.Black, 3, new DoubleCollection { 0, 1 }, Brushes.Yellow);

            // 4. Многоугольники (закрашенные и нет)
            Point[] trianglePoints = { new Point(220, 220), new Point(260, 280), new Point(180, 280) };
            DrawPolygon(trianglePoints, Brushes.DarkBlue, 2, new DoubleCollection { 1, 0 }, Brushes.LightSkyBlue);

            Point[] pentagonPoints = {
                new Point(350, 220),
                new Point(380, 240),
                new Point(370, 270),
                new Point(330, 270),
                new Point(320, 240)
            };
            DrawPolygon(pentagonPoints, Brushes.DarkGreen, 2, new DoubleCollection { 2, 1, 0, 1 }, Brushes.LightGreen);

            // 5. Сложная фигура - звезда
            Point[] starPoints = new Point[10];
            double centerX = 500, centerY = 250;
            double outerRadius = 40, innerRadius = 20;

            for (int i = 0; i < 10; i++)
            {
                double angle = Math.PI * 2 * i / 10;
                double radius = i % 2 == 0 ? outerRadius : innerRadius;
                starPoints[i] = new Point(
                    centerX + radius * Math.Cos(angle - Math.PI / 2),
                    centerY + radius * Math.Sin(angle - Math.PI / 2));
            }
            DrawPolygon(starPoints, Brushes.DarkGoldenrod, 2, new DoubleCollection { 1, 0 }, Brushes.Gold);
        }

        private void DrawLine(Point start, Point end, Brush strokeBrush, double thickness, DoubleCollection dashArray)
        {
            Line line = new Line
            {
                X1 = start.X,
                Y1 = start.Y,
                X2 = end.X,
                Y2 = end.Y,
                Stroke = strokeBrush,
                StrokeThickness = thickness,
                StrokeDashArray = dashArray,
                StrokeDashCap = PenLineCap.Round 
            };
            mainCanvas.Children.Add(line);
        }

        private void DrawRectangle(Rect rect, Brush strokeBrush, double thickness, DoubleCollection dashArray, Brush fillBrush)
        {
            Rectangle rectangle = new Rectangle
            {
                Width = rect.Width,
                Height = rect.Height,
                Stroke = strokeBrush,
                StrokeThickness = thickness,
                StrokeDashArray = dashArray,
                StrokeDashCap = PenLineCap.Round,
                Fill = fillBrush
            };
            Canvas.SetLeft(rectangle, rect.X);
            Canvas.SetTop(rectangle, rect.Y);
            mainCanvas.Children.Add(rectangle);
        }

        private void DrawEllipse(Point center, double radiusX, double radiusY, Brush strokeBrush, double thickness, DoubleCollection dashArray, Brush fillBrush)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = radiusX * 2,
                Height = radiusY * 2,
                Stroke = strokeBrush,
                StrokeThickness = thickness,
                StrokeDashArray = dashArray,
                StrokeDashCap = PenLineCap.Round,
                Fill = fillBrush
            };
            Canvas.SetLeft(ellipse, center.X - radiusX);
            Canvas.SetTop(ellipse, center.Y - radiusY);
            mainCanvas.Children.Add(ellipse);
        }

        private void DrawPolygon(Point[] points, Brush strokeBrush, double thickness, DoubleCollection dashArray, Brush fillBrush)
        {
            Polygon polygon = new Polygon
            {
                Stroke = strokeBrush,
                StrokeThickness = thickness,
                StrokeDashArray = dashArray,
                StrokeDashCap = PenLineCap.Round,
                Fill = fillBrush
            };

            foreach (Point point in points)
            {
                polygon.Points.Add(point);
            }

            mainCanvas.Children.Add(polygon);
        }
    }
}
