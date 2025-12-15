namespace SoogbadMusic
{

    public partial class ExitDialog : Form
    {

        public ExitDialog()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Utility.SetWindowTitleBarColor(Handle);
        }

    }

}
