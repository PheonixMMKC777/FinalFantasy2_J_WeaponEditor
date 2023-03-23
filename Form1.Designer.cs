using System.Collections;
using System.Security.Policy;

namespace FinalFantasy2_J_WeaponEditor
{

    public static class PRG
    {
        public static byte[] ROM;
        public static byte ROMOffset;
        public static int ROMIndex;
        // all armor related variables

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

        // all weapon rel variables
        public static int WeaponStartOffset = 0x30106; // unarmed
        public static int CurrentWeaponIndex = 0;
        public static int CurrentWeaponOffset = 0x30106;

        public static bool WBit7;
        public static bool WBit6;
        public static bool WBit5;
        public static bool WBit4;
        public static bool WBit3;
        public static bool WBit2;
        public static bool WBit1;
        public static bool WBit0;

        public static bool MBit7;
        public static bool MBit6;
        public static bool MBit5;
        public static bool MBit4;
        public static bool MBit3;
        public static bool MBit2;
        public static bool MBit1;
        public static bool MBit0;



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
            this.WeaponList = new System.Windows.Forms.ListBox();
            this.WeaponTypeBox = new System.Windows.Forms.ComboBox();
            this.WeaponAccBox = new System.Windows.Forms.TextBox();
            this.WeaponAttackBox = new System.Windows.Forms.TextBox();
            this.WeaponEvadeBox = new System.Windows.Forms.TextBox();
            this.WeaponMagicPenaltyBox = new System.Windows.Forms.TextBox();
            this.WeaponMagicPenaltyLabel = new System.Windows.Forms.Label();
            this.WeaponAccuracyLabel = new System.Windows.Forms.Label();
            this.WeaponAttackLabel = new System.Windows.Forms.Label();
            this.WeaponEvadeBonusLabel = new System.Windows.Forms.Label();
            this.WaeponElementLabel = new System.Windows.Forms.Label();
            this.WeaponElementCheckBox = new System.Windows.Forms.CheckedListBox();
            this.WeaponMonsterBonusLabel = new System.Windows.Forms.Label();
            this.MonsterBonusBox = new System.Windows.Forms.CheckedListBox();
            this.WeaponOffsetLabel = new System.Windows.Forms.Label();
            this.ArmorOffsetLabel = new System.Windows.Forms.Label();
            this.WeaponAsItemBox = new System.Windows.Forms.TextBox();
            this.WeaponAsItemLabel = new System.Windows.Forms.Label();
            this.WeaponUpdateButton = new System.Windows.Forms.Button();
            this.WeaponTypeLabel = new System.Windows.Forms.Label();
            this.DividerLabel = new System.Windows.Forms.Label();
            this.HexLabel2 = new System.Windows.Forms.Label();
            this.HexLabel1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(473, 24);
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
            this.openRomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openRomToolStripMenuItem.Text = "Open Rom";
            this.openRomToolStripMenuItem.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
            // 
            // saveRomToolStripMenuItem
            // 
            this.saveRomToolStripMenuItem.Name = "saveRomToolStripMenuItem";
            this.saveRomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.ArmorList.Location = new System.Drawing.Point(17, 369);
            this.ArmorList.Name = "ArmorList";
            this.ArmorList.Size = new System.Drawing.Size(94, 212);
            this.ArmorList.TabIndex = 1;
            this.ArmorList.SelectedIndexChanged += new System.EventHandler(this.ArmorList_SelectedIndexChanged);
            // 
            // DefenseBox
            // 
            this.DefenseBox.Location = new System.Drawing.Point(226, 398);
            this.DefenseBox.Name = "DefenseBox";
            this.DefenseBox.Size = new System.Drawing.Size(55, 20);
            this.DefenseBox.TabIndex = 2;
            // 
            // EvadePenaltyBox
            // 
            this.EvadePenaltyBox.Location = new System.Drawing.Point(226, 467);
            this.EvadePenaltyBox.Name = "EvadePenaltyBox";
            this.EvadePenaltyBox.Size = new System.Drawing.Size(55, 20);
            this.EvadePenaltyBox.TabIndex = 3;
            // 
            // MagicPenaltyBox
            // 
            this.MagicPenaltyBox.Location = new System.Drawing.Point(226, 502);
            this.MagicPenaltyBox.Name = "MagicPenaltyBox";
            this.MagicPenaltyBox.Size = new System.Drawing.Size(55, 20);
            this.MagicPenaltyBox.TabIndex = 4;
            // 
            // MagicDefenseBox
            // 
            this.MagicDefenseBox.Location = new System.Drawing.Point(226, 432);
            this.MagicDefenseBox.Name = "MagicDefenseBox";
            this.MagicDefenseBox.Size = new System.Drawing.Size(55, 20);
            this.MagicDefenseBox.TabIndex = 5;
            // 
            // DefenseL
            // 
            this.DefenseL.AutoSize = true;
            this.DefenseL.Location = new System.Drawing.Point(170, 401);
            this.DefenseL.Name = "DefenseL";
            this.DefenseL.Size = new System.Drawing.Size(50, 13);
            this.DefenseL.TabIndex = 6;
            this.DefenseL.Text = "Defense:";
            // 
            // MagicDefenseL
            // 
            this.MagicDefenseL.AutoSize = true;
            this.MagicDefenseL.Location = new System.Drawing.Point(138, 435);
            this.MagicDefenseL.Name = "MagicDefenseL";
            this.MagicDefenseL.Size = new System.Drawing.Size(82, 13);
            this.MagicDefenseL.TabIndex = 7;
            this.MagicDefenseL.Text = "Magic Defense:";
            // 
            // EvadePenaltyL
            // 
            this.EvadePenaltyL.AutoSize = true;
            this.EvadePenaltyL.Location = new System.Drawing.Point(141, 470);
            this.EvadePenaltyL.Name = "EvadePenaltyL";
            this.EvadePenaltyL.Size = new System.Drawing.Size(79, 13);
            this.EvadePenaltyL.TabIndex = 8;
            this.EvadePenaltyL.Text = "Evade Penalty:";
            // 
            // MagicPenaltyL
            // 
            this.MagicPenaltyL.AutoSize = true;
            this.MagicPenaltyL.Location = new System.Drawing.Point(143, 505);
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
            this.ElemDefenseCheckList.Location = new System.Drawing.Point(327, 398);
            this.ElemDefenseCheckList.Name = "ElemDefenseCheckList";
            this.ElemDefenseCheckList.Size = new System.Drawing.Size(120, 124);
            this.ElemDefenseCheckList.TabIndex = 10;
            this.ElemDefenseCheckList.SelectedIndexChanged += new System.EventHandler(this.ElemDefenseCheckList_SelectedIndexChanged);
            // 
            // MagicresistL
            // 
            this.MagicresistL.AutoSize = true;
            this.MagicresistL.Location = new System.Drawing.Point(338, 382);
            this.MagicresistL.Name = "MagicresistL";
            this.MagicresistL.Size = new System.Drawing.Size(95, 13);
            this.MagicresistL.TabIndex = 11;
            this.MagicresistL.Text = "Magic Resistance:";
            // 
            // StatBoostComboBox
            // 
            this.StatBoostComboBox.Enabled = false;
            this.StatBoostComboBox.FormattingEnabled = true;
            this.StatBoostComboBox.Items.AddRange(new object[] {
            "None",
            "Strength + 10",
            "Agility + 10",
            "Intelligence + 10",
            "Soul + 10"});
            this.StatBoostComboBox.Location = new System.Drawing.Point(327, 554);
            this.StatBoostComboBox.Name = "StatBoostComboBox";
            this.StatBoostComboBox.Size = new System.Drawing.Size(121, 21);
            this.StatBoostComboBox.TabIndex = 12;
            // 
            // StatBoostL
            // 
            this.StatBoostL.AutoSize = true;
            this.StatBoostL.Location = new System.Drawing.Point(350, 538);
            this.StatBoostL.Name = "StatBoostL";
            this.StatBoostL.Size = new System.Drawing.Size(64, 13);
            this.StatBoostL.TabIndex = 13;
            this.StatBoostL.Text = "Stat Boosts:";
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Location = new System.Drawing.Point(168, 560);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(110, 21);
            this.UpdateButton.TabIndex = 14;
            this.UpdateButton.Text = "Save Changes";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // WeaponList
            // 
            this.WeaponList.Enabled = false;
            this.WeaponList.FormattingEnabled = true;
            this.WeaponList.Items.AddRange(new object[] {
            "Unarmed",
            "Buckler Shield",
            "Bronze Shield",
            "Mithril Shield",
            "Gold Shield",
            "Ice Shield",
            "Flame Shield",
            "Diamond Shield",
            "Dragon Shield",
            "Aegis Shield",
            "Knife",
            "Dagger",
            "Mithril Knife",
            "Gouche",
            "Orhacon",
            "Ripper",
            "CatClaw",
            "Cane",
            "Mace",
            "Mithril Cane",
            "Were Cane",
            "Magic Cane",
            "Power Cane",
            "Evil Cane",
            "Greed Cane",
            "Diamond Cane",
            "Javelin ",
            "Spear ",
            "Mithril Spear",
            "Trident Spear",
            "Demon Spear",
            "Flame Spear",
            "Ice Spear",
            "Bolt Spear",
            "Holy Spear",
            "Broad Sword",
            "Long Sword",
            "Mithril Sword",
            "Ancient Sword",
            "Sleep Sword",
            "Winged Sword",
            "Blood Sword",
            "Earth Sword",
            "Flame Sword",
            "Ice Sword",
            "Defender",
            "Sun Sword",
            "Xcalibur",
            "Masamune",
            "Axe",
            "Battle Axe",
            "Mithril Axe",
            "Demon Axe",
            "Ogre Axe",
            "Poison Axe",
            "Rune Axe",
            "Bow",
            "Long Bow",
            "Mithril Bow",
            "Blind Bow",
            "Flame Bow",
            "Ice Bow",
            "Killer Bow",
            "Yoichi Bow"});
            this.WeaponList.Location = new System.Drawing.Point(17, 54);
            this.WeaponList.Name = "WeaponList";
            this.WeaponList.Size = new System.Drawing.Size(94, 264);
            this.WeaponList.TabIndex = 15;
            this.WeaponList.SelectedIndexChanged += new System.EventHandler(this.WeaponList_SelectedIndexChanged);
            // 
            // WeaponTypeBox
            // 
            this.WeaponTypeBox.Enabled = false;
            this.WeaponTypeBox.FormattingEnabled = true;
            this.WeaponTypeBox.Items.AddRange(new object[] {
            "Unarmed",
            "Shield",
            "Knive",
            "Cane",
            "Spear",
            "Sword",
            "Axe",
            "Bow"});
            this.WeaponTypeBox.Location = new System.Drawing.Point(160, 54);
            this.WeaponTypeBox.Name = "WeaponTypeBox";
            this.WeaponTypeBox.Size = new System.Drawing.Size(121, 21);
            this.WeaponTypeBox.TabIndex = 16;
            // 
            // WeaponAccBox
            // 
            this.WeaponAccBox.Location = new System.Drawing.Point(228, 101);
            this.WeaponAccBox.Name = "WeaponAccBox";
            this.WeaponAccBox.Size = new System.Drawing.Size(50, 20);
            this.WeaponAccBox.TabIndex = 17;
            // 
            // WeaponAttackBox
            // 
            this.WeaponAttackBox.Location = new System.Drawing.Point(228, 141);
            this.WeaponAttackBox.Name = "WeaponAttackBox";
            this.WeaponAttackBox.Size = new System.Drawing.Size(50, 20);
            this.WeaponAttackBox.TabIndex = 18;
            // 
            // WeaponEvadeBox
            // 
            this.WeaponEvadeBox.Location = new System.Drawing.Point(228, 181);
            this.WeaponEvadeBox.Name = "WeaponEvadeBox";
            this.WeaponEvadeBox.Size = new System.Drawing.Size(50, 20);
            this.WeaponEvadeBox.TabIndex = 19;
            // 
            // WeaponMagicPenaltyBox
            // 
            this.WeaponMagicPenaltyBox.Location = new System.Drawing.Point(228, 221);
            this.WeaponMagicPenaltyBox.Name = "WeaponMagicPenaltyBox";
            this.WeaponMagicPenaltyBox.Size = new System.Drawing.Size(50, 20);
            this.WeaponMagicPenaltyBox.TabIndex = 20;
            // 
            // WeaponMagicPenaltyLabel
            // 
            this.WeaponMagicPenaltyLabel.AutoSize = true;
            this.WeaponMagicPenaltyLabel.Location = new System.Drawing.Point(148, 224);
            this.WeaponMagicPenaltyLabel.Name = "WeaponMagicPenaltyLabel";
            this.WeaponMagicPenaltyLabel.Size = new System.Drawing.Size(77, 13);
            this.WeaponMagicPenaltyLabel.TabIndex = 21;
            this.WeaponMagicPenaltyLabel.Text = "Magic Penalty:";
            // 
            // WeaponAccuracyLabel
            // 
            this.WeaponAccuracyLabel.AutoSize = true;
            this.WeaponAccuracyLabel.Location = new System.Drawing.Point(171, 104);
            this.WeaponAccuracyLabel.Name = "WeaponAccuracyLabel";
            this.WeaponAccuracyLabel.Size = new System.Drawing.Size(55, 13);
            this.WeaponAccuracyLabel.TabIndex = 22;
            this.WeaponAccuracyLabel.Text = "Accuracy:";
            // 
            // WeaponAttackLabel
            // 
            this.WeaponAttackLabel.AutoSize = true;
            this.WeaponAttackLabel.Location = new System.Drawing.Point(182, 145);
            this.WeaponAttackLabel.Name = "WeaponAttackLabel";
            this.WeaponAttackLabel.Size = new System.Drawing.Size(44, 13);
            this.WeaponAttackLabel.TabIndex = 23;
            this.WeaponAttackLabel.Text = "Attack: ";
            // 
            // WeaponEvadeBonusLabel
            // 
            this.WeaponEvadeBonusLabel.AutoSize = true;
            this.WeaponEvadeBonusLabel.Location = new System.Drawing.Point(152, 185);
            this.WeaponEvadeBonusLabel.Name = "WeaponEvadeBonusLabel";
            this.WeaponEvadeBonusLabel.Size = new System.Drawing.Size(74, 13);
            this.WeaponEvadeBonusLabel.TabIndex = 24;
            this.WeaponEvadeBonusLabel.Text = "Evade Bonus:";
            // 
            // WaeponElementLabel
            // 
            this.WaeponElementLabel.AutoSize = true;
            this.WaeponElementLabel.Location = new System.Drawing.Point(339, 38);
            this.WaeponElementLabel.Name = "WaeponElementLabel";
            this.WaeponElementLabel.Size = new System.Drawing.Size(92, 13);
            this.WaeponElementLabel.TabIndex = 26;
            this.WaeponElementLabel.Text = "Weapon Element:";
            // 
            // WeaponElementCheckBox
            // 
            this.WeaponElementCheckBox.FormattingEnabled = true;
            this.WeaponElementCheckBox.Items.AddRange(new object[] {
            "Ice",
            "Poison",
            "Body ",
            "Death",
            "Thunder",
            "Mind",
            "Fire",
            "Dimension"});
            this.WeaponElementCheckBox.Location = new System.Drawing.Point(328, 54);
            this.WeaponElementCheckBox.Name = "WeaponElementCheckBox";
            this.WeaponElementCheckBox.Size = new System.Drawing.Size(120, 124);
            this.WeaponElementCheckBox.TabIndex = 25;
            // 
            // WeaponMonsterBonusLabel
            // 
            this.WeaponMonsterBonusLabel.AutoSize = true;
            this.WeaponMonsterBonusLabel.Location = new System.Drawing.Point(344, 182);
            this.WeaponMonsterBonusLabel.Name = "WeaponMonsterBonusLabel";
            this.WeaponMonsterBonusLabel.Size = new System.Drawing.Size(81, 13);
            this.WeaponMonsterBonusLabel.TabIndex = 28;
            this.WeaponMonsterBonusLabel.Text = "Monster Bonus:";
            // 
            // MonsterBonusBox
            // 
            this.MonsterBonusBox.FormattingEnabled = true;
            this.MonsterBonusBox.Items.AddRange(new object[] {
            "I",
            "dont ",
            "know ",
            "the",
            "order",
            "of",
            "these",
            "?????"});
            this.MonsterBonusBox.Location = new System.Drawing.Point(327, 198);
            this.MonsterBonusBox.Name = "MonsterBonusBox";
            this.MonsterBonusBox.Size = new System.Drawing.Size(120, 124);
            this.MonsterBonusBox.TabIndex = 27;
            // 
            // WeaponOffsetLabel
            // 
            this.WeaponOffsetLabel.AutoSize = true;
            this.WeaponOffsetLabel.Location = new System.Drawing.Point(35, 38);
            this.WeaponOffsetLabel.Name = "WeaponOffsetLabel";
            this.WeaponOffsetLabel.Size = new System.Drawing.Size(18, 13);
            this.WeaponOffsetLabel.TabIndex = 29;
            this.WeaponOffsetLabel.Text = "0x";
            // 
            // ArmorOffsetLabel
            // 
            this.ArmorOffsetLabel.AutoSize = true;
            this.ArmorOffsetLabel.Location = new System.Drawing.Point(35, 353);
            this.ArmorOffsetLabel.Name = "ArmorOffsetLabel";
            this.ArmorOffsetLabel.Size = new System.Drawing.Size(18, 13);
            this.ArmorOffsetLabel.TabIndex = 30;
            this.ArmorOffsetLabel.Text = "0x";
            // 
            // WeaponAsItemBox
            // 
            this.WeaponAsItemBox.Location = new System.Drawing.Point(228, 261);
            this.WeaponAsItemBox.Name = "WeaponAsItemBox";
            this.WeaponAsItemBox.Size = new System.Drawing.Size(50, 20);
            this.WeaponAsItemBox.TabIndex = 31;
            // 
            // WeaponAsItemLabel
            // 
            this.WeaponAsItemLabel.AutoSize = true;
            this.WeaponAsItemLabel.Location = new System.Drawing.Point(154, 265);
            this.WeaponAsItemLabel.Name = "WeaponAsItemLabel";
            this.WeaponAsItemLabel.Size = new System.Drawing.Size(72, 13);
            this.WeaponAsItemLabel.TabIndex = 32;
            this.WeaponAsItemLabel.Text = "Used as Item:";
            // 
            // WeaponUpdateButton
            // 
            this.WeaponUpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.WeaponUpdateButton.Enabled = false;
            this.WeaponUpdateButton.Location = new System.Drawing.Point(168, 299);
            this.WeaponUpdateButton.Name = "WeaponUpdateButton";
            this.WeaponUpdateButton.Size = new System.Drawing.Size(110, 21);
            this.WeaponUpdateButton.TabIndex = 33;
            this.WeaponUpdateButton.Text = "Save Changes";
            this.WeaponUpdateButton.UseVisualStyleBackColor = false;
            this.WeaponUpdateButton.Click += new System.EventHandler(this.WeaponUpdateButton_Click);
            // 
            // WeaponTypeLabel
            // 
            this.WeaponTypeLabel.AutoSize = true;
            this.WeaponTypeLabel.Location = new System.Drawing.Point(182, 38);
            this.WeaponTypeLabel.Name = "WeaponTypeLabel";
            this.WeaponTypeLabel.Size = new System.Drawing.Size(78, 13);
            this.WeaponTypeLabel.TabIndex = 34;
            this.WeaponTypeLabel.Text = "Weapon Type:";
            // 
            // DividerLabel
            // 
            this.DividerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DividerLabel.Location = new System.Drawing.Point(10, 336);
            this.DividerLabel.Name = "DividerLabel";
            this.DividerLabel.Size = new System.Drawing.Size(450, 2);
            this.DividerLabel.TabIndex = 35;
            // 
            // HexLabel2
            // 
            this.HexLabel2.AutoSize = true;
            this.HexLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.HexLabel2.Location = new System.Drawing.Point(238, 382);
            this.HexLabel2.Name = "HexLabel2";
            this.HexLabel2.Size = new System.Drawing.Size(32, 13);
            this.HexLabel2.TabIndex = 36;
            this.HexLabel2.Text = "(Hex)";
            // 
            // HexLabel1
            // 
            this.HexLabel1.AutoSize = true;
            this.HexLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.HexLabel1.Location = new System.Drawing.Point(238, 85);
            this.HexLabel1.Name = "HexLabel1";
            this.HexLabel1.Size = new System.Drawing.Size(32, 13);
            this.HexLabel1.TabIndex = 37;
            this.HexLabel1.Text = "(Hex)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 601);
            this.Controls.Add(this.HexLabel1);
            this.Controls.Add(this.HexLabel2);
            this.Controls.Add(this.DividerLabel);
            this.Controls.Add(this.WeaponTypeLabel);
            this.Controls.Add(this.WeaponUpdateButton);
            this.Controls.Add(this.WeaponAsItemLabel);
            this.Controls.Add(this.WeaponAsItemBox);
            this.Controls.Add(this.ArmorOffsetLabel);
            this.Controls.Add(this.WeaponOffsetLabel);
            this.Controls.Add(this.WeaponMonsterBonusLabel);
            this.Controls.Add(this.MonsterBonusBox);
            this.Controls.Add(this.WaeponElementLabel);
            this.Controls.Add(this.WeaponElementCheckBox);
            this.Controls.Add(this.WeaponEvadeBonusLabel);
            this.Controls.Add(this.WeaponAttackLabel);
            this.Controls.Add(this.WeaponAccuracyLabel);
            this.Controls.Add(this.WeaponMagicPenaltyLabel);
            this.Controls.Add(this.WeaponMagicPenaltyBox);
            this.Controls.Add(this.WeaponEvadeBox);
            this.Controls.Add(this.WeaponAttackBox);
            this.Controls.Add(this.WeaponAccBox);
            this.Controls.Add(this.WeaponTypeBox);
            this.Controls.Add(this.WeaponList);
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
            this.Text = "FF2 Weapon Editor by Scatfone";
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
        private System.Windows.Forms.ListBox WeaponList;
        private System.Windows.Forms.ComboBox WeaponTypeBox;
        private System.Windows.Forms.TextBox WeaponAccBox;
        private System.Windows.Forms.TextBox WeaponAttackBox;
        private System.Windows.Forms.TextBox WeaponEvadeBox;
        private System.Windows.Forms.TextBox WeaponMagicPenaltyBox;
        private System.Windows.Forms.Label WeaponMagicPenaltyLabel;
        private System.Windows.Forms.Label WeaponAccuracyLabel;
        private System.Windows.Forms.Label WeaponAttackLabel;
        private System.Windows.Forms.Label WeaponEvadeBonusLabel;
        private System.Windows.Forms.Label WaeponElementLabel;
        private System.Windows.Forms.CheckedListBox WeaponElementCheckBox;
        private System.Windows.Forms.Label WeaponMonsterBonusLabel;
        private System.Windows.Forms.CheckedListBox MonsterBonusBox;
        private System.Windows.Forms.Label WeaponOffsetLabel;
        private System.Windows.Forms.Label ArmorOffsetLabel;
        private System.Windows.Forms.TextBox WeaponAsItemBox;
        private System.Windows.Forms.Label WeaponAsItemLabel;
        private System.Windows.Forms.Button WeaponUpdateButton;
        private System.Windows.Forms.Label WeaponTypeLabel;
        private System.Windows.Forms.Label DividerLabel;
        private System.Windows.Forms.Label HexLabel2;
        private System.Windows.Forms.Label HexLabel1;
    }
}

