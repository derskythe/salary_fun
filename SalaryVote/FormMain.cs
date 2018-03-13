using System;
using System.Drawing;
using System.Windows.Forms;

namespace SalaryVote
{
    public partial class FormMain : Form
    {
        private bool _Answered;
        private Rectangle _Rectangle;
        private Random _Rnd;

        public FormMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_Answered)
            {
                e.Cancel = true;
                MessageBox.Show(
                                @"Пожалуйста, выберите ответ Да или Нет",
                                @"Ответ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }       

        private void btnNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            @"Этого не должно было произойти!",
                            @"Ответ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            lblResult.Visible = _Answered = true;
            lblQuestion.Visible = btnYes.Visible = btnNo.Visible = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _Rectangle = new Rectangle(btnNo.Location, btnNo.Size);
            _Rnd = new Random((int)DateTime.Now.Ticks);
        }

        private void NewLocation(Point cursorLocation)
        {
            do
            {
                _Rectangle.Location = new Point(
                                                _Rnd.Next(0, ClientSize.Width - _Rectangle.Width),
                                                _Rnd.Next(0, ClientSize.Height - _Rectangle.Height));
            } while (CheckCursor(cursorLocation));

            btnNo.Location = _Rectangle.Location;
        }

        private bool CheckCursor(Point cursorLocation)
        {
            return (cursorLocation.Y >= _Rectangle.Bottom && cursorLocation.Y <= _Rectangle.Top) ^
                   (cursorLocation.X <= _Rectangle.Right && cursorLocation.X >= _Rectangle.Left);
        }

        private void btnNo_MouseEnter(object sender, EventArgs e)
        {
            NewLocation(Cursor.Position);
        }
    }
}
