﻿//using Leap;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LeapSample
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Controller controller = new Controller();
//            SampleListener listener = new SampleListener();
//            controller.Connect += listener.OnServiceConnect;
//            controller.Device += listener.OnConnect;
//            controller.FrameReady += listener.OnFrame;

//            Console.WriteLine("Press Enter to quit...");
//            Console.ReadLine();

//            controller.Dispose();
//        }
//    }

//    class SampleListener
//    {
//        public void OnServiceConnect(object sender, ConnectionEventArgs args)
//        {
//            Console.WriteLine("Service Connected");
//        }

//        public void OnConnect(object sender, DeviceEventArgs args)
//        {
//            Console.WriteLine("Connected");
//        }
//        public void OnFrame(object sender, FrameEventArgs args)
//        {
//            Frame frame = args.frame;

//            //Console.WriteLine(
//            //  "Frame id: {0}, timestamp: {1}, hands: {2}",
//            // frame.Id, frame.Timestamp, frame.Hands.Count
//            //);
//            foreach (Hand hand in frame.Hands)
//            {
//                Console.WriteLine("{0}", hand.PalmPosition);

//                Vector normal = hand.PalmNormal;
//                Vector direction = hand.Direction;

//                Console.WriteLine(
//                  "  Hand pitch: {0} degrees, roll: {1} degrees, yaw: {2} degrees",
//                  direction.Pitch * 180.0f / (float)Math.PI,
//                  normal.Roll * 180.0f / (float)Math.PI,
//                  direction.Yaw * 180.0f / (float)Math.PI
//                );
//            }
//        }
//    }
//}
