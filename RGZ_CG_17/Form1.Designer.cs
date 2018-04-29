namespace RGZ_CG_17
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.GLControl = new OpenTK.GLControl();
            this.main_panel = new System.Windows.Forms.Panel();
            this.accuracyVaslue_label = new System.Windows.Forms.Label();
            this.accuracyName_label = new System.Windows.Forms.Label();
            this.accuracyValue_trackBar = new System.Windows.Forms.TrackBar();
            this.settings_groupBox = new System.Windows.Forms.GroupBox();
            this.spline_checkBox = new System.Windows.Forms.CheckBox();
            this.primitive_checkBox = new System.Windows.Forms.CheckBox();
            this.derivative_checkBox = new System.Windows.Forms.CheckBox();
            this.main_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyValue_trackBar)).BeginInit();
            this.settings_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GLControl
            // 
            this.GLControl.BackColor = System.Drawing.Color.Black;
            this.GLControl.Location = new System.Drawing.Point(1, -2);
            this.GLControl.Name = "GLControl";
            this.GLControl.Size = new System.Drawing.Size(807, 454);
            this.GLControl.TabIndex = 0;
            this.GLControl.VSync = false;
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.settings_groupBox);
            this.main_panel.Controls.Add(this.accuracyValue_trackBar);
            this.main_panel.Controls.Add(this.accuracyVaslue_label);
            this.main_panel.Controls.Add(this.accuracyName_label);
            this.main_panel.Location = new System.Drawing.Point(1, -2);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(86, 155);
            this.main_panel.TabIndex = 1;
            // 
            // accuracyVaslue_label
            // 
            this.accuracyVaslue_label.AutoSize = true;
            this.accuracyVaslue_label.Location = new System.Drawing.Point(64, 11);
            this.accuracyVaslue_label.Name = "accuracyVaslue_label";
            this.accuracyVaslue_label.Size = new System.Drawing.Size(13, 13);
            this.accuracyVaslue_label.TabIndex = 3;
            this.accuracyVaslue_label.Text = "7";
            // 
            // accuracyName_label
            // 
            this.accuracyName_label.AutoSize = true;
            this.accuracyName_label.Location = new System.Drawing.Point(0, 11);
            this.accuracyName_label.Name = "accuracyName_label";
            this.accuracyName_label.Size = new System.Drawing.Size(55, 13);
            this.accuracyName_label.TabIndex = 2;
            this.accuracyName_label.Text = "Accuracy:";
            // 
            // accuracyValue_trackBar
            // 
            this.accuracyValue_trackBar.Location = new System.Drawing.Point(3, 27);
            this.accuracyValue_trackBar.Maximum = 40;
            this.accuracyValue_trackBar.Name = "accuracyValue_trackBar";
            this.accuracyValue_trackBar.Size = new System.Drawing.Size(82, 45);
            this.accuracyValue_trackBar.TabIndex = 2;
            this.accuracyValue_trackBar.Value = 7;
            // 
            // settings_groupBox
            // 
            this.settings_groupBox.Controls.Add(this.primitive_checkBox);
            this.settings_groupBox.Controls.Add(this.derivative_checkBox);
            this.settings_groupBox.Controls.Add(this.spline_checkBox);
            this.settings_groupBox.Location = new System.Drawing.Point(-6, 67);
            this.settings_groupBox.Name = "settings_groupBox";
            this.settings_groupBox.Size = new System.Drawing.Size(91, 87);
            this.settings_groupBox.TabIndex = 2;
            this.settings_groupBox.TabStop = false;
            this.settings_groupBox.Text = "Settings";
            // 
            // spline_checkBox
            // 
            this.spline_checkBox.AutoSize = true;
            this.spline_checkBox.Location = new System.Drawing.Point(9, 19);
            this.spline_checkBox.Name = "spline_checkBox";
            this.spline_checkBox.Size = new System.Drawing.Size(55, 17);
            this.spline_checkBox.TabIndex = 2;
            this.spline_checkBox.Text = "Spline";
            this.spline_checkBox.UseVisualStyleBackColor = true;
            // 
            // primitive_checkBox
            // 
            this.primitive_checkBox.AutoSize = true;
            this.primitive_checkBox.Location = new System.Drawing.Point(9, 65);
            this.primitive_checkBox.Name = "primitive_checkBox";
            this.primitive_checkBox.Size = new System.Drawing.Size(65, 17);
            this.primitive_checkBox.TabIndex = 3;
            this.primitive_checkBox.Text = "Primitive";
            this.primitive_checkBox.UseVisualStyleBackColor = true;
            // 
            // derivative_checkBox
            // 
            this.derivative_checkBox.AutoSize = true;
            this.derivative_checkBox.Location = new System.Drawing.Point(9, 42);
            this.derivative_checkBox.Name = "derivative_checkBox";
            this.derivative_checkBox.Size = new System.Drawing.Size(74, 17);
            this.derivative_checkBox.TabIndex = 4;
            this.derivative_checkBox.Text = "Derivative";
            this.derivative_checkBox.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.GLControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "V17";
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accuracyValue_trackBar)).EndInit();
            this.settings_groupBox.ResumeLayout(false);
            this.settings_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl GLControl;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Label accuracyVaslue_label;
        private System.Windows.Forms.Label accuracyName_label;
        private System.Windows.Forms.GroupBox settings_groupBox;
        private System.Windows.Forms.CheckBox primitive_checkBox;
        private System.Windows.Forms.CheckBox derivative_checkBox;
        private System.Windows.Forms.CheckBox spline_checkBox;
        private System.Windows.Forms.TrackBar accuracyValue_trackBar;
    }
}

