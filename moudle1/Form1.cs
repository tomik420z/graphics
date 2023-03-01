namespace moudle1
{
    public partial class lab1 : Form
    {

        enum StateButton2
        {
            DEFAULT,
            DRAW_ROUTE,
            DRAW_FIGURE
        }

        private readonly Graphics graphics;

        private List<PointF> ArrayVertex;

        private PointF MoveObject;
        //private List<PointF> ArrayPointsOfObject;
        MoveObject Mobj;
        StateButton2 stateDraw;
        private int IndexVertex;
        private int CountStep;
        private int iter;
        private float t;
        private float rad;
        private float Speed;
        private int ChooseIndex;
        private Size Center;
        //     private readonly Button button;
        public lab1()
        { 
            ChooseIndex = -1;
            Speed = 0.0f;
            rad = 0.0f;
            Mobj = new MoveObject();
            stateDraw = StateButton2.DEFAULT;
            //ArrayPointsOfObject = new List<PointF>();
            iter = 0;
            CountStep = 10;
            InitializeComponent();
            this.BackColor = Color.LightGray;
            graphics = this.CreateGraphics();

            Center = this.ClientSize;

            MoveObject = new PointF(0, 0);
            ArrayVertex = new List<PointF>();
            IndexVertex = 0;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }



        private void Form1_Load(object sender, EventArgs e) { }

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

        private void DrawRoute()
        {
            Clear();
            if (Mobj.Count > 2)
            {
                graphics.DrawPolygon(Pens.Violet, Mobj.GetData());
            }
        }

        private void DrawAction()
        {

            Clear();
            graphics.DrawRectangle(Pens.Black, Center.Width / 2, Center.Height / 2, 20, 20);
            if (ArrayVertex.Count > 2)
            {
                for (int i = 0; i < ArrayVertex.Count; i++)
                {
                    graphics.FillRectangle(Brushes.Red, ArrayVertex[i].X - 3, ArrayVertex[i].Y - 3, 7, 7);
                    DoubleBuffered = true;
                }
                graphics.DrawPolygon(Pens.Black, ArrayVertex.ToArray());
            }
            if (Mobj.Count > 2)
            {
                graphics.DrawPolygon(Pens.Red, Mobj.GetData());
            }
        }

        private int ChooseVertex(float x, float y)
        {
            ChooseIndex = -1;
            for (int i = 0; i < ArrayVertex.Count; i++)
            {
                if ((x > ArrayVertex[i].X - 3.0f) & (x < ArrayVertex[i].X + 3.0f) &
                        (y > ArrayVertex[i].Y - 3.0f) & (y < ArrayVertex[i].Y + 3.0f))
                {
                    ChooseIndex = i;
                }
            }
            return ChooseIndex;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ChooseIndex = ChooseVertex(e.X, e.Y);
                button1.Text = ChooseIndex.ToString();
            }
            else
            {
                Clear();
                if (stateDraw == StateButton2.DRAW_ROUTE)
                {
                    ArrayVertex.Add(new PointF(e.X, e.Y));
                    DrawAction();
                }
                else if (stateDraw == StateButton2.DRAW_FIGURE)
                {
                    Mobj.AddNewVertex(new PointF(e.X, e.Y));
                    DrawAction();

                }
            }
        }


        private void DrawPoligon_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ChooseIndex != -1)
            {
                ArrayVertex[ChooseIndex] = new Point(e.X, e.Y);
                DrawAction();
            }
        }

        private void DrawCircle()
        {
            graphics.DrawEllipse(Pens.Red, MoveObject.X - 8, MoveObject.Y - 8, 16, 16);

        }

        private void MoveFigureToStart()
        {
            PointF P = ArrayVertex[0];
            float DeltaX = P.X - Mobj.First().X;
            float DeltaY = P.Y - Mobj.First().Y;
            Mobj.Move(DeltaX, DeltaY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ArrayVertex.Count > 2)
            {
                Speed = (float)numericUpDown2.Value / 100.0f;
                rad = (float)numericUpDown1.Value / 100.0f;
                MoveFigureToStart();
                t = 0.0f;
                MoveObject.X = ArrayVertex[0].X;
                MoveObject.Y = ArrayVertex[0].Y;
                timer1.Enabled = true;
            }
        }


        private void Rotate(float x, float y, float DeltaRad)
        {
            for (int i = 0; i < ArrayVertex.Count; i++)
            {
                PointF point = ArrayVertex[i];
                float dx = point.X - x, dy = point.Y - y;
                ArrayVertex[i] = new PointF(dx * MathF.Cos(DeltaRad) - dy * MathF.Sin(DeltaRad),
                                                       dy * MathF.Cos(DeltaRad) + dx * MathF.Sin(DeltaRad));
                ArrayVertex[i] = new PointF(x + ArrayVertex[i].X, y + ArrayVertex[i].Y);
            }
        }

        private void MakeMove()
        {
            iter += 1;
            

            //float c = (float)Math.Sqrt(Math.Abs(P1.X - P2.X) * Math.Abs(P1.X - P2.X) + Math.Abs(P1.Y - P2.Y) * Math.Abs(P1.Y - P2.Y));
            //float delta = ;
            
            // вертим маршрут 
            float rad1 = 0.1f;
            Rotate((float)Center.Width / 2, (float)Center.Height / 2, rad1);
            PointF P = Mobj.First();
            // вертим мобж
            Mobj.Rotate(P.X, P.Y, rad);

            PointF P1 = ArrayVertex[IndexVertex];
            PointF P2 = ArrayVertex[(IndexVertex + 1) % ArrayVertex.Count];
            PointF FirstPoint = new(((1.0f - t) * P1.X + t * P2.X), ((1.0f - t) * P1.Y + t * P2.Y));
            
            float deltaX = FirstPoint.X - P.X;
            float deltaY = FirstPoint.Y - P.Y;
            Mobj.Move(deltaX, deltaY);
         

       
            /*
            for(int i = 1; i < ArrayPointsOfObject.Count; i++)
            {
                ArrayPointsOfObject[i] = new PointF(ArrayPointsOfObject[i].X - deltaX, ArrayPointsOfObject[i].Y - deltaY);
            }*/
            // ArrayPointsOfObject[1] = 

            /*
            MoveObject.X = ((1.0f - t) * P1.X + t * P2.X);
            MoveObject.Y = ((1.0f - t) * P1.Y + t * P2.Y);
            */
            t += Speed; // speed 
            if (t >= 1.0f)
            {
                t = 0;
                iter = 0;
                IndexVertex += 1;
                IndexVertex %= ArrayVertex.Count;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MakeMove();

            DrawAction();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stateDraw = StateButton2.DRAW_FIGURE;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stateDraw = StateButton2.DRAW_ROUTE;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            rad = (float)numericUpDown1.Value / 100;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Speed = (float)numericUpDown2.Value / 100.0f;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Speed = 0.0f;
            rad = 0.0f;
        }

    }
}






