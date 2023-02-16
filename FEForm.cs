using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileEncryptor
{
    public partial class FEForm:Form
    {
        string folder;
        string outputFolder;
        string outputExtension;
        Thread thread;
        List<string> files=new List<string>();
        public FEForm()
        {
            InitializeComponent();
        }

        private void radioEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            EncryptChecked();
        }

        private void radioDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            DecryptChecked();
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {                     
            LoadFiles();
            if (radioDecrypt.Checked)
            {
                if (!AllDecIsGood())
                    return;
                DecryptFiles();
                StartDeleteTimer();
            }
            else
            {
                if (!AllEncIsGood())
                    return;
                EncryptFiles();
            }      
        }

        private bool AllDecIsGood()
        {
            var message="";
            if (string.IsNullOrEmpty(textKey.Text))
                message = "Please enter the key!";
            if (string.IsNullOrEmpty(outputFolder))
                message += Environment.NewLine + "Output folder not selected!";
            if (filesBox.SelectedItems.Count==0)
                message += Environment.NewLine + "No files selected to decrypt!";
            if (message.Length > 0)
            {
                MessageBox.Show(message);
                return false;
            }
            return true;
        }
        private bool AllEncIsGood()
        {
            var message = "";
            if (string.IsNullOrEmpty(textKey.Text) || textKey.Text != textKeyConfirm.Text)
                message = "Keys are empty or not matched!";
            if (string.IsNullOrEmpty(outputFolder))
                message += Environment.NewLine + "Output folder not selected!";
            if (filesBox.SelectedItems.Count == 0)
                message += Environment.NewLine + "No files selected to encrypt!";

            if (message.Length > 0)
            {
                MessageBox.Show(message);
                return false;
            }
            return true;
        }

        private void StartDeleteTimer()
        {
            if (!string.IsNullOrEmpty(txtBoxDeleteAfter.Text))
            {
                var waitTime = TimeSpan.FromMinutes(double.Parse(txtBoxDeleteAfter.Text));
                this.DisableClose();
                new Thread(()=>{                
                    Thread.Sleep(waitTime);
                    //start deleting all files in decrypted folder
                    Directory.Delete(folder,true);

            }).Start();
                
            }
        }

        private void LoadFiles()
        {
            foreach (var item in filesBox.Items)
            {
                var filePath = filesBox.GetItemText(item);
                files.Add(filePath);                
            }
            if (textExt.Text.Trim() == string.Empty)
            {
                if (radioEncrypt.Checked)
                {
                    textExt.Text = "dll";
                }
                else
                {
                    textExt.Text = "mp4";
                }
            }
            outputExtension = "." + textExt.Text;
        }

        private void Clear()
        {
            files.Clear();
            textExt.Text = string.Empty;
            outputExtension=string.Empty;
            textStatus.ForeColor = Color.Black;
            textKey.Text = string.Empty;
            textKeyConfirm.Text = string.Empty;
            textStatus.Text = string.Empty;
            errorKeysLbl.Text = string.Empty;
            textStatus.Text = string.Empty;
            filesBox.Items.Clear();
        }

        private void EncryptChecked()
        {
            if (radioEncrypt.Checked)
            {
                confirmKeyLbl.Show();
                textKeyConfirm.Show();
                buttonAction.Text = "Encrypt Selected Files";

            }
        }

        private void DecryptChecked()
        {
            if (radioDecrypt.Checked)
            {
                confirmKeyLbl.Hide();
                textKeyConfirm.Hide();
                buttonAction.Text = "Decrypt Selected Files";                
            }
        }

        private void EncryptFiles()
        {
            var key = textKey.Text;
            thread = new Thread(() => {
                var passed = true;
                foreach (var filePath in files)
                {
                    var fileInfo = new FileInfo(filePath);
                    var fileName = fileInfo.Name.Replace(fileInfo.Extension, outputExtension);
                    try
                    {
                        Encryptor.EncryptFile(filePath, Path.Combine(outputFolder, fileName), key);
                        ReportThreadStatus("pass", filePath);
                    }
                    catch (Exception exp)
                    {
                        ReportThreadStatus("fail", exp.GetBaseException().Message + "\n File:" + filePath);
                        passed = false;
                    }
                }
                if(passed)
                    ReportThreadStatus("finish", "All files encrypted successfull");
                else
                    ReportThreadStatus("finish-fail", "Some files failed.");
            });

            thread.Start();            
           
        }

        private void ReportThreadStatus(string status,string message)
        {
            var list=new List<string>();

            if (textStatus.InvokeRequired)
            {
                Action safeWrite = delegate
                {
                    list.AddRange(textStatus.Lines);
                    list.Add(message);
                    if (status=="pass")
                    {                       
                        textStatus.Lines = list.ToArray();
                    }
                    else if(status=="fail")
                    {
                        textStatus.Lines = list.ToArray();
                        textStatus.ForeColor = Color.Red;
                    }
                    else if (status == "finish")
                    {
                        textStatus.Text = message;
                        textStatus.ForeColor = Color.Green;
                    }
                    else if(status== "finish-fail")
                    {
                        list.Add(message);
                        textStatus.Lines = list.ToArray();
                        textStatus.ForeColor = Color.Red;
                    }
                };
                textStatus.Invoke(safeWrite);
            }   
        }
        private void DecryptFiles()
        {
            var key = textKey.Text;
            thread = new Thread(() => {
                var passed = true;
                foreach (var filePath in files)
                {
                    var fileInfo = new FileInfo(filePath);
                    var fileName = fileInfo.Name.Replace(fileInfo.Extension, outputExtension);
                    try
                    {
                        Encryptor.DecryptFile(filePath, Path.Combine(outputFolder, fileName), key);
                        ReportThreadStatus("pass", filePath);
                    }
                    catch (Exception exp)
                    {
                        ReportThreadStatus("fail", exp.GetBaseException().Message + "\n File:" + filePath);
                        passed = false;
                    }
                }
                if (passed)
                    ReportThreadStatus("finish", "All files decrypted successfull");
            });

            thread.Start();
        }

        private void VFMForm_Load(object sender, EventArgs e)
        {
            DecryptChecked();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filesBox.Items.Clear();
                files.Clear();
                LoadFilesIntoListBox(fileDialog.FileNames);                
            }
        }

        private void outputFolderButton_Click(object sender, EventArgs e)
        {
            if (outputFolderDialog.ShowDialog() == DialogResult.OK)
            {
                outputFolder = outputFolderDialog.SelectedPath;
                lblOutputFolder.Text = outputFolder;
            }
        }

        private void filesBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadFilesIntoListBox(files);
        }

        private void filesBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void LoadFilesIntoListBox(string[] selectedFiles)
        {
            files.Clear();
            foreach (var file in selectedFiles)
            {
                filesBox.Items.Add(file);
            }
            folder = new FileInfo(fileDialog.FileNames.FirstOrDefault()).DirectoryName;

            CalculateFilesSize();
        }

        private void filesBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < filesBox.SelectedItems.Count; i++)
                {
                    filesBox.Items.Remove(filesBox.SelectedItems[i]);
                    i--;
                    CalculateFilesSize();
                }
            }
        }

        private void CalculateFilesSize()
        {
            decimal filesSize = 0;           
            foreach (var item in filesBox.Items)
            {
                filesSize += new FileInfo(filesBox.GetItemText(item)).Length / (1024 * 1024 * 1024m);
            }

            lblFilesSize.Text = String.Format("{0:0.##} GB", filesSize);
        }
    }
}
