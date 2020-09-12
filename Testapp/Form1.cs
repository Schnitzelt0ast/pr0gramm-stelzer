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
        private const string V = "1.0.0";
        public string version;
        public string userdata;
        private bool isBanned;
        private string user;
        private int benis;
        private string userLink;
        private int bannedUntil;

        public Benisvergleich()
        {
            InitializeComponent();
            version = V;
            versionlabel.Text = "v. " + version;
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            //DEBUG - Might be changed - Generate example Data
            user = userInput.Text;
            isBanned = false;
            // benis = Convert.ToInt32(benisInput.Value);
            benis = 13370815;
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
                try
                {
                    var httpClient = new HttpClient();
                    var request = new HttpRequestMessage(new HttpMethod("GET"), "https://pr0gramm.com/api/profile/info?name=" + user);

                    var response = await httpClient.SendAsync(request);
                    userdata = await response.Content.ReadAsStringAsync();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Oh Neim...!");
                }
                // Check if User found
                if (userdata != "{\"error\": \"notFound\", \"code\": 404, \"msg\": \"Not Found\"}")
                {


                    // Check if User is banned - TODO: - Convert "Banned Until" - Visualize in Output
                    if (isBanned)
                    {
                        MessageBox.Show(user + " wurde gebannert!", "Oh Neim...!");

                    }
                    // Create final output - TODO: - Find a Way to show "Banned" and "Banned Until"
                    output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + Environment.NewLine + user + " hat " + benis + " Benis");
                    output.Enabled = true;
                }
                else
                {
                    output.Text = ("¯\\_(ツ)_/¯ ZOMG, Fehler" + Environment.NewLine + "Irgendwas doofes ist passiert!" + Environment.NewLine + "Der User " + user + " konnte nicht gefunden werden!");
                    output.Enabled = true;
                }

            }
        }
        //But this should exist - A small Easteregg - Do not tell anyone
        private void versionlabel_Click(object sender, EventArgs e)
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            if (today == DayOfWeek.Wednesday)
            {
                MessageBox.Show("Es ist Mittwoch meine Kerle!", "Memes!");
            }
            else if (today == DayOfWeek.Friday)
            {
                MessageBox.Show("Es ist Haitag mein Bursche!", "pr0gramm sagt:");
            }
            else if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
            {
                MessageBox.Show("Es ist ROCHENENDE!!!!!!!!!!!!!!!!!", "Hoch die Hände");
            }
            else
            {
                MessageBox.Show("Komm in ein paar Tagen wieder!", "Hey! Geh weg!");
            }
        }
    }
}
