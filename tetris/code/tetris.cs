// ����������̂Ȃ��e�g���X
//   �e�g���~�m�̉�]�̓}�E�X�̍��E�{�^�����N���b�N���܂��B
//   �e�g���~�m�ړ���Z(���ړ�)�AX(�E�ړ�)�L�[�ōs���܂��B
//   �A���S���Y���m�F�̂��߂ɍ쐬���܂����̂ŁA
//   �_���\��������鎞�̃A�j���\�����Ȃ���������̂Ȃ��e�g���X�ł��B
//   �������ɉ��ǂ��Ă݂�̂��y�����Ǝv���܂��B
//
// (�e�g���~�m�̌`��)
// +----------+------------------------------------+
// |          |      rot �i������_ ix,iy)       |
// |   bTP    +--------+--------+--------+---------+
// |          |   0    |   1    |    2   |   3     |
// +----------+--------+--------+--------+---------+
// |          |  ��    |     �� |  ����  |         |
// |    1     |  ��    | ������ |    ���@| ������  |
// |          |  ����  |        |    ��  | ��      |
// +----------+--------+--------+--------+---------+
// |          |    ��  |        |  ����  | ��      |
// |    2     |    ��  | ������ |  ��  �@| ������  |
// |          |  ����  |     �� |  ��    |         |
// +----------+--------+--------+--------+---------+
// |          |        |   ��   |  ��    |   ��    |
// |    3     | ������ |   ���� |�������@| ����    |
// |          |   ��   |   ��   |        |   ��    |
// +----------+--------+--------+--------+---------+
// |          |        |     �� |        
// |    4     | ����   |   ���� |
// |          |   ���� |   ��   | 
// +----------+--------+--------+
// |          |   ���� | ��     |        
// |    5     | ����   | ����   |
// |          |        |   ��   | 
// +----------+--------+--------+
// |          |        |   ��   |        
// |          |        |   ��   |
// |    6     |��������|   ��   | 
// |          |        |   ��   | 
// +----------+--------+--------+
// |          |  ����  |           
// |    7     |�@����  |    
// |          |        |    
// +----------+--------+

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetoris
{
    public partial class Form1 : Form
    {
        public Image image = new Bitmap(1000, 1000);//�\���p�r�b�g�}�b�v
        public static Graphics g;             //  �\���p�O���t�B�b�N�I�u�W�F�N�g
        public int[,] DT = new int[20, 10];
        public Brush[] ClDt = new Brush[8];
        public Brush bBlack = new SolidBrush(Color.Black);
        public Random rn = new Random();
        public Pen pWhite = new Pen(Color.White);
        public Pen pGray = new Pen(Color.FromArgb(50, 50, 50));
        public int bTP, rot, ix, iy;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)//�ĕ\��
        {
            base.OnPaint(e); e.Graphics.DrawImage(image, 10, 10);
        }
        public void drawStone(Graphics g, int i, int j, int ID)//�w�i�\��
        {
            g.FillRectangle(ClDt[ID], (float)(j * 20 + 20), (float)(i * 20), 20.0F, 20.0F);
            if (ID != 0)
            {
                float X = (float)(j * 20 + 20), Y = (float)(i * 20);
                g.DrawLine(pWhite, X, Y, X + 20, Y);
                g.DrawLine(pWhite, X, Y, X, Y + 20);
                g.DrawLine(pGray, X + 1, Y + 19, X + 19, Y + 19);
                g.DrawLine(pGray, X + 19, Y, X + 19, Y + 19);
            }
        }
        public void drawTt(int i1, int j1, int i2, int j2, int i3, int j3, int i4, int j4)
        {
            drawStone(g, iy + i1, ix + j1, bTP); drawStone(g, iy + i2, ix + j2, bTP);
            drawStone(g, iy + i3, ix + j3, bTP); drawStone(g, iy + i4, ix + j4, bTP);
        }
        public void drawTetrimino()// �e�g���~�m�̕\��
        {
            switch (bTP)
            {
                case 1:
                    switch (rot)
                    {
                        case 0: drawTt(-1, 0, 0, 0, 1, 0, 1, 1); break;
                        case 1: drawTt(0, -1, 0, 0, 0, 1, -1, 1); break;
                        case 2: drawTt(1, 0, 0, 0, -1, 0, -1, -1); break;
                        case 3: drawTt(1, -1, 0, -1, 0, 0, 0, 1); break;
                    }
                    break;
                case 2:
                    switch (rot)
                    {
                        case 0: drawTt(-1, 0, 0, 0, 1, 0, 1, -1); break;
                        case 1: drawTt(0, -1, 0, 0, 0, 1, 1, 1); break;
                        case 2: drawTt(1, 0, 0, 0, -1, 0, -1, 1); break;
                        case 3: drawTt(-1, -1, 0, -1, 0, 0, 0, 1); break;
                    }
                    break;
                case 3:
                    switch (rot)
                    {
                        case 0: drawTt(0, -1, 0, 0, 0, 1, 1, 0); break;
                        case 1: drawTt(-1, 0, 0, 0, 1, 0, 0, 1); break;
                        case 2: drawTt(-1, 0, 0, 0, 0, -1, 0, 1); break;
                        case 3: drawTt(-1, 0, 0, 0, 0, -1, 1, 0); break;
                    }
                    break;
                case 4:
                    if (rot == 0) drawTt(0, -1, 0, 0, 1, 0, 1, 1);
                    else drawTt(0, 1, 0, 0, -1, 1, 1, 0);
                    break;
                case 5:
                    if (rot == 0) drawTt(0, -1, 0, 0, -1, 0, -1, 1);
                    else drawTt(-1, -1, 0, -1, 0, 0, 1, 0);
                    break;
                case 6:
                    if (rot == 0) drawTt(0, -1, 0, 0, 0, 1, 0, 2);
                    else drawTt(1, 0, 0, 0, -1, 0, -2, 0);
                    break;
                case 7: drawTt(0, 0, 0, 1, 1, 0, 1, 1); break;
            }
        }
        public void draw()
        {
            g.Clear(this.BackColor);
            g.FillRectangle(bBlack, 10.0F, 10.0F, 10.0F, 390.0F);
            g.FillRectangle(bBlack, 220.0F, 10.0F, 10.0F, 390.0F);
            g.FillRectangle(bBlack, 10.0F, 400.0F, 220.0F, 10.0F);
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 10; j++) drawStone(g, i, j, DT[i, j]);
            drawTetrimino();
            this.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(image);
            for (int i = 0; i < 20; i++) for (int j = 0; j < 10; j++) DT[i, j] = 0;
            ClDt[0] = new SolidBrush(Color.White);
            ClDt[1] = new SolidBrush(Color.Blue);
            ClDt[2] = new SolidBrush(Color.Green);
            ClDt[3] = new SolidBrush(Color.Brown);
            ClDt[4] = new SolidBrush(Color.Cyan);
            ClDt[5] = new SolidBrush(Color.Yellow);
            ClDt[6] = new SolidBrush(Color.Purple);
            ClDt[7] = new SolidBrush(Color.Red);
            bTP = rn.Next(7) + 1; rot = 0; ix = rn.Next(5) + 2; iy = 2;
            draw(); timer1.Enabled = true;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {                   //�@�@����
            if (bTP != 7)   //�@�@�����@�̂Ƃ���]�Ȃ��ibTP=7)
            {   //��]�\�����`�F�b�N
                bool x = true;
                if (bTP == 6)
                {
                    if (rot == 0)   //   ���������������̂Ƃ��̉�]�\�̃`�F�b�N
                    {
                        if (iy <= 2 || iy >= 8) x = false;
                        else if (DT[iy - 2, ix] != 0 || DT[iy - 1, ix] != 0 ||
                                  DT[iy + 1, ix] != 0) x = false;
                    }
                    if (rot == 1)  //   �c�������������̂Ƃ��̉�]�\�`�F�b�N
                    {
                        if (ix <= 2 || ix >= 8) x = false;
                        else if (DT[iy, ix - 2] != 0 || DT[iy, ix - 1] != 0 ||
                                 DT[iy, ix + 1] != 0) x = false;
                    }
                }
                else  //   ���̑��̉�]�\�`�F�b�N�i����ɂ���Ή�]�s�Ƃ���j
                    for (int i = iy - 1; i <= iy + 1; i++)
                        for (int j = ix - 1; j <= ix + 1; j++)
                        {
                            if (i < 0 || i > 19 || j < 0 || j > 9) { x = false; break; }
                            if (DT[i, j] != 0) { x = false; break; }
                        }
                if (x)
                {   // ��]
                    if (e.Button == MouseButtons.Left)
                    {   // ���{�^���̂Ƃ����v�Ɣ��Ή��
                        rot++;
                        if (bTP < 4 && rot > 3) rot = 0;
                        else if (bTP >= 4 && bTP <= 6 && rot > 1) rot = 0;
                    }
                    else if (e.Button == MouseButtons.Right)
                    {   // �E�{�^���̂Ƃ����v���
                        rot--;
                        if (bTP < 4 && rot < 0) rot = 3;
                        else if (bTP >= 4 && bTP <= 6 && rot < 0) rot = 1;
                    }
                }
            }
            draw();
        }
        private void setDT(int i1, int j1, int i2, int j2, int i3, int j3, int i4, int j4)
        {
            DT[iy + i1, ix + j1] = bTP; DT[iy + i2, ix + j2] = bTP;
            DT[iy + i3, ix + j3] = bTP; DT[iy + i4, ix + j4] = bTP;
        }
        private bool chkMove(int maxY, int i1, int j1)
        {
            if (iy >= maxY) return true;
            else if (DT[iy + i1, ix + j1] != 0) return true;
            return false;
        }
        private bool chkMove(int maxY, int i1, int j1, int i2, int j2)
        {
            if (iy >= maxY) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0) return true;
            return false;
        }
        private bool chkMove(int maxY, int i1, int j1, int i2, int j2, int i3, int j3)
        {
            if (iy >= maxY) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0 ||
                    DT[iy + i3, ix + j3] != 0) return true;
            return false;
        }
        private bool chkMove(int maxY, int i1, int j1, int i2, int j2,
                                       int i3, int j3, int i4, int j4)
        {
            if (iy >= maxY) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0 ||
                    DT[iy + i3, ix + j3] != 0 || DT[iy + i4, ix + j4] != 0) return true;
            return false;
        }
        public bool movable()//�@�����Ɉړ��\�����`�F�b�N
        {
            switch (bTP)
            {
                case 1:
                    switch (rot)
                    {
                        case 0: return chkMove(18, 2, 0, 2, 1);
                        case 1: return chkMove(19, 1, -1, 1, 0, 1, 1);
                        case 2: return chkMove(18, 2, 0, 0, -1);
                        default: return chkMove(18, 2, -1, 1, 0, 1, 1);
                    }
                case 2:
                    switch (rot)
                    {
                        case 0: return chkMove(18, 2, -1, 2, 0);
                        case 1: return chkMove(18, 1, -1, 1, 0, 2, 1);
                        case 2: return chkMove(18, 2, 0, 0, 1);
                        default: return chkMove(19, 1, -1, 1, 0, 1, 1);
                    }
                case 3:
                    switch (rot)
                    {
                        case 0: return chkMove(18, 1, -1, 2, 0, 1, 1);
                        case 1: return chkMove(18, 2, 0, 1, 1);
                        case 2: return chkMove(19, 1, -1, 1, 0, 1, 1);
                        default: return chkMove(18, 1, -1, 2, 0);
                    }

                case 4:
                    switch (rot)
                    {
                        case 0: return chkMove(18, 1, -1, 2, 0, 2, 1);
                        default: return chkMove(18, 2, 0, 1, 1);
                    }
                case 5:
                    switch (rot)
                    {
                        case 0: return chkMove(19, 1, -1, 1, 0, 0, 1);
                        default: return chkMove(18, 1, -1, 2, 0);
                    }

                case 6:
                    switch (rot)
                    {
                        case 0: return chkMove(19, 1, -1, 1, 0, 1, 1, 1, 2);
                        default: return chkMove(18, 2, 0);
                    }

                case 7:
                    return chkMove(18, 2, 0, 2, 1);

            }
            return false;
        }
        private void stopProc()//��~���������e�g���~�m�`���DT�Ɉڂ��B
        {
            switch (bTP)
            {
                case 1:
                    switch (rot)
                    {
                        case 0: setDT(-1, 0, 0, 0, 1, 0, 1, 1); break;
                        case 1: setDT(0, -1, 0, 0, 0, 1, -1, 1); break;
                        case 2: setDT(1, 0, 0, 0, -1, 0, -1, -1); break;
                        case 3: setDT(1, -1, 0, -1, 0, 0, 0, 1); break;
                    }
                    break;
                case 2:
                    switch (rot)
                    {
                        case 0: setDT(-1, 0, 0, 0, 1, 0, 1, -1); break;
                        case 1: setDT(0, -1, 0, 0, 0, 1, 1, 1); break;
                        case 2: setDT(1, 0, 0, 0, -1, 0, -1, 1); break;
                        case 3: setDT(-1, -1, 0, -1, 0, 0, 0, 1); break;
                    }
                    break;
                case 3:
                    switch (rot)
                    {
                        case 0: setDT(0, -1, 0, 0, 0, 1, 1, 0); break;
                        case 1: setDT(-1, 0, 0, 0, 1, 0, 0, 1); break;
                        case 2: setDT(-1, 0, 0, 0, 0, -1, 0, 1); break;
                        case 3: setDT(-1, 0, 0, 0, 0, -1, 1, 0); break;
                    }
                    break;
                case 4:
                    if (rot == 0) setDT(0, -1, 0, 0, 1, 0, 1, 1);
                    else setDT(0, 1, 0, 0, -1, 1, 1, 0);
                    break;
                case 5:
                    if (rot == 0) setDT(0, -1, 0, 0, -1, 0, -1, 1);
                    else setDT(-1, -1, 0, -1, 0, 0, 1, 0);
                    break;
                case 6:
                    if (rot == 0) setDT(0, -1, 0, 0, 0, 1, 0, 2);
                    else setDT(1, 0, 0, 0, -1, 0, -2, 0);
                    break;
                case 7:
                    setDT(0, 0, 0, 1, 1, 0, 1, 1); break;
            }
        }
        private void deleteLine()// �s�̍폜
        {
            bool allflag = true;
            while (allflag)
            {
                allflag = false;
                for (int i = 19; i >= 0; i--)
                {
                    bool iflag = true;
                    for (int j = 0; j < 10; j++) if (DT[i, j] == 0) { iflag = false; break; }
                    if (iflag)
                    {
                        allflag = true;
                        for (int k = i; k >= 1; k--)
                            for (int j = 0; j < 10; j++) DT[k, j] = DT[k - 1, j];
                        for (int j = 0; j < 10; j++) DT[0, j] = 0;
                    }
                }
            }
        }
        private void judgeEnd()//�I������B�I�����^�C�}�[���~�߂�B
        {
            for (int ii = 0; ii < 3; ii++) for (int jj = 0; jj < 10; jj++)
                {
                    if (DT[ii, jj] != 0)
                    {
                        timer1.Enabled = false;
                        MessageBox.Show("�Q�[���I��");
                        for (int i = 0; i < 20; i++) for (int j = 0; j < 10; j++) DT[i, j] = 0;
                        break;
                    }
                }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!movable()) { iy++; draw(); return; }
            stopProc(); deleteLine(); judgeEnd();
            timer1.Enabled = true;
            bTP = rn.Next(7) + 1; rot = 0; ix = rn.Next(5) + 2; iy = 2;
            draw();
        }
        private bool chkLF(int minX, int i1, int j1)//���t�g�������ړ��\�����`�F�b�N
        {
            if (ix <= minX) return true;
            else if (DT[iy + i1, ix + j1] != 0) return true;
            return false;
        }
        private bool chkLF(int minX, int i1, int j1, int i2, int j2)
        {
            if (ix <= minX) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0) return true;
            return false;
        }
        private bool chkLF(int minX, int i1, int j1, int i2, int j2, int i3, int j3)
        {
            if (ix <= minX) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0 ||
                        DT[iy + i3, ix + j3] != 0) return true;
            return false;
        }
        private bool chkLF(int minX, int i1, int j1, int i2, int j2,
                                     int i3, int j3, int i4, int j4)
        {
            if (ix <= minX) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0 ||
                        DT[iy + i3, ix + j3] != 0 || DT[iy + i4, ix + j4] != 0) return true;
            return false;
        }
        private bool chkRT(int maxX, int i1, int j1)//�e�g���~�m���E�����Ɉړ��\�����`�F�b�N
        {
            if (ix >= maxX) return true;
            else if (DT[iy + i1, ix + j1] != 0) return true;
            return false;
        }
        private bool chkRT(int maxX, int i1, int j1, int i2, int j2)
        {
            if (ix >= maxX) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0) return true;
            return false;
        }
        private bool chkRT(int maxX, int i1, int j1, int i2, int j2, int i3, int j3)
        {
            if (ix >= maxX) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0 ||
                        DT[iy + i3, ix + j3] != 0) return true;
            return false;
        }
        private bool chkRT(int maxX, int i1, int j1, int i2, int j2,
                                     int i3, int j3, int i4, int j4)
        {
            if (ix >= maxX) return true;
            else if (DT[iy + i1, ix + j1] != 0 || DT[iy + i2, ix + j2] != 0 ||
                        DT[iy + i3, ix + j3] != 0 || DT[iy + i4, ix + j4] != 0) return true;
            return false;
        }
        private bool notMovableLeft()//�e�g���~�m�`��ʂ̍������ւ̈ړ��\���̃`�F�b�N
        {
            switch (bTP)
            {
                case 1:
                    switch (rot)
                    {
                        case 0: return chkLF(0, -1, -1, 0, -1, 1, -1);
                        case 1: return chkLF(1, -2, 0, -1, 0);
                        case 2: return chkLF(1, -1, -2, 0, -1, 1, -1);
                        default: return chkLF(1, 0, -2, 1, -2);
                    }
                case 2:
                    switch (rot)
                    {
                        case 0: return chkLF(1, -1, -1, 0, -1, 1, -2);
                        case 1: return chkLF(1, 0, -2, 1, 0);
                        case 2: return chkLF(0, -1, -1, 0, -1, 1, -1);
                        default: return chkLF(1, -1, -2, 0, -2);
                    }
                case 3:
                    switch (rot)
                    {
                        case 0: return chkLF(1, 0, -2, 1, -1);
                        case 1: return chkLF(0, -1, -1, 0, -1, 1, -1);
                        case 2: return chkLF(1, -1, -1, 0, -2);
                        default: return chkLF(1, -1, -1, 0, -2, 1, -1);
                    }
                case 4:
                    switch (rot)
                    {
                        case 0: return chkLF(1, 0, -2, 1, -1);
                        default: return chkLF(0, -1, 0, 0, -1, 1, -1);
                    }
                case 5:
                    switch (rot)
                    {
                        case 0: return chkLF(1, -1, -1, 0, -2);
                        default: return chkLF(1, -1, -2, 0, -2, 1, -1);
                    }
                case 6:
                    switch (rot)
                    {
                        case 0: return chkLF(1, 0, -2);
                        default: return chkLF(0, -2, -1, -1, -1, 0, -1, 1, -1);
                    }
                default: return chkLF(0, 0, -1, 1, -1);
            }
        }
        private bool notMovableRight()//�e�g���~�m�`��ʂ̉E�����ւ̈ړ��\���̃`�F�b�N
        {
            switch (bTP)
            {
                case 1:
                    switch (rot)
                    {
                        case 0: return chkRT(8, -1, 1, 0, 1, 1, 2);
                        case 1: return chkRT(8, -1, 2, 0, 2);
                        case 2: return chkRT(9, -1, 1, 0, 1, 1, 1);
                        default: return chkRT(8, 0, 2, 1, 0);
                    }
                case 2:
                    switch (rot)
                    {
                        case 0: return chkRT(9, -1, 1, 0, 1, 1, 1);
                        case 1: return chkRT(8, 0, 2, 1, 2);
                        case 2: return chkRT(8, -1, 2, 0, 1, 1, 1);
                        default: return chkRT(8, -1, 0, 0, 2);
                    }
                case 3:
                    switch (rot)
                    {
                        case 0: return chkRT(8, 0, 2, 1, 1);
                        case 1: return chkRT(8, -1, 1, 0, 2, 1, 1);
                        case 2: return chkRT(8, -1, 1, 0, 2);
                        default: return chkRT(9, -1, 1, 0, 1, 1, 1);
                    }
                case 4:
                    switch (rot)
                    {
                        case 0: return chkRT(8, 0, 1, 1, 2);
                        default: return chkRT(8, -1, 2, 0, 2, 1, 1);
                    }
                case 5:
                    switch (rot)
                    {
                        case 0: return chkRT(8, -1, 2, 0, 1);
                        default: return chkRT(9, -1, 0, 0, 1, 1, 1);
                    }
                case 6:
                    switch (rot)
                    {
                        case 0: return chkRT(7, 0, 3);
                        default: return chkRT(9, -2, 1, -1, 1, 0, 1, 1, 1);
                    }
                default:
                    return chkRT(8, 0, 2, 1, 2);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string s = e.KeyCode.ToString();
            if ((s == "Z" || s == "z") && !notMovableLeft()) ix--;
            else if ((s == "X" || s == "x") && !notMovableRight()) ix++;
        }
    }
}