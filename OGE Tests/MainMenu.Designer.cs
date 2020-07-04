namespace OGE_Tests
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnTakeTest = new System.Windows.Forms.Button();
            this.btnMyProgress = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(65, 199);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(150, 52);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "Профиль";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnTakeTest
            // 
            this.btnTakeTest.Location = new System.Drawing.Point(230, 199);
            this.btnTakeTest.Name = "btnTakeTest";
            this.btnTakeTest.Size = new System.Drawing.Size(150, 52);
            this.btnTakeTest.TabIndex = 1;
            this.btnTakeTest.Text = "Пройти тест";
            this.btnTakeTest.UseVisualStyleBackColor = true;
            this.btnTakeTest.Click += new System.EventHandler(this.btnTakeTest_Click);
            // 
            // btnMyProgress
            // 
            this.btnMyProgress.Location = new System.Drawing.Point(399, 199);
            this.btnMyProgress.Name = "btnMyProgress";
            this.btnMyProgress.Size = new System.Drawing.Size(150, 52);
            this.btnMyProgress.TabIndex = 2;
            this.btnMyProgress.Text = "Мои достижения";
            this.btnMyProgress.UseVisualStyleBackColor = true;
            this.btnMyProgress.Click += new System.EventHandler(this.btnMyProgress_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(565, 199);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(150, 52);
            this.btnInfo.TabIndex = 3;
            this.btnInfo.Text = "Справка";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnMyProgress);
            this.Controls.Add(this.btnTakeTest);
            this.Controls.Add(this.btnProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тренажёр ОГЭ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnTakeTest;
        private System.Windows.Forms.Button btnMyProgress;
        private System.Windows.Forms.Button btnInfo;
    }
}