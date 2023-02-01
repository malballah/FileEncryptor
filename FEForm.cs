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
            buttonAction.Enabled = false;            
            LoadFiles();
            if (radioDecrypt.Checked)
            {
                DecryptFiles();
                StartDeleteTimer();
            }
            else
            {
                EncryptFiles();
            }      
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
            foreach (var item in filesBox.SelectedItems)
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
            buttonAction.Enabled = true;
            checkSelectAll.Checked = false;
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
            if (!KeysMatched())
                return;
            CreateOutputDirectory("_dlls");
            var key = textKey.Text;
            thread = new Thread(() => {
                var passed = true;
                foreach (var filePath in files)
                {
                    var fileInfo = new FileInfo(filePath);
                    var fileName = fileInfo.Name.Replace(fileInfo.Extension, outputExtension);
                    try
                    {
                        Encryptor.EncryptFile(filePath, Path.Combine(folder, fileName), key);
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
                        buttonAction.Enabled = true;
                    }
                    else if(status== "finish-fail")
                    {
                        list.Add(message);
                        textStatus.Lines = list.ToArray();
                        textStatus.ForeColor = Color.Red;
                        buttonAction.Enabled = true;
                    }
                };
                textStatus.Invoke(safeWrite);
            }   
        }
        private void DecryptFiles()
        {
            CreateOutputDirectory("_vis");
            var key = textKey.Text;
            thread = new Thread(() => {
                var passed = true;
                foreach (var filePath in files)
                {
                    var fileInfo = new FileInfo(filePath);
                    var fileName = fileInfo.Name.Replace(fileInfo.Extension, outputExtension);
                    try
                    {
                        Encryptor.DecryptFile(filePath, Path.Combine(folder, fileName), key);
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

        private bool KeysMatched()
        {
            if (textKey.Text == textKeyConfirm.Text)
            {
                errorKeysLbl.Text = string.Empty;
                return true;
            }
            else
            {
                errorKeysLbl.Text = "Keys not matched";
                return false;
            }
        }

        private void CreateOutputDirectory(string name)
        {
            folder = Path.Combine(folder, name);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
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
                foreach (var file in fileDialog.FileNames)
                {
                    filesBox.Items.Add(file);
                }
                folder = new FileInfo(fileDialog.FileNames.FirstOrDefault()).DirectoryName;
            }
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            buttonAction.Enabled = true;
            if (checkSelectAll.Checked)
            {
                for (int i = 0; i < filesBox.Items.Count; i++)
                {
                    filesBox.SetSelected(i,true);
                }               
            }
            else
            {
                for (int i = 0; i < filesBox.Items.Count; i++)
                {
                    filesBox.SetSelected(i, false);
                }
            }
        }

    }
}
