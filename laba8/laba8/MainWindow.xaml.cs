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

namespace laba8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int N = 10; // Размер матрицы 10x10

        public MainWindow()
        {
            InitializeComponent();
            GenerateAndDisplayMatrix();
        }

        private void GenerateAndDisplayMatrix()
        {
            int[,] matrix = new int[N, N];
            FillMatrixSnakePattern(matrix);

            // Создаем текстовое представление матрицы
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sb.Append(matrix[i, j].ToString().PadLeft(4));
                }
                sb.AppendLine();
            }

            MatrixTextBlock.Text = sb.ToString();
        }

        private void FillMatrixSnakePattern(int[,] matrix)
        {
            int value = 1;
            int size = matrix.GetLength(0);

            for (int layer = 0; layer < 2 * size - 1; layer++)
            {
                if (layer % 2 == 0) // Движение по диагонали вверх
                {
                    int row = Math.Min(layer, size - 1);
                    int col = layer - row;
                    while (row >= 0 && col < size)
                    {
                        matrix[row, col] = value++;
                        row--;
                        col++;
                    }
                }
                else // Движение по диагонали вниз
                {
                    int col = Math.Min(layer, size - 1);
                    int row = layer - col;
                    while (col >= 0 && row < size)
                    {
                        matrix[row, col] = value++;
                        row++;
                        col--;
                    }
                }
            }
        }

        private void RegenerateButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateAndDisplayMatrix();
        }
    }
}
