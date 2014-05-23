using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;


namespace Tablice
{
    public partial class Form1 : Form
    {
        ManageFrame feed;
        ManageImage frame;
        FindBlob blob;

        Bitmap bmp;                
        List<Rectangle> rectangleList = new List<Rectangle>();
        ArrayList devices = new ArrayList();
        public FilterInfoCollection usbCams;
        public VideoCaptureDevice cam;

        public Form1()
        {
            InitializeComponent();
            feed = new ManageFrame();
            button4.Enabled = false;
            button5.Enabled = false;
        }

        //Get bitmap (from file for now)
        private void button1_Click(object sender, EventArgs e)
        {
             pictureBox1.Image =  new Bitmap("demo.bmp");
             bmp = pictureBox1.Image as Bitmap;
             frame = new ManageImage(bmp);           
        }      
   
        //Cut into letters
        private void button2_Click(object sender, EventArgs e)
        {
            frame.getBlack();   
            //findRegistration(bmp);                    
        }

        //Get list of USB cameras connected to the computer
        //and sent it to comboBox1
        private void button3_Click(object sender, EventArgs e)
        {
            devices = feed.getDevices();
            this.comboBox1.DataSource = devices;
            button4.Enabled = true;            
        }

        //Live feed into pictureBox2
        private void cam_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox2.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        
        //Capture frames from the feed
        private void button4_Click(object sender, EventArgs e)
        {
            usbCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cam = new VideoCaptureDevice(usbCams[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_newFrame);
            cam.Start();
            button5.Enabled = true;
        }

        //Freeze frame from pictureBox3
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = pictureBox2.Image;
        }


        private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            }

            return array;
        }

        //public void findRegistration(Bitmap bmp)
        //{
        //    BlobCounter blobCounter = new BlobCounter();
        //    blobCounter.ProcessImage(bmp);
        //    Blob[] blobs = blobCounter.GetObjectsInformation();
        //    // create Graphics object to draw on the image and a pen
        //    Graphics g = Graphics.FromImage(bmp);
        //    Pen bluePen = new Pen(Color.Blue, 2);
        //    for (int i = 0, n = blobs.Length; i < n; i++)
        //    {
        //        List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
        //        List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);

        //        g.DrawPolygon(bluePen, ToPointsArray(corners));
        //    }

        //    bluePen.Dispose();
        //    g.Dispose();

        //}






    }
}
