using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;

namespace Tablice
{
    class ManageImage
    {
        public Bitmap bmp;
        public ManageImage(Bitmap bmap)
        {
            bmp = bmap;
        }
        public ManageImage(){;}

        public System.Drawing.Image[] images; 
        //List of rectangle, used to store sizes of letters
        public List<Rectangle> rectangleList = new List<Rectangle>();



        //Storing positions and dimentions of letters in RectangleList
        public void getBlack()
        {
            bool flagLetter = false;
            int black = 0;
            Color pixelColor;
            int start = 0;
            int stop = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {        
                        //Gets oclor of each pixel
                        pixelColor = bmp.GetPixel(i, j);

                        //Check if pixel is dark
                        if (pixelColor.R < 40 && pixelColor.G < 30 && pixelColor.B < 30)
                        {
                            black++;
                        }                               
                }

                //If column has dark pixels it's a start of a letter
                if (black > 5 && flagLetter == false)
                {                                     
                    flagLetter = true;
                    start = i;
                }

                //If column doesn't have dark pixels it's no longer a letter
                //Add pisition and dimention of the letter as a rectangle to the list
                if (black < 5 && flagLetter == true)
                {                    
                    stop = i;                    
                    flagLetter = false;
                    rectangleList.Add(new Rectangle(start, 0, stop-start, bmp.Height));                    
                    start = 0;
                    stop = 0;
                }
                black = 0;
            }
            saveLetters();
        }

        //Crop letter
        public  System.Drawing.Image cropImage(System.Drawing.Image image, Rectangle imageRectangle)
        {            
            Bitmap bitmap = new Bitmap(image);
            Bitmap cropedBitmap = bitmap.Clone(imageRectangle, bitmap.PixelFormat);            
            return (System.Drawing.Image)(cropedBitmap);
            
        }

        //Cut each letter from Bitmap and save it
        public void saveLetters()
        {
            images = new System.Drawing.Image[rectangleList.Count]; 

            for (int i = 0; i < rectangleList.Count; i++)
            {
                string text = i.ToString();
                text += ".bmp";
                System.Drawing.Image image = bmp;
                image = cropImage(image, rectangleList[i]);
                image.Save(text);
                images[i]=image;

            }
        }

        public  Bitmap RotateImage(Bitmap bimp, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(bimp.Width, bimp.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            

            //now draw our new image onto the graphics object
            gfx.DrawImage(bimp, new System.Drawing.Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        public int calculateRotateAngle(List<IntPoint> blobCorners, List<IntPoint> frameCorners)
        {
            IntPoint center = new IntPoint(frameCorners[2].X/2, frameCorners[2].Y/2);
            float a = Math.Abs(blobCorners[1].DistanceTo(frameCorners[1]));
            float b = Math.Abs(blobCorners[1].DistanceTo(center));
            float c = Math.Abs(frameCorners[1].DistanceTo(center));

            float cosAlpha = (-1)*(a * a - b * b - c * c) / (2 * b * c);

            int angle = (int)Math.Acos(cosAlpha);


          //  if (blobCorners[0].Y > blobCorners[1].Y) angle = angle * (-1);
           


            return angle;

        }

        public Bitmap scaleImage(int PbWidth, int PbHeigth, Bitmap bitmap) 
        {

            float ratio;
            bool horizontal = false;
            if (bitmap.Width > bitmap.Height)
            {
                ratio = (float)PbWidth / (float)bitmap.Width;
                horizontal = true;
            }
            else ratio = (float)bitmap.Height / (float)PbHeigth;
            int heigth, width;


            float w = bitmap.Width * ratio;
            width = (int)w;

            float h = bitmap.Height * ratio;
            heigth = (int)h;


            ResizeBilinear filter = new ResizeBilinear(width, heigth);
            bitmap = filter.Apply(bitmap);

            return bitmap;
        }

        public Bitmap cutCorners(Bitmap bitmap) 
        {
            int heigth = bitmap.Height;
            int width = bitmap.Width;
            double topBottom = 0.12 * (double)heigth;
            double leftRight = 0.03 * (double)width;
            int h = heigth - 2 * (int)topBottom;
            int w = width - 2 * (int)leftRight;
            Rectangle area = new Rectangle((int)leftRight, (int)topBottom, w, h);

            System.Drawing.Image img = (System.Drawing.Image)bitmap;
            System.Drawing.Image cropped = cropImage(img, area);
            bitmap = new Bitmap(cropped);

            return bitmap;

            
        }
    }
}
