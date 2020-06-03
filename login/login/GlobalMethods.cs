﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace login
{
    class GlobalMethods
    {
        // Used to store login session info.
        public static class LoginInfo
        {
            public static int UserID;
            public static string Username;
        }

        // Method for switching forms quickly.
        public void SwitchForm(dynamic newForm)
        {
            var NotificationsForm = new notifications();
            Form.ActiveForm.Hide();
            newForm.Show();
        }

        // Method for creating a popup notification.
        public void ShowPopupNotification(string titleText, string contentText, int PopupDuration)
        {
            PopupNotifier PopUp = new PopupNotifier();
            PopUp.TitleText = titleText;
            PopUp.ContentText = contentText;
            PopUp.Delay = PopupDuration;
            PopUp.Popup();
        }
    }
}
