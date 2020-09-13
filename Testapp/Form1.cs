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
using System.Reflection;


namespace Testapp
{
    public partial class Benisvergleich : Form
    {
        private const string V = "1.2.2";
        public string version;
        public string userdata;
        public string user;
        public string userLink;
        public string rank;

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

                    // Dertermine User Rank
                    int mark = userinfo.user.mark;
                    if (mark == 0)
                    {
                        rank = "Schwuchtel";
                    }
                    else if (mark == 1)
                    {
                        rank = "Neuschwuchtel";
                    }
                    else if (mark == 2)
                    {
                        rank = "Altschwuchtel";
                    }
                    else if (mark == 3)
                    {
                        rank = "Admin";
                    }
                    else if (mark == 4)
                    {
                        rank = "Gesperrt";
                    }
                    else if (mark == 5)
                    {
                        rank = "Moderator";
                    }
                    else if (mark == 6)
                    {
                        rank = "Fliesentischbesitzer";
                    }
                    else if (mark == 7)
                    {
                        rank = "Lebende Legende";
                    }
                    else if (mark == 8)
                    {
                        rank = "Wichtler";
                    }
                    else if (mark == 9)
                    {
                        rank = "Edler Spender";
                    }
                    else if (mark == 10)
                    {
                        rank = "Mittelaltschwuchtel";
                    }
                    else if (mark == 11)
                    {
                        rank = "Alt-Moderator";
                    }
                    else if (mark == 12)
                    {
                        rank = "Community-Helfer";
                    }
                    else if (mark == 13)
                    {
                        rank = "Nutzer-Bot";
                    }
                    else if (mark == 14)
                    {
                        rank = "System-Bot";
                    }
                    else if (mark == 15)
                    {
                        rank = "Alt-Helfer";
                    }

                    // Check if User is banned 
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

                            // Create Output user time banned
                            output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + Environment.NewLine + user + " hat " + userinfo.user.score + " Benis" + Environment.NewLine + "Gebannt bis: " + printDate);
                            output.Enabled = true;
                        }
                        else
                        {
                            // Create Output user perma banned
                            output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + Environment.NewLine + user + " hat " + userinfo.user.score + " Benis" + Environment.NewLine + user + " ist für immer gebannt");
                            output.Enabled = true;
                        }
                    }
                    else
                    {

                        // Create output if user not banned"
                        output.Text = ("Der Link zum Profil von " + user + " lautet:" + Environment.NewLine + Environment.NewLine + userLink + Environment.NewLine + "Rang: " + rank + Environment.NewLine + user + " hat " + userinfo.user.score + " Benis" + Environment.NewLine + "Upvotes:" + userinfo.user.up + Environment.NewLine + "Downvotes:" + userinfo.user.down);
                        output.Visible = true;
                    }
                }
                else
                {
                    // Getting data out of json file
                    dynamic errorInfo;
                    errorInfo = JsonConvert.DeserializeObject(userdata);
                    output.Text = ("¯\\_(ツ)_/¯ ZOMG, Fehler" + Environment.NewLine + Environment.NewLine + "Irgendwas doofes ist passiert!" + Environment.NewLine + errorInfo.code + Environment.NewLine + errorInfo.msg);
                    output.Visible = true;
                }

            }
        }
        //A small Easteregg - Do not tell anyone
        private void versionlabel_Click(object sender, EventArgs e)
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            if (today == DayOfWeek.Wednesday)
            {
                MessageBox.Show("Es ist Mittwoch meine Kerle!", "froschler sagt:");
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

        private void infoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Entwickelt von: Schnitzelt0ast" + Environment.NewLine + "Weiterverbreitung nur über das GitHub von Schnitzelt0ast oder das Updatesystem von Schnitzelt0ast" + Environment.NewLine + "Dank an:" + Environment.NewLine + "5yn74x - Beratung Rangausgabe" + Environment.NewLine + "KnorkeKurbel - Betatester und Fehlerreport" + Environment.NewLine + "Pleitegrieche - Betatester", "Info über den pr0gramm-Stelzer");
        }
    }
}
