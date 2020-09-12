using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;

namespace Testapp
{
    public partial class Benisvergleich : Form
    {
        private bool isBanned;
        private string user;
        private int benis;
        private string userLink;
        private int bannedUntil;

        public Benisvergleich()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = userInput.Text;
            isBanned = bannedInput.Checked;
            benis = Convert.ToInt32(benisInput.Value);
            userLink = "https://pr0gramm.com/user/" + user;

            if (String.IsNullOrEmpty(user))
            {
                MessageBox.Show("Bitte gib einen Benutzernamen an!", "Oh Neim...!");
            }
            else
            {
                async Task getUser()
                {
                    try
                    {
                        var httpClient = new HttpClient();
                        var request = new HttpRequestMessage(new HttpMethod("GET"), "https://pr0gramm.com/api/profile/info?name=" + user);

                        var response = await httpClient.SendAsync(request);
                        MessageBox.Show("erfolgreich!", "Debug");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Oh Neim...!");
                    }

                }

                if (isBanned)
                {
                    MessageBox.Show(user + " wurde gebannert!", "Oh Neim...!");

                }

                output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + Environment.NewLine + user + " hat " + benis + " Benis");
                output.Enabled = true;
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void benisInput_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
