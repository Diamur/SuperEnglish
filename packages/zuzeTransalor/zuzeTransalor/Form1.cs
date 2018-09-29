using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using Google.API.Translate;
using System.Globalization;
using System.Diagnostics;

namespace zuzeTransalor
{
    public partial class Form1 : Form
    {
        public bool Autodetect;
        public string TranslateYourText(string text, string langFrom, string langTo)
        {
            string translated = "";
            Console.WriteLine(text);
            try
            {
                TranslateClient client = new TranslateClient("");
                Language lang1 = Language.English;
                Language lang2 = Language.Arabic;
                foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
                {
                    if (ci.EnglishName == langFrom)
                    {
                        lang1 = ci.Name;
                    }
                    if (ci.EnglishName == langTo)
                    {
                        lang2 = ci.Name;
                    }
                }
                if (Autodetect == true)
                {
                    string from;
                    translated = client.TranslateAndDetect(text, lang2.ToString(), out from);
                    foreach (string options in Language.GetEnums())
                    {
                        if (options == from)
                        {
                            CultureInfo ci = new CultureInfo(from);
                            combo_from.Text = ci.EnglishName;
                        }

                    }
                }
                else
                {
                    translated = client.Translate(text, lang1, lang2, TranslateFormat.Text);
                    Console.WriteLine(translated);
                }
                return translated;
            }
            catch
            {
                MessageBox.Show(this, "Check Your Internet Connection","Try Again Please",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return translated;
            }
        }
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chk_ontop.Checked = false;
        }

        private void btn_open_Click(object sender, EventArgs e)
        {

            OpenDialog.Title = "Open Your Text";
            OpenDialog.Filter = "Text Files|*.txt|Microsoft Word Documents|*.doc";
            OpenDialog.FilterIndex = 1;
            OpenDialog.InitialDirectory = "C:";
            OpenDialog.RestoreDirectory = false;
            OpenDialog.CheckFileExists = true;
            OpenDialog.CheckPathExists = true;
            OpenDialog.Multiselect = true;
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                string txt = OpenDialog.FileName;
                txt_from.Text = File.ReadAllText(txt);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Stream txtStreamWriter;
            SaveDialog.Title = "Save Your Translated Texr";
            SaveDialog.Filter = "Text Files|*.txt";
            SaveDialog.RestoreDirectory = true;
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                if ((txtStreamWriter = SaveDialog.OpenFile()) != null)
                {
                    StreamWriter texttt = new StreamWriter(txtStreamWriter);
                    texttt.Write(txt_to.Text,DateTime.Today.ToString());
                    texttt.Close();
                }
            }
        }

        private void combo_from_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < Google.API.Translate.Language.TranslatableCollection.Count(); i++)
            {
                combo_from.Items.Add(Google.API.Translate.Language.TranslatableCollection.ElementAt(i).ToString());
            }

        }

        private void combo_to_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < Google.API.Translate.Language.TranslatableCollection.Count(); i++)
            {
                combo_to.Items.Add(Google.API.Translate.Language.TranslatableCollection.ElementAt(i).ToString());
            }
        }

        private void btn_switch_Click(object sender, EventArgs e)
        {
            string LangFrom = combo_from.Text;
            string LangTo = combo_to.Text;
            combo_from.Text = LangTo;
            combo_to.Text = LangFrom;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

        }

        private void btn_translate_Click(object sender, EventArgs e)
        {
            txt_to.Clear();
            if (txt_from.Text == "")
            {
                MessageBox.Show(this, "Please type your text or use Open to bring your text", "No Text", MessageBoxButtons.OK);
            }
            else
            {
                if (combo_from.Text == "" && combo_to.Text == "")
                {
                    MessageBox.Show(this, "Please , Pick the language u want from boxes above" + "\n" + "Fill 'Form' and 'To'", "Find Languages You Want", MessageBoxButtons.OK);
                }
                else
                {
                    string translated = TranslateYourText(txt_from.Text, combo_from.Text, combo_to.Text);
                    txt_to.Text = translated;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            if (txt_to.Text == "")
            {
                MessageBox.Show("Nothing To Be Copied");
            }
            else
            {
                Clipboard.SetText(txt_to.Text);
            }
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            chk_ontop.Checked = false;
            Help help = new Help();
            help.Show();
        }

        private void chk_ontop_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ontop.Checked == true)
            {
                this.TopMost = true;
            }

            if (chk_ontop.Checked == false)
            {
                this.TopMost = false;
            }
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            chk_ontop.Checked = false;
            About about = new About();
            about.Show();

        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            if (btn_about.Checked == true)
            {
                Autodetect = true;
            }
            if (btn_about.Checked == false)
            {
                Autodetect = false;
            }
        }

        private void clearSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_from.Clear();
        }

        private void clearTranslatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_to.Clear();
        }

        private void copySourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            txt_to.Copy();
        }

        private void copySourceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            txt_from.Copy();
        }

        private void fontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = txt_from.Font;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txt_from.Font = fontDialog.Font;
                txt_to.Font = fontDialog.Font;
            }
        }
    }
}
