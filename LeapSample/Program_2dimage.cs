//using Leap;
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
//            Leap.Image image = new Leap.Image();
//            Bitmap bitmap = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
//            set palette
//            ColorPalette grayscale = bitmap.Palette;
//            for (int i = 0; i < 256; i++)
//            {
//                grayscale.Entries[i] = Color.FromArgb((int)255, i, i, i);
//            }
//            bitmap.Palette = grayscale;
//            Rectangle lockArea = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
//            BitmapData bitmapData = bitmap.LockBits(lockArea, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
//            byte[] rawImageData = image.Data;
//            System.Runtime.InteropServices.Marshal.Copy(rawImageData, 0, bitmapData.Scan0, image.Width * image.Height);
//            bitmap.UnlockBits(bitmapData);
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

//            Console.WriteLine(
//              "Frame id: {0}, timestamp: {1}, hands: {2}",
//             frame.Id, frame.Timestamp, frame.Hands.Count
//            );
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
