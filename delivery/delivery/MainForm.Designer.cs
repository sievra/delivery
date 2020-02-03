namespace delivery
{
    partial class MainForm
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
            this.gBAlgo = new System.Windows.Forms.GroupBox();
            this.cBAlgo = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.gMaps = new GMap.NET.WindowsForms.GMapControl();
            this.gBSource = new System.Windows.Forms.GroupBox();
            this.cBSource = new System.Windows.Forms.ComboBox();
            this.dataGVMatrix = new System.Windows.Forms.DataGridView();
            this.numUDCount = new System.Windows.Forms.NumericUpDown();
            this.dataGVTime = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBGAParams = new System.Windows.Forms.GroupBox();
            this.lblSelection = new System.Windows.Forms.Label();
            this.numUDMutation = new System.Windows.Forms.NumericUpDown();
            this.lblMutation = new System.Windows.Forms.Label();
            this.numUDGenerations = new System.Windows.Forms.NumericUpDown();
            this.lblGenerations = new System.Windows.Forms.Label();
            this.numUDIndivids = new System.Windows.Forms.NumericUpDown();
            this.lblIndivids = new System.Windows.Forms.Label();
            this.cBSelection = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tBResult = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gBCount = new System.Windows.Forms.GroupBox();
            this.gBMatrix = new System.Windows.Forms.GroupBox();
            this.gBMap = new System.Windows.Forms.GroupBox();
            this.btnClearMarkers = new System.Windows.Forms.Button();
            this.gBTime = new System.Windows.Forms.GroupBox();
            this.gBResult = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.gBAlgo.SuspendLayout();
            this.gBSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVTime)).BeginInit();
            this.gBGAParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDIndivids)).BeginInit();
            this.gBCount.SuspendLayout();
            this.gBMatrix.SuspendLayout();
            this.gBMap.SuspendLayout();
            this.gBTime.SuspendLayout();
            this.gBResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBAlgo
            // 
            this.gBAlgo.Controls.Add(this.cBAlgo);
            this.gBAlgo.Location = new System.Drawing.Point(12, 12);
            this.gBAlgo.Name = "gBAlgo";
            this.gBAlgo.Size = new System.Drawing.Size(158, 51);
            this.gBAlgo.TabIndex = 0;
            this.gBAlgo.TabStop = false;
            this.gBAlgo.Text = "Выбор алгоритма";
            // 
            // cBAlgo
            // 
            this.cBAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBAlgo.FormattingEnabled = true;
            this.cBAlgo.Items.AddRange(new object[] {
            "Полный перебор",
            "Жадный алгоритм",
            "Генетический алгоритм"});
            this.cBAlgo.Location = new System.Drawing.Point(6, 19);
            this.cBAlgo.Name = "cBAlgo";
            this.cBAlgo.Size = new System.Drawing.Size(146, 21);
            this.cBAlgo.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 407);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(144, 53);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Запуск";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // gMaps
            // 
            this.gMaps.Bearing = 0F;
            this.gMaps.CanDragMap = true;
            this.gMaps.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMaps.GrayScaleMode = false;
            this.gMaps.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMaps.LevelsKeepInMemmory = 5;
            this.gMaps.Location = new System.Drawing.Point(6, 19);
            this.gMaps.MarkersEnabled = true;
            this.gMaps.MaxZoom = 2;
            this.gMaps.MinZoom = 2;
            this.gMaps.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMaps.Name = "gMaps";
            this.gMaps.NegativeMode = false;
            this.gMaps.PolygonsEnabled = true;
            this.gMaps.RetryLoadTile = 0;
            this.gMaps.RoutesEnabled = true;
            this.gMaps.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMaps.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMaps.ShowTileGridLines = false;
            this.gMaps.Size = new System.Drawing.Size(392, 313);
            this.gMaps.TabIndex = 2;
            this.gMaps.Zoom = 0D;
            this.gMaps.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMaps_OnMarkerClick);
            this.gMaps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMaps_MouseDoubleClick);
            // 
            // gBSource
            // 
            this.gBSource.Controls.Add(this.cBSource);
            this.gBSource.Location = new System.Drawing.Point(176, 12);
            this.gBSource.Name = "gBSource";
            this.gBSource.Size = new System.Drawing.Size(158, 51);
            this.gBSource.TabIndex = 2;
            this.gBSource.TabStop = false;
            this.gBSource.Text = "Источник данных";
            // 
            // cBSource
            // 
            this.cBSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBSource.FormattingEnabled = true;
            this.cBSource.Items.AddRange(new object[] {
            "Форма",
            "Генератор",
            "Карта"});
            this.cBSource.Location = new System.Drawing.Point(6, 19);
            this.cBSource.Name = "cBSource";
            this.cBSource.Size = new System.Drawing.Size(146, 21);
            this.cBSource.TabIndex = 1;
            this.cBSource.SelectedIndexChanged += new System.EventHandler(this.cBSource_SelectedIndexChanged);
            // 
            // dataGVMatrix
            // 
            this.dataGVMatrix.AllowUserToAddRows = false;
            this.dataGVMatrix.AllowUserToDeleteRows = false;
            this.dataGVMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGVMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVMatrix.Location = new System.Drawing.Point(6, 19);
            this.dataGVMatrix.Name = "dataGVMatrix";
            this.dataGVMatrix.Size = new System.Drawing.Size(392, 313);
            this.dataGVMatrix.TabIndex = 11;
            this.dataGVMatrix.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGVMatrix_EditingControlShowing);
            // 
            // numUDCount
            // 
            this.numUDCount.Location = new System.Drawing.Point(6, 20);
            this.numUDCount.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numUDCount.Name = "numUDCount";
            this.numUDCount.Size = new System.Drawing.Size(120, 20);
            this.numUDCount.TabIndex = 12;
            this.numUDCount.ValueChanged += new System.EventHandler(this.numUDCount_ValueChanged);
            // 
            // dataGVTime
            // 
            this.dataGVTime.AllowUserToAddRows = false;
            this.dataGVTime.AllowUserToDeleteRows = false;
            this.dataGVTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGVTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGVTime.Location = new System.Drawing.Point(6, 19);
            this.dataGVTime.Name = "dataGVTime";
            this.dataGVTime.Size = new System.Drawing.Size(202, 313);
            this.dataGVTime.TabIndex = 13;
            this.dataGVTime.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGVTime_EditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Начало";
            this.Column1.Name = "Column1";
            this.Column1.Width = 69;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Конец";
            this.Column2.Name = "Column2";
            this.Column2.Width = 63;
            // 
            // gBGAParams
            // 
            this.gBGAParams.Controls.Add(this.lblSelection);
            this.gBGAParams.Controls.Add(this.numUDMutation);
            this.gBGAParams.Controls.Add(this.lblMutation);
            this.gBGAParams.Controls.Add(this.numUDGenerations);
            this.gBGAParams.Controls.Add(this.lblGenerations);
            this.gBGAParams.Controls.Add(this.numUDIndivids);
            this.gBGAParams.Controls.Add(this.lblIndivids);
            this.gBGAParams.Controls.Add(this.cBSelection);
            this.gBGAParams.Location = new System.Drawing.Point(12, 69);
            this.gBGAParams.Name = "gBGAParams";
            this.gBGAParams.Size = new System.Drawing.Size(322, 131);
            this.gBGAParams.TabIndex = 2;
            this.gBGAParams.TabStop = false;
            this.gBGAParams.Text = "Параметры генетического алгоритма";
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Location = new System.Drawing.Point(6, 101);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(56, 13);
            this.lblSelection.TabIndex = 18;
            this.lblSelection.Text = "Селекция";
            // 
            // numUDMutation
            // 
            this.numUDMutation.DecimalPlaces = 2;
            this.numUDMutation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numUDMutation.Location = new System.Drawing.Point(196, 72);
            this.numUDMutation.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDMutation.Name = "numUDMutation";
            this.numUDMutation.Size = new System.Drawing.Size(120, 20);
            this.numUDMutation.TabIndex = 17;
            this.numUDMutation.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // lblMutation
            // 
            this.lblMutation.AutoSize = true;
            this.lblMutation.Location = new System.Drawing.Point(6, 74);
            this.lblMutation.Name = "lblMutation";
            this.lblMutation.Size = new System.Drawing.Size(117, 13);
            this.lblMutation.TabIndex = 16;
            this.lblMutation.Text = "Вероятность мутации";
            // 
            // numUDGenerations
            // 
            this.numUDGenerations.Location = new System.Drawing.Point(196, 48);
            this.numUDGenerations.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUDGenerations.Name = "numUDGenerations";
            this.numUDGenerations.Size = new System.Drawing.Size(120, 20);
            this.numUDGenerations.TabIndex = 15;
            this.numUDGenerations.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblGenerations
            // 
            this.lblGenerations.AutoSize = true;
            this.lblGenerations.Location = new System.Drawing.Point(6, 50);
            this.lblGenerations.Name = "lblGenerations";
            this.lblGenerations.Size = new System.Drawing.Size(123, 13);
            this.lblGenerations.TabIndex = 14;
            this.lblGenerations.Text = "Количество поколений";
            // 
            // numUDIndivids
            // 
            this.numUDIndivids.Location = new System.Drawing.Point(196, 24);
            this.numUDIndivids.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUDIndivids.Name = "numUDIndivids";
            this.numUDIndivids.Size = new System.Drawing.Size(120, 20);
            this.numUDIndivids.TabIndex = 13;
            this.numUDIndivids.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblIndivids
            // 
            this.lblIndivids.AutoSize = true;
            this.lblIndivids.Location = new System.Drawing.Point(6, 26);
            this.lblIndivids.Name = "lblIndivids";
            this.lblIndivids.Size = new System.Drawing.Size(111, 13);
            this.lblIndivids.TabIndex = 2;
            this.lblIndivids.Text = "Особей в поколении";
            // 
            // cBSelection
            // 
            this.cBSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBSelection.FormattingEnabled = true;
            this.cBSelection.Items.AddRange(new object[] {
            "Турнир",
            "Рулетка"});
            this.cBSelection.Location = new System.Drawing.Point(196, 98);
            this.cBSelection.Name = "cBSelection";
            this.cBSelection.Size = new System.Drawing.Size(120, 21);
            this.cBSelection.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(6, 338);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(144, 53);
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "Импорт";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(156, 338);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(144, 53);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 471);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1225, 23);
            this.progressBar.TabIndex = 16;
            // 
            // tBResult
            // 
            this.tBResult.Location = new System.Drawing.Point(6, 19);
            this.tBResult.Multiline = true;
            this.tBResult.Name = "tBResult";
            this.tBResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBResult.Size = new System.Drawing.Size(253, 313);
            this.tBResult.TabIndex = 17;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(6, 338);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(144, 53);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "Генератор";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 506);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 19;
            // 
            // gBCount
            // 
            this.gBCount.Controls.Add(this.numUDCount);
            this.gBCount.Location = new System.Drawing.Point(346, 12);
            this.gBCount.Name = "gBCount";
            this.gBCount.Size = new System.Drawing.Size(174, 51);
            this.gBCount.TabIndex = 3;
            this.gBCount.TabStop = false;
            this.gBCount.Text = "Количество пунктов доставки";
            // 
            // gBMatrix
            // 
            this.gBMatrix.Controls.Add(this.dataGVMatrix);
            this.gBMatrix.Controls.Add(this.btnExport);
            this.gBMatrix.Controls.Add(this.btnImport);
            this.gBMatrix.Location = new System.Drawing.Point(346, 69);
            this.gBMatrix.Name = "gBMatrix";
            this.gBMatrix.Size = new System.Drawing.Size(404, 396);
            this.gBMatrix.TabIndex = 13;
            this.gBMatrix.TabStop = false;
            this.gBMatrix.Text = "Матрица времени";
            // 
            // gBMap
            // 
            this.gBMap.Controls.Add(this.gMaps);
            this.gBMap.Controls.Add(this.btnClearMarkers);
            this.gBMap.Location = new System.Drawing.Point(346, 69);
            this.gBMap.Name = "gBMap";
            this.gBMap.Size = new System.Drawing.Size(404, 396);
            this.gBMap.TabIndex = 16;
            this.gBMap.TabStop = false;
            this.gBMap.Text = "Карта";
            this.gBMap.Visible = false;
            // 
            // btnClearMarkers
            // 
            this.btnClearMarkers.Location = new System.Drawing.Point(6, 338);
            this.btnClearMarkers.Name = "btnClearMarkers";
            this.btnClearMarkers.Size = new System.Drawing.Size(144, 53);
            this.btnClearMarkers.TabIndex = 14;
            this.btnClearMarkers.Text = "Очистить маркеры";
            this.btnClearMarkers.UseVisualStyleBackColor = true;
            this.btnClearMarkers.Click += new System.EventHandler(this.btnClearMarkers_Click);
            // 
            // gBTime
            // 
            this.gBTime.Controls.Add(this.btnGenerate);
            this.gBTime.Controls.Add(this.dataGVTime);
            this.gBTime.Location = new System.Drawing.Point(756, 69);
            this.gBTime.Name = "gBTime";
            this.gBTime.Size = new System.Drawing.Size(210, 396);
            this.gBTime.TabIndex = 16;
            this.gBTime.TabStop = false;
            this.gBTime.Text = "Временные окна";
            // 
            // gBResult
            // 
            this.gBResult.Controls.Add(this.tBResult);
            this.gBResult.Location = new System.Drawing.Point(972, 69);
            this.gBResult.Name = "gBResult";
            this.gBResult.Size = new System.Drawing.Size(265, 396);
            this.gBResult.TabIndex = 19;
            this.gBResult.TabStop = false;
            this.gBResult.Text = "Результат";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(190, 407);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(144, 53);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 529);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.gBResult);
            this.Controls.Add(this.gBTime);
            this.Controls.Add(this.gBCount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.gBGAParams);
            this.Controls.Add(this.gBSource);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.gBAlgo);
            this.Controls.Add(this.gBMatrix);
            this.Controls.Add(this.gBMap);
            this.Name = "MainForm";
            this.Text = "Доставка грузов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.gBAlgo.ResumeLayout(false);
            this.gBSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVTime)).EndInit();
            this.gBGAParams.ResumeLayout(false);
            this.gBGAParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDIndivids)).EndInit();
            this.gBCount.ResumeLayout(false);
            this.gBMatrix.ResumeLayout(false);
            this.gBMap.ResumeLayout(false);
            this.gBTime.ResumeLayout(false);
            this.gBResult.ResumeLayout(false);
            this.gBResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBAlgo;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ComboBox cBAlgo;
        private GMap.NET.WindowsForms.GMapControl gMaps;
        private System.Windows.Forms.GroupBox gBSource;
        private System.Windows.Forms.ComboBox cBSource;
        private System.Windows.Forms.DataGridView dataGVMatrix;
        private System.Windows.Forms.NumericUpDown numUDCount;
        private System.Windows.Forms.DataGridView dataGVTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox gBGAParams;
        private System.Windows.Forms.Label lblIndivids;
        private System.Windows.Forms.ComboBox cBSelection;
        private System.Windows.Forms.NumericUpDown numUDMutation;
        private System.Windows.Forms.Label lblMutation;
        private System.Windows.Forms.NumericUpDown numUDGenerations;
        private System.Windows.Forms.Label lblGenerations;
        private System.Windows.Forms.NumericUpDown numUDIndivids;
        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox tBResult;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox gBCount;
        private System.Windows.Forms.GroupBox gBMatrix;
        private System.Windows.Forms.GroupBox gBMap;
        private System.Windows.Forms.Button btnClearMarkers;
        private System.Windows.Forms.GroupBox gBTime;
        private System.Windows.Forms.GroupBox gBResult;
        private System.Windows.Forms.Button btnStop;
    }
}

