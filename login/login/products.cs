using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class products : Form
    {
        // Load neccessities.
        GlobalMethods GlobalMethods = new GlobalMethods();
        connection connection = new connection();
        DataLayer DataLayer = new DataLayer();

        int Yposition = 1;

        public products()
        {
            InitializeComponent();
        }

        private void products_Load(object sender, EventArgs e)
        {
            DataTable aa = DataLayer.Query("SELECT brand, category FROM discount_offers", p => { });
            DataRow[] row = aa.Select();
            for (int i = 0; i < row.Length; i++)
            {
                //components
                Panel itemContainer = new Panel();
                PictureBox itemImg = new PictureBox();
                Label itemName = new Label();
                Button itemBtn = new Button();
                //options
                itemContainer.BackColor = SystemColors.ControlDark;
                itemContainer.Height = 100;
                itemContainer.Width = 500;
                itemContainer.Top = Yposition * 112;
                itemContainer.Left = 12;

                //itemImg.Image = Properties.Resources.albert_heijn;
                //itemImg.SizeMode = PictureBoxSizeMode.Zoom;
                //itemImg.Top = 10;
                //itemImg.Left = 10;
                //itemImg.Width = 80;
                //itemImg.Height = 80;

                itemName.Text = row[i][0].ToString();
                itemName.Top = 10;
                itemName.Left = 110;

                itemBtn.Text = row[i][1].ToString();
                itemBtn.BackColor = SystemColors.Control;
                itemBtn.Width = 80;
                itemBtn.Top = 10;
                itemBtn.Left = 410;

                //move next item down
                Yposition++;
                //add panel
                this.Controls.Add(itemContainer);
                //add controls inside panel
                itemContainer.Controls.Add(itemImg);
                itemContainer.Controls.Add(itemName);
                itemContainer.Controls.Add(itemBtn);

                //MessageBox.Show(row[i][1].ToString());
            }
        }
    }
}
