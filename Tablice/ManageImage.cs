using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tablice
{
    class ManageImage
    {
        public Bitmap bmp;
        public ManageImage(Bitmap bmap)
        {
            bmp = bmap;
        }

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
        private static Image cropImage(Image image, Rectangle imageRectangle)
        {            
            Bitmap bitmap = new Bitmap(image);
            Bitmap cropedBitmap = bitmap.Clone(imageRectangle, bitmap.PixelFormat);            
            return (Image)(cropedBitmap);
            
        }

        //Cut each letter from Bitmap and save it
        public void saveLetters()
        {
            for (int i = 0; i < rectangleList.Count; i++)
            {
                string text = i.ToString();
                text += ".bmp";
                Image image = bmp;
                image = cropImage(image, rectangleList[i]);
                image.Save(text);
            }
        }


    }
}
