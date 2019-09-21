using System.Collections.Generic;

namespace GameEngineCore
{
    public class MovingAverage
    {
        private readonly Queue<double> _samples = new Queue<double>();
        private readonly int _windowSize;
        private double _sampleAccumulator;

        public MovingAverage(int windowSize = 500)
        {
            _windowSize = windowSize;
        }

        /// <summary>
        /// Computes a new windowed average each time a new sample arrives
        /// </summary>
        /// <param name="newSample"></param>
        public double ComputeAverage(double newSample)
        {
            _sampleAccumulator += newSample;
            _samples.Enqueue(newSample);

            if (_samples.Count > _windowSize)
            {
                _sampleAccumulator -= _samples.Dequeue();
            }

            return _sampleAccumulator / _samples.Count;
        }
    }
}