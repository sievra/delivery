namespace delivery
{
    partial class GeneratorForm
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
            this.gBTestParams = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.numUDError = new System.Windows.Forms.NumericUpDown();
            this.lblMaxCoor = new System.Windows.Forms.Label();
            this.numUDMinCoor = new System.Windows.Forms.NumericUpDown();
            this.lblMinCoor = new System.Windows.Forms.Label();
            this.numUDCount = new System.Windows.Forms.NumericUpDown();
            this.lblCount = new System.Windows.Forms.Label();
            this.numUDMaxCoor = new System.Windows.Forms.NumericUpDown();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gBTestParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDMinCoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDMaxCoor)).BeginInit();
            this.SuspendLayout();
            // 
            // gBTestParams
            // 
            this.gBTestParams.Controls.Add(this.numUDMaxCoor);
            this.gBTestParams.Controls.Add(this.lblError);
            this.gBTestParams.Controls.Add(this.numUDError);
            this.gBTestParams.Controls.Add(this.lblMaxCoor);
            this.gBTestParams.Controls.Add(this.numUDMinCoor);
            this.gBTestParams.Controls.Add(this.lblMinCoor);
            this.gBTestParams.Controls.Add(this.numUDCount);
            this.gBTestParams.Controls.Add(this.lblCount);
            this.gBTestParams.Location = new System.Drawing.Point(12, 12);
            this.gBTestParams.Name = "gBTestParams";
            this.gBTestParams.Size = new System.Drawing.Size(322, 131);
            this.gBTestParams.TabIndex = 3;
            this.gBTestParams.TabStop = false;
            this.gBTestParams.Text = "Параметры теста";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(6, 101);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(75, 13);
            this.lblError.TabIndex = 18;
            this.lblError.Text = "Погрешность";
            // 
            // numUDError
            // 
            this.numUDError.DecimalPlaces = 2;
            this.numUDError.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUDError.Location = new System.Drawing.Point(196, 99);
            this.numUDError.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numUDError.Name = "numUDError";
            this.numUDError.Size = new System.Drawing.Size(120, 20);
            this.numUDError.TabIndex = 4;
            this.numUDError.Value = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            // 
            // lblMaxCoor
            // 
            this.lblMaxCoor.AutoSize = true;
            this.lblMaxCoor.Location = new System.Drawing.Point(6, 74);
            this.lblMaxCoor.Name = "lblMaxCoor";
            this.lblMaxCoor.Size = new System.Drawing.Size(190, 13);
            this.lblMaxCoor.TabIndex = 16;
            this.lblMaxCoor.Text = "Максимальное значение координат";
            // 
            // numUDMinCoor
            // 
            this.numUDMinCoor.Location = new System.Drawing.Point(196, 48);
            this.numUDMinCoor.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numUDMinCoor.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numUDMinCoor.Name = "numUDMinCoor";
            this.numUDMinCoor.Size = new System.Drawing.Size(120, 20);
            this.numUDMinCoor.TabIndex = 2;
            this.numUDMinCoor.Value = new decimal(new int[] {
            120,
            0,
            0,
            -2147483648});
            // 
            // lblMinCoor
            // 
            this.lblMinCoor.AutoSize = true;
            this.lblMinCoor.Location = new System.Drawing.Point(6, 50);
            this.lblMinCoor.Name = "lblMinCoor";
            this.lblMinCoor.Size = new System.Drawing.Size(184, 13);
            this.lblMinCoor.TabIndex = 14;
            this.lblMinCoor.Text = "Минимальное значение координат";
            // 
            // numUDCount
            // 
            this.numUDCount.Location = new System.Drawing.Point(196, 24);
            this.numUDCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUDCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDCount.Name = "numUDCount";
            this.numUDCount.Size = new System.Drawing.Size(120, 20);
            this.numUDCount.TabIndex = 1;
            this.numUDCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(6, 26);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(159, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Количество пунктов доставки";
            // 
            // numUDMaxCoor
            // 
            this.numUDMaxCoor.Location = new System.Drawing.Point(196, 72);
            this.numUDMaxCoor.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUDMaxCoor.Name = "numUDMaxCoor";
            this.numUDMaxCoor.Size = new System.Drawing.Size(120, 20);
            this.numUDMaxCoor.TabIndex = 3;
            this.numUDMaxCoor.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 149);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(322, 36);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Сгенерировать";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 197);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.gBTestParams);
            this.Name = "GeneratorForm";
            this.Text = "Генератор тестов";
            this.gBTestParams.ResumeLayout(false);
            this.gBTestParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDMinCoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDMaxCoor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBTestParams;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.NumericUpDown numUDError;
        private System.Windows.Forms.Label lblMaxCoor;
        private System.Windows.Forms.NumericUpDown numUDMinCoor;
        private System.Windows.Forms.Label lblMinCoor;
        private System.Windows.Forms.NumericUpDown numUDCount;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown numUDMaxCoor;
        private System.Windows.Forms.Button btnGenerate;
    }
}