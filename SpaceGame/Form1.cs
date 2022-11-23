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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int fuel = 500;

            if (radioButton2.Checked)
            {
                fuel = 1000;
                engines = new Engine[2];
                engines[0] = new OilEngine();
                engines[1] = new OilEngine();
                //player = new Player(new Point(2,4), )
            }
            else if (radioButton3.Checked)
            {
                fuel = 1500;
                engines = new Engine[1];
                engines[0] = new NuclearEngine();
            }

            player = new Player(new Point(2, 4), fuel, engines);
            GameForm gameForm = new GameForm(player);

            this.Hide();
            gameForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
