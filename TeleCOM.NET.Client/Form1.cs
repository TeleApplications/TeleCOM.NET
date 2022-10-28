using TeleCOM.NET.API.Interops;

namespace TeleCOM.NET.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InteropManager.SetParent(this.Handle, new IntPtr(-3));
            RawInputListener inputListener = new(this);
        }
    }
}