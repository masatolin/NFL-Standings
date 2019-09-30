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

namespace NFL_Standings_Masato_Lin
{
    public partial class nFLStandings : Form
    {
        public nFLStandings()
        {
            InitializeComponent();
        }

        // Main method: Finds the division checked and adds teams to list box
        private void GetStandings()
        {
            // Checks which division is checked and returns the division name as a string
            string DivisionName = GetCheckedDivisionName();
            // For the selected division name, it adds the teams in that division to the list box
            GetTeamsByDivisionName(DivisionName);
        }

        // For each division string case, adds corresponding teams to the list box
        private void GetTeamsByDivisionName(string DivisionName)
        {
            switch (DivisionName)
            {
                case "AFC North":
                    divisionStandingsListBox.Items.Add("1) Steelers");
                    divisionStandingsListBox.Items.Add("2) Bengals");
                    divisionStandingsListBox.Items.Add("3) Ravens");
                    divisionStandingsListBox.Items.Add("4) Browns");
                    break;

                case "AFC South":
                    divisionStandingsListBox.Items.Add("1) Texans");
                    divisionStandingsListBox.Items.Add("2) Titans");
                    divisionStandingsListBox.Items.Add("3) Colts");
                    divisionStandingsListBox.Items.Add("4) Jaguars");
                    break;

                case "AFC East":
                    divisionStandingsListBox.Items.Add("1) Patriots");
                    divisionStandingsListBox.Items.Add("2) Dolphins");
                    divisionStandingsListBox.Items.Add("3) Jets");
                    divisionStandingsListBox.Items.Add("4) Bills");
                    break;

                case "AFC West":
                    divisionStandingsListBox.Items.Add("1) Chiefs");
                    divisionStandingsListBox.Items.Add("2) Chargers");
                    divisionStandingsListBox.Items.Add("3) Broncos");
                    divisionStandingsListBox.Items.Add("4) Raiders");
                    break;

                case "NFC North":
                    divisionStandingsListBox.Items.Add("1) Bears");
                    divisionStandingsListBox.Items.Add("2) Vikings");
                    divisionStandingsListBox.Items.Add("3) Packers");
                    divisionStandingsListBox.Items.Add("4) Lions");
                    break;

                case "NFC South":
                    divisionStandingsListBox.Items.Add("1) Saints");
                    divisionStandingsListBox.Items.Add("2) Panthers");
                    divisionStandingsListBox.Items.Add("3) Falcons");
                    divisionStandingsListBox.Items.Add("4) Buccaneers");
                    break;

                case "NFC East":
                    divisionStandingsListBox.Items.Add("1) Redskins");
                    divisionStandingsListBox.Items.Add("2) Eagles");
                    divisionStandingsListBox.Items.Add("3) Cowboys");
                    divisionStandingsListBox.Items.Add("4) Giants");
                    break;

                case "NFC West":
                    divisionStandingsListBox.Items.Add("1) Rams");
                    divisionStandingsListBox.Items.Add("2) Seahawks");
                    divisionStandingsListBox.Items.Add("3) Cardinals");
                    divisionStandingsListBox.Items.Add("4) 49ers");
                    break;
                default:
                    divisionStandingsListBox.Items.Add("Error");
                    break;
            }
        }

        // Sees which radio button is checked and pulls out division name for corresponding button
        private string GetCheckedDivisionName()
        {
            if (aFCNorthRadioButton.Checked)
            {
                return ("AFC North");
            }
            else if (aFCSouthRadioButton.Checked)
            {
                return ("AFC South");
            }
            else if (aFCEastRadioButton.Checked)
            {
                return ("AFC East");
            }
            else if (aFCWestRadioButton.Checked)
            {
                return ("AFC West");
            }
            else if (nFCNorthRadioButton.Checked)
            {
                return ("NFC North");
            }
            else if (nFCSouthRadioButton.Checked)
            {
                return ("NFC South");
            }
            else if (nFCEastRadioButton.Checked)
            {
                return ("NFC East");
            }
            else if (nFCWestRadioButton.Checked)
            {
                return ("NFC West");
            }
            else
            {
                return ("Nothing checked");
            }
        }

        // Clears list box, then uses methods GetStandings to put in teams in the list box
        private void showStandingsButton_Click(object sender, EventArgs e)
        {
            divisionStandingsListBox.Items.Clear();
            GetStandings();

        }

        // Creates save dialog and then writes in list items in file
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Pulls out save dialog for text doc
                StreamWriter outputFile;
                SaveFileDialog.DefaultExt = "txt";
                SaveFileDialog.Filter = "Text Document|*.txt";
                SaveFileDialog.Title = "Division Standings";
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Create the selected file.
                    outputFile = File.CreateText(SaveFileDialog.FileName);
                    foreach (string item in divisionStandingsListBox.Items)
                    {
                        outputFile.WriteLine(item.ToString());
                    }
                    outputFile.Close();
                }
                else
                {
                    // If save is cancelled
                    MessageBox.Show("Save cancelled.");
                }
            }
            catch
            {
                //Display Error Message
                MessageBox.Show("Error writing the file.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Close program
            this.Close();
        }
    }
}
