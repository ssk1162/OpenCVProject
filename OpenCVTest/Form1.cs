using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Cognex.InSight;
using Cognex.InSight.Net;
using Cognex.InSight.Controls.Display;
using System.IO;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using Tesseract;
using ZXing;
using System.Windows.Media;

namespace OpenCVTest
{
    public partial class Form1 : Form
    {
        // ( 이미지 크기, 행/열 ), 정밀도 : CV_타입(8비트, unsigned / 8U) 채널(C1~4)
        // 이미지 처리 시 8비트가 가장 효율
        // 머신러닝 같은 경우 16비트가 가장 효율
        // 채널 1개일때 단일 채널(흑백 / 명암 정보를 저장할때 사용)
        // 채널 3~4개일때 다중 채널(각가의 채널은 이미지의 색상을 혼합해 최종 색상을 생성)
        // 예 : Red채널 빨간색 성분, Green채널 초록색 성분, Blue채널 파란색 성분, Alpha채널 투명도 조절

        //Mat src = new Mat(new OpenCvSharp.Size(640, 480), MatType.CV_8UC1);
        //Mat gray = new Mat(640, 480, MatType.CV_8UC1);

        // 이미지, 동영상, 이미지 or 동영상
        private Mat image, frame, result;

        // 동영상 출력
        private VideoCapture video;


        private CvsNetworkMonitor _Monitor;

        private CvsHostSensor _HostSensor;

        // Cognex 카메라 주소 저장
        private string SensorAddress;

        // 카메라1,2,3 / 그레이스케일 / 트리거
        private bool Ca1Flag, Ca2Flag, Ca3Flag, AffineFlag, BlurFlag, MoneyFlag, faceFlag;

        private RibbonCheckBox btnCheck;

        private Mat originalImage;

        private bool SymmetryFlag;

        int cropX, cropY, cropWidth, cropHeight;
        private System.Drawing.Pen cropPen;

        private bool Makeselection = false;

        private double num = 0;
        public int XYCount = 0;

        Bitmap img1;

        OpenCV openCV = new OpenCV();
        OpenCVBlur blur = new OpenCVBlur();
        OpenCVEdit openCVEdit = new OpenCVEdit();
        CoordinatesXY xy = new CoordinatesXY();

        OpenFileDialog ofd = new OpenFileDialog();
        UserControlForm ucf;
        BlurControl bc;

        DBConnect db = new DBConnect();

        string company;
        string product;
        string production;
        DateTime date;
        string test;

        public Form1()
        {
            InitializeComponent();

            // kit 초기화
            CvsInSightSoftwareDevelopmentKit.Initialize();

            Init();

            frame = new Mat();
            result = new Mat();

            // 마우스 줌인/아웃
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            // 스크롤바 100% 나타내기
            this.hScrollBar1.Maximum += this.hScrollBar1.LargeChange - 1;

            pictureBox1.DoubleClick += PictureBox1_DoubleClick;

            // db 접속 연결
            db.connect();
            //MessageBox.Show(db.msg);
        }

        private int Bc_eventClose()
        {
            // BlurControl이 있으면 지우고 메모리 해제
            if (panel2.Controls.Contains(bc))
            {
                panel2.Controls.Remove(bc);
                bc.Dispose();
            }
            return 0;
        }

        // 이미지 초기화
        private int Bc_eventReturn()
        {
            SymmetryReturn();
            return 0;
        }

        // 블러 BilateralFilter 이벤트
        private int Bc_eventBilateralFilter()
        {
            pictureBox1.Image = blur.btnBilateralFilter(result).ToBitmap();

            return 0;
        }

        // 블러 가우시안블러 이벤트
        private int Bc_eventGaussianBlur()
        {
            pictureBox1.Image = blur.btnGaussianBlur(result).ToBitmap();

            return 0;
        }

        // 블러 MedianBlur 이벤트
        private int Bc_eventMedianBlur()
        {
            pictureBox1.Image = blur.btnMedianBlur(result).ToBitmap();

            return 0;
        }

        // 블러 BoxFilter 이벤트
        private int Bc_eventBoxFilter()
        {
            pictureBox1.Image = blur.btnBoxFilter(result).ToBitmap();

            return 0;
        }

        // 블러 이벤트
        private int Bc_eventBlur()
        {
            pictureBox1.Image = blur.btnBlur(result).ToBitmap();

            return 0;
        }

        private int Ucf_eventClose()
        {
            // userControlForm1가 있으면 지우고 메모리 해제
            if (panel2.Controls.Contains(ucf))
            {
                XYCount = 0;
                panel2.Controls.Remove(ucf);
                ucf.Dispose();
            }
            return 0;
        }

        // 초기화
        private int Ucf_eventSymmetryReturn()
        {
            SymmetryReturn();
            XYCount = 0;
            return 0;
        }

        // 4개의 점 입력 받기
        private int Ucf_eventSender()
        {
            pictureBox1.Image = openCV.GeometricImage(result).ToBitmap();
            return 0;
        }

        // 폴더 열기
        private void ribbonOrbOpen_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MoneyFlag = false;
            Ca1Flag = false;
            Ca2Flag = false;
            Ca3Flag = false;

            ofd.Filter = "All Files (*.*)|*.*|Files (*.jpg *.jpeg *.png)|*.jpg;*.jpeg;*.png;|" +
                "Video Files (*.mp4 *.avi *.mov *.mkv *.wmv)|*.mp4;*.avi;*.mov;*.mkv;*.wmv;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(ofd.FileName);

                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    image = Cv2.ImRead(ofd.FileName, ImreadModes.Unchanged);

                    result = image;

                    pictureBox1.Size = new System.Drawing.Size(image.Width, image.Height);
                    pictureBox1.Image = result.ToBitmap();

                    timer1.Enabled = false;
                    btnRibbonTrigger.Enabled = false;
                }
                else if (extension == ".mp4" || extension == ".avi" || extension == ".mov" || extension == ".mkv" || extension == ".wmv")
                {
                    video = new VideoCapture(ofd.FileName);

                    timer1.Enabled = true;
                    btnRibbonTrigger.Enabled = true;
                }

                hScrollBar1.Value = 100;
                ScaleValue.Text = $"{hScrollBar1.Value.ToString()}%";

                ribbonUpDown.TextBoxText = "100%";
                ribbonUpDown.Value = "100";
                if (list != null)
                    list.Clear();
                else
                    return;
            }
        }

        // 이미지 저장
        private void ribbonOrbSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (result != null)
            {
                sfd.Title = "다른 이름으로 저장";
                // 이미있는 파일 이름이 있으면 알려줌
                sfd.OverwritePrompt = true;
                sfd.Filter = "Image Files (*.jpg *.jpeg *.png)|*.jpg;*.jpeg;*.png;";
                sfd.FilterIndex = 1;

                try
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = sfd.FileName;
                        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                        pictureBox1.Image.Save(fileName);
                    }
                }
                catch
                {
                    MessageBox.Show("이미지가 없습니다");
                }

            }
        }

        private void ribbonOrbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // USB 카메라1
        private void btnRibbon_Click(object sender, EventArgs e)
        {
            if (Ca1Flag == false)
            {
                try
                {
                    video = new VideoCapture(0);
                    video.FrameWidth = 800;
                    video.FrameHeight = 600;

                    timer1.Enabled = true;
                }
                catch
                {
                    timer1.Enabled = false;
                }

                MoneyFlag = false;
                Ca1Flag = true;
                Ca2Flag = false;
                Ca3Flag = false;

                groupBox2.Visible = false;
                btnRibbonTrigger.Enabled = true;
                cvsInSightDisplay1.Visible = false;
                _HostSensor = null;
                cvsInSightDisplay1.Disconnect();

                hScrollBar1.Value = 100;
                ScaleValue.Text = $"{hScrollBar1.Value.ToString()}%";
                ribbonUpDown.TextBoxText = "100%";
                ribbonUpDown.Value = "100";

                cbRibbonLive.Checked = false;
                cbRibbonLive.Enabled = false;
                // 이미지 자르기 좌표값 초기화
                if (list != null)
                    list.Clear();
                else
                    return;
            }
            else
            {
                Ca1Flag = false;
                timer1.Enabled = false;
                pictureBox1.Image = null;
                btnRibbonTrigger.Enabled = false;
                video.Release();
            }
        }

        // USB 카메라2
        private void btnRibbon2_Click(object sender, EventArgs e)
        {
            if (Ca2Flag == false)
            {
                try
                {
                    video = new VideoCapture(1);
                    video.FrameWidth = 800;
                    video.FrameHeight = 600;

                    timer1.Enabled = true;
                }
                catch
                {
                    timer1.Enabled = false;
                }

                MoneyFlag = false;
                Ca1Flag = false;
                Ca2Flag = true;
                Ca3Flag = false;

                groupBox2.Visible = false;
                btnRibbonTrigger.Enabled = true;
                cvsInSightDisplay1.Visible = false;
                _HostSensor = null;
                cvsInSightDisplay1.Disconnect();

                hScrollBar1.Value = 100;
                ScaleValue.Text = $"{hScrollBar1.Value.ToString()}%";
                ribbonUpDown.TextBoxText = "100%";
                ribbonUpDown.Value = "100";

                cbRibbonLive.Checked = false;
                cbRibbonLive.Enabled = false;
                if (list != null)
                    list.Clear();
                else
                    return;
            }
            else
            {
                Ca2Flag = false;
                timer1.Enabled = false;
                pictureBox1.Image = null;
                btnRibbonTrigger.Enabled = false;
                video.Release();
            }
        }

        // Cognex
        private void btnRibbon3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ca3Flag == false)
                {
                    // 프로그램 실행하자마자 바로 연결이 안되므로 5초 후 버튼 활성화
                    _HostSensor = _Monitor.Hosts[SensorAddress];
                    if (_HostSensor.IPAddressString != null)
                    {
                        cvsInSightDisplay1.Connect(_HostSensor.IPAddressString, "admin", "", false);
                    }

                    cvsInSightDisplay1.Visible = true;
                    cvsInSightDisplay1.ImageZoomMode = CvsDisplayZoom.Fit;

                    MoneyFlag = false;
                    Ca1Flag = false;
                    Ca2Flag = false;
                    Ca3Flag = true;

                    pictureBox1.Image = null;

                    hScrollBar1.Value = 100;
                    ScaleValue.Text = $"{hScrollBar1.Value.ToString()}%";

                    ribbonUpDown.TextBoxText = "100%";
                    ribbonUpDown.Value = "100";

                    groupBox2.Visible = false;
                    btnRibbonTrigger.Enabled = true;
                    cbRibbonLive.Enabled = true;
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    if (list != null)
                        list.Clear();
                    else
                        return;
                }
                else
                {
                    cvsInSightDisplay1.InSight.LiveAcquisition = false;
                    Ca3Flag = false;
                    btnRibbonTrigger.Enabled = false;
                    _HostSensor = null;
                    cvsInSightDisplay1.Disconnect();
                    cvsInSightDisplay1.Dispose();
                }

            }
            catch { }

        }

        // 트리거
        private void btnRibbonTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                if ((video != null && Ca1Flag == true) || (video != null && Ca2Flag == true))
                {
                    video.Read(frame);
                    result = frame;
                    pictureBox1.Image = result.ToBitmap();
                    timer1.Enabled = false;

                    hScrollBar1.Value = 100;
                    ScaleValue.Text = $"{hScrollBar1.Value.ToString()}%";

                    video.Release();
                    frame.Dispose();

                }
                else if (img1 != null && Ca3Flag == true)
                {
                    Mat img = BitmapConverter.ToMat(img1);
                    result = img;

                    pictureBox1.Image = result.ToBitmap();

                    cvsInSightDisplay1.Visible = false;
                    cvsInSightDisplay1.Disconnect();
                    btnCheck.Checked = false;
                    Ca3Flag = false;
                    cvsInSightDisplay1.InSight.LiveAcquisition = false;

                    cvsInSightDisplay1.Dispose();
                    img.Dispose();
                }

            }
            catch { }

        }

        // Congnex 출력값 바뀔때마다
        private void cvsInSightDisplay1_ResultsChanged(object sender, EventArgs e)
        {
            // Cognex 카메라가 촬영한 데이터를 resultSet에 할당
            CvsResultSet resultSet = cvsInSightDisplay1.Results;

            if (Ca3Flag == true)
            {
                // 새로 획득한 이미지가 포함되어있는지 여부를 나타내는 플래그
                if (resultSet.HasNewlyAcquiredImage)
                {
                    // 이미지를 가져온다
                    img1 = new Bitmap(cvsInSightDisplay1.GetBitmap());
                }
            }
            cvsInSightDisplay1.AcceptUpdate();

        }

        // 동전 검출 실행
        private void btnMoney_Click(object sender, EventArgs e)
        {
            if (MoneyFlag == false && pictureBox1.Image != null)
            {
                MoneyFlag = true;
                timer1.Enabled = true;
            }
            else
            {
                MoneyFlag = false;
                timer1.Enabled = false;
            }

        }

        // 카메라 실행
        FaceDetection face;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (video != null)
            {
                try
                {
                    video.Read(frame);

                    if (frame.Empty())
                    {
                        return;
                    }

                    if (MoneyFlag == true)
                    {
                        result = CircleImg(frame);
                        pictureBox1.Image = result.ToBitmap();
                    }
                    else if (faceFlag == true)
                    {
                        face = new FaceDetection();

                        // 첫 번째 이미지 불러오기
                        Mat m_src = Cv2.ImRead("C:\\Users\\user\\Desktop\\새 폴더 (2)\\dwqdwqfe.png", ImreadModes.Unchanged);

                        pictureBox1.Image = face.haarface(frame, m_src).ToBitmap();

                        // 리소스 해제
                        m_src.Dispose();
                    }
                    else
                    {
                        result = frame;
                        pictureBox1.Image = result.ToBitmap();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"타이머 : {ex.Message}");
                    video.Release();
                }
            }
        }

        // 동전 검출
        private Mat CircleImg(Mat src)
        {
            string coin = "";
            Mat dst = new Mat();
            Mat img = new Mat();
            Mat imgresult = new Mat();

            Cv2.CopyTo(src, dst);

            if (src.Channels() != 1)
                img = openCV.GrayScale(src);

            Cv2.BilateralFilter(img, imgresult, 9, 3, 3, BorderTypes.Default);
            Cv2.EqualizeHist(imgresult, imgresult);
            Cv2.AdaptiveThreshold(imgresult, img, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.BinaryInv, 11, 10);

            CircleSegment[] circles = Cv2.HoughCircles(img, HoughModes.Gradient, 1, 40, 100, 20, 40, 60);

            foreach (var imgcircle in circles)
            {
                OpenCvSharp.Point center = (OpenCvSharp.Point)imgcircle.Center;
                double radius = imgcircle.Radius;

                if (radius > 40 && radius < 53)
                {
                    coin = "100 won";
                }
                else if (radius >= 53 && radius < 60)
                {
                    coin = "500 won";
                }
                Cv2.Circle(dst, (OpenCvSharp.Point)imgcircle.Center, (int)imgcircle.Radius, Scalar.Red, 2);

                Cv2.PutText(dst, coin, new OpenCvSharp.Point(center.X - 20, center.Y - radius - 10), HersheyFonts.HersheySimplex, 1.0, Scalar.White, 1);
            }
            img.Dispose();
            imgresult.Dispose();

            return dst;
        }

        // Congnex 버튼 활성화
        private void timer2_Tick(object sender, EventArgs e)
        {
            btnRibbon3.Enabled = true;
        }

        private void cbRibbonLive_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            // RibbonCheckBox 속성값에 접근하기 위한 sender
            if (Ca3Flag == true)
            {
                btnCheck = (RibbonCheckBox)sender;
                cvsInSightDisplay1.InSight.LiveAcquisition = btnCheck.Checked;
            }
        }

        // 그레이스케일
        private void btnRibbonGray_Click(object sender, EventArgs e)
        {
            result = BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = openCV.GrayScale(result).ToBitmap();
            }
            else
            {
                return;
            }
        }

        // 마우스 클릭 시 위치 값 저장 후 선 그리기
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                System.Drawing.Point Location = e.Location;
                Cursor = Cursors.Default;
                if (Makeselection)
                {
                    try
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            Cursor = Cursors.Cross;
                            cropX = e.X;
                            cropY = e.Y;

                            cropPen = new System.Drawing.Pen(System.Drawing.Color.Red, 1);
                            cropPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        }
                        pictureBox1.Refresh();
                    }
                    catch { }
                }
            }

        }

        // 이미지 자를 위치 값을 list에 저장하고 사각형 그리기
        List<int> list;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                System.Drawing.Point Location = e.Location;
                Cursor = Cursors.Default;
                if (Makeselection)
                {
                    try
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            pictureBox1.Refresh();
                            cropWidth = e.X - cropX;
                            cropHeight = e.Y - cropY;
                            pictureBox1.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                            list = new List<int>(new int[] { cropX, cropY, cropWidth, cropHeight });
                        }
                    }
                    catch { }
                }
            }

        }

        // list에 저장된 위치 값을 가져와 SubMat을 사용하여 이미지의 특정부분을 가져온다
        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            try
            {
                if (cropWidth < 1)
                    return;

                result = result.SubMat(new OpenCvSharp.Rect(list[0], list[1], list[2], list[3]));

                pictureBox1.Image = result.ToBitmap();

            }
            catch { }

            Makeselection = false;
        }

        // 자르기 버튼
        private void btnRibbonSet_Click(object sender, EventArgs e)
        {
            Makeselection = true;
        }

        // 초기 설정
        private void Init()
        {
            _Monitor = new CvsNetworkMonitor();

            _Monitor.HostsChanged += _Monitor_HostsChanged;
            _Monitor.Enabled = true;

        }

        // 이진화 트랙바 사용
        private void btnRibbonBinaryization_Click(object sender, EventArgs e)
        {
            // 기본 임계값
            int binaryValue = 190;
            if (pictureBox1.Image != null)
            {
                Cv2.NamedWindow("Binary");
                Cv2.CreateTrackbar("임계치", "Binary", ref binaryValue, 255);
                try
                {
                    while (true)
                    {
                        pictureBox1.Image = openCV.BinaryA(result).ToBitmap();
                        Cv2.ImShow("Binary", openCV.BinaryA(result));
                        if (Cv2.WaitKey(33) == 'q')
                            break;
                    }
                    Cv2.DestroyAllWindows();
                }
                catch { }
            }

        }

        // 캐니엣지 트랙바 사용
        private void btnRibbonCannyEdge_Click(object sender, EventArgs e)
        {
            // 기본 임계값
            int cannyValue = 100;
            if (pictureBox1.Image != null)
            {
                Cv2.NamedWindow("Canny");
                Cv2.CreateTrackbar("임계치", "Canny", ref cannyValue, 255);
                try
                {
                    while (true)
                    {
                        pictureBox1.Image = openCV.CannyEdge(result).ToBitmap();
                        Cv2.ImShow("Canny", openCV.CannyEdge(result));
                        if (Cv2.WaitKey(33) == 'q')
                            break;
                    }
                    Cv2.DestroyAllWindows();
                }
                catch { }
            }

        }

        // 코너 검출
        private void btnRibbonCorner_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image = openCV.GoodFeaturesToTrack(result).ToBitmap();
            else
                return;
        }

        // 코너 검출2
        private void btnRibbonApproxPoly_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image = openCV.ApproxPoly(result).ToBitmap();
            else
                return;
        }

        // 기하학적 변환
        private void btnRibbonAffine_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (AffineFlag == false || ucf.IsDisposed)
                {
                    AffineFlag = true;

                    // userControlForm1 메모리 해제 되었으면 추가
                    ucf = new UserControlForm();
                    //ucf = userControlForm1;
                    panel2.Controls.Add(ucf);

                    ucf.eventSender += Ucf_eventSender;
                    ucf.eventSymmetryReturn += Ucf_eventSymmetryReturn;
                    ucf.eventClose += Ucf_eventClose;
                }
                else
                {
                    AffineFlag = false;
                    // userControlForm1가 있으면 지우고 메모리 해제
                    if (panel2.Controls.Contains(ucf))
                    {
                        XYCount = 0;
                        panel2.Controls.Remove(ucf);
                        ucf.Dispose();
                    }
                }

            }
            else
            {
                return;
            }

        }

        // 블러 버튼 / 클릭시 userControl 활성화
        private void btnBlur_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (BlurFlag == false || bc.IsDisposed)
                {
                    BlurFlag = true;
                    bc = new BlurControl();
                    panel2.Controls.Add(bc);

                    bc.eventBlur += Bc_eventBlur;
                    bc.eventBoxFilter += Bc_eventBoxFilter;
                    bc.eventMedianBlur += Bc_eventMedianBlur;
                    bc.eventGaussianBlur += Bc_eventGaussianBlur;
                    bc.eventBilateralFilter += Bc_eventBilateralFilter;
                    bc.eventClose += Bc_eventClose;
                    bc.eventReturn += Bc_eventReturn;
                }
                else
                {
                    BlurFlag = false;

                    if (panel2.Controls.Contains(bc))
                    {
                        panel2.Controls.Remove((bc));
                        bc.Dispose();
                    }
                }
            }
            else
            {
                return;
            }
        }

        // 팽창
        private void Expansion_Click(object sender, EventArgs e)
        {
            // 기본 임계값
            int cannyValue = 50;
            if (pictureBox1.Image != null)
            {
                Cv2.NamedWindow("Dilate");
                Cv2.CreateTrackbar("임계치", "Dilate", ref cannyValue, 255);
                try
                {
                    while (true)
                    {
                        pictureBox1.Image = openCV.DilateImage(result).ToBitmap();
                        Cv2.ImShow("Dilate", openCV.DilateImage(result));
                        if (Cv2.WaitKey(33) == 'q')
                            break;
                    }
                    Cv2.DestroyAllWindows();
                }
                catch { }
            }
        }

        // 침식
        private void Erosion_Click(object sender, EventArgs e)
        {
            // 기본 임계값
            int cannyValue = 50;
            if (pictureBox1.Image != null)
            {
                Cv2.NamedWindow("Erode");
                Cv2.CreateTrackbar("임계치", "Erode", ref cannyValue, 255);
                try
                {
                    while (true)
                    {
                        pictureBox1.Image = openCV.ErodeImage(result).ToBitmap();
                        Cv2.ImShow("Erode", openCV.ErodeImage(result));
                        if (Cv2.WaitKey(33) == 'q')
                            break;
                    }
                    Cv2.DestroyAllWindows();
                }
                catch { }
            }
        }

        // 기하학적 변환 위치값 전달
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // pictrurebox 클릭으로 좌표 얻었을때
            if (pictureBox1.Image != null && AffineFlag == true)
            {
                XYCount++;

                if (XYCount == 1)
                {
                    xy.LUpX = e.X;
                    xy.LUpY = e.Y;
                    openCV.MouseXY(xy.LUpX, xy.LUpY);
                    ucf.txtLUpX.Text = xy.LUpX.ToString();
                    ucf.txtLUpY.Text = xy.LUpY.ToString();

                }
                else if (XYCount == 2)
                {
                    xy.LDownX = e.X;
                    xy.LDownY = e.Y;
                    openCV.MouseXY(xy.LDownX, xy.LDownY);
                    ucf.txtLDownX.Text = xy.LDownX.ToString();
                    ucf.txtLDownY.Text = xy.LDownY.ToString();

                }
                else if (XYCount == 3)
                {
                    xy.RUpX = e.X;
                    xy.RUpY = e.Y;
                    openCV.MouseXY(xy.RUpX, xy.RUpY);
                    ucf.txtRUpX.Text = xy.RUpX.ToString();
                    ucf.txtRUpY.Text = xy.RUpY.ToString();

                }
                else
                {
                    xy.RDownX = e.X;
                    xy.RDownY = e.Y;
                    openCV.MouseXY(xy.RDownX, xy.RDownY);
                    ucf.txtRDownX.Text = xy.RDownX.ToString();
                    ucf.txtRDownY.Text = xy.RDownY.ToString();
                }

                if (XYCount >= 4)
                {
                    XYCount = 0;
                }
            }
        }

        // 확대
        private void ribbonUpDown_UpButtonClicked(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                num = double.Parse(ribbonUpDown.Value);
                if (num < 200.0)
                {
                    double xy = num + 10.0;
                    ribbonUpDown.TextBoxText = xy.ToString() + "%";
                    ribbonUpDown.Value = xy.ToString();
                    pictureBox1.Image = openCVEdit.ribbonUpDown(result, xy).ToBitmap();
                }
            }
            else
            {
                return;
            }

        }

        // 축소
        private void ribbonUpDown_DownButtonClicked(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                num = double.Parse(ribbonUpDown.Value);
                if (num > 10.0)
                {
                    double xy = num - 10.0;
                    ribbonUpDown.TextBoxText = xy.ToString() + "%";
                    ribbonUpDown.Value = xy.ToString();
                    pictureBox1.Image = openCVEdit.ribbonUpDown(result, xy).ToBitmap();
                }
            }
            else
            {
                return;
            }

        }

        private void _Monitor_HostsChanged(object sender, EventArgs e)
        {
            // Cognex 카메라 주소를 가져와 SensorAddress 변수에 저장
            foreach (CvsHostSensor host in _Monitor.Hosts)
            {
                SensorAddress = host.Name;
            }
        }

        // 마우스 휠 이벤트
        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (e.Delta > 0)
                {
                    if (hScrollBar1.Value < hScrollBar1.Maximum && hScrollBar1.Value < 200)
                        hScrollBar1.Value += 1;
                }
                else
                {
                    if (hScrollBar1.Value > hScrollBar1.Minimum)
                        hScrollBar1.Value -= 1;
                }
                UpdateSize();
            }
            else
            {
                return;
            }

        }

        // 스크롤바 이벤트
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                UpdateSize();
            }
            else
            {
                return;
            }
        }

        // 마우스 휠, 스크롤바 동기화
        private void UpdateSize()
        {
            Mat dst = new Mat();
            Cv2.Resize(result, dst, new OpenCvSharp.Size(0, 0), hScrollBar1.Value / 100.0, hScrollBar1.Value / 100.0);
            pictureBox1.Image = dst.ToBitmap();
            ScaleValue.Text = hScrollBar1.Value + "%";
        }

        public void SymmetryReturn()
        {
            originalImage = result.Clone();
            pictureBox1.Image = originalImage.ToBitmap();
        }

        // X축 대칭
        private void btnRibbonSymmetry_Click(object sender, EventArgs e)
        {
            result = BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
            if (pictureBox1.Image != null)
            {
                try
                {
                    if (SymmetryFlag == false)
                    {
                        pictureBox1.Image = openCVEdit.RibbonSymmetryX(result).ToBitmap();
                        SymmetryFlag = true;
                    }
                    else
                    {
                        SymmetryReturn();
                        SymmetryFlag = false;
                    }
                }
                catch { }
            }
        }

        // Y축 대칭
        private void btnRibbonSymmetry2_Click(object sender, EventArgs e)
        {
            result = BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
            if (pictureBox1 != null)
            {
                try
                {
                    if (SymmetryFlag == false)
                    {
                        pictureBox1.Image = openCVEdit.RibbonSymmetryY(result).ToBitmap();
                        SymmetryFlag = true;
                    }
                    else
                    {
                        SymmetryReturn();
                        SymmetryFlag = false;
                    }
                }
                catch { }
            }
        }

        // 45도 회전
        private void btnRibbon45Rotation_Click(object sender, EventArgs e)
        {
            //result = BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
            if (pictureBox1 != null)
            {
                try
                {
                    pictureBox1.Image = openCVEdit.Ribbon45Rotation(result).ToBitmap();
                }
                catch { }
            }
        }

        // 90도 회전
        private void btnRibbon90Rotation_Click(object sender, EventArgs e)
        {
            //result = BitmapConverter.ToMat((Bitmap)pictureBox1.Image);
            if (pictureBox1 != null)
            {
                try
                {
                    pictureBox1.Image = openCVEdit.Ribbon90Rotation(result).ToBitmap();
                }
                catch { }
            }
        }

        // 바코드를 읽고 해당값이 맞다면 DB에 저장
        int year;
        int month;
        private void btnBarCord_Click(object sender, EventArgs e)
        {
            string decoded = "";
            BarcodeReader reader = new BarcodeReader();
            // 영상에 비친 코드 값을 가져온다
            Result result = reader.Decode((Bitmap)pictureBox1.Image);

            if (result != null)
            {
                // 바코드의 13자리를 나눔
                int[] num = { 2, 4, 2, 4, 1 };
                // num의 위치값
                int currentPosition = 0;

                decoded = result.ToString() + "\r\n" + result.BarcodeFormat.ToString();

                for (int i = 0; i < num.Length; i++)
                {
                    if (currentPosition + num[i] <= result.Text.Length)
                    {
                        string segment = result.Text.Substring(currentPosition, num[i]);
                        currentPosition += num[i];

                        if (i == 0)
                        {
                            switch (segment)
                            {
                                case "11":
                                    company = "삼성";
                                    break;
                                case "21":
                                    company = "엘지";
                                    break;
                                case "88":
                                    company = "씨제이";
                                    break;
                                case "99":
                                    company = "오뚜기";
                                    break;
                            }
                        }
                        else if (i == 1)
                        {
                            switch (segment)
                            {
                                case "1234":
                                    product = "세탁기";
                                    break;
                                case "1245":
                                    product = "냉장고";
                                    break;
                                case "1256":
                                    product = "정수기";
                                    break;
                                case "1267":
                                    product = "에어컨";
                                    break;
                                case "3412":
                                    product = "햇반";
                                    break;
                                case "3413":
                                    product = "밀가루";
                                    break;
                                case "3415":
                                    product = "만두";
                                    break;
                                case "3416":
                                    product = "라면";
                                    break;
                            }
                        }
                        else if (i == 2)
                        {
                            switch (segment)
                            {
                                case "11":
                                    production = "한국";
                                    break;
                                case "12":
                                    production = "차이나";
                                    break;
                                case "13":
                                    production = "베트남";
                                    break;
                                case "14":
                                    production = "태국";
                                    break;
                            }
                        }
                        else if (i == 3)
                        {
                            string yearSub = segment.Substring(0, 2);
                            string monthSub = segment.Substring(2, 2);

                            year = 2000 + int.Parse(yearSub);
                            month = int.Parse(monthSub);

                            date = new DateTime(year, month, 1);
                        }
                        else
                        {
                            // 13자리의 끝자리를 제외 후 12자리의 홀,짝을 각각 더한 후 짝수는 3을 곱하고,
                            // 홀,짝을 더한 다음 더한 값의 마지막 끝자리를 10에서 뺀다
                            // 예: (12 + 12 * 3) = (12 + 36) = 48
                            // 끝자리 8 ( 10 - 8 ) = 2
                            int oddSum = 0;
                            int evenSum = 0;
                            char[] arr = result.Text.ToCharArray();
                            for (int j = 0; j < result.Text.Length - 1; j++)
                            {
                                int ch = int.Parse(arr[j].ToString());

                                if ((j + 1) % 2 == 1)
                                {
                                    oddSum += ch;
                                }
                                else
                                {
                                    evenSum += ch;
                                }
                            }

                            int checkDigit = 10 - ((oddSum + evenSum * 3) % 10);

                            if (checkDigit == 10) checkDigit = 0;

                            if (segment.Equals(checkDigit.ToString()))
                            {
                                test = segment;
                            }
                        }

                    }
                }

                db.insert(company, product, production, date, test);
                // 그리드뷰에 바인드
                dataGridView1.DataSource = db.dt;
                groupBox2.Visible = true;

                MessageBox.Show($"{db.msg} : {year}");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            db.select(textBox1.Text);
            dataGridView1.DataSource = db.dt;
        }

        private void btnFace_Click(object sender, EventArgs e)
        {
            if (faceFlag == false)
            {
                faceFlag = true;
                timer1.Enabled = true;
            } else
            {
                faceFlag = false;
                timer1.Enabled = false;
            }
        }

        // 원 검출
        private void btnCircleDetection_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image = openCV.AllCircleColor(result).ToBitmap();
            else
                return;
        }

        // 영어 번역
        int a, b;
        private void btnRibbonEnglish_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap img = new Bitmap(pictureBox1.Image);

                var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                var texts = ocr.Process(img);

                foreach (var i in texts.GetText())
                {
                    if (char.IsUpper(i))
                        a++;
                    else if (char.IsLower(i))
                        b++;

                }

                ucf.label6.Text = "대문자 : " + a.ToString();
                ucf.label7.Text = "소문자 : " + b.ToString();
                ucf.label8.Text = texts.GetText();
                a = 0;
                b = 0;

            }
            else
            {
                return;
            }

        }

        // 한글 번역
        private void btnRibbonHangul_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap img = new Bitmap(pictureBox1.Image);
                var ocr = new TesseractEngine("./tessdata", "kor", EngineMode.Default);
                var texts = ocr.Process(img);
                //ucf.label6.Text = "대문자 : ";
                //ucf.label7.Text = "소문자 : ";
                ucf.label8.Text = texts.GetText();
            }
            else
            {
                return;
            }
        }

        // 모폴로지 열기
        private void OpenMorphology_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = openCV.OpenMorphology(result).ToBitmap();
            }
            else
            {
                return;
            }
        }

        // 모폴로지 닫기
        private void CloseMorphology_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = openCV.CloseMorphology(result).ToBitmap();
            }
            else
            {
                return;
            }
        }

        // 모폴로지 그라이언트
        private void GradientMorphology_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = openCV.GradientMorphology(result).ToBitmap();
            }
            else
            {
                return;
            }
        }

        // 탑햇
        private void TopHatMorphology_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = openCV.TopHatMorphology(result).ToBitmap();
            }
            else
            {
                return;
            }
        }

        // 블랙햇
        private void BlackHatMorphology_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = openCV.BlackHatMorphology(result).ToBitmap();
            }
            else
            {
                return;
            }
        }

        // 히트미스
        private void HitMissMorphology_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = openCV.HitMissMorphology(result).ToBitmap();
            }
            else
            {
                return;
            }
        }

    }
}
