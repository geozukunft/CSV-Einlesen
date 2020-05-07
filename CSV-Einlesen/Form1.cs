﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;


namespace CSV_Einlesen
{
    public partial class Form1 : Form
    {
        string datafile; //Path to file
        string filename; //filename
        ArrayList dataStream = new ArrayList(); //Array that hold raw data
        ArrayList sumList = new ArrayList(); //Array for Sums of Lines

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpenFile_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdData = new OpenFileDialog()
            {
                InitialDirectory = @"C:\",

                Title = "Datei öffnen",

                DefaultExt = "csv",
                Filter = "CSV Datei (*.csv)|*.csv|Alle Dateien (*.*)|*.*",
                FilterIndex = 0,

                CheckFileExists = true,
                CheckPathExists = true,

                Multiselect = false
            };

            if (ofdData.ShowDialog() == DialogResult.OK)
            {
                datafile = ofdData.FileName;
                filename = Path.GetFileName(datafile);

                readData();
                updateData();

            }



        }

        private void schließenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Sind Sie sicher, dass sie das Programm beenden möchten ohne vorher zu speichern?", "Schließen ohne Speichern", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {

                Application.Exit();
            }
        }

        private void speichern()
        {
            if (datafile == null)
            {
                MessageBox.Show("Keine Datei zum speichern ausgwählt bitte öffnen sie zuerst eine Datei!");
            }
            else
            {
                File.WriteAllText(datafile, String.Empty);
                using (StreamWriter file = File.AppendText(datafile))
                {
                    foreach (string line in dataStream)
                        file.WriteLine(line);

                    file.Close();
                }
            }
        }

        private void speichernSchließenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (datafile == null)
            {
                MessageBox.Show("Keine Datei zum speichern ausgwählt bitte öffnen sie zuerst eine Datei!");
            }
            else
            {
                File.WriteAllText(datafile, String.Empty);
                using (StreamWriter file = File.AppendText(datafile))
                {

                    foreach (string line in dataStream)
                        file.WriteLine(line);

                    file.Close();
                }

                Application.Exit();
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speichern();
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(datafile == null)
            {
                MessageBox.Show("Keine Datei geöffnet welche gelöscht werden kann.");
            }
            else
            {
                DialogResult result = MessageBox.Show(String.Format("Sind Sie sicher, dasss sie die Datei {0} löschen möchten?",filename), "Datei Löschen" ,MessageBoxButtons.OKCancel);
                if(result == DialogResult.OK)
                {
                    File.Delete(datafile);
                }
            }
        }

        private void readData()
        {
            foreach(string line in File.ReadLines(datafile))
                {
                dataStream.Add(line); 
            }
        }

        private void updateData()
        {
            lboRawData.Items.Clear();
            lboSum.Items.Clear();
            sumList.Clear();

            foreach (string line in dataStream)
                lboRawData.Items.Add(line);

            foreach(string line in dataStream)
            {
                int sum = 0;
                string[] splitLine = line.Split(';');

                foreach(string splitPart in splitLine)
                {
                    sum += Convert.ToInt32(splitPart);
                }

                sumList.Add(sum);
            }

            foreach(int sum in sumList)
            {
                lboSum.Items.Add(sum);
            }

        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if(budgetRegex(txtInput.Text))
                {
                    dataStream.Add(txtInput.Text);
                    updateData();
                    txtInput.Clear();
                }
                else
                {
                    MessageBox.Show("Bitte überprüfen Sie Ihre Eingabe. Format: ZAHL;ZAHL;ZAHL", "Fehlerhafte Eingabe", MessageBoxButtons.OK);
                    txtInput.Clear();
                }
            }
        }

        private bool budgetRegex(string InputData)  //Manually Coded a Regex to check for wrong inputs
        {
            char[] splitData = InputData.ToCharArray();
            int DataLength = splitData.Length;
            bool doubleCheck = false;

            if (DataLength == 0)
                return false;

            if (splitData[0] == ';' || splitData[DataLength - 1] == ';')
                return false;

            foreach (char splitPart in splitData)
            {
              
                if (!(splitPart.Equals('1') || splitPart.Equals('2') || splitPart.Equals('3') || splitPart.Equals('4') || splitPart.Equals('5') || splitPart.Equals('6') || splitPart.Equals('7') || splitPart.Equals('8') || splitPart.Equals('9') || splitPart.Equals('0') || splitPart.Equals(';')))
                {
                    return false;
                }

                if(splitPart == ';' && doubleCheck == true)
                {
                    return false;
                }
                else if(splitPart == ';')
                {
                    doubleCheck = true;
                }
                else
                {
                    doubleCheck = false;
                }
            }

            return true;
        }
    }
}