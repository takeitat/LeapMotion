using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Leap;

namespace LeapViewer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Controller controller = new Controller();

            controller.FrameReady += OnFrame;
        }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            MainCanvas.Children.Clear();

               var frame = args.frame;
            foreach (Hand hand in frame.Hands)
            {
                if (hand == null || hand.Fingers.Count == 0) continue;
                var finger0 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_THUMB).FirstOrDefault();
                var finger1 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_INDEX).FirstOrDefault();
                var finger2 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_MIDDLE).FirstOrDefault();
                var finger3 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_RING).FirstOrDefault();
                var finger4 = hand.Fingers.Where(f => f.Type == Finger.FingerType.TYPE_PINKY).FirstOrDefault();

                Finger index_fin = null;
                foreach (var fin in hand.Fingers)
                {
                    if (fin.Type == Finger.FingerType.TYPE_INDEX) index_fin = fin;
                }


                BoneDefine(finger0);
                BoneDefine(finger1);
                BoneDefine(finger2);
                BoneDefine(finger3);
                BoneDefine(finger4);

            }
        }

        void DrawCircle(double x,double y)
        {
            var circle = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = Brushes.Red
            };

            Canvas.SetLeft(circle, x);
            Canvas.SetTop(circle, y);
           
            MainCanvas.Children.Add(circle);
        }

        void BoneDefine(Finger x)
        {

            if (x != null)
            {
                double a = 150;
                double b = 200;
                Bone bone0 = x.Bone(Bone.BoneType.TYPE_METACARPAL);
                DrawCircle(bone0.NextJoint.x * 2 + a, bone0.NextJoint.z * 2 + b);
                Bone bone1 = x.Bone(Bone.BoneType.TYPE_PROXIMAL);
                DrawCircle(bone1.NextJoint.x * 2 + a, bone1.NextJoint.z * 2 + b);
                Bone bone2 = x.Bone(Bone.BoneType.TYPE_INTERMEDIATE);
                DrawCircle(bone2.NextJoint.x * 2 + a, bone2.NextJoint.z * 2 + b);
                Bone bone3 = x.Bone(Bone.BoneType.TYPE_DISTAL);
                DrawCircle(bone3.NextJoint.x * 2 + a, bone3.NextJoint.z * 2 + b);
            }
        }
    }
}
