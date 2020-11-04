using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async void Banana()
        {
            Title = "Zero seconds have passed.";
            await Task.Delay(1000).ConfigureAwait(false);
            Title = "One second has passed.";
            await Task.Delay(1000).ConfigureAwait(false);
            Title = "Two seconds have passed.";
            await Task.Delay(1000).ConfigureAwait(false);
            Title = "Three seconds have passed.";
            await Task.Delay(1000).ConfigureAwait(false);
            Title = "Four seconds have passed.";
            await Task.Delay(1000).ConfigureAwait(false);
            Title = "Five seconds have passed.";
        }

        public async void Pear()
        {
            await Task.Delay(1000).ConfigureAwait(false);
            MenuModel.FrameText = "Here's some text that should appear in the bottom right corner after one second.";
        }
    }
}