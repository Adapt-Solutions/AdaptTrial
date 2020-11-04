using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AdaptTrial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var buttonDataContext = (string) button.DataContext;
            var method = typeof(MainWindow).GetMethod(buttonDataContext) ?? throw new Exception($"Couldn't find the method with the name '{buttonDataContext}'.");
            method.Invoke(this, null);
        }

        public void Apple()
        {
            var sequence = new List<int> {0, 1, 1, 2, 3, 5, 8, 13};
            var last = 7;

            for (var i = 0; i < 10; i++)
            {
                sequence.Add(sequence[1 - last] + sequence[last]);
                last++;
            }

            MenuModel.OutputText = $"The first {sequence.Count} numbers of the Fibonacci sequence are:" + string.Join(", ", sequence.Select(x => x.ToString()));
        }

        public static void Banana()
        {
        }

        public static void Pear()
        {
        }
    }
}