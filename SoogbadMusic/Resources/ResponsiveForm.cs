using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SoogbadMusic.Resources
{

    public class ResponsiveForm : Form
    {

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private const int DWMWA_CAPTION_COLOR = 35;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            var colorRef = ColorTranslator.ToWin32(Color.FromArgb(20, 115, 60));
            DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref colorRef, sizeof(int));
        }

        private Size initialFormSize = Size.Empty;
        private Dictionary<string, Values> initialValues = new Dictionary<string, Values>();
        private List<string> widthBlacklist = new List<string>(), heightBlacklist = new List<string>(), leftBlacklist = new List<string>(), topBlacklist = new List<string>();
        private List<Control> invisibleControls = new List<Control>();
        private List<string> changeAnchor = new List<string>();

        protected event EmptyEventHandler ResponsiveClientSizeChanged;

        protected void BlacklistControlWidth(Control control)
        {
            widthBlacklist.Add(control.Name);
        }
        protected void BlacklistControlHeight(Control control)
        {
            heightBlacklist.Add(control.Name);
        }
        protected void BlacklistControlLeft(Control control)
        {
            leftBlacklist.Add(control.Name);
        }
        protected void BlacklistControlTop(Control control)
        {
            topBlacklist.Add(control.Name);
        }

        protected void AddInvisibleControls(List<Control> controls)
        {
            invisibleControls.AddRange(controls);
            foreach(Control control in controls)
                OnControlAdded(control);
        }

        protected void AddChangeAnchorControl(Control control)
        {
            changeAnchor.Add(control.Name);
        }
        protected virtual int GetRTLExtraMargin(Control control)
        {
            return 0;
        }

        public override Size MinimumSize
        {
            get
            {
                return SizeFromClientSize(initialFormSize);
            }
        }


        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            OnControlAdded(e.Control);
        }
        private void OnControlAdded(Control control)
        {
            try
            {
                initialValues.Add(control.Name, new Values(control));
            }
            catch(ArgumentException) { }
            control.TextChanged += OnControlTextChanged;
            if(WindowState == FormWindowState.Minimized)
                return;
            MakeResponsive(control, ClientSize.Width / initialFormSize.Width, ClientSize.Height / initialFormSize.Height);
        }
        private void OnControlTextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if(control.Text == "")
                return;
            control.RightToLeft = Utility.ContainsRTLCharacters(control.Text) ? RightToLeft.Yes : RightToLeft.No;
            MakeResponsive(control, (float)ClientSize.Width / initialFormSize.Width, (float)ClientSize.Height / initialFormSize.Height);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            if(WindowState == FormWindowState.Minimized)
                return;
            if(initialFormSize.IsEmpty)
            {
                initialFormSize = ClientSize;
                return;
            }
            float horizontalFactor = (float)ClientSize.Width / initialFormSize.Width;
            float verticalFactor = (float)ClientSize.Height / initialFormSize.Height;
            foreach(Control control in Controls)
                MakeResponsive(control, horizontalFactor, verticalFactor);
            foreach(Control control in invisibleControls)
                MakeResponsive(control, horizontalFactor, verticalFactor);
            if(ResponsiveClientSizeChanged != null)
                ResponsiveClientSizeChanged();
        }

        private void MakeResponsive(Control control, float horizontalFactor, float verticalFactor)
        {
            if(horizontalFactor == 0 || verticalFactor == 0)
                return;
            string name = control.Name;
            Values init = initialValues[name];
            control.Font = new Font(control.Font.FontFamily, Math.Min(horizontalFactor, verticalFactor) * init.FontSize, control.Font.Style);
            if(!widthBlacklist.Contains(name))
                control.Width = (int)(horizontalFactor * init.Width);
            if(!heightBlacklist.Contains(name))
                control.Height = (int)(verticalFactor * init.Height);
            if(!leftBlacklist.Contains(name))
                control.Left = control.RightToLeft == RightToLeft.Yes && changeAnchor.Contains(name) ? ClientSize.Width - GetRTLExtraMargin(control) - control.Width - init.Left : (int)(horizontalFactor * init.Left);
            if(!topBlacklist.Contains(name))
                control.Top = (int)(verticalFactor * init.Top);
        }


        private struct Values
        {

            public Values(int fontSize, int width, int height, int left, int top)
            {
                FontSize = fontSize; Width = width; Height = height; Left = left; Top = top;
            }
            public Values(Control control)
            {
                FontSize = control.Font.Size; Width = control.Width; Height = control.Height; Left = control.Left; Top = control.Top;
            }

            public float FontSize { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Left { get; set; }
            public int Top { get; set; }

        }

    }

}
