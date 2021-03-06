﻿using System.Linq;
using System.Windows.Input;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WP.Basics.TouchSamples
{
    public partial class TouchEventsSample : PhoneApplicationPage
    {
        public TouchEventsSample()
        {
            InitializeComponent();
            Touch.FrameReported += TouchFrameReported;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Touch.FrameReported += TouchFrameReported;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Touch.FrameReported -= TouchFrameReported;
        }

        void TouchFrameReported(object sender, TouchFrameEventArgs e)
        {
            TouchPointCollection tpc = e.GetTouchPoints(ContentCanvas);
            tpc.ToList().ForEach(p =>
            {
                // p.Action of type ActionType: Up, Down, Move
                Ellipse el = TouchUtils.CreateEllipse(p.Position);
                ContentCanvas.Children.Add(el);
            });
        }
    }
}