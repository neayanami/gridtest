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

namespace laba7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int[] originalArray = new int[10]; // Исходный массив (не изменяется)
        private int[] currentArray; // Массив для операций

        public MainWindow()
        {
            InitializeComponent();
            InitializeArray();
            ResetArrays();
            UpdateArrayDisplay();
        }

        // Инициализация массива значениями от 1 до 10
        private void InitializeArray()
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = i + 1;
            }
        }

        // Сброс currentArray к исходному состоянию
        private void ResetArrays()
        {
            currentArray = (int[])originalArray.Clone();
        }

        // Обновление отображения массивов
        private void UpdateArrayDisplay()
        {
            OriginalArrayTextBlock.Text = string.Join(", ", originalArray);
            ShiftedArrayTextBlock.Text = string.Join(", ", currentArray);
        }

        // Обработчик нажатия кнопки сдвига
        private void ShiftButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentArray.Length == 0) return;

            // Сохраняем первый элемент
            int firstElement = currentArray[0];

            // Сдвигаем все элементы влево
            for (int i = 0; i < currentArray.Length - 1; i++)
            {
                currentArray[i] = currentArray[i + 1];
            }

            // Помещаем первый элемент в конец
            currentArray[currentArray.Length - 1] = firstElement;

            // Обновляем отображение
            UpdateArrayDisplay();
        }

        // Обработчик кнопки сброса
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetArrays();
            UpdateArrayDisplay();
        }
    }
}
