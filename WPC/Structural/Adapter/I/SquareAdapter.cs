using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Adapter.I
{
    public class SquareAdapter : ICircle
    {
        private Square _square;

        public SquareAdapter(Square square)
        {
            _square = square;
        }

        public float Radius => _square.Width * (float)Math.Sqrt(2) / 2f;
    }
}
