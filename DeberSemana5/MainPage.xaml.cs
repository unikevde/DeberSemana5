namespace DeberSemana5
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                ContBtn.Text = $"Clicked {count} time";
            else
                ContBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(ContBtn.Text);
        }
    }

}
