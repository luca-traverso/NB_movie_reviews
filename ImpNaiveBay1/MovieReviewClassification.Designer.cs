namespace ImpNaiveBay1
{
    partial class MovieReviewClassification
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieReviewClassification));
            this.viewMovies = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosPerc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNegPerc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPred = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridMovieReview = new DevExpress.XtraGrid.GridControl();
            this.viewFold = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFoldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemSearchLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblAccuracy = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.viewTokens = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colToken = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTFIDF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogPos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNegProb = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.viewMovies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovieReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewFold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // viewMovies
            // 
            this.viewMovies.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colPosPerc,
            this.colNegPerc,
            this.colLabel,
            this.colPred,
            this.colContent});
            this.viewMovies.GridControl = this.gridMovieReview;
            this.viewMovies.Name = "viewMovies";
            this.viewMovies.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewMovies.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewMovies.OptionsBehavior.AutoPopulateColumns = false;
            this.viewMovies.OptionsView.ShowGroupPanel = false;
            this.viewMovies.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.viewMovies.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.viewMovies_RowStyle);
            // 
            // colName
            // 
            this.colName.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colName.AppearanceCell.Options.UseForeColor = true;
            this.colName.Caption = "File Name";
            this.colName.FieldName = "MovieReviewFileName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colPosPerc
            // 
            this.colPosPerc.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colPosPerc.AppearanceCell.Options.UseForeColor = true;
            this.colPosPerc.Caption = "Positive Probability";
            this.colPosPerc.FieldName = "PosPercentage";
            this.colPosPerc.Name = "colPosPerc";
            this.colPosPerc.OptionsColumn.AllowEdit = false;
            this.colPosPerc.OptionsColumn.ReadOnly = true;
            this.colPosPerc.Visible = true;
            this.colPosPerc.VisibleIndex = 1;
            // 
            // colNegPerc
            // 
            this.colNegPerc.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colNegPerc.AppearanceCell.Options.UseForeColor = true;
            this.colNegPerc.Caption = "Negative Probability";
            this.colNegPerc.FieldName = "NegPercentage";
            this.colNegPerc.Name = "colNegPerc";
            this.colNegPerc.OptionsColumn.AllowEdit = false;
            this.colNegPerc.OptionsColumn.ReadOnly = true;
            this.colNegPerc.Visible = true;
            this.colNegPerc.VisibleIndex = 2;
            // 
            // colLabel
            // 
            this.colLabel.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colLabel.AppearanceCell.Options.UseForeColor = true;
            this.colLabel.Caption = "Label";
            this.colLabel.FieldName = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.OptionsColumn.AllowEdit = false;
            this.colLabel.OptionsColumn.ReadOnly = true;
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 3;
            // 
            // colPred
            // 
            this.colPred.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colPred.AppearanceCell.Options.UseForeColor = true;
            this.colPred.Caption = "Predicted Label";
            this.colPred.FieldName = "PredictedLabel";
            this.colPred.Name = "colPred";
            this.colPred.OptionsColumn.AllowEdit = false;
            this.colPred.OptionsColumn.ReadOnly = true;
            this.colPred.Visible = true;
            this.colPred.VisibleIndex = 4;
            // 
            // colContent
            // 
            this.colContent.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colContent.AppearanceCell.Options.UseForeColor = true;
            this.colContent.Caption = "Content";
            this.colContent.ColumnEdit = this.repositoryItemMemoEdit;
            this.colContent.FieldName = "Content";
            this.colContent.Name = "colContent";
            this.colContent.OptionsColumn.AllowEdit = false;
            this.colContent.OptionsColumn.ReadOnly = true;
            this.colContent.Visible = true;
            this.colContent.VisibleIndex = 5;
            // 
            // repositoryItemMemoEdit
            // 
            this.repositoryItemMemoEdit.Name = "repositoryItemMemoEdit";
            // 
            // gridMovieReview
            // 
            this.gridMovieReview.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.viewMovies;
            gridLevelNode1.RelationName = "FoldDetails";
            gridLevelNode2.LevelTemplate = this.viewTokens;
            gridLevelNode2.RelationName = "TokenLevel";
            this.gridMovieReview.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gridMovieReview.Location = new System.Drawing.Point(2, 20);
            this.gridMovieReview.MainView = this.viewFold;
            this.gridMovieReview.Name = "gridMovieReview";
            this.gridMovieReview.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar,
            this.repositoryItemRichTextEdit,
            this.repositoryItemMemoEdit,
            this.repositoryItemSearchLookUpEdit});
            this.gridMovieReview.Size = new System.Drawing.Size(1073, 515);
            this.gridMovieReview.TabIndex = 0;
            this.gridMovieReview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewFold,
            this.viewMovies,
            this.viewTokens});
            // 
            // viewFold
            // 
            this.viewFold.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFoldName,
            this.colProgress,
            this.colResult});
            this.viewFold.GridControl = this.gridMovieReview;
            this.viewFold.Name = "viewFold";
            this.viewFold.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewFold.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewFold.OptionsBehavior.AutoExpandAllGroups = true;
            this.viewFold.OptionsBehavior.AutoPopulateColumns = false;
            this.viewFold.OptionsView.ShowGroupPanel = false;
            this.viewFold.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.ViewFold_GetRelationName);
            // 
            // colFoldName
            // 
            this.colFoldName.Caption = "Fold";
            this.colFoldName.FieldName = "FoldName";
            this.colFoldName.Name = "colFoldName";
            this.colFoldName.OptionsColumn.AllowEdit = false;
            this.colFoldName.OptionsColumn.ReadOnly = true;
            this.colFoldName.Visible = true;
            this.colFoldName.VisibleIndex = 0;
            // 
            // colProgress
            // 
            this.colProgress.Caption = "Status";
            this.colProgress.ColumnEdit = this.repositoryItemProgressBar;
            this.colProgress.FieldName = "Status";
            this.colProgress.Name = "colProgress";
            this.colProgress.OptionsColumn.AllowEdit = false;
            this.colProgress.OptionsColumn.ReadOnly = true;
            this.colProgress.Visible = true;
            this.colProgress.VisibleIndex = 1;
            // 
            // repositoryItemProgressBar
            // 
            this.repositoryItemProgressBar.Name = "repositoryItemProgressBar";
            // 
            // colResult
            // 
            this.colResult.Caption = "Accuracy";
            this.colResult.FieldName = "Accuracy";
            this.colResult.Name = "colResult";
            this.colResult.OptionsColumn.AllowEdit = false;
            this.colResult.OptionsColumn.ReadOnly = true;
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 2;
            // 
            // repositoryItemRichTextEdit
            // 
            this.repositoryItemRichTextEdit.Name = "repositoryItemRichTextEdit";
            this.repositoryItemRichTextEdit.ShowCaretInReadOnly = false;
            // 
            // repositoryItemSearchLookUpEdit
            // 
            this.repositoryItemSearchLookUpEdit.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit.Name = "repositoryItemSearchLookUpEdit";
            this.repositoryItemSearchLookUpEdit.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1083, 628);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridMovieReview);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1077, 537);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Result";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblResult, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblAccuracy, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1077, 31);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(3, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(95, 13);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Average Accuracy";
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAccuracy.AutoSize = true;
            this.lblAccuracy.Location = new System.Drawing.Point(106, 9);
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(0, 13);
            this.lblAccuracy.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnClose, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 583);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1077, 42);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(541, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(533, 36);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.ImageOptions.Image")));
            this.btnStart.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(532, 36);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_Completed);
            // 
            // viewTokens
            // 
            this.viewTokens.ChildGridLevelName = "TokenLevel";
            this.viewTokens.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colToken,
            this.colTFIDF,
            this.colLogPos,
            this.colNegProb});
            this.viewTokens.GridControl = this.gridMovieReview;
            this.viewTokens.Name = "viewTokens";
            this.viewTokens.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewTokens.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewTokens.OptionsBehavior.AutoPopulateColumns = false;
            this.viewTokens.OptionsBehavior.ReadOnly = true;
            this.viewTokens.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.viewMovies_GetRelationName);
            // 
            // colToken
            // 
            this.colToken.Caption = "Token";
            this.colToken.FieldName = "Token";
            this.colToken.Name = "colToken";
            this.colToken.OptionsColumn.AllowEdit = false;
            this.colToken.OptionsColumn.ReadOnly = true;
            this.colToken.Visible = true;
            this.colToken.VisibleIndex = 0;
            // 
            // colTFIDF
            // 
            this.colTFIDF.Caption = "TfIdf";
            this.colTFIDF.FieldName = "Likelihood";
            this.colTFIDF.Name = "colTFIDF";
            this.colTFIDF.OptionsColumn.AllowEdit = false;
            this.colTFIDF.OptionsColumn.ReadOnly = true;
            this.colTFIDF.Visible = true;
            this.colTFIDF.VisibleIndex = 1;
            // 
            // colLogPos
            // 
            this.colLogPos.Caption = "Positive Log Probability";
            this.colLogPos.FieldName = "PosLogProbability";
            this.colLogPos.Name = "colLogPos";
            this.colLogPos.OptionsColumn.AllowEdit = false;
            this.colLogPos.OptionsColumn.ReadOnly = true;
            this.colLogPos.Visible = true;
            this.colLogPos.VisibleIndex = 2;
            // 
            // colNegProb
            // 
            this.colNegProb.Caption = "Negative Log Probability";
            this.colNegProb.FieldName = "NegLogProbability";
            this.colNegProb.Name = "colNegProb";
            this.colNegProb.OptionsColumn.AllowEdit = false;
            this.colNegProb.OptionsColumn.ReadOnly = true;
            this.colNegProb.Visible = true;
            this.colNegProb.VisibleIndex = 3;
            // 
            // MovieReviewClassification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MovieReviewClassification";
            this.Text = "MovieReviewClassification";
            ((System.ComponentModel.ISupportInitialize)(this.viewMovies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovieReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewFold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewTokens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridMovieReview;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private DevExpress.XtraGrid.Columns.GridColumn colFoldName;
        private DevExpress.XtraGrid.Columns.GridColumn colProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblAccuracy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPosPerc;
        private DevExpress.XtraGrid.Columns.GridColumn colNegPerc;
        private DevExpress.XtraGrid.Columns.GridColumn colLabel;
        private DevExpress.XtraGrid.Columns.GridColumn colPred;
        private DevExpress.XtraGrid.Columns.GridColumn colContent;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Views.Grid.GridView viewTokens;
        private DevExpress.XtraGrid.Views.Grid.GridView viewMovies;
        private DevExpress.XtraGrid.Views.Grid.GridView viewFold;
        private DevExpress.XtraGrid.Columns.GridColumn colToken;
        private DevExpress.XtraGrid.Columns.GridColumn colTFIDF;
        private DevExpress.XtraGrid.Columns.GridColumn colLogPos;
        private DevExpress.XtraGrid.Columns.GridColumn colNegProb;
    }
}