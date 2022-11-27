using SpaceGame.Game;
using SpaceGame.Game.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceGame
{
    public partial class Form1 : Form
    {
        //GameForm gameForm;
        Player player;
        Engine[] engines;
        public Form1()
        {
            InitializeComponent();


        }

        private Engine GetInstanceFromName(string name)
        {
            switch (name)
            {
                case "Нефтяной двигатель":
                    return new OilEngine();
                case "Ядерный двигатель":
                    return new NuclearEngine();
                case "Звёздный двигатель":
                    return new SolarEngine();
                default:
                    return new OilEngine();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int fuel = 500;
            int fuelPerTurn = 1;

            if (radioButton1.Checked)
            {
                engines = new Engine[3];
                engines[0] = GetInstanceFromName(comboBox1.SelectedItem.ToString());
                engines[1] = GetInstanceFromName(comboBox2.SelectedItem.ToString());
                engines[2] = GetInstanceFromName(comboBox3.SelectedItem.ToString());
                fuelPerTurn = 4;
            }
            else if (radioButton2.Checked)
            {
                fuel = 1000;
                engines = new Engine[2];
                engines[0] = new OilEngine();
                engines[1] = new OilEngine();
                fuelPerTurn = 2;
            }
            else if (radioButton3.Checked)
            {
                fuel = 1500;
                engines = new Engine[1];
                engines[0] = new NuclearEngine();
            }

            int cells = Convert.ToInt32(textBox1.Text);

            Random rand = new Random();

            player = new Player(new Point(rand.Next(0, cells), rand.Next(0, cells)), fuel, engines, fuelPerTurn);
            GameForm gameForm = new GameForm(player, cells);

            this.Hide();
            gameForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox1.Items[1];
            comboBox3.SelectedItem = comboBox1.Items[2];
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = radioButton1.Checked;
            comboBox2.Visible = radioButton1.Checked;
            comboBox3.Visible = radioButton1.Checked;
        }
    }
}
