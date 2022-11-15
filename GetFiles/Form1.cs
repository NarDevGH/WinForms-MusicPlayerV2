using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFiles
{
    public partial class Form1 : Form
    {
        private readonly Random random = new Random();
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer() ;

        List<string> mp3s = new List<string>();
        private string currentMp3 = "",newMp3 = "";
        private bool playing = false;


        public Form1()
        {
            InitializeComponent();
        }


        private List<string> GetMP3s() {
            List<string> mp3sAct = new List<string>();
            string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            foreach (string file in files)
            {
                if (file.EndsWith(".mp3")) {
                    mp3sAct.Add(file);
                    label1.Text += file + "\n";
                }
            }

            return mp3sAct;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                mp3s = GetMP3s();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (playing)
                player.controls.pause();
            else
                player.controls.play();

            playing = !playing;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            playing = false;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            player.settings.volume = trackBar1.Value;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            while (currentMp3 == newMp3)
                newMp3 = mp3s[random.Next(0, mp3s.Count)];
            currentMp3 = newMp3;
            label1.Text = currentMp3;
            player.URL = currentMp3;
            player.settings.volume = trackBar1.Value;
        }
    }
}
