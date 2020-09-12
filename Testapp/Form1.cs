using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Testapp
{
    public partial class Benisvergleich : Form
    {
        private const string V = "1.0.0";
        public string version;
        public string userdata;
        public string user;
        public string userLink;
        //public int bannedUntil;

        public Benisvergleich()
        {
            InitializeComponent();
            version = V;
            versionlabel.Text = "v. " + version;
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            user = userInput.Text;
            //generate Userlink
            userLink = "https://pr0gramm.com/user/" + user;

            // First check if there is a Username entered - Throw Error if not!
            if (String.IsNullOrEmpty(user))
            {
                MessageBox.Show("Irgendwas doofes ist passiert!" + Environment.NewLine + Environment.NewLine + "Bitte gib einen Benutzernamen an!", "¯\\_(ツ)_ /¯ ZOMG, Fehler");
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
                    MessageBox.Show("Irgendwas doofes ist passiert!" + Environment.NewLine + exception.Message, "¯\\_(ツ)_/¯ ZOMG, Fehler");
                }
                // Check if User found
                if (userdata != "{\"error\": \"notFound\", \"code\": 404, \"msg\": \"Not Found\"}")
                {

                    // Getting data out of json file
                    dynamic userinfo;
                    userinfo = JsonConvert.DeserializeObject(userdata);

                    // Check if User is banned - TODO: - Convert "Banned Until" - Visualize in Output
                    if (userinfo.user.banned != "0")
                    {
                        MessageBox.Show(user + " wurde gebannert!", "Oh Neim...!");
                        if (userinfo.user.bannedUntil != null)
                        {
                            // calculate time, how long the user is banned
                            // convert Output from json to timestamp
                            double timestamp = Convert.ToDouble(userinfo.user.bannedUntil);
                            // First make a System.DateTime equivalent to the UNIX Epoch.
                            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

                            // Add the number of seconds in UNIX timestamp to be converted.
                            dateTime = dateTime.AddSeconds(timestamp);

                            // The dateTime now contains the right date/time so to format the string,
                            // use the standard formatting methods of the DateTime object.
                            string printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();

                            output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + Environment.NewLine + user + " hat " + userinfo.user.score + " Benis" + Environment.NewLine + "Gebannt bis: " + printDate);
                            output.Enabled = true;
                        }
                        else
                        {
                            output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + Environment.NewLine + user + " hat " + userinfo.user.score + " Benis" + Environment.NewLine + user + " ist für immer gebannt");
                            output.Enabled = true;
                        }
                    }
                    else
                    {
                        // Create final output - TODO: - Find a Way to show "Banned" and "Banned Until"
                        output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + Environment.NewLine + user + " hat " + userinfo.user.score + " Benis");
                        output.Enabled = true;
                    }
                }
                else
                {
                    output.Text = ("¯\\_(ツ)_/¯ ZOMG, Fehler" + Environment.NewLine + Environment.NewLine + "Irgendwas doofes ist passiert!" + Environment.NewLine + "Der User " + user + " konnte nicht gefunden werden!");
                    output.Enabled = true;
                }

            }
        }
        //A small Easteregg - Do not tell anyone
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
