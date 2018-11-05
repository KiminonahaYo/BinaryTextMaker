namespace BinaryTextMaker
{
    partial class FrmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtBinaryFileName = new System.Windows.Forms.TextBox();
            this.txtTextFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvertTextToBinary = new System.Windows.Forms.Button();
            this.btnConvertBinaryToText = new System.Windows.Forms.Button();
            this.btnReferenceBinary = new System.Windows.Forms.Button();
            this.btnReferenceText = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "バイナリファイル名";
            // 
            // txtBinaryFileName
            // 
            this.txtBinaryFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBinaryFileName.Location = new System.Drawing.Point(117, 10);
            this.txtBinaryFileName.Name = "txtBinaryFileName";
            this.txtBinaryFileName.Size = new System.Drawing.Size(386, 19);
            this.txtBinaryFileName.TabIndex = 1;
            // 
            // txtTextFileName
            // 
            this.txtTextFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextFileName.Location = new System.Drawing.Point(117, 94);
            this.txtTextFileName.Name = "txtTextFileName";
            this.txtTextFileName.Size = new System.Drawing.Size(386, 19);
            this.txtTextFileName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "テキストファイル名";
            // 
            // btnConvertTextToBinary
            // 
            this.btnConvertTextToBinary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertTextToBinary.Location = new System.Drawing.Point(394, 119);
            this.btnConvertTextToBinary.Name = "btnConvertTextToBinary";
            this.btnConvertTextToBinary.Size = new System.Drawing.Size(109, 23);
            this.btnConvertTextToBinary.TabIndex = 4;
            this.btnConvertTextToBinary.Text = "バイナリに変換";
            this.btnConvertTextToBinary.UseVisualStyleBackColor = true;
            this.btnConvertTextToBinary.Click += new System.EventHandler(this.btnConvertTextToBinary_Click);
            // 
            // btnConvertBinaryToText
            // 
            this.btnConvertBinaryToText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertBinaryToText.Location = new System.Drawing.Point(394, 35);
            this.btnConvertBinaryToText.Name = "btnConvertBinaryToText";
            this.btnConvertBinaryToText.Size = new System.Drawing.Size(109, 23);
            this.btnConvertBinaryToText.TabIndex = 5;
            this.btnConvertBinaryToText.Text = "テキストに変換";
            this.btnConvertBinaryToText.UseVisualStyleBackColor = true;
            this.btnConvertBinaryToText.Click += new System.EventHandler(this.btnConvertBinaryToText_Click);
            // 
            // btnReferenceBinary
            // 
            this.btnReferenceBinary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReferenceBinary.Location = new System.Drawing.Point(312, 35);
            this.btnReferenceBinary.Name = "btnReferenceBinary";
            this.btnReferenceBinary.Size = new System.Drawing.Size(76, 23);
            this.btnReferenceBinary.TabIndex = 6;
            this.btnReferenceBinary.Text = "参照";
            this.btnReferenceBinary.UseVisualStyleBackColor = true;
            this.btnReferenceBinary.Click += new System.EventHandler(this.btnReferenceBinary_Click);
            // 
            // btnReferenceText
            // 
            this.btnReferenceText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReferenceText.Location = new System.Drawing.Point(312, 119);
            this.btnReferenceText.Name = "btnReferenceText";
            this.btnReferenceText.Size = new System.Drawing.Size(76, 23);
            this.btnReferenceText.TabIndex = 7;
            this.btnReferenceText.Text = "参照";
            this.btnReferenceText.UseVisualStyleBackColor = true;
            this.btnReferenceText.Click += new System.EventHandler(this.btnReferenceText_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "バイナリ ファイル|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "テキストファイル（16進数）|*.txt";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "テキストファイル（16進数文字列）|*.txt";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "バイナリ ファイル|*.*";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 153);
            this.Controls.Add(this.btnReferenceText);
            this.Controls.Add(this.btnReferenceBinary);
            this.Controls.Add(this.btnConvertBinaryToText);
            this.Controls.Add(this.btnConvertTextToBinary);
            this.Controls.Add(this.txtTextFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBinaryFileName);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "バイナリファイルとテキストファイルの変換";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBinaryFileName;
        private System.Windows.Forms.TextBox txtTextFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvertTextToBinary;
        private System.Windows.Forms.Button btnConvertBinaryToText;
        private System.Windows.Forms.Button btnReferenceBinary;
        private System.Windows.Forms.Button btnReferenceText;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}

