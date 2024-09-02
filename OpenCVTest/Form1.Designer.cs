using System.Drawing;
using System.Security.Cryptography;

namespace OpenCVTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ScaleValue = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.cbRibbonLive = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.ribbonUpDown = new System.Windows.Forms.RibbonUpDown();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel11 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel12 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel9 = new System.Windows.Forms.RibbonPanel();
            this.cvsInSightDisplay1 = new Cognex.InSight.Controls.Display.CvsInSightDisplay();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ribbonTab6 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel13 = new System.Windows.Forms.RibbonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ribbonOrbOpen = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonOrbSave = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonOrbClose = new System.Windows.Forms.RibbonOrbMenuItem();
            this.btnRibbon = new System.Windows.Forms.RibbonButton();
            this.btnRibbon2 = new System.Windows.Forms.RibbonButton();
            this.btnRibbon3 = new System.Windows.Forms.RibbonButton();
            this.btnRibbonTrigger = new System.Windows.Forms.RibbonButton();
            this.btnRibbonSymmetry = new System.Windows.Forms.RibbonButton();
            this.btnRibbonSymmetry2 = new System.Windows.Forms.RibbonButton();
            this.btnRibbon45Rotation = new System.Windows.Forms.RibbonButton();
            this.btnRibbon90Rotation = new System.Windows.Forms.RibbonButton();
            this.btnRibbonSet = new System.Windows.Forms.RibbonButton();
            this.btnRibbonGray = new System.Windows.Forms.RibbonButton();
            this.btnRibbonBinaryization = new System.Windows.Forms.RibbonButton();
            this.btnRibbonCannyEdge = new System.Windows.Forms.RibbonButton();
            this.btnRibbonCorner = new System.Windows.Forms.RibbonButton();
            this.btnRibbonApproxPoly = new System.Windows.Forms.RibbonButton();
            this.btnRibbonAffine = new System.Windows.Forms.RibbonButton();
            this.Expansion = new System.Windows.Forms.RibbonButton();
            this.Erosion = new System.Windows.Forms.RibbonButton();
            this.OpenMorphology = new System.Windows.Forms.RibbonButton();
            this.CloseMorphology = new System.Windows.Forms.RibbonButton();
            this.GradientMorphology = new System.Windows.Forms.RibbonButton();
            this.TopHatMorphology = new System.Windows.Forms.RibbonButton();
            this.BlackHatMorphology = new System.Windows.Forms.RibbonButton();
            this.HitMissMorphology = new System.Windows.Forms.RibbonButton();
            this.btnRibbonEnglish = new System.Windows.Forms.RibbonButton();
            this.btnRibbonHangul = new System.Windows.Forms.RibbonButton();
            this.btnBlur = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel14 = new System.Windows.Forms.RibbonPanel();
            this.btnCircleDetection = new System.Windows.Forms.RibbonButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ScaleValue);
            this.groupBox1.Controls.Add(this.hScrollBar1);
            this.groupBox1.Location = new System.Drawing.Point(0, 1207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1730, 65);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // ScaleValue
            // 
            this.ScaleValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleValue.AutoSize = true;
            this.ScaleValue.Location = new System.Drawing.Point(1411, 29);
            this.ScaleValue.Name = "ScaleValue";
            this.ScaleValue.Size = new System.Drawing.Size(52, 18);
            this.ScaleValue.TabIndex = 2;
            this.ScaleValue.Text = "100%";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(1478, 19);
            this.hScrollBar1.Maximum = 200;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(238, 27);
            this.hScrollBar1.SmallChange = 5;
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Value = 100;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbOpen);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbSave);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbClose);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 204);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "파일";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1730, 200);
            this.ribbon1.TabIndex = 7;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.Tabs.Add(this.ribbonTab5);
            this.ribbon1.Tabs.Add(this.ribbonTab6);
            this.ribbon1.TabSpacing = 3;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel4);
            this.ribbonTab1.Text = "카메라";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.btnRibbon);
            this.ribbonPanel1.Items.Add(this.btnRibbon2);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.btnRibbon3);
            this.ribbonPanel2.Items.Add(this.cbRibbonLive);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Cognex";
            // 
            // cbRibbonLive
            // 
            this.cbRibbonLive.Enabled = false;
            this.cbRibbonLive.Name = "cbRibbonLive";
            this.cbRibbonLive.Text = "Live";
            this.cbRibbonLive.CheckBoxCheckChanged += new System.EventHandler(this.cbRibbonLive_CheckBoxCheckChanged);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.btnRibbonTrigger);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = "";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Panels.Add(this.ribbonPanel5);
            this.ribbonTab2.Panels.Add(this.ribbonPanel6);
            this.ribbonTab2.Panels.Add(this.ribbonPanel7);
            this.ribbonTab2.Panels.Add(this.ribbonPanel8);
            this.ribbonTab2.Text = "수정";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.btnRibbonSymmetry);
            this.ribbonPanel5.Items.Add(this.btnRibbonSymmetry2);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = "방향 전환";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.btnRibbon45Rotation);
            this.ribbonPanel6.Items.Add(this.btnRibbon90Rotation);
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = "회전";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.ButtonMoreVisible = false;
            this.ribbonPanel7.Items.Add(this.btnRibbonSet);
            this.ribbonPanel7.Name = "ribbonPanel7";
            this.ribbonPanel7.Text = "크기 조절";
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.ButtonMoreVisible = false;
            this.ribbonPanel8.Items.Add(this.ribbonUpDown);
            this.ribbonPanel8.Name = "ribbonPanel8";
            this.ribbonPanel8.Text = "확대/축소";
            // 
            // ribbonUpDown
            // 
            this.ribbonUpDown.Name = "ribbonUpDown";
            this.ribbonUpDown.TextBoxText = "100%";
            this.ribbonUpDown.TextBoxWidth = 50;
            this.ribbonUpDown.Value = "100";
            this.ribbonUpDown.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_UpButtonClicked);
            this.ribbonUpDown.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_DownButtonClicked);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Panels.Add(this.ribbonPanel3);
            this.ribbonTab3.Text = "필터";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.btnRibbonGray);
            this.ribbonPanel3.Items.Add(this.btnRibbonBinaryization);
            this.ribbonPanel3.Items.Add(this.btnRibbonCannyEdge);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "필터";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Name = "ribbonTab4";
            this.ribbonTab4.Panels.Add(this.ribbonPanel11);
            this.ribbonTab4.Panels.Add(this.ribbonPanel12);
            this.ribbonTab4.Text = "알고리즘";
            // 
            // ribbonPanel11
            // 
            this.ribbonPanel11.ButtonMoreVisible = false;
            this.ribbonPanel11.Items.Add(this.btnRibbonCorner);
            this.ribbonPanel11.Items.Add(this.btnRibbonApproxPoly);
            this.ribbonPanel11.Items.Add(this.btnRibbonAffine);
            this.ribbonPanel11.Name = "ribbonPanel11";
            this.ribbonPanel11.Text = "";
            // 
            // ribbonPanel12
            // 
            this.ribbonPanel12.ButtonMoreVisible = false;
            this.ribbonPanel12.Items.Add(this.Expansion);
            this.ribbonPanel12.Items.Add(this.Erosion);
            this.ribbonPanel12.Items.Add(this.OpenMorphology);
            this.ribbonPanel12.Items.Add(this.CloseMorphology);
            this.ribbonPanel12.Items.Add(this.GradientMorphology);
            this.ribbonPanel12.Items.Add(this.TopHatMorphology);
            this.ribbonPanel12.Items.Add(this.BlackHatMorphology);
            this.ribbonPanel12.Items.Add(this.HitMissMorphology);
            this.ribbonPanel12.Name = "ribbonPanel12";
            this.ribbonPanel12.Text = "";
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Name = "ribbonTab5";
            this.ribbonTab5.Panels.Add(this.ribbonPanel9);
            this.ribbonTab5.Text = "명함";
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.ButtonMoreVisible = false;
            this.ribbonPanel9.Items.Add(this.btnRibbonEnglish);
            this.ribbonPanel9.Items.Add(this.btnRibbonHangul);
            this.ribbonPanel9.Name = "ribbonPanel9";
            this.ribbonPanel9.Text = "판독";
            // 
            // cvsInSightDisplay1
            // 
            this.cvsInSightDisplay1.DefaultTextScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplay.TextScaleModeType.Proportional;
            this.cvsInSightDisplay1.DialogIcon = null;
            this.cvsInSightDisplay1.Location = new System.Drawing.Point(0, 0);
            this.cvsInSightDisplay1.Name = "cvsInSightDisplay1";
            this.cvsInSightDisplay1.PreferredCropScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplayCropScaleMode.Default;
            this.cvsInSightDisplay1.Size = new System.Drawing.Size(1280, 960);
            this.cvsInSightDisplay1.TabIndex = 8;
            this.cvsInSightDisplay1.Visible = false;
            this.cvsInSightDisplay1.ResultsChanged += new System.EventHandler(this.cvsInSightDisplay1_ResultsChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.cvsInSightDisplay1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(9, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 960);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(1295, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 979);
            this.panel2.TabIndex = 10;
            // 
            // ribbonTab6
            // 
            this.ribbonTab6.Name = "ribbonTab6";
            this.ribbonTab6.Panels.Add(this.ribbonPanel13);
            this.ribbonTab6.Panels.Add(this.ribbonPanel14);
            this.ribbonTab6.Text = "색상검출";
            // 
            // ribbonPanel13
            // 
            this.ribbonPanel13.ButtonMoreVisible = false;
            this.ribbonPanel13.Items.Add(this.btnBlur);
            this.ribbonPanel13.Name = "ribbonPanel13";
            this.ribbonPanel13.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 960);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // ribbonOrbOpen
            // 
            this.ribbonOrbOpen.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbOpen.Image = global::OpenCVTest.Properties.Resources._12217691;
            this.ribbonOrbOpen.LargeImage = global::OpenCVTest.Properties.Resources._12217691;
            this.ribbonOrbOpen.Name = "ribbonOrbOpen";
            this.ribbonOrbOpen.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOpen.SmallImage")));
            this.ribbonOrbOpen.Text = "Open";
            this.ribbonOrbOpen.Click += new System.EventHandler(this.ribbonOrbOpen_Click);
            // 
            // ribbonOrbSave
            // 
            this.ribbonOrbSave.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbSave.Image = global::OpenCVTest.Properties.Resources.ewqewq;
            this.ribbonOrbSave.LargeImage = global::OpenCVTest.Properties.Resources.ewqewq;
            this.ribbonOrbSave.Name = "ribbonOrbSave";
            this.ribbonOrbSave.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbSave.SmallImage")));
            this.ribbonOrbSave.Text = "Save";
            this.ribbonOrbSave.Click += new System.EventHandler(this.ribbonOrbSave_Click);
            // 
            // ribbonOrbClose
            // 
            this.ribbonOrbClose.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbClose.Image = global::OpenCVTest.Properties.Resources._12520057;
            this.ribbonOrbClose.LargeImage = global::OpenCVTest.Properties.Resources._12520057;
            this.ribbonOrbClose.Name = "ribbonOrbClose";
            this.ribbonOrbClose.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbClose.SmallImage")));
            this.ribbonOrbClose.Text = "Close";
            // 
            // btnRibbon
            // 
            this.btnRibbon.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbon.Image")));
            this.btnRibbon.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon.LargeImage")));
            this.btnRibbon.Name = "btnRibbon";
            this.btnRibbon.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon.SmallImage")));
            this.btnRibbon.Text = "Camera";
            this.btnRibbon.Click += new System.EventHandler(this.btnRibbon_Click);
            // 
            // btnRibbon2
            // 
            this.btnRibbon2.Enabled = false;
            this.btnRibbon2.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbon2.Image")));
            this.btnRibbon2.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon2.LargeImage")));
            this.btnRibbon2.Name = "btnRibbon2";
            this.btnRibbon2.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon2.SmallImage")));
            this.btnRibbon2.Text = "Camera2";
            this.btnRibbon2.Click += new System.EventHandler(this.btnRibbon2_Click);
            // 
            // btnRibbon3
            // 
            this.btnRibbon3.Enabled = false;
            this.btnRibbon3.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbon3.Image")));
            this.btnRibbon3.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon3.LargeImage")));
            this.btnRibbon3.Name = "btnRibbon3";
            this.btnRibbon3.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon3.SmallImage")));
            this.btnRibbon3.Text = "Camera3";
            this.btnRibbon3.Click += new System.EventHandler(this.btnRibbon3_Click);
            // 
            // btnRibbonTrigger
            // 
            this.btnRibbonTrigger.Enabled = false;
            this.btnRibbonTrigger.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonTrigger.Image")));
            this.btnRibbonTrigger.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonTrigger.LargeImage")));
            this.btnRibbonTrigger.Name = "btnRibbonTrigger";
            this.btnRibbonTrigger.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonTrigger.SmallImage")));
            this.btnRibbonTrigger.Text = "Trigger";
            this.btnRibbonTrigger.Click += new System.EventHandler(this.btnRibbonTrigger_Click);
            // 
            // btnRibbonSymmetry
            // 
            this.btnRibbonSymmetry.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonSymmetry.Image")));
            this.btnRibbonSymmetry.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonSymmetry.LargeImage")));
            this.btnRibbonSymmetry.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbonSymmetry.Name = "btnRibbonSymmetry";
            this.btnRibbonSymmetry.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonSymmetry.SmallImage")));
            this.btnRibbonSymmetry.Text = "X축 대칭";
            this.btnRibbonSymmetry.Click += new System.EventHandler(this.btnRibbonSymmetry_Click);
            // 
            // btnRibbonSymmetry2
            // 
            this.btnRibbonSymmetry2.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonSymmetry2.Image")));
            this.btnRibbonSymmetry2.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonSymmetry2.LargeImage")));
            this.btnRibbonSymmetry2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbonSymmetry2.Name = "btnRibbonSymmetry2";
            this.btnRibbonSymmetry2.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonSymmetry2.SmallImage")));
            this.btnRibbonSymmetry2.Text = "Y축 대칭";
            this.btnRibbonSymmetry2.Click += new System.EventHandler(this.btnRibbonSymmetry2_Click);
            // 
            // btnRibbon45Rotation
            // 
            this.btnRibbon45Rotation.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbon45Rotation.Image")));
            this.btnRibbon45Rotation.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon45Rotation.LargeImage")));
            this.btnRibbon45Rotation.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbon45Rotation.Name = "btnRibbon45Rotation";
            this.btnRibbon45Rotation.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon45Rotation.SmallImage")));
            this.btnRibbon45Rotation.Text = "45˚ 회전";
            this.btnRibbon45Rotation.Click += new System.EventHandler(this.btnRibbon45Rotation_Click);
            // 
            // btnRibbon90Rotation
            // 
            this.btnRibbon90Rotation.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbon90Rotation.Image")));
            this.btnRibbon90Rotation.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon90Rotation.LargeImage")));
            this.btnRibbon90Rotation.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbon90Rotation.Name = "btnRibbon90Rotation";
            this.btnRibbon90Rotation.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbon90Rotation.SmallImage")));
            this.btnRibbon90Rotation.Text = "90˚ 회전";
            this.btnRibbon90Rotation.Click += new System.EventHandler(this.btnRibbon90Rotation_Click);
            // 
            // btnRibbonSet
            // 
            this.btnRibbonSet.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonSet.Image")));
            this.btnRibbonSet.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonSet.LargeImage")));
            this.btnRibbonSet.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbonSet.Name = "btnRibbonSet";
            this.btnRibbonSet.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonSet.SmallImage")));
            this.btnRibbonSet.Text = " 자르기";
            this.btnRibbonSet.Click += new System.EventHandler(this.btnRibbonSet_Click);
            // 
            // btnRibbonGray
            // 
            this.btnRibbonGray.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonGray.Image")));
            this.btnRibbonGray.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonGray.LargeImage")));
            this.btnRibbonGray.Name = "btnRibbonGray";
            this.btnRibbonGray.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonGray.SmallImage")));
            this.btnRibbonGray.Text = "그레이스케일";
            this.btnRibbonGray.Click += new System.EventHandler(this.btnRibbonGray_Click);
            // 
            // btnRibbonBinaryization
            // 
            this.btnRibbonBinaryization.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonBinaryization.Image")));
            this.btnRibbonBinaryization.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonBinaryization.LargeImage")));
            this.btnRibbonBinaryization.Name = "btnRibbonBinaryization";
            this.btnRibbonBinaryization.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonBinaryization.SmallImage")));
            this.btnRibbonBinaryization.Text = "이진화";
            this.btnRibbonBinaryization.Click += new System.EventHandler(this.btnRibbonBinaryization_Click);
            // 
            // btnRibbonCannyEdge
            // 
            this.btnRibbonCannyEdge.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonCannyEdge.Image")));
            this.btnRibbonCannyEdge.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonCannyEdge.LargeImage")));
            this.btnRibbonCannyEdge.Name = "btnRibbonCannyEdge";
            this.btnRibbonCannyEdge.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonCannyEdge.SmallImage")));
            this.btnRibbonCannyEdge.Text = "케니에지";
            this.btnRibbonCannyEdge.Click += new System.EventHandler(this.btnRibbonCannyEdge_Click);
            // 
            // btnRibbonCorner
            // 
            this.btnRibbonCorner.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonCorner.Image")));
            this.btnRibbonCorner.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonCorner.LargeImage")));
            this.btnRibbonCorner.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbonCorner.Name = "btnRibbonCorner";
            this.btnRibbonCorner.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonCorner.SmallImage")));
            this.btnRibbonCorner.Text = "코너 검출";
            this.btnRibbonCorner.Click += new System.EventHandler(this.btnRibbonCorner_Click);
            // 
            // btnRibbonApproxPoly
            // 
            this.btnRibbonApproxPoly.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonApproxPoly.Image")));
            this.btnRibbonApproxPoly.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonApproxPoly.LargeImage")));
            this.btnRibbonApproxPoly.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbonApproxPoly.Name = "btnRibbonApproxPoly";
            this.btnRibbonApproxPoly.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonApproxPoly.SmallImage")));
            this.btnRibbonApproxPoly.Text = "코너 검출2";
            this.btnRibbonApproxPoly.Click += new System.EventHandler(this.btnRibbonApproxPoly_Click);
            // 
            // btnRibbonAffine
            // 
            this.btnRibbonAffine.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonAffine.Image")));
            this.btnRibbonAffine.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonAffine.LargeImage")));
            this.btnRibbonAffine.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbonAffine.Name = "btnRibbonAffine";
            this.btnRibbonAffine.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonAffine.SmallImage")));
            this.btnRibbonAffine.Text = "기하학적변환";
            this.btnRibbonAffine.Click += new System.EventHandler(this.btnRibbonAffine_Click);
            // 
            // Expansion
            // 
            this.Expansion.Image = ((System.Drawing.Image)(resources.GetObject("Expansion.Image")));
            this.Expansion.LargeImage = ((System.Drawing.Image)(resources.GetObject("Expansion.LargeImage")));
            this.Expansion.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.Expansion.Name = "Expansion";
            this.Expansion.SmallImage = ((System.Drawing.Image)(resources.GetObject("Expansion.SmallImage")));
            this.Expansion.Text = "팽창";
            this.Expansion.Click += new System.EventHandler(this.Expansion_Click);
            // 
            // Erosion
            // 
            this.Erosion.Image = ((System.Drawing.Image)(resources.GetObject("Erosion.Image")));
            this.Erosion.LargeImage = ((System.Drawing.Image)(resources.GetObject("Erosion.LargeImage")));
            this.Erosion.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.Erosion.Name = "Erosion";
            this.Erosion.SmallImage = ((System.Drawing.Image)(resources.GetObject("Erosion.SmallImage")));
            this.Erosion.Text = "침식";
            this.Erosion.Click += new System.EventHandler(this.Erosion_Click);
            // 
            // OpenMorphology
            // 
            this.OpenMorphology.Image = ((System.Drawing.Image)(resources.GetObject("OpenMorphology.Image")));
            this.OpenMorphology.LargeImage = ((System.Drawing.Image)(resources.GetObject("OpenMorphology.LargeImage")));
            this.OpenMorphology.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.OpenMorphology.Name = "OpenMorphology";
            this.OpenMorphology.SmallImage = ((System.Drawing.Image)(resources.GetObject("OpenMorphology.SmallImage")));
            this.OpenMorphology.Text = "열기 모폴로지";
            this.OpenMorphology.Click += new System.EventHandler(this.OpenMorphology_Click);
            // 
            // CloseMorphology
            // 
            this.CloseMorphology.Image = ((System.Drawing.Image)(resources.GetObject("CloseMorphology.Image")));
            this.CloseMorphology.LargeImage = ((System.Drawing.Image)(resources.GetObject("CloseMorphology.LargeImage")));
            this.CloseMorphology.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.CloseMorphology.Name = "CloseMorphology";
            this.CloseMorphology.SmallImage = ((System.Drawing.Image)(resources.GetObject("CloseMorphology.SmallImage")));
            this.CloseMorphology.Text = "닫기 모폴로지";
            this.CloseMorphology.Click += new System.EventHandler(this.CloseMorphology_Click);
            // 
            // GradientMorphology
            // 
            this.GradientMorphology.Image = ((System.Drawing.Image)(resources.GetObject("GradientMorphology.Image")));
            this.GradientMorphology.LargeImage = ((System.Drawing.Image)(resources.GetObject("GradientMorphology.LargeImage")));
            this.GradientMorphology.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.GradientMorphology.Name = "GradientMorphology";
            this.GradientMorphology.SmallImage = ((System.Drawing.Image)(resources.GetObject("GradientMorphology.SmallImage")));
            this.GradientMorphology.Text = "그라이언트";
            this.GradientMorphology.Click += new System.EventHandler(this.GradientMorphology_Click);
            // 
            // TopHatMorphology
            // 
            this.TopHatMorphology.Image = ((System.Drawing.Image)(resources.GetObject("TopHatMorphology.Image")));
            this.TopHatMorphology.LargeImage = ((System.Drawing.Image)(resources.GetObject("TopHatMorphology.LargeImage")));
            this.TopHatMorphology.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.TopHatMorphology.Name = "TopHatMorphology";
            this.TopHatMorphology.SmallImage = ((System.Drawing.Image)(resources.GetObject("TopHatMorphology.SmallImage")));
            this.TopHatMorphology.Text = "탑햇";
            this.TopHatMorphology.Click += new System.EventHandler(this.TopHatMorphology_Click);
            // 
            // BlackHatMorphology
            // 
            this.BlackHatMorphology.Image = ((System.Drawing.Image)(resources.GetObject("BlackHatMorphology.Image")));
            this.BlackHatMorphology.LargeImage = ((System.Drawing.Image)(resources.GetObject("BlackHatMorphology.LargeImage")));
            this.BlackHatMorphology.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.BlackHatMorphology.Name = "BlackHatMorphology";
            this.BlackHatMorphology.SmallImage = ((System.Drawing.Image)(resources.GetObject("BlackHatMorphology.SmallImage")));
            this.BlackHatMorphology.Text = "블랙햇";
            this.BlackHatMorphology.Click += new System.EventHandler(this.BlackHatMorphology_Click);
            // 
            // HitMissMorphology
            // 
            this.HitMissMorphology.Image = ((System.Drawing.Image)(resources.GetObject("HitMissMorphology.Image")));
            this.HitMissMorphology.LargeImage = ((System.Drawing.Image)(resources.GetObject("HitMissMorphology.LargeImage")));
            this.HitMissMorphology.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.HitMissMorphology.Name = "HitMissMorphology";
            this.HitMissMorphology.SmallImage = ((System.Drawing.Image)(resources.GetObject("HitMissMorphology.SmallImage")));
            this.HitMissMorphology.Text = "히트미스";
            this.HitMissMorphology.Click += new System.EventHandler(this.HitMissMorphology_Click);
            // 
            // btnRibbonEnglish
            // 
            this.btnRibbonEnglish.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonEnglish.Image")));
            this.btnRibbonEnglish.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonEnglish.LargeImage")));
            this.btnRibbonEnglish.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbonEnglish.Name = "btnRibbonEnglish";
            this.btnRibbonEnglish.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonEnglish.SmallImage")));
            this.btnRibbonEnglish.Text = "영문자 판독";
            this.btnRibbonEnglish.Click += new System.EventHandler(this.btnRibbonEnglish_Click);
            // 
            // btnRibbonHangul
            // 
            this.btnRibbonHangul.Image = ((System.Drawing.Image)(resources.GetObject("btnRibbonHangul.Image")));
            this.btnRibbonHangul.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonHangul.LargeImage")));
            this.btnRibbonHangul.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnRibbonHangul.Name = "btnRibbonHangul";
            this.btnRibbonHangul.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRibbonHangul.SmallImage")));
            this.btnRibbonHangul.Text = "한글 판독";
            this.btnRibbonHangul.Click += new System.EventHandler(this.btnRibbonHangul_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.Image = ((System.Drawing.Image)(resources.GetObject("btnBlur.Image")));
            this.btnBlur.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBlur.LargeImage")));
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBlur.SmallImage")));
            this.btnBlur.Text = "블러";
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // ribbonPanel14
            // 
            this.ribbonPanel14.Items.Add(this.btnCircleDetection);
            this.ribbonPanel14.Name = "ribbonPanel14";
            this.ribbonPanel14.Text = "";
            // 
            // btnCircleDetection
            // 
            this.btnCircleDetection.Image = ((System.Drawing.Image)(resources.GetObject("btnCircleDetection.Image")));
            this.btnCircleDetection.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCircleDetection.LargeImage")));
            this.btnCircleDetection.Name = "btnCircleDetection";
            this.btnCircleDetection.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCircleDetection.SmallImage")));
            this.btnCircleDetection.Text = "원검출";
            this.btnCircleDetection.Click += new System.EventHandler(this.btnCircleDetection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1730, 1274);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "OpenCV";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ScaleValue;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbClose;
        private System.Windows.Forms.RibbonButton btnRibbon;
        private System.Windows.Forms.RibbonButton btnRibbon2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton btnRibbonGray;
        private Cognex.InSight.Controls.Display.CvsInSightDisplay cvsInSightDisplay1;
        private System.Windows.Forms.RibbonButton btnRibbon3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton btnRibbonTrigger;
        private System.Windows.Forms.RibbonCheckBox cbRibbonLive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton btnRibbonSymmetry;
        private System.Windows.Forms.RibbonButton btnRibbonSymmetry2;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton btnRibbon45Rotation;
        private System.Windows.Forms.RibbonButton btnRibbon90Rotation;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonButton btnRibbonSet;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbSave;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonUpDown ribbonUpDown;
        private System.Windows.Forms.RibbonButton btnRibbonBinaryization;
        private System.Windows.Forms.RibbonButton btnRibbonCannyEdge;
        private System.Windows.Forms.RibbonButton btnRibbonCorner;
        private System.Windows.Forms.RibbonButton btnRibbonApproxPoly;
        private System.Windows.Forms.RibbonButton btnRibbonAffine;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbOpen;
        private System.Windows.Forms.RibbonTab ribbonTab5;
        private System.Windows.Forms.RibbonPanel ribbonPanel9;
        private System.Windows.Forms.RibbonButton btnRibbonEnglish;
        private System.Windows.Forms.RibbonButton btnRibbonHangul;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonPanel ribbonPanel10;
        private System.Windows.Forms.RibbonPanel ribbonPanel11;
        private System.Windows.Forms.RibbonButton Expansion;
        private System.Windows.Forms.RibbonButton Erosion;
        private System.Windows.Forms.RibbonButton OpenMorphology;
        private System.Windows.Forms.RibbonButton CloseMorphology;
        private System.Windows.Forms.RibbonPanel ribbonPanel12;
        private System.Windows.Forms.RibbonButton GradientMorphology;
        private System.Windows.Forms.RibbonButton TopHatMorphology;
        private System.Windows.Forms.RibbonButton BlackHatMorphology;
        private System.Windows.Forms.RibbonButton HitMissMorphology;
        private System.Windows.Forms.RibbonTab ribbonTab6;
        private System.Windows.Forms.RibbonPanel ribbonPanel13;
        private System.Windows.Forms.RibbonButton btnBlur;
        private System.Windows.Forms.RibbonPanel ribbonPanel14;
        private System.Windows.Forms.RibbonButton btnCircleDetection;
    }
}

