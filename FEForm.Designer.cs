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
        private void DisableClose()
        {
            this.ControlBox = false;
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
            this.label2 = new System.Windows.Forms.Label();
            this.radioEncrypt = new System.Windows.Forms.RadioButton();
            this.radioDecrypt = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.confirmKeyLbl = new System.Windows.Forms.Label();
            this.textKeyConfirm = new System.Windows.Forms.TextBox();
            this.errorKeysLbl = new System.Windows.Forms.Label();
            this.textExt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxDeleteAfter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.outputFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputFolderButton = new System.Windows.Forms.Button();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filesBox
            // 
            this.filesBox.FormattingEnabled = true;
            this.filesBox.Location = new System.Drawing.Point(12, 91);
            this.filesBox.Name = "filesBox";
            this.filesBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.filesBox.Size = new System.Drawing.Size(185, 160);
            this.filesBox.TabIndex = 0;
            // 
            // buttonAction
            // 
            this.buttonAction.Location = new System.Drawing.Point(12, 313);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(185, 23);
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
            this.btnBrowse.Location = new System.Drawing.Point(12, 63);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "Select files";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Delete Files After";
            // 
            // txtBoxDeleteAfter
            // 
            this.txtBoxDeleteAfter.Location = new System.Drawing.Point(393, 316);
            this.txtBoxDeleteAfter.Name = "txtBoxDeleteAfter";
            this.txtBoxDeleteAfter.Size = new System.Drawing.Size(37, 20);
            this.txtBoxDeleteAfter.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Minutes";
            // 
            // outputFolderButton
            // 
            this.outputFolderButton.Location = new System.Drawing.Point(12, 254);
            this.outputFolderButton.Name = "outputFolderButton";
            this.outputFolderButton.Size = new System.Drawing.Size(97, 23);
            this.outputFolderButton.TabIndex = 24;
            this.outputFolderButton.Text = "Select output folder";
            this.outputFolderButton.UseVisualStyleBackColor = true;
            this.outputFolderButton.Click += new System.EventHandler(this.outputFolderButton_Click);
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(14, 280);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(0, 13);
            this.lblOutputFolder.TabIndex = 25;
            // 
            // FEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 344);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.outputFolderButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxDeleteAfter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textExt);
            this.Controls.Add(this.confirmKeyLbl);
            this.Controls.Add(this.textKeyConfirm);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorKeysLbl);
            this.Controls.Add(this.textKey);
            this.Controls.Add(this.buttonAction);
            this.Controls.Add(this.filesBox);
            this.Name = "FEForm";
            this.Text = "File Encryptor and Decryptor";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioEncrypt;
        private System.Windows.Forms.RadioButton radioDecrypt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label confirmKeyLbl;
        private System.Windows.Forms.TextBox textKeyConfirm;
        private System.Windows.Forms.Label errorKeysLbl;
        private System.Windows.Forms.TextBox textExt;
        private System.Windows.Forms.Label label3;
        private Label label4;
        private TextBox txtBoxDeleteAfter;
        private Label label5;
        private FolderBrowserDialog outputFolderDialog;
        private Button outputFolderButton;
        private Label lblOutputFolder;
    }
}

