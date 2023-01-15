using System.Windows.Forms;

namespace FileEncryptor
{
    partial class FEForm : Form
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
            this.filesBox = new System.Windows.Forms.ListBox();
            this.buttonAction = new System.Windows.Forms.Button();
            this.textKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioEncrypt = new System.Windows.Forms.RadioButton();
            this.radioDecrypt = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.confirmKeyLbl = new System.Windows.Forms.Label();
            this.textKeyConfirm = new System.Windows.Forms.TextBox();
            this.errorKeysLbl = new System.Windows.Forms.Label();
            this.textExt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filesBox
            // 
            this.filesBox.FormattingEnabled = true;
            this.filesBox.Location = new System.Drawing.Point(12, 120);
            this.filesBox.Name = "filesBox";
            this.filesBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.filesBox.Size = new System.Drawing.Size(185, 160);
            this.filesBox.TabIndex = 0;
            // 
            // buttonAction
            // 
            this.buttonAction.Location = new System.Drawing.Point(12, 296);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(478, 23);
            this.buttonAction.TabIndex = 1;
            this.buttonAction.Text = "Decrypt Select Files";
            this.buttonAction.UseVisualStyleBackColor = true;
            this.buttonAction.Click += new System.EventHandler(this.buttonAction_Click);
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(291, 25);
            this.textKey.Name = "textKey";
            this.textKey.PasswordChar = '*';
            this.textKey.Size = new System.Drawing.Size(189, 20);
            this.textKey.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Found Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key";
            // 
            // radioEncrypt
            // 
            this.radioEncrypt.AutoSize = true;
            this.radioEncrypt.Location = new System.Drawing.Point(114, 13);
            this.radioEncrypt.Name = "radioEncrypt";
            this.radioEncrypt.Size = new System.Drawing.Size(61, 17);
            this.radioEncrypt.TabIndex = 7;
            this.radioEncrypt.Text = "Encrypt";
            this.radioEncrypt.UseVisualStyleBackColor = true;
            this.radioEncrypt.CheckedChanged += new System.EventHandler(this.radioEncrypt_CheckedChanged);
            // 
            // radioDecrypt
            // 
            this.radioDecrypt.AutoSize = true;
            this.radioDecrypt.Checked = true;
            this.radioDecrypt.Location = new System.Drawing.Point(3, 13);
            this.radioDecrypt.Name = "radioDecrypt";
            this.radioDecrypt.Size = new System.Drawing.Size(62, 17);
            this.radioDecrypt.TabIndex = 8;
            this.radioDecrypt.TabStop = true;
            this.radioDecrypt.Text = "Decrypt";
            this.radioDecrypt.UseVisualStyleBackColor = true;
            this.radioDecrypt.CheckedChanged += new System.EventHandler(this.radioDecrypt_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioEncrypt);
            this.panel1.Controls.Add(this.radioDecrypt);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 45);
            this.panel1.TabIndex = 9;
            // 
            // textStatus
            // 
            this.textStatus.Location = new System.Drawing.Point(218, 120);
            this.textStatus.Multiline = true;
            this.textStatus.Name = "textStatus";
            this.textStatus.ReadOnly = true;
            this.textStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textStatus.Size = new System.Drawing.Size(262, 157);
            this.textStatus.TabIndex = 10;
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "FileDialog";
            this.fileDialog.Multiselect = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 71);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(126, 99);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.checkSelectAll.TabIndex = 16;
            this.checkSelectAll.Text = "Select All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.checkSelectAll_CheckedChanged);
            // 
            // confirmKeyLbl
            // 
            this.confirmKeyLbl.AutoSize = true;
            this.confirmKeyLbl.Location = new System.Drawing.Point(215, 58);
            this.confirmKeyLbl.Name = "confirmKeyLbl";
            this.confirmKeyLbl.Size = new System.Drawing.Size(63, 13);
            this.confirmKeyLbl.TabIndex = 18;
            this.confirmKeyLbl.Text = "Confirm Key";
            // 
            // textKeyConfirm
            // 
            this.textKeyConfirm.Location = new System.Drawing.Point(291, 55);
            this.textKeyConfirm.Name = "textKeyConfirm";
            this.textKeyConfirm.PasswordChar = '*';
            this.textKeyConfirm.Size = new System.Drawing.Size(189, 20);
            this.textKeyConfirm.TabIndex = 1;
            // 
            // errorKeysLbl
            // 
            this.errorKeysLbl.AutoSize = true;
            this.errorKeysLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorKeysLbl.Location = new System.Drawing.Point(300, 280);
            this.errorKeysLbl.Name = "errorKeysLbl";
            this.errorKeysLbl.Size = new System.Drawing.Size(0, 13);
            this.errorKeysLbl.TabIndex = 3;
            // 
            // textExt
            // 
            this.textExt.Location = new System.Drawing.Point(353, 88);
            this.textExt.Name = "textExt";
            this.textExt.Size = new System.Drawing.Size(127, 20);
            this.textExt.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Output Extension(Ex: mp4)";
            // 
            // VFMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 328);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textExt);
            this.Controls.Add(this.confirmKeyLbl);
            this.Controls.Add(this.textKeyConfirm);
            this.Controls.Add(this.checkSelectAll);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorKeysLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textKey);
            this.Controls.Add(this.buttonAction);
            this.Controls.Add(this.filesBox);
            this.Name = "VFMForm";
            this.Text = "Video File Manager";
            this.Load += new System.EventHandler(this.VFMForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox filesBox;
        private System.Windows.Forms.Button buttonAction;
        private System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioEncrypt;
        private System.Windows.Forms.RadioButton radioDecrypt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.Label confirmKeyLbl;
        private System.Windows.Forms.TextBox textKeyConfirm;
        private System.Windows.Forms.Label errorKeysLbl;
        private System.Windows.Forms.TextBox textExt;
        private System.Windows.Forms.Label label3;
    }
}

