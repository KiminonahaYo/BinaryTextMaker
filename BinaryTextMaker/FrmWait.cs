using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace BinaryTextMaker
{
    public partial class FrmWait : Form
    {
        private long iMaxTask;
        private long iNowTask;
        private string strNowStatus;

        /// <summary>
        ///     最大処理量を取得または設定します。
        /// </summary>
        public long MaxTask
        {
            get { return this.iMaxTask; }
            set { this.iMaxTask = value; this.ShowProgress(); }
        }

        /// <summary>
        ///     現在の処理量を取得または設定します。
        /// </summary>
        public long NowTask
        {
            get { return this.iNowTask; }
            set { this.iNowTask = value; this.ShowProgress(); }
        }

        /// <summary>
        ///     現在の処理状態を取得または設定します。
        /// </summary>
        public string Status
        {
            get { return this.strNowStatus; }
            set { this.strNowStatus = value; this.ShowProgress(); }
        }

        /// <summary>
        ///     コンストラクタ
        /// </summary>
        public FrmWait()
        {
            InitializeComponent();
            this.iMaxTask = 0L;
            this.iNowTask = 0L;
            this.Status = "お待ちください…";
            this.ShowProgress();
        }

        /// <summary>
        ///     ×ボタンを無効にする
        /// </summary>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.Demand,
                Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;

                return cp;
            }
        }

        /// <summary>
        ///     プロパティの内容を画面に反映する
        /// </summary>
        private void ShowProgress()
        {
            int iMaxTaskShow;
            int iNowTaskShow;
            bool isOverFlow = false;
            checked
            {
                try
                {
                    iMaxTaskShow = (int)(this.iMaxTask);
                    iNowTaskShow = (int)(this.iNowTask);
                }
                catch (OverflowException)
                {
                    iMaxTaskShow = (int)(this.iMaxTask / 1000000);
                    iNowTaskShow = (int)(this.iNowTask / 1000000);
                    isOverFlow = true;
                }
            }
            this.progressBar1.Maximum = iMaxTaskShow;
            this.progressBar1.Value = iNowTaskShow;
            this.lblTitle.Text = this.strNowStatus;

            decimal dcParcent;
            if (iNowTask != 0)
                dcParcent = (decimal)iNowTask / (decimal)iMaxTask * 100m;
            else
                dcParcent = (decimal)0;

            if(!isOverFlow)
                this.lblStatus.Text = string.Format("{0:0.00}％完了 {1}byte／{2}byte", dcParcent, iNowTaskShow, iMaxTaskShow);
            else
                this.lblStatus.Text = string.Format("{0:0.00}％完了 {1}MB／{2}MB", dcParcent, iNowTaskShow, iMaxTaskShow);
        }
    }
}
