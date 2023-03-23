using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalFantasy2_J_WeaponEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open file Dialog...
            this.openFileDialog.DefaultExt = "nes";
            this.openFileDialog.InitialDirectory = @"C:\";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Filter = "NES files (*.nes)|*nes|All files (*.*)|*.*\"";
            this.openFileDialog.Title = "Final Fantasy 2 Rom...";
            this.openFileDialog.ShowDialog();


            PRG.ROM = File.ReadAllBytes(this.openFileDialog.FileName);

            this.ArmorList.Enabled = true;
            this.WeaponList.Enabled = true;
            this.WeaponTypeBox.Enabled = true;
            this.UpdateButton.Enabled = true;
            this.WeaponUpdateButton.Enabled = true;
            this.StatBoostComboBox.Enabled = true;
        }

        private void ArmorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            

          

            PRG.CurrentIndex = this.ArmorList.SelectedIndex * 6;
            PRG.CurrentIndex = PRG.CurrentIndex + 6;
            PRG.CurrentOffset = PRG.ArmorStartOffset + PRG.CurrentIndex;

            this.ArmorOffsetLabel.Text = ("0x" + PRG.CurrentOffset.ToString("x2"));

            this.DefenseBox.Text = PRG.ROM[PRG.CurrentOffset + 0].ToString("x2"); // def
            this.EvadePenaltyBox.Text = PRG.ROM[PRG.CurrentOffset + 1].ToString("x2"); // eva pen
            this.MagicPenaltyBox.Text = PRG.ROM[PRG.CurrentOffset + 2].ToString("x2"); // int pen
            this.MagicDefenseBox.Text = PRG.ROM[PRG.CurrentOffset + 5].ToString("x2"); // mdef

            // stat boost ??
            int X = PRG.ROM[PRG.CurrentOffset + 4]; // stat boost

            // 00 STR, 01 AGI, 02 int ,03 soul
            if (X == 0x00)
            {
                this.StatBoostComboBox.SelectedIndex = 1;
            }
            if (X == 0x01)
            {
                this.StatBoostComboBox.SelectedIndex = 2;
            }
            if (X == 0x03)
            {
                this.StatBoostComboBox.SelectedIndex = 3;
            }
            if (X == 0x04)
            {
                this.StatBoostComboBox.SelectedIndex = 4;
            }
            if (X == 0xFF)
            {
                this.StatBoostComboBox.SelectedIndex = 0;
            }

            // stat bit in prg 



            byte Dbit = PRG.ROM[PRG.CurrentOffset + 3];

            PRG.Bit0 = Convert.ToBoolean(Dbit & 0b10000000); //ice
            PRG.Bit1 = Convert.ToBoolean(Dbit & 0b01000000); //poi
            PRG.Bit2 = Convert.ToBoolean(Dbit & 0b00100000); //body
            PRG.Bit3 = Convert.ToBoolean(Dbit & 0b00010000); //deth
            PRG.Bit4 = Convert.ToBoolean(Dbit & 0b00001000); //thun
            PRG.Bit5 = Convert.ToBoolean(Dbit & 0b00000100); //mind
            PRG.Bit6 = Convert.ToBoolean(Dbit & 0b00000010); //fire
            PRG.Bit7 = Convert.ToBoolean(Dbit & 0b00000001); //dime

            if (PRG.Bit0 == true) { this.ElemDefenseCheckList.SetItemCheckState(0,CheckState.Checked); }
            if (PRG.Bit1 == true) { this.ElemDefenseCheckList.SetItemCheckState(1, CheckState.Checked); }
            if (PRG.Bit2 == true) { this.ElemDefenseCheckList.SetItemCheckState(2, CheckState.Checked); }
            if (PRG.Bit3 == true) { this.ElemDefenseCheckList.SetItemCheckState(3, CheckState.Checked); }
            if (PRG.Bit4 == true) { this.ElemDefenseCheckList.SetItemCheckState(4, CheckState.Checked); }
            if (PRG.Bit5== true) { this.ElemDefenseCheckList.SetItemCheckState(5, CheckState.Checked); }
            if (PRG.Bit6 == true) { this.ElemDefenseCheckList.SetItemCheckState(6, CheckState.Checked); }
            if (PRG.Bit7 == true) { this.ElemDefenseCheckList.SetItemCheckState(7, CheckState.Checked); }

            if (PRG.Bit0 == false) { this.ElemDefenseCheckList.SetItemCheckState(0, CheckState.Unchecked); }
            if (PRG.Bit1 == false) { this.ElemDefenseCheckList.SetItemCheckState(1, CheckState.Unchecked); }
            if (PRG.Bit2 == false) { this.ElemDefenseCheckList.SetItemCheckState(2, CheckState.Unchecked); }
            if (PRG.Bit3 == false) { this.ElemDefenseCheckList.SetItemCheckState(3, CheckState.Unchecked); }
            if (PRG.Bit4 == false) { this.ElemDefenseCheckList.SetItemCheckState(4, CheckState.Unchecked); }
            if (PRG.Bit5 == false) { this.ElemDefenseCheckList.SetItemCheckState(5, CheckState.Unchecked); }
            if (PRG.Bit6 == false) { this.ElemDefenseCheckList.SetItemCheckState(6, CheckState.Unchecked); }
            if (PRG.Bit7 == false) { this.ElemDefenseCheckList.SetItemCheckState(7, CheckState.Unchecked); }
            //


        }

        private void button1_Click(object sender, EventArgs e) //update button
        {
            PRG.ROM[PRG.CurrentOffset + 0] = Convert.ToByte(this.DefenseBox.Text,16);
            PRG.ROM[PRG.CurrentOffset + 1] = Convert.ToByte(this.EvadePenaltyBox.Text,16);
            PRG.ROM[PRG.CurrentOffset + 2] = Convert.ToByte(this.MagicPenaltyBox.Text,16);
            PRG.ROM[PRG.CurrentOffset + 5] = Convert.ToByte(this.MagicDefenseBox.Text,16);

            byte StatByte = 0x00;
            if (this.StatBoostComboBox.SelectedIndex == 0) {StatByte = 0xFF; }
            if (this.StatBoostComboBox.SelectedIndex == 1) { StatByte = 0x00; }
            if (this.StatBoostComboBox.SelectedIndex == 2) { StatByte = 0x01; }
            if (this.StatBoostComboBox.SelectedIndex == 3) { StatByte = 0x03; }
            if (this.StatBoostComboBox.SelectedIndex == 4) { StatByte = 0x04; }
            PRG.ROM[PRG.CurrentOffset + 4] = StatByte;

            int ElemWriteByte = 0x00;
            PRG.Bit0 = this.ElemDefenseCheckList.GetItemChecked(0);
            PRG.Bit1 = this.ElemDefenseCheckList.GetItemChecked(1);
            PRG.Bit2 = this.ElemDefenseCheckList.GetItemChecked(2);
            PRG.Bit3 = this.ElemDefenseCheckList.GetItemChecked(3);
            PRG.Bit4 = this.ElemDefenseCheckList.GetItemChecked(4);
            PRG.Bit5 = this.ElemDefenseCheckList.GetItemChecked(5);
            PRG.Bit6 = this.ElemDefenseCheckList.GetItemChecked(6);
            PRG.Bit7 = this.ElemDefenseCheckList.GetItemChecked(7);

            if (PRG.Bit0 == true) { ElemWriteByte = ElemWriteByte + 128; }
            if (PRG.Bit1 == true) { ElemWriteByte = ElemWriteByte + 64; }
            if (PRG.Bit2 == true) { ElemWriteByte = ElemWriteByte + 32; }
            if (PRG.Bit3 == true) { ElemWriteByte = ElemWriteByte + 16; }
            if (PRG.Bit4 == true) { ElemWriteByte = ElemWriteByte + 8; }
            if (PRG.Bit5 == true) { ElemWriteByte = ElemWriteByte + 4; }
            if (PRG.Bit6 == true) { ElemWriteByte = ElemWriteByte + 2; }
            if (PRG.Bit7 == true) { ElemWriteByte = ElemWriteByte + 1; }



            PRG.ROM[PRG.CurrentOffset + 3] = Convert.ToByte(ElemWriteByte);


        }

        private void saveRomToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //save handler
            this.SaveAsRom.RestoreDirectory = true;
            this.SaveAsRom.Title = "Save Rom File...";
            this.SaveAsRom.DefaultExt = "nes";
            this.SaveAsRom.Filter = "NES files (*.nes)|*nes|All files (*.*)|*.*\"";
            this.SaveAsRom.FileName = "FinalFantasy2_Weapons";
            this.SaveAsRom.CheckPathExists = true;
            this.SaveAsRom.ShowDialog();

            //write to file
            File.WriteAllBytes(this.SaveAsRom.FileName, PRG.ROM);
        }

        private void ElemDefenseCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WeaponList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PRG.CurrentWeaponIndex = this.WeaponList.SelectedIndex;
            PRG.CurrentWeaponOffset = PRG.WeaponStartOffset + PRG.CurrentWeaponIndex * 9;

            this.WeaponOffsetLabel.Text = ("0x" + PRG.CurrentWeaponOffset.ToString("x2"));

            #region LoadWeaponType
            if (PRG.ROM[PRG.CurrentWeaponOffset] == 0x00)
            {
                this.WeaponTypeBox.SelectedIndex = 0;
            }

            if (PRG.ROM[PRG.CurrentWeaponOffset] == 0x01)
            {
                this.WeaponTypeBox.SelectedIndex = 1;
            }

            if (PRG.ROM[PRG.CurrentWeaponOffset] == 0x02)
            {
                this.WeaponTypeBox.SelectedIndex = 2;
            }

            if (PRG.ROM[PRG.CurrentWeaponOffset] == 0x03)
            {
                this.WeaponTypeBox.SelectedIndex = 3;
            }

            if (PRG.ROM[PRG.CurrentWeaponOffset] == 0x04)
            {
                this.WeaponTypeBox.SelectedIndex = 4;
            }

            if (PRG.ROM[PRG.CurrentWeaponOffset] == 0x05)
            {
                this.WeaponTypeBox.SelectedIndex = 5;
            }

            if (PRG.ROM[PRG.CurrentWeaponOffset] == 0x06)
            {
                this.WeaponTypeBox.SelectedIndex = 6;
            }

            if (PRG.ROM[PRG.CurrentWeaponOffset] == 0x07)
            {
                this.WeaponTypeBox.SelectedIndex = 7;
            }

            #endregion LoadWeaponType


            this.WeaponAccBox.Text = Convert.ToString(PRG.ROM[PRG.CurrentWeaponOffset + 1]);
            this.WeaponAttackBox.Text = Convert.ToString(PRG.ROM[PRG.CurrentWeaponOffset + 2]);
            this.WeaponEvadeBox.Text = Convert.ToString(PRG.ROM[PRG.CurrentWeaponOffset + 3]);
            this.WeaponMagicPenaltyBox.Text = Convert.ToString(PRG.ROM[PRG.CurrentWeaponOffset + 4]);

            //offset +5
            #region LoadElementBit

            byte Dbit = PRG.ROM[PRG.CurrentWeaponOffset + 5];

            PRG.WBit0 = Convert.ToBoolean(Dbit & 0b10000000); //ice
            PRG.WBit1 = Convert.ToBoolean(Dbit & 0b01000000); //poi
            PRG.WBit2 = Convert.ToBoolean(Dbit & 0b00100000); //body
            PRG.WBit3 = Convert.ToBoolean(Dbit & 0b00010000); //deth
            PRG.WBit4 = Convert.ToBoolean(Dbit & 0b00001000); //thun
            PRG.WBit5 = Convert.ToBoolean(Dbit & 0b00000100); //mind
            PRG.WBit6 = Convert.ToBoolean(Dbit & 0b00000010); //fire
            PRG.WBit7 = Convert.ToBoolean(Dbit & 0b00000001); //dime

            if (PRG.WBit0 == true) { this.WeaponElementCheckBox.SetItemCheckState(0, CheckState.Checked); }
            if (PRG.WBit1 == true) { this.WeaponElementCheckBox.SetItemCheckState(1, CheckState.Checked); }
            if (PRG.WBit2 == true) { this.WeaponElementCheckBox.SetItemCheckState(2, CheckState.Checked); }
            if (PRG.WBit3 == true) { this.WeaponElementCheckBox.SetItemCheckState(3, CheckState.Checked); }
            if (PRG.WBit4 == true) { this.WeaponElementCheckBox.SetItemCheckState(4, CheckState.Checked); }
            if (PRG.WBit5 == true) { this.WeaponElementCheckBox.SetItemCheckState(5, CheckState.Checked); }
            if (PRG.WBit6 == true) { this.WeaponElementCheckBox.SetItemCheckState(6, CheckState.Checked); }
            if (PRG.WBit7 == true) { this.WeaponElementCheckBox.SetItemCheckState(7, CheckState.Checked); }

            if (PRG.WBit0 == false) { this.WeaponElementCheckBox.SetItemCheckState(0, CheckState.Unchecked); }
            if (PRG.WBit1 == false) { this.WeaponElementCheckBox.SetItemCheckState(1, CheckState.Unchecked); }
            if (PRG.WBit2 == false) { this.WeaponElementCheckBox.SetItemCheckState(2, CheckState.Unchecked); }
            if (PRG.WBit3 == false) { this.WeaponElementCheckBox.SetItemCheckState(3, CheckState.Unchecked); }
            if (PRG.WBit4 == false) { this.WeaponElementCheckBox.SetItemCheckState(4, CheckState.Unchecked); }
            if (PRG.WBit5 == false) { this.WeaponElementCheckBox.SetItemCheckState(5, CheckState.Unchecked); }
            if (PRG.WBit6 == false) { this.WeaponElementCheckBox.SetItemCheckState(6, CheckState.Unchecked); }
            if (PRG.WBit7 == false) { this.WeaponElementCheckBox.SetItemCheckState(7, CheckState.Unchecked); }


            #endregion LoadElementBit 



            #region LoadMosterBit

            byte Zbit = PRG.ROM[PRG.CurrentWeaponOffset + 6];

            PRG.MBit0 = Convert.ToBoolean(Zbit & 0b10000000); //ice
            PRG.MBit1 = Convert.ToBoolean(Zbit & 0b01000000); //poi
            PRG.MBit2 = Convert.ToBoolean(Zbit & 0b00100000); //body
            PRG.MBit3 = Convert.ToBoolean(Zbit & 0b00010000); //deth
            PRG.MBit4 = Convert.ToBoolean(Zbit & 0b00001000); //thun
            PRG.MBit5 = Convert.ToBoolean(Zbit & 0b00000100); //mind
            PRG.MBit6 = Convert.ToBoolean(Zbit & 0b00000010); //fire
            PRG.MBit7 = Convert.ToBoolean(Zbit & 0b00000001); //dime

            if (PRG.MBit0 == true) { this.MonsterBonusBox.SetItemCheckState(0, CheckState.Checked); }
            if (PRG.MBit1 == true) { this.MonsterBonusBox.SetItemCheckState(1, CheckState.Checked); }
            if (PRG.MBit2 == true) { this.MonsterBonusBox.SetItemCheckState(2, CheckState.Checked); }
            if (PRG.MBit3 == true) { this.MonsterBonusBox.SetItemCheckState(3, CheckState.Checked); }
            if (PRG.MBit4 == true) { this.MonsterBonusBox.SetItemCheckState(4, CheckState.Checked); }
            if (PRG.MBit5 == true) { this.MonsterBonusBox.SetItemCheckState(5, CheckState.Checked); }
            if (PRG.MBit6 == true) { this.MonsterBonusBox.SetItemCheckState(6, CheckState.Checked); }
            if (PRG.MBit7 == true) { this.MonsterBonusBox.SetItemCheckState(7, CheckState.Checked); }

            if (PRG.MBit0 == false) { this.MonsterBonusBox.SetItemCheckState(0, CheckState.Unchecked); }
            if (PRG.MBit1 == false) { this.MonsterBonusBox.SetItemCheckState(1, CheckState.Unchecked); }
            if (PRG.MBit2 == false) { this.MonsterBonusBox.SetItemCheckState(2, CheckState.Unchecked); }
            if (PRG.MBit3 == false) { this.MonsterBonusBox.SetItemCheckState(3, CheckState.Unchecked); }
            if (PRG.MBit4 == false) { this.MonsterBonusBox.SetItemCheckState(4, CheckState.Unchecked); }
            if (PRG.MBit5 == false) { this.MonsterBonusBox.SetItemCheckState(5, CheckState.Unchecked); }
            if (PRG.MBit6 == false) { this.MonsterBonusBox.SetItemCheckState(6, CheckState.Unchecked); }
            if (PRG.MBit7 == false) { this.MonsterBonusBox.SetItemCheckState(7, CheckState.Unchecked); }


            #endregion



            //Used as item

            this.WeaponAsItemBox.Text = PRG.ROM[PRG.CurrentWeaponOffset + 8].ToString();


        }

        private void WeaponUpdateButton_Click(object sender, EventArgs e)
        {

            // Weapon Type
            byte StatByte = 0x00;
            if (this.WeaponTypeBox.SelectedIndex == 0) { StatByte = 0x00; }
            if (this.WeaponTypeBox.SelectedIndex == 1) { StatByte = 0x00; }
            if (this.WeaponTypeBox.SelectedIndex == 2) { StatByte = 0x01; }
            if (this.WeaponTypeBox.SelectedIndex == 3) { StatByte = 0x03; }
            if (this.WeaponTypeBox.SelectedIndex == 4) { StatByte = 0x04; }
            if (this.WeaponTypeBox.SelectedIndex == 5) { StatByte = 0x05; }
            if (this.WeaponTypeBox.SelectedIndex == 6) { StatByte = 0x06; }
            if (this.WeaponTypeBox.SelectedIndex == 7) { StatByte = 0x07; }
            PRG.ROM[PRG.CurrentWeaponOffset + 0] = StatByte;


            PRG.ROM[PRG.CurrentWeaponOffset + 1] = Convert.ToByte(this.WeaponAccBox.Text, 16); // accuracy
            PRG.ROM[PRG.CurrentWeaponOffset + 2] = Convert.ToByte(this.WeaponAttackBox.Text, 16); //damage
            PRG.ROM[PRG.CurrentWeaponOffset + 3] = Convert.ToByte(this.WeaponEvadeBox.Text, 16); //evade bonus
            PRG.ROM[PRG.CurrentWeaponOffset + 4] = Convert.ToByte(this.WeaponMagicPenaltyBox.Text, 16); // magic penalty



            // Weapon Elemet
            int ElemWriteByte = 0x00;
            bool Bit0 = this.WeaponElementCheckBox.GetItemChecked(0);
            bool Bit1 = this.WeaponElementCheckBox.GetItemChecked(1);
            bool Bit2 = this.WeaponElementCheckBox.GetItemChecked(2);
            bool Bit3 = this.WeaponElementCheckBox.GetItemChecked(3);
            bool Bit4 = this.WeaponElementCheckBox.GetItemChecked(4);
            bool Bit5 = this.WeaponElementCheckBox.GetItemChecked(5);
            bool Bit6 = this.WeaponElementCheckBox.GetItemChecked(6);
            bool Bit7 = this.WeaponElementCheckBox.GetItemChecked(7);

            if (Bit0 == true) { ElemWriteByte = ElemWriteByte + 128; }
            if (Bit1 == true) { ElemWriteByte = ElemWriteByte + 64; }
            if (Bit2 == true) { ElemWriteByte = ElemWriteByte + 32; }
            if (Bit3 == true) { ElemWriteByte = ElemWriteByte + 16; }
            if (Bit4 == true) { ElemWriteByte = ElemWriteByte + 8; }
            if (Bit5 == true) { ElemWriteByte = ElemWriteByte + 4; }
            if (Bit6 == true) { ElemWriteByte = ElemWriteByte + 2; }
            if (Bit7 == true) { ElemWriteByte = ElemWriteByte + 1; }
            PRG.ROM[PRG.CurrentWeaponOffset + 5] = Convert.ToByte(ElemWriteByte);


            //Monster Type Bonus
            ElemWriteByte = 0x00;
            Bit0 = this.MonsterBonusBox.GetItemChecked(0);
            Bit1 = this.MonsterBonusBox.GetItemChecked(1);
            Bit2 = this.MonsterBonusBox.GetItemChecked(2);
            Bit3 = this.MonsterBonusBox.GetItemChecked(3);
            Bit4 = this.MonsterBonusBox.GetItemChecked(4);
            Bit5 = this.MonsterBonusBox.GetItemChecked(5);
            Bit6 = this.MonsterBonusBox.GetItemChecked(6);
            Bit7 = this.MonsterBonusBox.GetItemChecked(7);

            if (Bit0 == true) { ElemWriteByte = ElemWriteByte + 128; }
            if (Bit1 == true) { ElemWriteByte = ElemWriteByte + 64; }
            if (Bit2 == true) { ElemWriteByte = ElemWriteByte + 32; }
            if (Bit3 == true) { ElemWriteByte = ElemWriteByte + 16; }
            if (Bit4 == true) { ElemWriteByte = ElemWriteByte + 8; }
            if (Bit5 == true) { ElemWriteByte = ElemWriteByte + 4; }
            if (Bit6 == true) { ElemWriteByte = ElemWriteByte + 2; }
            if (Bit7 == true) { ElemWriteByte = ElemWriteByte + 1; }
            PRG.ROM[PRG.CurrentWeaponOffset + 6] = Convert.ToByte(ElemWriteByte);

            // 7 is unkown


            // 255 glitches out... dumb workaround

            if (this.WeaponAsItemBox.Text == "255")
            {
                PRG.ROM[PRG.CurrentWeaponOffset + 8] = Convert.ToByte(0xFF); //as item
            }
            else
            {
                PRG.ROM[PRG.CurrentWeaponOffset + 8] = Convert.ToByte(this.WeaponAsItemBox.Text, 16); //as item
            }
        }
    }
}
