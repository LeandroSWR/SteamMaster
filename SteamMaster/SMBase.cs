using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;

namespace SteamMaster
{
    public partial class SMBase : Form
    {
        private long _UserID;

        private IconButton _CurrentButton;
        private Panel _LeftBorderBtn;
        private Form _CurrentChildForm;

        private Size _FormSize;

        private int _BorderSize;

        public SMBase(long userID)
        {
            this._UserID = userID;

            InitializeComponent();

            _LeftBorderBtn = new Panel();
            _LeftBorderBtn.Size = new Size(7, 60);
            _LeftBorderBtn.BackColor = Color.Gainsboro;
            _PanelSideMenu.Controls.Add(_LeftBorderBtn);
            ActivateButton(_BttMain);
            OpenChildForm(new SMMain());

            // Form
            _BorderSize = 3;
            this.Padding = new Padding(_BorderSize);
            this.BackColor = Color.FromArgb(36, 40, 47);
            _FormSize = this.ClientSize;
        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                // Disable Previous button before activating new one;
                DisableButton();

                // Modify button style
                _CurrentButton = (IconButton)senderBtn;
                _CurrentButton.BackColor = Color.FromArgb(62, 78, 105);
                _CurrentButton.TextAlign = ContentAlignment.MiddleCenter;
                _CurrentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                _CurrentButton.ImageAlign = ContentAlignment.MiddleRight;

                // Left border button
                _LeftBorderBtn.BackColor = Color.Gainsboro;
                _LeftBorderBtn.Location = new Point(0, _CurrentButton.Location.Y);
                _LeftBorderBtn.Visible = true;
                _LeftBorderBtn.BringToFront();

                _IconCurrentTab.IconChar = _CurrentButton.IconChar;
                _NameCurrentTab.Text = _CurrentButton.Text;
            }
        }

        private void DisableButton()
        {
            if (_CurrentButton != null)
            {
                _CurrentButton.BackColor = Color.FromArgb(36, 40, 47);
                _CurrentButton.TextAlign = ContentAlignment.MiddleLeft;
                _CurrentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                _CurrentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (_CurrentChildForm != null)
            {
                _CurrentChildForm.Close();
            }
            _CurrentChildForm = childForm;
            _CurrentChildForm.TopLevel = false;
            _CurrentChildForm.FormBorderStyle = FormBorderStyle.None;
            _CurrentChildForm.Dock = DockStyle.Fill;
            _PanelDesktop.Controls.Add(childForm);
            _PanelDesktop.Tag = childForm;
            _CurrentChildForm.BringToFront();
            _CurrentChildForm.Show();
        }

        private void _BttMain_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new SMMain());
        }

        private void _BttSelectGame_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new SMGameSelector(_UserID));
        }

        private void _BttIdle_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        // Don't touch!
        #region FormBorderAndResising

        // Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void _PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standard Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int _ResizeAreaSize = 10;
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= _ResizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= _ResizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                            {
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            }
                            else if (clientPoint.X < (this.Size.Width - _ResizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                            {
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            }
                            else //Resize diagonally to the right
                            {
                                m.Result = (IntPtr)HTTOPRIGHT;
                            }
                        }
                        else if (clientPoint.Y <= (this.Size.Height - _ResizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= _ResizeAreaSize)//Resize horizontally to the left
                            {
                                m.Result = (IntPtr)HTLEFT;
                            }
                            else if (clientPoint.X > (this.Width - _ResizeAreaSize))//Resize horizontally to the right
                            {
                                m.Result = (IntPtr)HTRIGHT;
                            }
                        }
                        else
                        {
                            if (clientPoint.X <= _ResizeAreaSize)//Resize diagonally to the left
                            {
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            }
                            else if (clientPoint.X < (this.Size.Width - _ResizeAreaSize)) //Resize vertically down
                            {
                                m.Result = (IntPtr)HTBOTTOM;
                            }
                            else //Resize diagonally to the right
                            {
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                            }
                        }
                    }
                }
                return;
            }

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                {
                    _FormSize = this.ClientSize;
                }
                if (wParam == SC_RESTORE)// Restored form(Before)
                {
                    this.Size = _FormSize;
                }
            }
            base.WndProc(ref m);
        }

        private void SMmain_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void AdjustForm()
        {
            switch(this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != _BorderSize)
                    {
                        this.Padding = new Padding(_BorderSize);
                    }
                    break;
            }
        }

        private void _BttMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void _BttMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                _FormSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = _FormSize;
            }
        }

        private void _BttClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
