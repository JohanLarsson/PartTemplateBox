namespace PartTemplateBox
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnSwapTemplateClick(object sender, RoutedEventArgs e)
        {
            this.FooControl.ChangeTemplate();
        }
    }
}
