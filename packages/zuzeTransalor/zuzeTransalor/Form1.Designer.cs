namespace zuzeTransalor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_open = new System.Windows.Forms.ToolStripButton();
            this.btn_save = new System.Windows.Forms.ToolStripButton();
            this.btn_auto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_help = new System.Windows.Forms.ToolStripButton();
            this.btn_about = new System.Windows.Forms.ToolStripButton();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.txt_from = new System.Windows.Forms.RichTextBox();
            this.txt_to = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.chk_ontop = new System.Windows.Forms.CheckBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.combo_from = new System.Windows.Forms.ToolStripComboBox();
            this.btn_switch = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.combo_to = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_translate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn_copy = new System.Windows.Forms.ToolStripDropDownButton();
            this.copySourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySourceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_clear = new System.Windows.Forms.ToolStripSplitButton();
            this.clearSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTranslatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_open,
            this.btn_save,
            this.btn_auto,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.btn_help,
            this.btn_about});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(704, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_open
            // 
            this.btn_open.Image = ((System.Drawing.Image)(resources.GetObject("btn_open.Image")));
            this.btn_open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(93, 32);
            this.btn_open.Text = "&Open Text";
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(98, 32);
            this.btn_save.Text = "&Save Result";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_auto
            // 
            this.btn_auto.CheckOnClick = true;
            this.btn_auto.Image = ((System.Drawing.Image)(resources.GetObject("btn_auto.Image")));
            this.btn_auto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(157, 32);
            this.btn_auto.Text = "&Auto Detect Language";
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontSizeToolStripMenuItem,
            this.foToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(75, 32);
            this.toolStripButton1.Text = "Font";
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.fontSizeToolStripMenuItem.Text = "Font";
            this.fontSizeToolStripMenuItem.Click += new System.EventHandler(this.fontSizeToolStripMenuItem_Click);
            // 
            // foToolStripMenuItem
            // 
            this.foToolStripMenuItem.Name = "foToolStripMenuItem";
            this.foToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.foToolStripMenuItem.Text = "Color";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // btn_help
            // 
            this.btn_help.Image = ((System.Drawing.Image)(resources.GetObject("btn_help.Image")));
            this.btn_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(64, 32);
            this.btn_help.Text = "&Help";
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // btn_about
            // 
            this.btn_about.Image = ((System.Drawing.Image)(resources.GetObject("btn_about.Image")));
            this.btn_about.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(72, 32);
            this.btn_about.Text = "A&bout";
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "openFileDialog1";
            // 
            // txt_from
            // 
            this.txt_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_from.Location = new System.Drawing.Point(12, 102);
            this.txt_from.Name = "txt_from";
            this.txt_from.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txt_from.Size = new System.Drawing.Size(331, 265);
            this.txt_from.TabIndex = 2;
            this.txt_from.Text = "";
            // 
            // txt_to
            // 
            this.txt_to.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_to.Location = new System.Drawing.Point(361, 102);
            this.txt_to.Name = "txt_to";
            this.txt_to.ReadOnly = true;
            this.txt_to.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txt_to.Size = new System.Drawing.Size(331, 265);
            this.txt_to.TabIndex = 3;
            this.txt_to.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source Text :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "TranslatedText :";
            // 
            // chk_ontop
            // 
            this.chk_ontop.AutoSize = true;
            this.chk_ontop.Location = new System.Drawing.Point(602, 373);
            this.chk_ontop.Name = "chk_ontop";
            this.chk_ontop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_ontop.Size = new System.Drawing.Size(90, 17);
            this.chk_ontop.TabIndex = 8;
            this.chk_ontop.Text = "Keep On Top";
            this.chk_ontop.UseVisualStyleBackColor = true;
            this.chk_ontop.CheckedChanged += new System.EventHandler(this.chk_ontop_CheckedChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 32);
            this.toolStripLabel1.Text = "Translate Text From :";
            // 
            // combo_from
            // 
            this.combo_from.ForeColor = System.Drawing.Color.Black;
            this.combo_from.Name = "combo_from";
            this.combo_from.Size = new System.Drawing.Size(121, 35);
            this.combo_from.Click += new System.EventHandler(this.combo_from_Click_1);
            // 
            // btn_switch
            // 
            this.btn_switch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_switch.Image = ((System.Drawing.Image)(resources.GetObject("btn_switch.Image")));
            this.btn_switch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_switch.Name = "btn_switch";
            this.btn_switch.Size = new System.Drawing.Size(32, 32);
            this.btn_switch.Text = "toolStripButton1";
            this.btn_switch.Click += new System.EventHandler(this.btn_switch_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(27, 32);
            this.toolStripLabel2.Text = "To :";
            // 
            // combo_to
            // 
            this.combo_to.ForeColor = System.Drawing.Color.Black;
            this.combo_to.Name = "combo_to";
            this.combo_to.Size = new System.Drawing.Size(121, 35);
            this.combo_to.Click += new System.EventHandler(this.combo_to_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // btn_translate
            // 
            this.btn_translate.Image = ((System.Drawing.Image)(resources.GetObject("btn_translate.Image")));
            this.btn_translate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_translate.Name = "btn_translate";
            this.btn_translate.Size = new System.Drawing.Size(87, 32);
            this.btn_translate.Text = "&Translate";
            this.btn_translate.Click += new System.EventHandler(this.btn_translate_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.combo_from,
            this.btn_switch,
            this.toolStripLabel2,
            this.combo_to,
            this.toolStripSeparator1,
            this.btn_translate,
            this.toolStripSeparator3,
            this.btn_copy,
            this.btn_clear});
            this.toolStrip2.Location = new System.Drawing.Point(0, 35);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(704, 35);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btn_copy
            // 
            this.btn_copy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySourceToolStripMenuItem,
            this.copySourceToolStripMenuItem1});
            this.btn_copy.Image = ((System.Drawing.Image)(resources.GetObject("btn_copy.Image")));
            this.btn_copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(101, 32);
            this.btn_copy.Text = "&Copy Text";
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // copySourceToolStripMenuItem
            // 
            this.copySourceToolStripMenuItem.Name = "copySourceToolStripMenuItem";
            this.copySourceToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copySourceToolStripMenuItem.Text = "Copy Translated";
            this.copySourceToolStripMenuItem.Click += new System.EventHandler(this.copySourceToolStripMenuItem_Click);
            // 
            // copySourceToolStripMenuItem1
            // 
            this.copySourceToolStripMenuItem1.Name = "copySourceToolStripMenuItem1";
            this.copySourceToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.copySourceToolStripMenuItem1.Text = "Copy Source";
            this.copySourceToolStripMenuItem1.Click += new System.EventHandler(this.copySourceToolStripMenuItem1_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSourceToolStripMenuItem,
            this.clearTranslatedToolStripMenuItem});
            this.btn_clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_clear.Image")));
            this.btn_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(78, 32);
            this.btn_clear.Text = "Clea&r";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // clearSourceToolStripMenuItem
            // 
            this.clearSourceToolStripMenuItem.Name = "clearSourceToolStripMenuItem";
            this.clearSourceToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.clearSourceToolStripMenuItem.Text = "Clear Source";
            this.clearSourceToolStripMenuItem.Click += new System.EventHandler(this.clearSourceToolStripMenuItem_Click);
            // 
            // clearTranslatedToolStripMenuItem
            // 
            this.clearTranslatedToolStripMenuItem.Name = "clearTranslatedToolStripMenuItem";
            this.clearTranslatedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.clearTranslatedToolStripMenuItem.Text = "Clear Translated";
            this.clearTranslatedToolStripMenuItem.Click += new System.EventHandler(this.clearTranslatedToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 398);
            this.Controls.Add(this.chk_ontop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_to);
            this.Controls.Add(this.txt_from);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.MaximumSize = new System.Drawing.Size(720, 436);
            this.MinimumSize = new System.Drawing.Size(720, 436);
            this.Name = "Form1";
            this.Text = "zuze Translator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_open;
        private System.Windows.Forms.ToolStripButton btn_save;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.RichTextBox txt_from;
        private System.Windows.Forms.ToolStripButton btn_auto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_help;
        private System.Windows.Forms.ToolStripButton btn_about;
        private System.Windows.Forms.RichTextBox txt_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.CheckBox chk_ontop;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox combo_from;
        private System.Windows.Forms.ToolStripButton btn_switch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox combo_to;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_translate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSplitButton btn_clear;
        private System.Windows.Forms.ToolStripMenuItem clearSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTranslatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton btn_copy;
        private System.Windows.Forms.ToolStripMenuItem copySourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySourceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.FontDialog fontDialog;
    }
}

