namespace TeleCOM.NET.TestProject
{
    public partial class Form1 : Form
    {
        private KeyboardListener keyboardListener;
        public Form1()
        {
            InitializeComponent();
            keyboardListener = new();
            Task.Run(async() => await keyboardListener.StartRecievingAsync());
        }
    }
}