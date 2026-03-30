using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }


        public Form1()
        {
            InitializeComponent();
        }


        public bool checkValues(PictureBox Box1, PictureBox Box2, PictureBox Box3)
        {

            if(Box1.Tag.ToString() != "?" && Box1.Tag.ToString() == Box2.Tag.ToString() && Box1.Tag.ToString() == Box3.Tag.ToString()){
                
                Box1.BackColor = Color.White;
                Box2.BackColor = Color.White;
                Box3.BackColor = Color.White;

                if (Box1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;

                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }




            }else
            {
                GameStatus.GameOver=false;
                return false;
            }



        }



        void EndGame()
        {

            lable_Turn.Text = "GameOver";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:

                    lable_Turn.Text = "Player (1)";
                    label_Winner.Text = "Player (1)";

                    break;

                 case enWinner.Player2:
                  lable_Turn.Text = "Player (2)";
                   label_Winner.Text = "Player (2)";
                    break;

                    default:
                    lable_Turn.Text = "Draw";
                    label_Winner.Text = "Draw";
                    break;
                    
            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }



        public void checkWinner()
        {
            //row
            if(checkValues(pictureBox, pictureBox2, pictureBox3))
            {
                return;
            }
            if (checkValues(pictureBox9, pictureBox6, pictureBox4))
            {
                return;
            }
            if (checkValues(pictureBox8, pictureBox7, pictureBox5))
            {
                return;
            }

            //col
            if(checkValues(pictureBox, pictureBox9, pictureBox8))
            {
                return;
            }

            if(checkValues(pictureBox2 , pictureBox6, pictureBox7))
            {
                return;
            }

            if( checkValues(pictureBox3 , pictureBox4, pictureBox5))
            {
                return;
            }

            //diagonal

            if (checkValues(pictureBox, pictureBox6, pictureBox5))
            {
                return;
            }

            if (checkValues(pictureBox8, pictureBox6, pictureBox3))
            {
                return;
            }

        }



        public void Change_Image(PictureBox Box)
        {
            if(Box.Tag.ToString() == "?")
            {
                switch(PlayerTurn) {

                case enPlayer.Player1:
                    Box.Image = Properties.Resources.X;
                    PlayerTurn = enPlayer.Player2;
                    lable_Turn.Text = "Player (2)";
                    GameStatus.PlayCount++;
                    Box.Tag = "X";
                        checkWinner();

                        break;
                    
                    
                 case enPlayer.Player2:
                    Box.Image = Properties.Resources.O;
                    PlayerTurn = enPlayer.Player1;
                    lable_Turn.Text = "Player (1)";
                    GameStatus.PlayCount++;
                    Box.Tag = "O";
                        checkWinner();
                        break;

                }

            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
                {
                    GameStatus.GameOver = true;
                    GameStatus.Winner = enWinner.Draw;
                    EndGame();
                }


        }







        private void RestButton(PictureBox box)
        {
            box.Image = Properties.Resources.question_mark_96;
            box.Tag = "?";
            box.BackColor = Color.Transparent;
        }


        private void RestartGame()
        {

            RestButton(pictureBox);
            RestButton(pictureBox2);
            RestButton(pictureBox3);
            RestButton(pictureBox4);
            RestButton(pictureBox5);
            RestButton(pictureBox6);
            RestButton(pictureBox7);
            RestButton(pictureBox8);
            RestButton(pictureBox9);

            PlayerTurn = enPlayer.Player1;
            lable_Turn.Text = "Player (1)";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            label_Winner.Text = "In Progress";

        }
        private void btn_RestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Color Black = Color.FromArgb(255, 0, 0, 0);
            Pen Pen = new Pen(Black);
            Pen.Width = 15;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            /*
               | Line type  |              Condition   |
               | ---------- | ------------------------ |
               | Horizontal | `y1 == y2` and `x1 ≠ x2` |
               | Vertical   | `x1 == x2` and `y1 ≠ y2` |
               | Diagonal   | `x1 ≠ x2` and `y1 ≠ y2`  |

             */



            e.Graphics.DrawLine(Pen, 70, 130, 400, 130);
            e.Graphics.DrawLine(Pen, 70, 250, 400, 250);

            e.Graphics.DrawLine(Pen, 315, 350, 315, 50);
            e.Graphics.DrawLine(Pen, 150, 350, 150, 50);



        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox5);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox3);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox9);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox6);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox4);

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox8);

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox7);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Change_Image(pictureBox2);

        }
    }
}
