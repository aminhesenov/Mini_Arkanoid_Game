namespace mini_arkanoid_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dx = 5;
        int dy = -5;
        int score = 0;
        bool GameOver = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && panel1.Left > 0)
            {
                panel1.Left -= 20;
            }
            if (e.KeyCode == Keys.Right && panel1.Right < ClientSize.Width)
            {
                panel1.Left += 20;
            }

            //yeni oyun
            if(e.KeyCode==Keys.Enter && GameOver)
            {
                RestarGame();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GameOver) return;
            ball.Left += dx;
            ball.Top += dy;
            //divar ile toqqushma
            if (ball.Left <= 0 || ball.Right >= this.ClientSize.Width)
            {
                dx = -dx;
            }
            if (ball.Top <= 0)
            {
                dy = -dy;
            }
            //panel toqqushma
            if (ball.Bounds.IntersectsWith(panel1.Bounds))
            {                               
                dy = -dy;
                dy--;
                score++;
            }
            //gameover
            if (ball.Bottom >= ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Oyun bitdi\nNetice: " + score + "\nYeni oyun üçün Enter basın");
                GameOver = true;
            }
        }
        private void RestarGame()
        {
            GameOver = false;
            ball.Location = new Point(94, 10);
            panel1.Location = new Point(284, 412);
            dx = 5;
            dy = -5;
            score = 0;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
