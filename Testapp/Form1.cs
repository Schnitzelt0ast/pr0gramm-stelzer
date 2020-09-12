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
        public string version;
        private bool isBanned;
        private string user;
        private int benis;
        private string userLink;
        private int bannedUntil;

        public Benisvergleich()
        {
            InitializeComponent();
            version = "0.2 - ALPHA";
            versionlabel.Text = "v. " + version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DEBUG - Might be changed - Generate example Data
            user = userInput.Text;
            isBanned = bannedInput.Checked;
            benis = Convert.ToInt32(benisInput.Value);
            //generate Userlink
            userLink = "https://pr0gramm.com/user/" + user;

            // First check if there is a Username entered - Throw Error if not!
            if (String.IsNullOrEmpty(user))
            {
                MessageBox.Show("Bitte gib einen Benutzernamen an!", "Oh Neim...!");
            }
            else
            {
                // Get the Userdata from pr0gramm.com/api
                // This is what I am too stupid for ^^
                async Task getUser()
                {
                    try
                    {
                        var httpClient = new HttpClient();
                        var request = new HttpRequestMessage(new HttpMethod("GET"), "https://pr0gramm.com/api/profile/info?name=" + user);

                        var response = await httpClient.SendAsync(request);
                        // Might be removed
                        MessageBox.Show("erfolgreich!", "Debug");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Oh Neim...!");
                    }

                }
                // Check if User is banned - TODO: - Convert "Banned Until" - Visualize in Output
                if (isBanned)
                {
                    MessageBox.Show(user + " wurde gebannert!", "Oh Neim...!");

                }
                // Create final output - TODO: - Find a Way to show "Banned" and "Banned Until"
                output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + Environment.NewLine + user + " hat " + benis + " Benis");
                output.Enabled = true;
            }

        }
        //those functions should not exist
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void benisInput_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
