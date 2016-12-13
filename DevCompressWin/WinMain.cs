using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevCompress;


namespace DevCompressWin
{
    public partial class WinMain : Form
    {
        private DevCompressFileMake make;
        private DevCompressFileRead read;
        private mySorter sorter;
        public WinMain(string[] args)
        {
            InitializeComponent();
            sorter = new mySorter();
            this.listView1.ListViewItemSorter = sorter;
            sorter.SortOrder = SortOrder.Ascending;

            if(args.Length>0)
            {
                try
                {
                    read = new DevCompressFileRead(args[0]);
                    ReadHand();
                    ShowRead();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                make = new DevCompressFileMake(saveFileDialog1.FileName);
                MakeHand();
                make.MakeProgress += Make_MakeProgress;
            }
        }

        private void 新建ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(make!=null)
                if(this.folderBrowserDialog1.ShowDialog()==DialogResult.OK)
                {
                    make.AddDirectory(folderBrowserDialog1.SelectedPath);
                    ShowMake();
                }
        }

        private void ReadHand()
        {
            this.listView1.Items.Clear();
            var columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            var columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            var columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            var columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            var columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            var columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Path";
            columnHeader1.Width = 266;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "FileName";
            columnHeader2.Width = 237;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Size";
            columnHeader3.Width = 115;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "IsCompress";
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "CompressSize";
            columnHeader5.Width = 120;
            // 
            // columnHeader0
            // 
            columnHeader0.Text = "Index";

            this.listView1.Columns.Clear();
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader0,
            columnHeader1,
            columnHeader2,
            columnHeader3,
            columnHeader4,
            columnHeader5});

            this.contextMenuStrip1.Items.Clear();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出文件ToolStripMenuItem1,
            this.全部导出到文件夹ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 48);

            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
        }


        private void MakeHand()
        {
            this.listView1.Items.Clear();
            var columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            var columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            var columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            var columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            // 
            // columnHeader1
            // 
            columnHeader1.Text = "PATH";
            columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "FileName";
            columnHeader2.Width = 169;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Size";
            columnHeader3.Width = 112;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "ReadFullName";
            columnHeader4.Width = 480;

            this.listView1.Columns.Clear();
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2,
            columnHeader3,
            columnHeader4});

            this.contextMenuStrip1.Items.Clear();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入文件夹ToolStripMenuItem,
            this.导入文件ToolStripMenuItem1,
            this.删除ToolStripMenuItem1,
            this.编译ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 92);

            this.listView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void ShowMake()
        {

            this.listView1.ListViewItemSorter = null;
            this.listView1.Items.Clear();

            foreach (var file in make.WFileList)
            {

                ListViewItem Item = new ListViewItem(file.Path);
                Item.Tag = file;
                Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, file.FileName));
                Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, file.Size.ToString()));
                Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, file.fileInfo.FullName));

                this.listView1.Items.Add(Item);
            }

            this.listView1.ListViewItemSorter = sorter;
        }

        private void 导入文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (make != null)
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SetPath tmp = new SetPath(openFileDialog1.FileName);

                    tmp.ShowDialog();

                    if (tmp.IsOK)
                    {
                        string filename = openFileDialog1.FileName;
                        string path = tmp.Path;

                        make.AddFile(filename, path);

                        ShowMake();
                    }
                }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.listView1.SelectedItems.Count>0)
            {
                foreach (ListViewItem item in this.listView1.SelectedItems)
                {
                    var x = item.Tag as WDevFile;
                    if(x!=null)
                        make.WFileList.Remove(x);
                }

                ShowMake();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (make != null)
                Task.Run(delegate
                {
                    try
                    {
                        make.Make();

                        MessageBox.Show("完成");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                });
        }

        private void Make_MakeProgress(string filename, int index, int lengt)
        {
            this.BeginInvoke(new EventHandler((a, b) =>
                {
                    this.progressBar1.Maximum = lengt;
                    this.progressBar1.Value = index;
                    this.label1.Text = filename;

                }));
        }

        private void 打开ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(openFileDialog2.ShowDialog()==DialogResult.OK)
            {

                FileStream stream = new FileStream(openFileDialog2.FileName, FileMode.Open, FileAccess.Read);

                read = new DevCompressFileRead(stream);
                ReadHand();
                ShowRead();
            }
        }

        private void ShowRead()
        {

            this.listView1.ListViewItemSorter = null;
            this.listView1.Items.Clear();

            foreach (var file in read)
            {

                ListViewItem Item = new ListViewItem(file.Index.ToString());
                Item.Tag = file;
                Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, file.Path));
                Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, file.FileName));
                Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, file.Size.ToString()));
                Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, file.IsCompress?"是":"否"));
                Item.SubItems.Add(new ListViewItem.ListViewSubItem(Item, file.CompressSize.ToString()));

                this.listView1.Items.Add(Item);
            }

            this.listView1.ListViewItemSorter = sorter;

        }

        private void 导出文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.read!=null)
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    var file = this.listView1.SelectedItems[0].Tag as DevFile;

                    if(file!=null)
                    {
                        saveFileDialog2.FileName = file.FileName;

                        if(saveFileDialog2.ShowDialog()==DialogResult.OK)
                        {
                             byte[] data=  read.Read(file.KEY);

                            if (data != null)
                            {
                                System.IO.File.WriteAllBytes(saveFileDialog2.FileName, data);
                            }
                        }

                        MessageBox.Show("到出完成");
                    }
                }
            }
        }

        private void 全部导出到文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.read != null)
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string dir = folderBrowserDialog1.SelectedPath;

                    Task.Run(delegate
                    {
                        try
                        {
                            int i = 1;
                            int max = read.Count();

                            foreach (var file in read)
                            {
                                this.BeginInvoke(new EventHandler(delegate
                                {
                                    Make_MakeProgress(file.KEY, i, max);
                                }));

                                byte[] data = read.Read(file.KEY);

                                if (data != null)
                                {
                                    FileInfo makefile = new FileInfo(dir + file.KEY);

                                    if (!makefile.Directory.Exists)
                                    {
                                        makefile.Directory.Create();
                                    }

                                    System.IO.File.WriteAllBytes(makefile.FullName, data);
                                }

                                i++;
                            }

                            MessageBox.Show("导出完成");

                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(er.Message);
                        }
                    });
                }
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == this.sorter.SortColumn)
            {
                if (this.sorter.SortOrder == SortOrder.Ascending)
                    this.sorter.SortOrder = SortOrder.Descending;
                else
                if (this.sorter.SortOrder == SortOrder.Descending)
                    this.sorter.SortOrder = SortOrder.Ascending;
                else
                    return;
            }
            else
            {
                this.sorter.SortColumn = e.Column;
            }
            this.listView1.Sort();
        }


        private void 关联文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Microsoft.Win32.RegistryKey rootkey = Microsoft.Win32.Registry.ClassesRoot;

            Microsoft.Win32.RegistryKey key;
            if (rootkey.OpenSubKey(".dev") == null)
                key = rootkey.CreateSubKey(".dev");
            else
            {
                key = rootkey.OpenSubKey(".dev", true);               
            }

            key.SetValue("", "devfile", Microsoft.Win32.RegistryValueKind.String);

            if (rootkey.OpenSubKey("devfile") == null)
                key = rootkey.CreateSubKey("devfile");
            else
            {

                key = rootkey.OpenSubKey("devfile", true);
            }

            var icoFile = File.Create(Application.StartupPath + "/DevCompressICO.ico");

            Properties.Resources.DevCompressICO.Save(icoFile);
            icoFile.Close();
            icoFile.Dispose();

            var iconkey = key.CreateSubKey("DefaultIcon", true);

            iconkey.SetValue("", Application.StartupPath + "/DevCompressICO.ico", Microsoft.Win32.RegistryValueKind.String);
            var commandKey= key.CreateSubKey("shell", true).CreateSubKey("open",true).CreateSubKey("command",true);

            commandKey.SetValue("", Application.ExecutablePath + " \"%1\"", Microsoft.Win32.RegistryValueKind.String);

            MessageBox.Show("关联成功");
        }
    }
}
