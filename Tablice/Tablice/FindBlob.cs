using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
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
        
        //private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        //{
        //    System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

        //    for (int i = 0, n = points.Count; i < n; i++)
        //    {
        //        array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
        //    }

        //    return array;
        //}

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
