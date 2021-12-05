using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamMaster
{
    public partial class SMMain : Form
    {
        private const string TIME_FORMAT = "HH:mm:ss";
        private const string DATE_FORMAT = "dddd , MMM dd yyyy";

        public SMMain()
        {
            InitializeComponent();
            _TimeText.Parent = _AppLogo;
            _DateText.Parent = _TimeText;
        }

        private void OnSecondPassed(object sender, EventArgs e)
        {
            _TimeText.Text = DateTime.Now.ToString(TIME_FORMAT);
            _DateText.Text = DateTime.Now.ToString(DATE_FORMAT);

        }

        private void SMMain_Load(object sender, EventArgs e)
        {
            _TimeText.Text = DateTime.Now.ToString(TIME_FORMAT);
            _DateText.Text = DateTime.Now.ToString(DATE_FORMAT);
        }
    }
}
