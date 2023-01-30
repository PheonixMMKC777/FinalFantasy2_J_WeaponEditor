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
        }

        private void ArmorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            

          

            PRG.CurrentIndex = this.ArmorList.SelectedIndex * 6;
            PRG.CurrentIndex = PRG.CurrentIndex + 6;
            PRG.CurrentOffset = PRG.ArmorStartOffset + PRG.CurrentIndex;


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
            byte RBit;

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
    }
}
