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
using System.IO;


namespace Tablice
{
    public partial class Form1 : Form
    {
        ManageFrame feed = new ManageFrame();
        ManageImage frame = new ManageImage();
        FindBlob blob = new FindBlob();

        Bitmap bmp;
        Bitmap toEdit;
        Bitmap croppedBmp;
        Bitmap croppedVideo;
        Bitmap shot;
        
        List<Rectangle> rectangleList = new List<Rectangle>();
        ArrayList devices = new ArrayList();
        public FilterInfoCollection usbCams;
        public VideoCaptureDevice cam;
        List<IntPoint> cornerList = new List<IntPoint>();

        NeuralNetworkOperations net = new NeuralNetworkOperations(63 * 69);

        public Form1()
        {
            InitializeComponent();
            feed = new ManageFrame();
            findPlate.Enabled = false;
         
        }


        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        //Get list of USB cameras connected to the computer
        //and sent it to comboBox1
        private void button3_Click(object sender, EventArgs e)
        {
            devices = feed.getDevices();
            this.comboBox1.DataSource = devices;         

            usbCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cam = new VideoCaptureDevice(usbCams[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_newFrame);
            cam.Start();
            findPlate.Enabled = true;

 //           InitTimer();
        }

        //Live feed into pictureBox2
        private void cam_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            shot = (Bitmap)eventArgs.Frame.Clone();
            shot = frame.scaleImage(pictureBox2.Width, pictureBox2.Height, shot);
            pictureBox2.Image = shot;
            
        }
       
       
         private void timer1_Tick(object sender, EventArgs e)
        {
           // pictureBox2.Image = shot;
            
        }
        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureboxEditPicture_Click(object sender, EventArgs e)
        {

        }

      

        
       

       
        //private void rotateButton_Click(object sender, EventArgs e)
        //{
        //    cornerList = blob.getCorners(croppedBmp);
        //    List<IntPoint> frameCorners = new List<IntPoint>();
        //    IntPoint zero = new IntPoint(0, 0);
        //    IntPoint one = new IntPoint(croppedBmp.Width, 0);
        //    IntPoint two = new IntPoint(croppedBmp.Width, croppedBmp.Height);
        //    IntPoint three = new IntPoint(0, croppedBmp.Height);
        //    frameCorners.Add(zero);
        //    frameCorners.Add(one);
        //    frameCorners.Add(two);
        //    frameCorners.Add(three);

        //    int angle = frame.calculateRotateAngle(cornerList, frameCorners);

        //    croppedBmp = frame.RotateImage(croppedBmp, angle);
        //    pictureBoxCutPlate.Image = croppedBmp; 
            
        //}

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

      
       

        private void tabPage1_Click_1(object sender, EventArgs e)
        {
             
        }


       private void status_Click(object sender, EventArgs e)
       {

       }

       private void tabPage2_Click(object sender, EventArgs e)
       {

       }

       private void LoadFileButton_Click(object sender, EventArgs e)
       {

           pictureBoxCutPlate.Image = null;
           pictureboxEditPicture.Image = null;

           String input = string.Empty;
           OpenFileDialog dialog = new OpenFileDialog();

           dialog.Filter = "BMP | *.bmp";

          // dialog.InitialDirectory = "D:/Studia/BIAI/Tablice/Tablice/bin/Debug";
           dialog.InitialDirectory = "C:";
          
           dialog.Title = "Select a text file";
           if (dialog.ShowDialog() == DialogResult.OK)

               input = dialog.FileName;

           if (input == String.Empty)

               return; //user didn't select a file to opena
           toEdit = new Bitmap(dialog.FileName);
           toEdit = frame.scaleImage(pictureboxEditPicture.Width, pictureboxEditPicture.Height, toEdit);
           pictureboxEditPicture.Image = toEdit;



           //CUT PLATE
           List<IntPoint> corners = blob.getCorners(toEdit);

           if (corners.Count > 0)
           {
               int maxY, minY, maxX, minX;
               if (corners[1].Y < corners[0].Y) maxY = corners[1].Y;
               else maxY = corners[0].Y;

               if (corners[3].Y > corners[2].Y) minY = corners[3].Y;
               else minY = corners[2].Y;

               if (corners[0].X < corners[3].X) minX = corners[0].X;
               else minX = corners[3].X;

               if (corners[1].X < corners[2].X) maxX = corners[2].X;
               else maxX = corners[1].X;



               Rectangle rectangle = new Rectangle(minX, maxY, maxX - minX, minY - maxY);
               System.Drawing.Image img = (System.Drawing.Image)toEdit;
               System.Drawing.Image cropped = frame.cropImage(img, rectangle);
               croppedBmp = new Bitmap(cropped);
               croppedBmp = frame.scaleImage(pictureBoxCutPlate.Width, pictureBoxCutPlate.Height, croppedBmp);

               pictureBoxCutPlate.Image = croppedBmp;

               //GREYSCALE & THRESEHOLD
               Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
               // apply the filter
               croppedBmp = filter.Apply(croppedBmp);


               OtsuThreshold thr = new OtsuThreshold();
               //   apply the filter
               thr.ApplyInPlace(croppedBmp);
               pictureBoxCutPlate.Image = croppedBmp;

               croppedBmp = frame.cutCorners(croppedBmp);
               croppedBmp = frame.scaleImage(pictureBoxCutPlate.Width, pictureBoxCutPlate.Height, croppedBmp);
               pictureBoxCutPlate.Image = croppedBmp;
              // pictureBox1.Image = croppedBmp;


               status.Text = "Plate found";

               bmp = pictureBoxCutPlate.Image as Bitmap;
               frame = new ManageImage(bmp);
               frame.getBlack();

               if (frame.images.Count() > 0)
               {

                   status.Text = "Characters found and saved";
                 
               }
               else status.Text = "No characters found";


           }
           else status.Text = "Plate not found";


           toEdit = blob.ProcessImage(toEdit);
           pictureboxEditPicture.Image = toEdit;

       }

       private void Form1_Load(object sender, EventArgs e)
       {

       }

       private void pictureBoxCutPlate_Click(object sender, EventArgs e)
       {

       }

       public void processVideo()

       { 
       //CUT PLATE
           Bitmap toEditVideo = pictureboxCatched.Image as Bitmap;
           List<IntPoint> corners = blob.getCorners(toEditVideo);

           if (corners.Count > 0)
           {
               int maxY, minY, maxX, minX;
               if (corners[1].Y < corners[0].Y) maxY = corners[1].Y;
               else maxY = corners[0].Y;

               if (corners[3].Y > corners[2].Y) minY = corners[3].Y;
               else minY = corners[2].Y;

               if (corners[0].X < corners[3].X) minX = corners[0].X;
               else minX = corners[3].X;

               if (corners[1].X < corners[2].X) maxX = corners[2].X;
               else maxX = corners[1].X;



               Rectangle rectangle = new Rectangle(minX, maxY, maxX - minX, minY - maxY);
               System.Drawing.Image img = (System.Drawing.Image)toEditVideo;
               System.Drawing.Image cropped = frame.cropImage(img, rectangle);
               croppedVideo = new Bitmap(cropped);
               croppedVideo = frame.scaleImage(pictureBox1.Width, pictureBox1.Height, croppedVideo);

               pictureBox1.Image = croppedVideo;

               //GREYSCALE & THRESEHOLD
               Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
               // apply the filter
               croppedVideo = filter.Apply(croppedVideo);


               OtsuThreshold thr = new OtsuThreshold();
               //   apply the filter
               thr.ApplyInPlace(croppedVideo);
               pictureBox1.Image = croppedVideo;

               croppedVideo = frame.cutCorners(croppedVideo);
               croppedVideo = frame.scaleImage(pictureBox1.Width, pictureBox1.Height, croppedVideo);
               pictureBox1.Image = croppedVideo;


               statusVideo.Text = "Plate found";

               bmp = pictureBox1.Image as Bitmap;
               frame = new ManageImage(bmp);
               frame.getBlack();


               if (frame.images.Count() > 0)
               {

                   status.Text = "Characters found and saved";

               }
               else status.Text = "No characters found";

           }
           else statusVideo.Text = "Plate not found";


           toEditVideo = blob.ProcessImage(toEditVideo);
           pictureboxCatched.Image = toEditVideo;
       
       }

       private void pictureBox1_Click(object sender, EventArgs e)
       {

       }

       private void findPlate_Click(object sender, EventArgs e)
       {
           pictureboxCatched.Image = pictureBox2.Image;
           if (pictureboxCatched.Image != null) processVideo();
           else statusVideo.Text = "Frame not found";
           
       }

       private void pictureBox2_Click(object sender, EventArgs e)
       {

       }

       private void recognitionButton_Click(object sender, EventArgs e)
       {
           net.prepareBlobData();


           this.licensePlateTextBox.Text = net.runRecognition();
       }

       private void licensePlateTextBox_TextChanged(object sender, EventArgs e)
       {

       }

    }

}