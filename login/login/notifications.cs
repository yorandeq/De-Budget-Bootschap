using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace login
{
    public partial class notifications : Form
    {
        public notifications()
        {
            InitializeComponent();
        }

        private void showTestNotification_Click(object sender, EventArgs e)
        {
            PopupNotifier PopUp = new PopupNotifier();
            PopUp.TitleText = "This is a test title.";
            PopUp.ContentText = "This is a test message.";
            PopUp.Popup();
        }
    }
}
