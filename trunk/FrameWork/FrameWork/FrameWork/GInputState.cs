using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Input.Touch;

namespace FrameWork
{
    class GInputState
    {
        public TouchCollection TouchState;
        public List<GestureSample> Gestures = new List<GestureSample>();

        private Accelerometer m_AccelSensor;
        private Vector3 m_AccelReading;

        public Accelerometer AccelSensor
        {
            get { return m_AccelSensor; }
            set { m_AccelSensor = value; }
        }
        public Vector3 AccelReading
        {
            get { return m_AccelReading; }
            set { m_AccelReading = value; }
        }
        public GInputState()
        {
            m_AccelReading = new Vector3();
            m_AccelSensor = new Accelerometer();

            m_AccelSensor.ReadingChanged += new EventHandler<AccelerometerReadingEventArgs>(AccelerometerReadingChanged);
            m_AccelSensor.Start();
        }
        public void Update()
        {
            TouchState = TouchPanel.GetState();
            Gestures.Clear();
            while (TouchPanel.IsGestureAvailable)
            {
                Gestures.Add(TouchPanel.ReadGesture());
            }
        }
        public void AccelerometerReadingChanged(object sender, AccelerometerReadingEventArgs e)
        {
            m_AccelReading.X = (float)e.X;
            m_AccelReading.Y = -(float)e.Y;
            m_AccelReading.Z = -(float)e.Z;
        }

        public void UnloadInput()
        {
            m_AccelSensor.Stop();
        }
    }
}
