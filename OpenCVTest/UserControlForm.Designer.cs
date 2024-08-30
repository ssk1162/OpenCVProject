using System.Drawing;

namespace OpenCVTest
{
    partial class UserControlForm
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnXYBack = new System.Windows.Forms.Button();
            this.btnXYResult = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRDownY = new System.Windows.Forms.TextBox();
            this.txtRDownX = new System.Windows.Forms.TextBox();
            this.txtRUpY = new System.Windows.Forms.TextBox();
            this.txtRUpX = new System.Windows.Forms.TextBox();
            this.txtLDownY = new System.Windows.Forms.TextBox();
            this.txtLDownX = new System.Windows.Forms.TextBox();
            this.txtLUpY = new System.Windows.Forms.TextBox();
            this.txtLUpX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "기하학적 변환";
            // 
            // btnXYBack
            // 
            this.btnXYBack.Location = new System.Drawing.Point(222, 312);
            this.btnXYBack.Name = "btnXYBack";
            this.btnXYBack.Size = new System.Drawing.Size(124, 43);
            this.btnXYBack.TabIndex = 16;
            this.btnXYBack.Text = "되돌리기";
            this.btnXYBack.UseVisualStyleBackColor = true;
            this.btnXYBack.Click += new System.EventHandler(this.btnXYBack_Click);
            // 
            // btnXYResult
            // 
            this.btnXYResult.Location = new System.Drawing.Point(92, 312);
            this.btnXYResult.Name = "btnXYResult";
            this.btnXYResult.Size = new System.Drawing.Size(124, 43);
            this.btnXYResult.TabIndex = 17;
            this.btnXYResult.Text = "변환하기";
            this.btnXYResult.UseVisualStyleBackColor = true;
            this.btnXYResult.Click += new System.EventHandler(this.btnXYResult_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(72, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "우하XY";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(72, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "우상XY";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(72, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "좌하XY";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(72, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "좌상XY";
            // 
            // txtRDownY
            // 
            this.txtRDownY.Location = new System.Drawing.Point(263, 246);
            this.txtRDownY.Name = "txtRDownY";
            this.txtRDownY.Size = new System.Drawing.Size(100, 28);
            this.txtRDownY.TabIndex = 4;
            // 
            // txtRDownX
            // 
            this.txtRDownX.Location = new System.Drawing.Point(157, 246);
            this.txtRDownX.Name = "txtRDownX";
            this.txtRDownX.Size = new System.Drawing.Size(100, 28);
            this.txtRDownX.TabIndex = 5;
            // 
            // txtRUpY
            // 
            this.txtRUpY.Location = new System.Drawing.Point(263, 212);
            this.txtRUpY.Name = "txtRUpY";
            this.txtRUpY.Size = new System.Drawing.Size(100, 28);
            this.txtRUpY.TabIndex = 6;
            // 
            // txtRUpX
            // 
            this.txtRUpX.Location = new System.Drawing.Point(157, 212);
            this.txtRUpX.Name = "txtRUpX";
            this.txtRUpX.Size = new System.Drawing.Size(100, 28);
            this.txtRUpX.TabIndex = 7;
            // 
            // txtLDownY
            // 
            this.txtLDownY.Location = new System.Drawing.Point(263, 178);
            this.txtLDownY.Name = "txtLDownY";
            this.txtLDownY.Size = new System.Drawing.Size(100, 28);
            this.txtLDownY.TabIndex = 8;
            // 
            // txtLDownX
            // 
            this.txtLDownX.Location = new System.Drawing.Point(157, 178);
            this.txtLDownX.Name = "txtLDownX";
            this.txtLDownX.Size = new System.Drawing.Size(100, 28);
            this.txtLDownX.TabIndex = 9;
            // 
            // txtLUpY
            // 
            this.txtLUpY.Location = new System.Drawing.Point(263, 144);
            this.txtLUpY.Name = "txtLUpY";
            this.txtLUpY.Size = new System.Drawing.Size(100, 28);
            this.txtLUpY.TabIndex = 10;
            // 
            // txtLUpX
            // 
            this.txtLUpX.Location = new System.Drawing.Point(157, 144);
            this.txtLUpX.Name = "txtLUpX";
            this.txtLUpX.Size = new System.Drawing.Size(100, 28);
            this.txtLUpX.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "대문자 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "소문자 :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 572);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 18);
            this.label8.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(390, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 20;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UserControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXYBack);
            this.Controls.Add(this.btnXYResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRDownY);
            this.Controls.Add(this.txtRDownX);
            this.Controls.Add(this.txtRUpY);
            this.Controls.Add(this.txtRUpX);
            this.Controls.Add(this.txtLDownY);
            this.Controls.Add(this.txtLDownX);
            this.Controls.Add(this.txtLUpY);
            this.Controls.Add(this.txtLUpX);
            this.Name = "UserControlForm";
            this.Size = new System.Drawing.Size(435, 979);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXYBack;
        private System.Windows.Forms.Button btnXYResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtRDownY;
        public System.Windows.Forms.TextBox txtRDownX;
        public System.Windows.Forms.TextBox txtRUpY;
        public System.Windows.Forms.TextBox txtRUpX;
        public System.Windows.Forms.TextBox txtLDownY;
        public System.Windows.Forms.TextBox txtLDownX;
        public System.Windows.Forms.TextBox txtLUpY;
        public System.Windows.Forms.TextBox txtLUpX;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
    }
}
