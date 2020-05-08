using System;
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
using System.Windows.Input;
using System.Windows;
using System.Xml;

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
            lblLastChanged.Text = "Zuletzt geändert:";
            
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
            DialogResult result = MessageBox.Show("Sind Sie sicher, dass sie das Programm beenden möchten ohne vorher zu speichern?", "Schließen ohne Speichern", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {

                Application.Exit();
            }
        }

        private void speichern()
        {
            if (datafile == null)
            {
                MessageBox.Show("Keine Datei zum speichern ausgwählt bitte öffnen sie zuerst eine Datei!", "Datei auswählen" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                updateTime();
            }
        }

        private void speichernSchließenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (datafile == null)
            {
                MessageBox.Show("Keine Datei zum speichern ausgwählt bitte öffnen sie zuerst eine Datei!","Datei auswählen", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Keine Datei geöffnet welche gelöscht werden kann.","Keine Datei ausgewählt" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show(String.Format("Sind Sie sicher, dasss sie die Datei {0} löschen möchten?",filename), "Datei Löschen" ,MessageBoxButtons.OKCancel);
                if(result == DialogResult.OK)
                {
                    File.Delete(datafile);
                }

                lblLastChanged.Text = "Zuletzt geändert:";
            }
        }

        private void readData()
        {
            bool truedata = false;
            foreach (string line in File.ReadLines(datafile))
            {
                if(string.IsNullOrEmpty(line))
                {
                    truedata = true;
                }
                else if (!(budgetRegex(line)))
                {
                    truedata = false;
                }
                else
                {
                    truedata = true;
                }
            }
            if(truedata)
            {
                foreach (string line in File.ReadLines(datafile))
                {
                    if(!(string.IsNullOrEmpty(line)))
                    {
                        dataStream.Add(line);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Die ausgewählte Datei entspricht nicht dem gewünschtem Format!","Fehlerhafte Datei", MessageBoxButtons.OK,MessageBoxIcon.Error);
                datafile = null;
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

            updateTime();

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
                    MessageBox.Show("Bitte überprüfen Sie Ihre Eingabe. Format: ZAHL;ZAHL;ZAHL", "Fehlerhafte Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInput.Clear();
                }
                e.Handled = true; //Suppress Windows Notify Sound when pressing Enter
                
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

        private void updateTime()
        {
            if(datafile != null)
            {
                lblLastChanged.Text = "Zuletzt geändert: " + File.GetLastWriteTime(datafile).ToLongTimeString() + " " + File.GetLastWriteTime(datafile).ToLongDateString();
            }
            
        }

        /*private void CtrlS(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
        }*/

        private void clearUserInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(String.Format("Sind Sie sicher, dasss sie die Datei {0} ohne zu speichern schließen möchten und alle ungespeicherten Informationen löschen?", filename), "Datei Schließen Daten Löschen", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                datafile = null;
                lboSum.Items.Clear();
                lboRawData.Items.Clear();
            }

            
        }
    }
}
