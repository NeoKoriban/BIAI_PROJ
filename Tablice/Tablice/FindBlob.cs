using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;


namespace Tablice
{
    class FindBlob
    {
        public Bitmap bmp;
        public List<IntPoint> corn = new List<IntPoint>();



        // Process image
        public Bitmap ProcessImage(Bitmap toEdit)
        {

            Bitmap bitmap = new Bitmap(toEdit);
            List<IntPoint> corners = new List<IntPoint>();
            // lock image
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            //black background
            ColorFiltering colorFilter = new ColorFiltering();

            colorFilter.Red = new IntRange(0, 64);
            colorFilter.Green = new IntRange(0, 64);
            colorFilter.Blue = new IntRange(0, 64);
            colorFilter.FillOutsideRange = false;

            colorFilter.ApplyInPlace(bitmapData);

            //locating figures
            BlobCounter blobCounter = new BlobCounter();

            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 5;
            blobCounter.MinWidth = 5;

            blobCounter.ProcessImage(bitmapData);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            bitmap.UnlockBits(bitmapData);

            //check type of figure
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

            Graphics g = Graphics.FromImage(bitmap);

            Pen redPen = new Pen(Color.Red, 2);       // pen to colour egdes

            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);




                // is triangle or rectangle
                if (shapeChecker.IsConvexPolygon(edgePoints, out corners))
                {
                    // get subtype (is rectangle?)
                    PolygonSubType subType = shapeChecker.CheckPolygonSubType(corners);

                    Pen pen;

                    /*
                    if (subType == PolygonSubType.Unknown)
                    {
                        pen = (corners.Count == 4) ? redPen : bluePen;
                    }
                    else
                    {
                        pen = (corners.Count == 4) ? brownPen : greenPen;
                    }
                    */

                    if (subType == PolygonSubType.Rectangle)
                    {
                        int blobHeigth = Math.Abs(corners[3].Y - corners[0].Y);
                        int blobWidth = Math.Abs(corners[1].X - corners[0].X);

                        if (blobHeigth < blobWidth)
                        {
                            pen = redPen;

                            g.DrawPolygon(pen, ToPointsArray(corners));
                        }
                    }

                }
            }


            redPen.Dispose();

            g.Dispose();

            
            Clipboard.SetDataObject(bitmap);
            // and to picture box
            // pictureBox.Image = bitmap;
            return bitmap;
            // UpdatePictureBoxPosition();


        }

        //returns corners of found rectangle
        public List<IntPoint> getCorners(Bitmap toEdit)
        {

            Bitmap bitmap = new Bitmap(toEdit);
            List<IntPoint> corners = new List<IntPoint>();
            List<IntPoint> oneBlob = new List<IntPoint>();
            // lock image
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            //black background
            ColorFiltering colorFilter = new ColorFiltering();

            colorFilter.Red = new IntRange(0, 64);
            colorFilter.Green = new IntRange(0, 64);
            colorFilter.Blue = new IntRange(0, 64);
            colorFilter.FillOutsideRange = false;

            colorFilter.ApplyInPlace(bitmapData);

            //locate figurres
            BlobCounter blobCounter = new BlobCounter();

            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 8;
            blobCounter.MinWidth = 8;

            blobCounter.ProcessImage(bitmapData);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            bitmap.UnlockBits(bitmapData);

            //check object type
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

            Graphics g = Graphics.FromImage(bitmap);



            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);




                // check if trainge of rectangle
                if (shapeChecker.IsConvexPolygon(edgePoints, out corners))
                {
                    // get subtype (is rectangle?)
                    PolygonSubType subType = shapeChecker.CheckPolygonSubType(corners);


                    if (subType == PolygonSubType.Rectangle)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                IntPoint temp = new IntPoint();
                                if (j < 3)
                                {
                                    if (corners[k].Y > corners[k + 1].Y)
                                    {
                                        temp = corners[k];
                                        corners[k] = corners[k + 1];
                                        corners[k + 1] = temp;
                                    }

                                }
                            }
                        }
                        //sort list of corners
                        if (corners[0].X > corners[1].X)
                        {
                            IntPoint temp = new IntPoint();
                            temp = corners[0];
                            corners[0] = corners[1];
                            corners[1] = temp;
                        }

                        if (corners[3].X > corners[2].X)
                        {
                            IntPoint temp = new IntPoint();
                            temp = corners[2];
                            corners[2] = corners[3];
                            corners[3] = temp;
                        }

                        int blobHeigth = Math.Abs(corners[3].Y - corners[0].Y);
                        int blobWidth = Math.Abs(corners[1].X - corners[0].X);

                        if (blobHeigth < blobWidth)
                        {
                            //   float ratio = blobWidth / blobHeigth;

                            //  if(ratio > 1)
                            oneBlob = corners;
                        }
                    }

                }
            }

            g.Dispose();

            // put new image to clipboard
            Clipboard.SetDataObject(bitmap);
            // and to picture box
            // pictureBox.Image = bitmap;
            return oneBlob;
            // UpdatePictureBoxPosition();

        }


        // Conver list of AForge.NET's points to array of .NET points
        private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            }

            return array;
        }

        //crop bitmap by cornars
        public Bitmap cropBlob(Bitmap toEdit, List<IntPoint> corners)
        {

            Rectangle cropRect = new Rectangle();
            Bitmap src = toEdit;
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }

            return target;
        }


    }
}
