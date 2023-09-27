using System.Drawing;

namespace Example.Source._Car
{
    // 
    public class CarKey
    {
        public Color Indicator { get; private set; }
        private readonly Car _car;

        public CarKey(Car car)
        {
            _car = car;
            Indicator = Color.Red;
        }

        public void ToggleLock()
        {
            if (_car.IsLocked)
            {
                Unlock();
            }
            else
            {
                Lock();
            }
            _car.BlinkLights();
            _car.SignalBeep();
        }

        private void Lock()
        {
            _car.IsLocked = false;
            Indicator = Color.Red;
        }

        private void Unlock()
        {
            _car.IsLocked = true;
            Indicator = Color.Green;
        }
    }
}