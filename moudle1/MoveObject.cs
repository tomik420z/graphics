using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moudle1
{
    internal class MoveObject
    {
        private List<PointF> ArrayPointsOfObject;

        public MoveObject()
        {
            ArrayPointsOfObject = new List<PointF>();
        }

        public void AddNewVertex(PointF point) 
        {
            ArrayPointsOfObject.Add(point);
        }

        public void AddNewVertex(float x, float y)
        {
            ArrayPointsOfObject.Add(new PointF(x, y));
        }

        public void Rotate(float x, float y, float DeltaRad) 
        {
            for(int i = 0; i < ArrayPointsOfObject.Count; i++)
            {
                PointF point = ArrayPointsOfObject[i];
                float dx = point.X - x,  dy = point.Y - y;
                ArrayPointsOfObject[i] = new PointF(dx * MathF.Cos(DeltaRad) - dy * MathF.Sin(DeltaRad),
                                                       dy * MathF.Cos(DeltaRad) + dx * MathF.Sin(DeltaRad));        
                ArrayPointsOfObject[i] = new PointF(x + ArrayPointsOfObject[i].X, y + ArrayPointsOfObject[i].Y);
            }
        } 


        public void Move(float dx, float dy)
        {
            for(int i = 0; i < ArrayPointsOfObject.Count; i++)
            {
                ArrayPointsOfObject[i] = new PointF(ArrayPointsOfObject[i].X +  dx, ArrayPointsOfObject[i].Y + dy);
            }
        }

        public PointF First() => ArrayPointsOfObject.First();

        public PointF[] GetData() => ArrayPointsOfObject.ToArray();

        public int Count => ArrayPointsOfObject.Count;

        public void Clear()
        {
            ArrayPointsOfObject.Clear();
        }

       

    }
}
