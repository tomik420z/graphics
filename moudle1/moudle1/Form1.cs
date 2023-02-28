using System.Collections;
using System.Security.Cryptography.Xml;

namespace moudle1
{
    public partial class lab1 : Form
    {
   

        private readonly Graphics graphics;
        
        private readonly List<PointF> ArrayVertex;
        
        private PointF MoveObject;
        private int IndexVertex;
        private int CountStep;
        private int iter;
        //     private readonly Button button;
        public lab1()
        {
            iter = 0;
            CountStep = 100;
            InitializeComponent();
            this.BackColor = Color.LightGray;
            graphics = this.CreateGraphics();
            MoveObject = new PointF(0, 0);
            ArrayVertex = new List<PointF>();
            IndexVertex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Clear()
        {
            graphics.Clear(Color.LightGray);
        }

        private void DrawPoligon()
        {
            Clear();
            if (ArrayVertex.Count > 2)
            {
                
                graphics.DrawPolygon(Pens.Black, ArrayVertex.ToArray());
            }
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ArrayVertex.Add(new PointF(e.X, e.Y));
            DrawPoligon();
        }

        private void DrawPoligon_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void DrawCircle()
        {
            graphics.DrawEllipse(Pens.Red, MoveObject.X, MoveObject.Y, 16, 16);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ArrayVertex.Count > 2)
            {
                MoveObject.X = ArrayVertex[0].X - 8;
                MoveObject.Y = ArrayVertex[0].Y - 8;
                timer1.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MakeMove()
        {
            iter += 1;
            PointF P1 = ArrayVertex[IndexVertex];           
            PointF P2 = ArrayVertex[(IndexVertex + 1) % ArrayVertex.Count];
            
            float DeltaX = (float)(Math.Sqrt(Math.Abs(P1.X - P2.X) * Math.Abs(P1.X - P2.X) + Math.Abs(P1.Y - P2.Y) * Math.Abs(P1.Y - P2.Y)) / (float)CountStep);

            float KCoeff = (P1.Y - P2.Y) / (P1.X - P2.X);
            float bCoeff = P1.Y - KCoeff * P1.X;
            if (P1.X < P2.X)
            {
                MoveObject.X += DeltaX;
            }
            else
            {
                MoveObject.X -= DeltaX;
            }
            MoveObject.Y = KCoeff * MoveObject.X + bCoeff;
            if (iter >= CountStep)
            {
                iter = 0;
                IndexVertex += 1;
                IndexVertex %= ArrayVertex.Count;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            Clear();
            DrawPoligon();

            MakeMove();
            DrawCircle();
        }
    }
}






