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

namespace laba6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SwapButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = ""; // Очищаем Label

            if (InputListBox.Items.Count == 0)
            {
                ResultLabel.Content = "Список строк пуст!";
                return;
            }

            foreach (var item in InputListBox.Items)
            {
                string originalText = item is ListBoxItem listBoxItem
                    ? listBoxItem.Content.ToString()
                    : item.ToString();

                string processedText = SwapFirstAndLastLetters(originalText);
                ResultLabel.Content += $"{processedText}\n";
            }
        }

        private string SwapFirstAndLastLetters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 1)
                {
                    char firstChar = words[i][0];
                    char lastChar = words[i][words[i].Length - 1]; // Получаем последний символ

                    // Формируем новое слово:
                    // 1. Последний символ
                    // 2. Подстрока без первого и последнего символа
                    // 3. Первый символ
                    words[i] = lastChar +
                              words[i].Substring(1, words[i].Length - 2) +
                              firstChar;
                }
            }

            return string.Join(" ", words);
        }
    }
}