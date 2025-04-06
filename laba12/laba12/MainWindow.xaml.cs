using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WriteableBitmap _originalBitmap;
        private WriteableBitmap _processedBitmap;

        public MainWindow()
        {
            InitializeComponent();
            LoadImage("cc.jpg"); // Замените на путь к вашему изображению
        }

        private void LoadImage(string filePath)
        {
            try
            {
                var bitmap = new BitmapImage(new Uri(filePath, UriKind.RelativeOrAbsolute));
                _originalBitmap = new WriteableBitmap(bitmap);
                _processedBitmap = new WriteableBitmap(_originalBitmap);
                ImageDisplay.Source = _processedBitmap;

                // Активируем кнопки после загрузки изображения
                RedChannelButton.IsEnabled = true;
                GreenChannelButton.IsEnabled = true;
                BlueChannelButton.IsEnabled = true;
                ResetButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
            }
        }

        private void ZeroChannel(Func<Color, Color> channelProcessor)
        {
            if (_originalBitmap == null) return;

            int width = _originalBitmap.PixelWidth;
            int height = _originalBitmap.PixelHeight;
            int stride = width * 4; // 4 bytes per pixel (BGRA)

            byte[] pixels = new byte[height * stride];
            _originalBitmap.CopyPixels(pixels, stride, 0);

            // Обрабатываем каждый пиксель
            for (int i = 0; i < pixels.Length; i += 4)
            {
                Color originalColor = Color.FromArgb(
                    pixels[i + 3], // A
                    pixels[i + 2], // R
                    pixels[i + 1], // G
                    pixels[i]      // B
                );

                Color processedColor = channelProcessor(originalColor);

                pixels[i] = processedColor.B;     // Blue
                pixels[i + 1] = processedColor.G; // Green
                pixels[i + 2] = processedColor.R; // Red
                // Alpha канал оставляем без изменений
            }

            // Применяем изменения к изображению
            _processedBitmap.WritePixels(
                new Int32Rect(0, 0, width, height),
                pixels,
                stride,
                0
            );

            ImageDisplay.Source = _processedBitmap;
        }

        // Обработчики кнопок
        private void RedChannelButton_Click(object sender, RoutedEventArgs e)
        {
            ZeroChannel(color => Color.FromArgb(color.A, 0, color.G, color.B));
        }

        private void GreenChannelButton_Click(object sender, RoutedEventArgs e)
        {
            ZeroChannel(color => Color.FromArgb(color.A, color.R, 0, color.B));
        }

        private void BlueChannelButton_Click(object sender, RoutedEventArgs e)
        {
            ZeroChannel(color => Color.FromArgb(color.A, color.R, color.G, 0));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (_originalBitmap != null)
            {
                _processedBitmap = new WriteableBitmap(_originalBitmap);
                ImageDisplay.Source = _processedBitmap;
            }
        }
    }
}
