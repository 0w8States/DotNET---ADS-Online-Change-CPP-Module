namespace WinForms_TC3CPP_OnlineChange
{
    partial class CppOnlineDash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CppOnlineDash));
            this.btnAdsConnect = new System.Windows.Forms.Button();
            this.btnAdsDisconnect = new System.Windows.Forms.Button();
            this.btnTcComVer1 = new System.Windows.Forms.Button();
            this.btnTcComVer2 = new System.Windows.Forms.Button();
            this.btnTcComVer3 = new System.Windows.Forms.Button();
            this.btnTcComVer5 = new System.Windows.Forms.Button();
            this.btnTcComVer4 = new System.Windows.Forms.Button();
            this.checkBoxAdsLocal = new System.Windows.Forms.CheckBox();
            this.comboBoxAdsTargets = new System.Windows.Forms.ComboBox();
            this.labelModuleDesc = new System.Windows.Forms.Label();
            this.labelTcComStatus = new System.Windows.Forms.Label();
            this.scopeProjectPanel = new TwinCAT.Measurement.Scope.Control.ScopeProjectPanel();
            this.labelSignalValue = new System.Windows.Forms.Label();
            this.labelValueStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdsConnect
            // 
            this.btnAdsConnect.Location = new System.Drawing.Point(12, 12);
            this.btnAdsConnect.Name = "btnAdsConnect";
            this.btnAdsConnect.Size = new System.Drawing.Size(75, 23);
            this.btnAdsConnect.TabIndex = 1;
            this.btnAdsConnect.Text = "Connect";
            this.btnAdsConnect.UseVisualStyleBackColor = true;
            // 
            // btnAdsDisconnect
            // 
            this.btnAdsDisconnect.Location = new System.Drawing.Point(93, 12);
            this.btnAdsDisconnect.Name = "btnAdsDisconnect";
            this.btnAdsDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnAdsDisconnect.TabIndex = 2;
            this.btnAdsDisconnect.Text = "Disconnect";
            this.btnAdsDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnTcComVer1
            // 
            this.btnTcComVer1.Location = new System.Drawing.Point(344, 12);
            this.btnTcComVer1.Name = "btnTcComVer1";
            this.btnTcComVer1.Size = new System.Drawing.Size(75, 23);
            this.btnTcComVer1.TabIndex = 3;
            this.btnTcComVer1.Text = "Version 1";
            this.btnTcComVer1.UseVisualStyleBackColor = true;
            // 
            // btnTcComVer2
            // 
            this.btnTcComVer2.Location = new System.Drawing.Point(425, 12);
            this.btnTcComVer2.Name = "btnTcComVer2";
            this.btnTcComVer2.Size = new System.Drawing.Size(75, 23);
            this.btnTcComVer2.TabIndex = 4;
            this.btnTcComVer2.Text = "Version 2";
            this.btnTcComVer2.UseVisualStyleBackColor = true;
            // 
            // btnTcComVer3
            // 
            this.btnTcComVer3.Location = new System.Drawing.Point(506, 12);
            this.btnTcComVer3.Name = "btnTcComVer3";
            this.btnTcComVer3.Size = new System.Drawing.Size(75, 23);
            this.btnTcComVer3.TabIndex = 5;
            this.btnTcComVer3.Text = "Version 3";
            this.btnTcComVer3.UseVisualStyleBackColor = true;
            // 
            // btnTcComVer5
            // 
            this.btnTcComVer5.Location = new System.Drawing.Point(668, 12);
            this.btnTcComVer5.Name = "btnTcComVer5";
            this.btnTcComVer5.Size = new System.Drawing.Size(75, 23);
            this.btnTcComVer5.TabIndex = 7;
            this.btnTcComVer5.Text = "Version 5";
            this.btnTcComVer5.UseVisualStyleBackColor = true;
            // 
            // btnTcComVer4
            // 
            this.btnTcComVer4.Location = new System.Drawing.Point(587, 12);
            this.btnTcComVer4.Name = "btnTcComVer4";
            this.btnTcComVer4.Size = new System.Drawing.Size(75, 23);
            this.btnTcComVer4.TabIndex = 6;
            this.btnTcComVer4.Text = "Version 4";
            this.btnTcComVer4.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdsLocal
            // 
            this.checkBoxAdsLocal.AutoSize = true;
            this.checkBoxAdsLocal.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxAdsLocal.Checked = true;
            this.checkBoxAdsLocal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAdsLocal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxAdsLocal.Location = new System.Drawing.Point(14, 42);
            this.checkBoxAdsLocal.Name = "checkBoxAdsLocal";
            this.checkBoxAdsLocal.Size = new System.Drawing.Size(86, 17);
            this.checkBoxAdsLocal.TabIndex = 9;
            this.checkBoxAdsLocal.Text = "Local Target";
            this.checkBoxAdsLocal.UseVisualStyleBackColor = false;
            // 
            // comboBoxAdsTargets
            // 
            this.comboBoxAdsTargets.FormattingEnabled = true;
            this.comboBoxAdsTargets.Location = new System.Drawing.Point(13, 64);
            this.comboBoxAdsTargets.Name = "comboBoxAdsTargets";
            this.comboBoxAdsTargets.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAdsTargets.TabIndex = 10;
            // 
            // labelModuleDesc
            // 
            this.labelModuleDesc.AutoSize = true;
            this.labelModuleDesc.BackColor = System.Drawing.SystemColors.Control;
            this.labelModuleDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelModuleDesc.Location = new System.Drawing.Point(307, 60);
            this.labelModuleDesc.Name = "labelModuleDesc";
            this.labelModuleDesc.Size = new System.Drawing.Size(151, 13);
            this.labelModuleDesc.TabIndex = 11;
            this.labelModuleDesc.Text = "Online TcCOM Module Status:";
            // 
            // labelTcComStatus
            // 
            this.labelTcComStatus.BackColor = System.Drawing.SystemColors.Control;
            this.labelTcComStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTcComStatus.Location = new System.Drawing.Point(458, 60);
            this.labelTcComStatus.Name = "labelTcComStatus";
            this.labelTcComStatus.Size = new System.Drawing.Size(255, 13);
            this.labelTcComStatus.TabIndex = 12;
            this.labelTcComStatus.Text = "Disconnected";
            // 
            // scopeProjectPanel
            // 
            this.scopeProjectPanel.AllowDrop = true;
            this.scopeProjectPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scopeProjectPanel.GraphicLibrary = TwinCAT.Scope2.Communications.GraphicLibrary.GDI_Plus;
            this.scopeProjectPanel.Location = new System.Drawing.Point(14, 94);
            this.scopeProjectPanel.Name = "scopeProjectPanel";
            this.scopeProjectPanel.ScopeProject = null;
            this.scopeProjectPanel.Size = new System.Drawing.Size(772, 390);
            this.scopeProjectPanel.TabIndex = 0;
            // 
            // labelSignalValue
            // 
            this.labelSignalValue.BackColor = System.Drawing.SystemColors.Control;
            this.labelSignalValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSignalValue.Location = new System.Drawing.Point(458, 78);
            this.labelSignalValue.Name = "labelSignalValue";
            this.labelSignalValue.Size = new System.Drawing.Size(255, 13);
            this.labelSignalValue.TabIndex = 14;
            // 
            // labelValueStatus
            // 
            this.labelValueStatus.AutoSize = true;
            this.labelValueStatus.BackColor = System.Drawing.SystemColors.Control;
            this.labelValueStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelValueStatus.Location = new System.Drawing.Point(385, 78);
            this.labelValueStatus.Name = "labelValueStatus";
            this.labelValueStatus.Size = new System.Drawing.Size(73, 13);
            this.labelValueStatus.TabIndex = 13;
            this.labelValueStatus.Text = "Online Value: ";
            // 
            // CppOnlineDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.labelSignalValue);
            this.Controls.Add(this.labelValueStatus);
            this.Controls.Add(this.labelTcComStatus);
            this.Controls.Add(this.labelModuleDesc);
            this.Controls.Add(this.comboBoxAdsTargets);
            this.Controls.Add(this.checkBoxAdsLocal);
            this.Controls.Add(this.btnTcComVer5);
            this.Controls.Add(this.btnTcComVer4);
            this.Controls.Add(this.btnTcComVer3);
            this.Controls.Add(this.btnTcComVer2);
            this.Controls.Add(this.btnTcComVer1);
            this.Controls.Add(this.btnAdsDisconnect);
            this.Controls.Add(this.btnAdsConnect);
            this.Controls.Add(this.scopeProjectPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CppOnlineDash";
            this.Text = "CPP Online Changeable Dashboard";
            this.Load += new System.EventHandler(this.CppOnlineDash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdsConnect;
        private System.Windows.Forms.Button btnAdsDisconnect;
        private System.Windows.Forms.Button btnTcComVer1;
        private System.Windows.Forms.Button btnTcComVer2;
        private System.Windows.Forms.Button btnTcComVer3;
        private System.Windows.Forms.Button btnTcComVer5;
        private System.Windows.Forms.Button btnTcComVer4;
        private System.Windows.Forms.CheckBox checkBoxAdsLocal;
        private System.Windows.Forms.ComboBox comboBoxAdsTargets;
        private System.Windows.Forms.Label labelModuleDesc;
        private System.Windows.Forms.Label labelTcComStatus;
        private TwinCAT.Measurement.Scope.Control.ScopeProjectPanel scopeProjectPanel;
        private System.Windows.Forms.Label labelSignalValue;
        private System.Windows.Forms.Label labelValueStatus;
    }
}

