using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsbEject.Library;

namespace Get_Eject_USB
{
    class Program
    {

       private static   bool _loading = false;
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                if (args[0].ToUpper() == "GET")
                {
                    loadUSB();
                }

                if (args[0].ToUpper() == "EJECT")
                {
                    ejectUSB();
                }
            }
            else
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine("*      Wistron Chengdu ATE                              *");
                Console.WriteLine("*      Ver:1.0.0.0                                      *");
                Console.WriteLine("*      Author:edward_song@yeah.net                      *");
                Console.WriteLine("*      Command:1,GET                                    *");
                Console.WriteLine("*              2,EJECT                                  *");
                Console.WriteLine("*      GET:get all the USB mass storage device          *");
                Console.WriteLine("*      EJECT:eject all the USB mass storage device      *");
                Console.WriteLine("*********************************************************");
            }
        }

        private static  void loadUSB()
        {
            _loading = true;
            //lstInfo.Items.Clear();
            // display volumes
            VolumeDeviceClass volumeDeviceClass = new VolumeDeviceClass();
            try
            {
                foreach (Volume device in volumeDeviceClass.Devices)
                {
                    if (device.IsUsb)
                    {
                        // lstInfo.Items.Add(device.Description + " " + device.LogicalDrive + "" + device.FriendlyName);
                        Console.WriteLine("Find the device:" + device.Description + " " + device.LogicalDrive + "" + device.FriendlyName);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            _loading = false; 
        }


        private static  void ejectUSB()
        {
            _loading = true;
            VolumeDeviceClass volumeDeviceClass = new VolumeDeviceClass();
            foreach (Volume device in volumeDeviceClass.Devices)
            {
                if (device.IsUsb)
                {
                    //lstInfo.Items.Add(device.Description + " " + device.LogicalDrive + "" + device.FriendlyName);
                    string s = device.Eject(true);
                    if (s != null)
                    {
                        Console.WriteLine("Error:" + s);
                    }
                    else
                    {
                        Console.WriteLine("Eject USB:" + device.Description + " " + device.LogicalDrive + "" + device.FriendlyName);
                    }
                }
            }

            _loading = false;
        }




    }
}
