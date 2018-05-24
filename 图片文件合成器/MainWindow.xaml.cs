using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 图片文件合成器
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileimg;
        private string filezip;
        private bool download;
        private string tempfile = "";
        private string ext = "";
        public MainWindow()
        {
            InitializeComponent();
            DoubleAnimation da = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.4)));
            TTMainWindow.BeginAnimation(UIElement.OpacityProperty, da);
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {

            }
        }

        private void BtnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Timers.Timer time = new System.Timers.Timer(400);
            time.Elapsed += new System.Timers.ElapsedEventHandler(MainClose);
            time.AutoReset = false;
            time.Enabled = true;
            DoubleAnimation da = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.4)));
            TTMainWindow.BeginAnimation(UIElement.OpacityProperty, da);
        }
        private void MainClose(object source, System.Timers.ElapsedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void BtnMin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "图片文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif";
            dialog.Title = "请选择图片文件";
            if (dialog.ShowDialog() == true)
            {
                fileimg = dialog.FileName;
                img.Source = new BitmapImage(new Uri(fileimg));
                add.Source = new BitmapImage(new Uri("img/add.png", UriKind.Relative));
                add.ToolTip = "合成";
                download = false;
            }
        }

        private void zip_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "压缩文件|*.rar;*.zip;*.7z;*.tar;*.gz";
            dialog.Title = "请选择压缩文件";
            if (dialog.ShowDialog() == true)
            {
                filezip = dialog.FileName;
                zip.Source = new BitmapImage(new Uri("img/fullzip.png", UriKind.Relative));
                add.Source = new BitmapImage(new Uri("img/add.png", UriKind.Relative));
                add.ToolTip = "合成";
                download = false;
            }
        }

        private void add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (download)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "默认文件名";
                dlg.DefaultExt = ext;
                dlg.Filter = "图片|*" + ext;

                Nullable<bool> result = dlg.ShowDialog();
                string filename = string.Empty;
                if (result == true)
                {
                    filename = dlg.FileName;
                    File.Copy(tempfile, filename, true);
                    MsgOK ms = new MsgOK();
                    ms.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (fileimg == null || filezip == null)
                {
                    return;
                }
                if (FileSize(fileimg))
                {
                    MsgNG ms = new MsgNG();
                    ms.ShowDialog();
                    return;
                }
                tempfile = System.IO.Path.GetTempFileName();
                ext = System.IO.Path.GetExtension(fileimg);
                System.IO.File.Delete(tempfile);
                //创建一个进程
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                string strCMD = "copy /b " + fileimg + " +" + filezip + " " + tempfile;
                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine(strCMD + "&exit");

                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程

                add.Source = new BitmapImage(new Uri("img/download.png", UriKind.Relative));
                download = true;
                add.ToolTip = "下载";
            }
        }

        private bool FileSize(string img)
        {
            FileInfo fi = new FileInfo(img);
            Int64 size = fi.Length;
            if (size >= 2097152)
                return true;
            else
                return false;
            
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.ttitt.net");
        }
    }
}
