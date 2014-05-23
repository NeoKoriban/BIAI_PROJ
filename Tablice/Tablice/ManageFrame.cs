using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Video;
using AForge.Video.DirectShow;


namespace Tablice
{
    class ManageFrame
    {
        public ArrayList devices = new ArrayList();
        public FilterInfoCollection usbCams;
      //public VideoCaptureDevice cam;

        //Get a list of USB cameras connected to computer
        public ArrayList getDevices()
        {
            usbCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo camera in usbCams)
            {
                devices.Add(camera.Name);
            }
            return devices;
        }
    }
}
