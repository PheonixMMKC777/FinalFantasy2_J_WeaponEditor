using System.Collections;

namespace FinalFantasy2_J_WeaponEditor
{

    public static class PRG
    {
        public static byte[] ROM; 
        public static byte ROMOffset;
        public static int ROMIndex;
        public static int ArmorSize = 5;
        public static int ArmorStartOffset = 0x30010;
        public static int CurrentIndex = 0x00;
        public static int CurrentOffset = 0x00000;
        public static bool[] ElemBits;

        public static bool Bit7;
        public static bool Bit6;
        public static bool Bit5;
        public static bool Bit4;
        public static bool Bit3;
        public static bool Bit2;
        public static bool Bit1;
        public static bool Bit0;
    }


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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ArmorList = new System.Windows.Forms.ListBox();
            this.DefenseBox = new System.Windows.Forms.TextBox();
            this.EvadePenaltyBox = new System.Windows.Forms.TextBox();
            this.MagicPenaltyBox = new System.Windows.Forms.TextBox();
            this.MagicDefenseBox = new System.Windows.Forms.TextBox();
            this.DefenseL = new System.Windows.Forms.Label();
            this.MagicDefenseL = new System.Windows.Forms.Label();
            this.EvadePenaltyL = new System.Windows.Forms.Label();
            this.MagicPenaltyL = new System.Windows.Forms.Label();
            this.ElemDefenseCheckList = new System.Windows.Forms.CheckedListBox();
            this.MagicresistL = new System.Windows.Forms.Label();
            this.StatBoostComboBox = new System.Windows.Forms.ComboBox();
            this.StatBoostL = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SaveAsRom = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(476, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRomToolStripMenuItem,
            this.saveRomToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openRomToolStripMenuItem
            // 
            this.openRomToolStripMenuItem.Name = "openRomToolStripMenuItem";
            this.openRomToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openRomToolStripMenuItem.Text = "Open Rom";
            this.openRomToolStripMenuItem.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
            // 
            // saveRomToolStripMenuItem
            // 
            this.saveRomToolStripMenuItem.Name = "saveRomToolStripMenuItem";
            this.saveRomToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.saveRomToolStripMenuItem.Text = "Save Rom";
            this.saveRomToolStripMenuItem.Click += new System.EventHandler(this.saveRomToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ArmorList
            // 
            this.ArmorList.Enabled = false;
            this.ArmorList.FormattingEnabled = true;
            this.ArmorList.Items.AddRange(new object[] {
            "Leather H",
            "Bronze H",
            "Mythril H",
            "Giant H",
            "Flame H",
            "Spiral H",
            "Genji H",
            "Spiral LH",
            "Goldpin LH",
            "Ribbon LH",
            "Clothes A",
            "Leather A",
            "Bronze A",
            "Mythril A",
            "Gold A",
            "Knight A",
            "Flame A",
            "Ice A",
            "Diamond A-1 ",
            "Dragon A",
            "Genji A",
            "Copper LA",
            "Silver LA",
            "Ruby LA",
            "Quartz LA",
            "Diamond LA-2",
            "WhtRobe LA",
            "BlkRobe LA",
            "Power LA",
            "Black LA",
            "Leather G",
            "Bronze G",
            "Mythril G",
            "Thief G",
            "Giant G",
            "Ice G",
            "Diamond ",
            "Genji G",
            "Defender G",
            "Power G"});
            this.ArmorList.Location = new System.Drawing.Point(12, 33);
            this.ArmorList.Name = "ArmorList";
            this.ArmorList.Size = new System.Drawing.Size(94, 212);
            this.ArmorList.TabIndex = 1;
            this.ArmorList.SelectedIndexChanged += new System.EventHandler(this.ArmorList_SelectedIndexChanged);
            // 
            // DefenseBox
            // 
            this.DefenseBox.Location = new System.Drawing.Point(240, 62);
            this.DefenseBox.Name = "DefenseBox";
            this.DefenseBox.Size = new System.Drawing.Size(55, 20);
            this.DefenseBox.TabIndex = 2;
            // 
            // EvadePenaltyBox
            // 
            this.EvadePenaltyBox.Location = new System.Drawing.Point(240, 131);
            this.EvadePenaltyBox.Name = "EvadePenaltyBox";
            this.EvadePenaltyBox.Size = new System.Drawing.Size(55, 20);
            this.EvadePenaltyBox.TabIndex = 3;
            // 
            // MagicPenaltyBox
            // 
            this.MagicPenaltyBox.Location = new System.Drawing.Point(240, 166);
            this.MagicPenaltyBox.Name = "MagicPenaltyBox";
            this.MagicPenaltyBox.Size = new System.Drawing.Size(55, 20);
            this.MagicPenaltyBox.TabIndex = 4;
            // 
            // MagicDefenseBox
            // 
            this.MagicDefenseBox.Location = new System.Drawing.Point(240, 96);
            this.MagicDefenseBox.Name = "MagicDefenseBox";
            this.MagicDefenseBox.Size = new System.Drawing.Size(55, 20);
            this.MagicDefenseBox.TabIndex = 5;
            // 
            // DefenseL
            // 
            this.DefenseL.AutoSize = true;
            this.DefenseL.Location = new System.Drawing.Point(184, 65);
            this.DefenseL.Name = "DefenseL";
            this.DefenseL.Size = new System.Drawing.Size(50, 13);
            this.DefenseL.TabIndex = 6;
            this.DefenseL.Text = "Defense:";
            // 
            // MagicDefenseL
            // 
            this.MagicDefenseL.AutoSize = true;
            this.MagicDefenseL.Location = new System.Drawing.Point(152, 99);
            this.MagicDefenseL.Name = "MagicDefenseL";
            this.MagicDefenseL.Size = new System.Drawing.Size(82, 13);
            this.MagicDefenseL.TabIndex = 7;
            this.MagicDefenseL.Text = "Magic Defense:";
            // 
            // EvadePenaltyL
            // 
            this.EvadePenaltyL.AutoSize = true;
            this.EvadePenaltyL.Location = new System.Drawing.Point(155, 134);
            this.EvadePenaltyL.Name = "EvadePenaltyL";
            this.EvadePenaltyL.Size = new System.Drawing.Size(79, 13);
            this.EvadePenaltyL.TabIndex = 8;
            this.EvadePenaltyL.Text = "Evade Penalty:";
            // 
            // MagicPenaltyL
            // 
            this.MagicPenaltyL.AutoSize = true;
            this.MagicPenaltyL.Location = new System.Drawing.Point(157, 169);
            this.MagicPenaltyL.Name = "MagicPenaltyL";
            this.MagicPenaltyL.Size = new System.Drawing.Size(77, 13);
            this.MagicPenaltyL.TabIndex = 9;
            this.MagicPenaltyL.Text = "Magic Penalty:";
            // 
            // ElemDefenseCheckList
            // 
            this.ElemDefenseCheckList.FormattingEnabled = true;
            this.ElemDefenseCheckList.Items.AddRange(new object[] {
            "Ice",
            "Poison",
            "Body ",
            "Death",
            "Thunder",
            "Mind",
            "Fire",
            "Dimension"});
            this.ElemDefenseCheckList.Location = new System.Drawing.Point(322, 62);
            this.ElemDefenseCheckList.Name = "ElemDefenseCheckList";
            this.ElemDefenseCheckList.Size = new System.Drawing.Size(120, 124);
            this.ElemDefenseCheckList.TabIndex = 10;
            this.ElemDefenseCheckList.SelectedIndexChanged += new System.EventHandler(this.ElemDefenseCheckList_SelectedIndexChanged);
            // 
            // MagicresistL
            // 
            this.MagicresistL.AutoSize = true;
            this.MagicresistL.Location = new System.Drawing.Point(333, 46);
            this.MagicresistL.Name = "MagicresistL";
            this.MagicresistL.Size = new System.Drawing.Size(95, 13);
            this.MagicresistL.TabIndex = 11;
            this.MagicresistL.Text = "Magic Resistance:";
            // 
            // StatBoostComboBox
            // 
            this.StatBoostComboBox.FormattingEnabled = true;
            this.StatBoostComboBox.Items.AddRange(new object[] {
            "None",
            "Strength + 10",
            "Agility + 10",
            "Intelligence + 10",
            "Soul + 10"});
            this.StatBoostComboBox.Location = new System.Drawing.Point(322, 218);
            this.StatBoostComboBox.Name = "StatBoostComboBox";
            this.StatBoostComboBox.Size = new System.Drawing.Size(121, 21);
            this.StatBoostComboBox.TabIndex = 12;
            // 
            // StatBoostL
            // 
            this.StatBoostL.AutoSize = true;
            this.StatBoostL.Location = new System.Drawing.Point(345, 202);
            this.StatBoostL.Name = "StatBoostL";
            this.StatBoostL.Size = new System.Drawing.Size(64, 13);
            this.StatBoostL.TabIndex = 13;
            this.StatBoostL.Text = "Stat Boosts:";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(173, 218);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(110, 21);
            this.UpdateButton.TabIndex = 14;
            this.UpdateButton.Text = "Save Changes";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 257);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.StatBoostL);
            this.Controls.Add(this.StatBoostComboBox);
            this.Controls.Add(this.MagicresistL);
            this.Controls.Add(this.ElemDefenseCheckList);
            this.Controls.Add(this.MagicPenaltyL);
            this.Controls.Add(this.EvadePenaltyL);
            this.Controls.Add(this.MagicDefenseL);
            this.Controls.Add(this.DefenseL);
            this.Controls.Add(this.MagicDefenseBox);
            this.Controls.Add(this.MagicPenaltyBox);
            this.Controls.Add(this.EvadePenaltyBox);
            this.Controls.Add(this.DefenseBox);
            this.Controls.Add(this.ArmorList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FF2J_Weapons";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRomToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox ArmorList;
        private System.Windows.Forms.TextBox DefenseBox;
        private System.Windows.Forms.TextBox EvadePenaltyBox;
        private System.Windows.Forms.TextBox MagicPenaltyBox;
        private System.Windows.Forms.TextBox MagicDefenseBox;
        private System.Windows.Forms.Label DefenseL;
        private System.Windows.Forms.Label MagicDefenseL;
        private System.Windows.Forms.Label EvadePenaltyL;
        private System.Windows.Forms.Label MagicPenaltyL;
        private System.Windows.Forms.CheckedListBox ElemDefenseCheckList;
        private System.Windows.Forms.Label MagicresistL;
        private System.Windows.Forms.ComboBox StatBoostComboBox;
        private System.Windows.Forms.Label StatBoostL;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ToolStripMenuItem saveRomToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveAsRom;
    }
}

