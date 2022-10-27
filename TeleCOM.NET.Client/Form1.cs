using TeleCOM.NET.API.Interops;

namespace TeleCOM.NET.Client
{
    public partial class Form1 : Form
    {
        private RawInputListener inputListener = new();
        public Form1()
        {
            InitializeComponent();
            InteropManager.SetParent(this.Handle, new(-3));
            Task.Run(async() => await inputListener.StartRecievingAsync());
        }

        protected override void WndProc(ref Message m)
        {
            inputListener.CurrentMessage = new(m.HWnd, (uint)m.Msg, m.WParam, m.LParam, 0);
            base.WndProc(ref m);
        }
    }
}