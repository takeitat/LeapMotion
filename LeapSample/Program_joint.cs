using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeapSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            SampleListener listener = new SampleListener();
            controller.Connect += listener.OnServiceConnect;
            controller.Device += listener.OnConnect;
            controller.FrameReady += listener.OnFrame;

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();

            controller.Dispose();
            listener.Dispose();
        }
    }

    class SampleListener
    {
        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            Console.WriteLine("Service Connected");
        }


        StreamWriter sw;

        public SampleListener()
        {
            sw = new System.IO.StreamWriter("test.csv", true, System.Text.Encoding.GetEncoding("shift_jis"));
        }

        public void Dispose()
        {
            sw.Dispose();
        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            Console.WriteLine("Connected");
        }
        public void OnFrame(object sender, FrameEventArgs args)
        {
            Frame frame = args.frame;
            foreach (Hand hand in frame.Hands)
            {
                if (hand == null || hand.Fingers.Count == 0) continue;
                var finger1 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_THUMB).FirstOrDefault();
                var finger2 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_INDEX).FirstOrDefault();
                var finger3 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_MIDDLE).FirstOrDefault();
                var finger4 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_RING).FirstOrDefault();
                var finger5 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_PINKY).FirstOrDefault();

                Finger index_fin = null;
                foreach (var fin in hand.Fingers)
                {
                    if (fin.Type == Finger.FingerType.TYPE_INDEX) index_fin = fin;
                }



                if (finger1 != null)
                {
                    Bone bone1 = finger1.Bone(Bone.BoneType.TYPE_DISTAL);
                    Bone bone2 = finger1.Bone(Bone.BoneType.TYPE_INTERMEDIATE);
                    Bone bone3 = finger1.Bone(Bone.BoneType.TYPE_PROXIMAL);
                    Bone bone4 = finger1.Bone(Bone.BoneType.TYPE_METACARPAL);

                    Console.WriteLine(finger1.Type + "0: " + hand.PalmPosition);
                    Console.WriteLine(finger1.Type + "1: " + bone1.NextJoint);
                    Console.WriteLine(finger1.Type + "2: " + bone2.NextJoint);
                    Console.WriteLine(finger1.Type + "3: " + bone3.NextJoint);
                    Console.WriteLine(finger1.Type + "4: " + bone4.NextJoint);
                    Console.WriteLine(finger1.Type + "5: " + bone4.PrevJoint);

                    {
                        sw.Write("{0}, {1}, {2}", hand.PalmPosition.x, hand.PalmPosition.y, hand.PalmPosition.z + ",");
                        sw.Write("{0}, {1}, {2}", bone1.NextJoint.x, bone1.NextJoint.y, bone1.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone2.NextJoint.x, bone2.NextJoint.y, bone2.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone3.NextJoint.x, bone3.NextJoint.y, bone3.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.NextJoint.x, bone4.NextJoint.y, bone4.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.PrevJoint.x, bone4.PrevJoint.y, bone4.PrevJoint.z + ",");
                    }
                }
                if (finger2 != null)
                {
                    Bone bone1 = finger2.Bone(Bone.BoneType.TYPE_DISTAL);
                    Bone bone2 = finger2.Bone(Bone.BoneType.TYPE_INTERMEDIATE);
                    Bone bone3 = finger2.Bone(Bone.BoneType.TYPE_PROXIMAL);
                    Bone bone4 = finger2.Bone(Bone.BoneType.TYPE_METACARPAL);

                    Console.WriteLine(finger2.Type + "1: " + bone1.NextJoint);
                    Console.WriteLine(finger2.Type + "2: " + bone2.NextJoint);
                    Console.WriteLine(finger2.Type + "3: " + bone3.NextJoint);
                    Console.WriteLine(finger2.Type + "4: " + bone4.NextJoint);
                    Console.WriteLine(finger2.Type + "5: " + bone4.PrevJoint);

                    {
                        sw.Write("{0}, {1}, {2}", bone1.NextJoint.x, bone1.NextJoint.y, bone1.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone2.NextJoint.x, bone2.NextJoint.y, bone2.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone3.NextJoint.x, bone3.NextJoint.y, bone3.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.NextJoint.x, bone4.NextJoint.y, bone4.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.PrevJoint.x, bone4.PrevJoint.y, bone4.PrevJoint.z + ",");
                    }
                }
                if (finger3 != null)
                {
                    Bone bone1 = finger3.Bone(Bone.BoneType.TYPE_DISTAL);
                    Bone bone2 = finger3.Bone(Bone.BoneType.TYPE_INTERMEDIATE);
                    Bone bone3 = finger3.Bone(Bone.BoneType.TYPE_PROXIMAL);
                    Bone bone4 = finger3.Bone(Bone.BoneType.TYPE_METACARPAL);

                    Console.WriteLine(finger3.Type + "1: " + bone1.NextJoint);
                    Console.WriteLine(finger3.Type + "2: " + bone2.NextJoint);
                    Console.WriteLine(finger3.Type + "3: " + bone3.NextJoint);
                    Console.WriteLine(finger3.Type + "4: " + bone4.NextJoint);
                    Console.WriteLine(finger3.Type + "5: " + bone4.PrevJoint);

                    {
                        sw.Write("{0}, {1}, {2}", bone1.NextJoint.x, bone1.NextJoint.y, bone1.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone2.NextJoint.x, bone2.NextJoint.y, bone2.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone3.NextJoint.x, bone3.NextJoint.y, bone3.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.NextJoint.x, bone4.NextJoint.y, bone4.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.PrevJoint.x, bone4.PrevJoint.y, bone4.PrevJoint.z + ",");
                    }
                }
                if (finger4 != null)
                {
                    Bone bone1 = finger4.Bone(Bone.BoneType.TYPE_DISTAL);
                    Bone bone2 = finger4.Bone(Bone.BoneType.TYPE_INTERMEDIATE);
                    Bone bone3 = finger4.Bone(Bone.BoneType.TYPE_PROXIMAL);
                    Bone bone4 = finger4.Bone(Bone.BoneType.TYPE_METACARPAL);

                    Console.WriteLine(finger4.Type + "1: " + bone1.NextJoint);
                    Console.WriteLine(finger4.Type + "2: " + bone2.NextJoint);
                    Console.WriteLine(finger4.Type + "3: " + bone3.NextJoint);
                    Console.WriteLine(finger4.Type + "4: " + bone4.NextJoint);
                    Console.WriteLine(finger4.Type + "5: " + bone4.PrevJoint);

                    {
                        sw.Write("{0}, {1}, {2}", bone1.NextJoint.x, bone1.NextJoint.y, bone1.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone2.NextJoint.x, bone2.NextJoint.y, bone2.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone3.NextJoint.x, bone3.NextJoint.y, bone3.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.NextJoint.x, bone4.NextJoint.y, bone4.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.PrevJoint.x, bone4.PrevJoint.y, bone4.PrevJoint.z + ",");
                    }
                }
                if (finger5 != null)
                {
                    Bone bone1 = finger5.Bone(Bone.BoneType.TYPE_DISTAL);
                    Bone bone2 = finger5.Bone(Bone.BoneType.TYPE_INTERMEDIATE);
                    Bone bone3 = finger5.Bone(Bone.BoneType.TYPE_PROXIMAL);
                    Bone bone4 = finger5.Bone(Bone.BoneType.TYPE_METACARPAL);

                    Console.WriteLine(finger5.Type + "1: " + bone1.NextJoint);
                    Console.WriteLine(finger5.Type + "2: " + bone2.NextJoint);
                    Console.WriteLine(finger5.Type + "3: " + bone3.NextJoint);
                    Console.WriteLine(finger5.Type + "4: " + bone4.NextJoint);
                    Console.WriteLine(finger5.Type + "5: " + bone4.PrevJoint);

                    {
                        sw.Write("{0}, {1}, {2}", bone1.NextJoint.x, bone1.NextJoint.y, bone1.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone2.NextJoint.x, bone2.NextJoint.y, bone2.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone3.NextJoint.x, bone3.NextJoint.y, bone3.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.NextJoint.x, bone4.NextJoint.y, bone4.NextJoint.z + ",");
                        sw.Write("{0}, {1}, {2}", bone4.PrevJoint.x, bone4.PrevJoint.y, bone4.PrevJoint.z + ",");
                    }
                }
                Console.WriteLine(frame.Id);
                var dt = DateTime.Now;
                sw.WriteLine(dt.Millisecond + ",");
            }
        }
    }
}
