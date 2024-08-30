using System;
using System.Windows.Forms;

namespace OpenCVTest
{
    public partial class UserControlForm : UserControl
    {
        public delegate int delEvent();
        public event delEvent eventSender;

        public delegate int ReEvent();
        public event ReEvent eventSymmetryReturn;

        public delegate int CloseEvent();
        public event CloseEvent eventClose;

        OpenCV openCV = new OpenCV();

        public UserControlForm()
        {
            InitializeComponent();

            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
        }

        private void btnXYResult_Click(object sender, EventArgs e)
        {
            try
            {
                // textbox에 집적 입력 받았을때
                openCV.MouseXY(float.Parse(txtLUpX.Text), float.Parse(txtLUpY.Text));
                openCV.MouseXY(float.Parse(txtLDownX.Text), float.Parse(txtLDownY.Text));
                openCV.MouseXY(float.Parse(txtRUpX.Text), float.Parse(txtRUpY.Text));
                openCV.MouseXY(float.Parse(txtRDownX.Text), float.Parse(txtRDownY.Text));

                eventSender?.Invoke();

            }
            catch { MessageBox.Show("좌표를 입력하세요"); }

        }

        private void btnXYBack_Click(object sender, EventArgs e)
        {
            txtLUpX.Text = "";
            txtLUpY.Text = "";
            txtLDownX.Text = "";
            txtLDownY.Text = "";
            txtRUpX.Text = "";
            txtRUpY.Text = "";
            txtRDownX.Text = "";
            txtRDownY.Text = "";

            eventSymmetryReturn?.Invoke();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            eventClose.Invoke();
        }
    }
}
