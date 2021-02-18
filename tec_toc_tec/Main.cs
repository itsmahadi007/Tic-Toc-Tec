using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tec_toc_tec
{
    
    public partial class Main : Form
    {
        bool turn = true;//true=x turn and false=y turn//
        int turn_count = 0;
        bool finish = false;
        public Main()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by Mahadi Hassan and Mostofa Kamal", "Tic Tac toe About ");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Login objl = new Login();
            objl.Show();
        }

        private void button_click(object sender, EventArgs e)
        {
            if (finish == false)
            {
                Button b = (Button)sender;
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
                turn = !turn;
                b.Enabled = false;
                turn_count++;
                checkForWinner();
            }
            else
            { MessageBox.Show("Please Start A New Game","Game Over");
            }
        }
        private void checkForWinner()
        {
            bool there_is_winner = false;
            //horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                there_is_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text)&& (!C1.Enabled))
                there_is_winner = true;

            //verticaly check
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_winner = true;

            //Diagonal check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_winner = true;
            

            if (there_is_winner)
            {
                finish = true;
                disableButtons();
                string winner= "";
                if (turn)
                {
                    winner = "O";
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show(winner + " Wins", "Great!");
            }//end if
            else
            {
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show(" Draw", "Good!");
                }
            }
        }//end checkForWinner
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
              
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                
            }
           catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Newgame();
        }

        private void Newgame()
        {
            turn = true;
            turn_count = 0;
            finish = false;
           
                foreach (Control c in Controls)
                {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
            
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                    b.Text = "";
                
            }
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
            Newgame();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login objl = new Login();
            this.Hide();
            objl.Show();
        }
    }
}
