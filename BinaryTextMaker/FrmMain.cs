using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BinaryTextMaker
{
    public partial class FrmMain : Form
    {
        /// <summary>
        ///     変換タイプ
        /// </summary>
        private enum ConvertType
        {
            ToText,
            ToBinary
        }

        /// <summary>
        ///     変換情報クラス
        /// </summary>
        private class ConvertInfo
        {
            /// <summary>
            ///     変換タイプ
            /// </summary>
            public ConvertType ConvertType { get; set; }

            /// <summary>
            ///     読み込みファイル名
            /// </summary>
            public string LoadFileName { get; set; }

            /// <summary>
            ///     書き込みファイル名
            /// </summary>
            public string SaveFileName { get; set; }
        }

        /// <summary>
        ///     ステータス情報構造体
        /// </summary>
        private struct StatusInfo
        {
            /// <summary>
            ///     最大処理量
            /// </summary>
            public long MaxTask { get; set; }

            /// <summary>
            ///     現在処理量
            /// </summary>
            public long NowTask { get; set; }

            /// <summary>
            ///     ステータス文字列
            /// </summary>
            public string Status { get; set; }
        }

        private FrmWait frmWait;

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     バイナリファイルを選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReferenceBinary_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtBinaryFileName.Text = this.openFileDialog1.FileName;
            }
        }

        /// <summary>
        ///     バイナリデータをテキストファイルにしたものを選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReferenceText_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                this.txtTextFileName.Text = this.openFileDialog2.FileName;
            }
        }

        /// <summary>
        ///     バイナリファイル→テキストファイルに変換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertBinaryToText_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.txtBinaryFileName.Text))
            {
                MessageBox.Show("指定されたバイナリファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string strSaveFileName = this.saveFileDialog1.FileName;

            this.frmWait = new FrmWait();
            this.backgroundWorker1.RunWorkerAsync(new ConvertInfo() { ConvertType = ConvertType.ToText, LoadFileName = this.txtBinaryFileName.Text, SaveFileName = strSaveFileName });
            this.frmWait.ShowDialog();
            if (this.Error != null)
            {
                MessageBox.Show("変換処理に失敗しました。\n\n" + this.Error.GetType().ToString() + " - " + this.Error.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.saveFileDialog1.FileName = "";
        }

        /// <summary>
        ///     テキストファイル→バイナリファイルに変換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertTextToBinary_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.txtTextFileName.Text))
            {
                MessageBox.Show("指定されたテキストファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (new FileInfo(this.txtTextFileName.Text).Extension != ".txt")
            {
                MessageBox.Show("指定されたテキストファイルの拡張子が正しくありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.saveFileDialog2.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string strSaveFileName = this.saveFileDialog2.FileName;

            this.frmWait = new FrmWait();
            this.backgroundWorker1.RunWorkerAsync(new ConvertInfo() { ConvertType = ConvertType.ToBinary, LoadFileName = this.txtTextFileName.Text, SaveFileName = strSaveFileName });
            this.frmWait.ShowDialog();
            if (this.Error != null)
            {
                MessageBox.Show("変換処理に失敗しました。\n\n" + this.Error.GetType().ToString() + " - " + this.Error.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.saveFileDialog2.FileName = "";
        }

        #region 非同期操作
        private Exception Error { get; set; }

        /// <summary>
        ///     非同期操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ConvertInfo convertInfo = e.Argument as ConvertInfo;
            BackgroundWorker bgw = sender as BackgroundWorker;

            try
            {
                switch (convertInfo.ConvertType)
                {
                    case ConvertType.ToText:
                        this.ConvertBinaryToText(bgw, e, convertInfo);
                        break;
                    case ConvertType.ToBinary:
                        this.ConvertTextToBinary(bgw, e, convertInfo);
                        break;
                }
                e.Result = null;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        ///     バイナリファイルからテキストファイルに変換する。
        /// </summary>
        /// <param name="bgw"></param>
        /// <param name="e"></param>
        private void ConvertBinaryToText(BackgroundWorker bgw, DoWorkEventArgs e, ConvertInfo convertInfo)
        {
            StatusInfo statusInfo = new StatusInfo() { Status = "バイナリファイルをテキストファイルに変換しています…", MaxTask = 0, NowTask = 0 };

            using (FileStream fs = new FileStream(convertInfo.LoadFileName, FileMode.Open))
            {
                using (StreamWriter sw = new StreamWriter(convertInfo.SaveFileName))
                {
                    string strExtension = new FileInfo(convertInfo.LoadFileName).Extension;
                    sw.Write(strExtension);
                    sw.Write("/");
                    statusInfo.MaxTask = fs.Length;
                    while(this.SeekBinaryToText(fs, sw))
                    {
                        statusInfo.NowTask++;
                        if (statusInfo.NowTask >= 1000)
                            if (statusInfo.NowTask % (statusInfo.MaxTask / 100) == 0)
                                bgw.ReportProgress(0, statusInfo);
                    }
                }
            }
        }

        /// <summary>
        ///     テキストファイルからバイナリファイルに変換する。
        /// </summary>
        /// <param name="bgw"></param>
        /// <param name="e"></param>
        private void ConvertTextToBinary(BackgroundWorker bgw, DoWorkEventArgs e, ConvertInfo convertInfo)
        {
            StatusInfo statusInfo = new StatusInfo() { Status = "テキストファイルをバイナリファイルに変換しています…", MaxTask = 0, NowTask = 0 };

            using (FileStream fsRead = new FileStream(convertInfo.LoadFileName, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fsRead))
                {
                    //拡張子を取り出す。
                    string strExtension = "";
                    char c;
                    while (true)
                    {
                        c = (char)fsRead.ReadByte();
                        if (c == '/') break;
                        strExtension += c.ToString();
                    }
                    string strSaveFileName = convertInfo.SaveFileName;
                    strSaveFileName = Path.ChangeExtension(strSaveFileName, strExtension);

                    //バイナリデータを読み込む。
                    using (FileStream fsWrite = new FileStream(strSaveFileName, FileMode.Create))
                    {
                        //1byteのバイナリは2byteの文字列になるため、2で割る
                        statusInfo.MaxTask = fsRead.Length / 2;
                        while (this.SeekTextToBinary(sr, fsWrite))
                        {
                            statusInfo.NowTask++;
                            if (statusInfo.NowTask >= 1000)
                                if (statusInfo.NowTask % (statusInfo.MaxTask / 100) == 0)
                                    bgw.ReportProgress(0, statusInfo);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     バイナリファイルからテキストファイルに書き込む（1byte）
        /// </summary>
        /// <param name="fsBinary"></param>
        /// <param name="swText"></param>
        private bool SeekBinaryToText(FileStream fsBinary, StreamWriter swText)
        {
            int iBinary = fsBinary.ReadByte();
            if (iBinary == -1) return false;
            byte binary = (byte)iBinary;
            string str = this.ConvertByteToString(binary);
            swText.Write(str);
            return true;
        }

        /// <summary>
        ///     テキストファイルからバイナリファイルに書き込む（1byte）
        /// </summary>
        /// <param name="srText"></param>
        /// <param name="fsBinary"></param>
        private bool SeekTextToBinary(StreamReader srText, FileStream fsBinary)
        {
            string str = "";
            for (int iLoop1 = 0; iLoop1 < 2; iLoop1++)
            {
                if (srText.EndOfStream) break;
                str += ((char)srText.Read()).ToString();
            }

            if (str == "") return false;

            byte binary = this.ConvertStringToByte(str);
            fsBinary.WriteByte(binary);

            return true;
        }

        /// <summary>
        ///     string->byte
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>byte</returns>
        private byte ConvertStringToByte(string text)
        {
            return byte.Parse(text, System.Globalization.NumberStyles.HexNumber);
        }

        /// <summary>
        ///     byte->string
        /// </summary>
        /// <param name="binary">byte</param>
        /// <returns>string</returns>
        private string ConvertByteToString(byte binary)
        {
            return binary.ToString("X2");
        }

        /// <summary>
        ///     進行状況を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusInfo statusInfo = (StatusInfo)e.UserState;

            this.frmWait.MaxTask = statusInfo.MaxTask;
            this.frmWait.NowTask = statusInfo.NowTask;
            this.frmWait.Status = statusInfo.Status;
            this.frmWait.Text = statusInfo.Status;
        }

        /// <summary>
        ///     非同期操作が完了したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.frmWait != null)
            {
                this.frmWait.Close();
            }
            this.Error = e.Result as Exception;
        }
        #endregion
    }
}
