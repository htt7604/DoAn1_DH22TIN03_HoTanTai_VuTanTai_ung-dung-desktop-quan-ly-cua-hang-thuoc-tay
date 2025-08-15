using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace QL_Nha_thuoc.BanHang.MaVach
{
    public partial class FormQuetMaVach : Form
    {
        private VideoCapture capture;
        private CancellationTokenSource cts;

        public string MaVach { get; private set; } // Lưu mã vạch vừa quét

        public FormQuetMaVach()
        {
            InitializeComponent();
            //InitForm();
        }

        //private void InitForm()
        //{
        //    this.Text = "Quét Mã Vạch";
        //    this.Width = 800;
        //    this.Height = 600;

        //    // PictureBox hiển thị camera
        //    PictureBox pictureBox = new PictureBox
        //    {
        //        Name = "pictureBoxCamera",
        //        Dock = DockStyle.Fill,
        //        SizeMode = PictureBoxSizeMode.StretchImage
        //    };
        //    this.Controls.Add(pictureBox);

        //    // Button bắt đầu quét
        //    Button btnQuet = new Button
        //    {
        //        Text = "Bắt đầu quét",
        //        Dock = DockStyle.Bottom,
        //        Height = 40
        //    };
        //    btnQuet.Click += BtnQuet_Click;
        //    this.Controls.Add(btnQuet);
        //}

        //private async void BtnQuet_Click(object sender, EventArgs e)
        //{
        //    Button btn = sender as Button;

        //    if (btn.Text == "Bắt đầu quét")
        //    {
        //        btn.Text = "Dừng quét";

        //        capture = new VideoCapture(0);
        //        if (!capture.IsOpened())
        //        {
        //            MessageBox.Show("Không thể mở camera!");
        //            return;
        //        }

        //        cts = new CancellationTokenSource();
        //        await Task.Run(() => QuetMaVachLoop(cts.Token));
        //    }
        //    else
        //    {
        //        btn.Text = "Bắt đầu quét";
        //        StopQuet();
        //    }
        //}

        //private void StopQuet()
        //{
        //    if (cts != null)
        //    {
        //        cts.Cancel();
        //        cts.Dispose();
        //        cts = null;
        //    }

        //    if (capture != null)
        //    {
        //        capture.Release();
        //        capture.Dispose();
        //        capture = null;
        //    }

        //    var pb = CapturePictureBox();
        //    if (pb != null)
        //    {
        //        if (pb.Image != null) pb.Image.Dispose();
        //        pb.Image = null;
        //    }
        //}

        //private PictureBox CapturePictureBox()
        //{
        //    return this.Controls["pictureBoxCamera"] as PictureBox;
        //}

        //private void QuetMaVachLoop(CancellationToken token)
        //{
        //    var reader = new BarcodeReader
        //    {
        //        AutoRotate = true,
        //        Options = { TryHarder = true }
        //    };
        //    Mat frame = new Mat();

        //    while (!token.IsCancellationRequested)
        //    {
        //        capture.Read(frame);
        //        if (frame.Empty()) continue;

        //        using (Bitmap bitmap = BitmapConverter.ToBitmap(frame))
        //        {
        //            var result = reader.Decode(bitmap);

        //            // Hiển thị hình ảnh lên PictureBox
        //            var pb = CapturePictureBox();
        //            if (pb != null)
        //            {
        //                var bitmapClone = (Bitmap)bitmap.Clone();
        //                pb.Invoke(new Action(() =>
        //                {
        //                    if (pb.Image != null) pb.Image.Dispose();
        //                    pb.Image = bitmapClone;
        //                }));
        //            }

        //            if (result != null)
        //            {
        //                MaVach = result.Text;

        //                // Hiển thị MessageBox trên UI thread
        //                this.Invoke(new Action(() =>
        //                {
        //                    MessageBox.Show($"Mã vạch: {MaVach}");
        //                    StopQuet();
        //                }));
        //                break;
        //            }
        //        }
        //    }
        //}


        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    StopQuet();
        //    base.OnFormClosing(e);
        //}
    }
}
