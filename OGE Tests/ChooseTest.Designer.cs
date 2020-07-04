namespace OGE_Tests
{
    partial class ChooseTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseTest));
            this.btnGenerateTest = new System.Windows.Forms.Button();
            this.cbChooseTest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateTest
            // 
            resources.ApplyResources(this.btnGenerateTest, "btnGenerateTest");
            this.btnGenerateTest.Name = "btnGenerateTest";
            this.btnGenerateTest.UseVisualStyleBackColor = true;
            this.btnGenerateTest.Click += new System.EventHandler(this.btnGenerateTest_Click);
            // 
            // cbChooseTest
            // 
            this.cbChooseTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChooseTest.FormattingEnabled = true;
            resources.ApplyResources(this.cbChooseTest, "cbChooseTest");
            this.cbChooseTest.Name = "cbChooseTest";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnBack
            // 
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.Name = "btnBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ChooseTest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChooseTest);
            this.Controls.Add(this.btnGenerateTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChooseTest";
            this.Load += new System.EventHandler(this.ChooseTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateTest;
        private System.Windows.Forms.ComboBox cbChooseTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
    }
}