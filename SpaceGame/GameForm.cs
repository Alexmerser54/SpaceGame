using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceGame.Game;
using System.Windows.Forms;


namespace SpaceGame
{
    public partial class GameForm : Form
    {
        const int CELLS_NUM = 40;
        int[,] gameField;
        int cellSize;
        int starsCount;
        int planetCount;
        int stationsCount;

        List<bool> fill;
        int rowCount = 20;
        int colCount = 20;
        //int cellSize = 30;

        Player player;
        Pen playerPen;
        Pen gridPed;
        Pen starPen;
        Pen starEnergyRadiusPen;
        Pen starDestroyRadiusPen;
        Pen markerPen;
        Pen planetPen;
        Pen stationPen;


        Random rand;

        Star[] stars;
        Planet[] planets;
        Station[] stations;

        int tempX;
        int tempY;
        Point coordsToMove;

        RefrashStates refrashState;
        Rectangle[][] rectangles;
        int colNumber;
        int rowNumber;
        void RenderPlayer(Pen pen, PaintEventArgs e)
        {
            PaintSquare(rectangles[player.Position.Y][player.Position.X], e, pen.Brush);
        }

        void RenderStars(Pen starPen, Pen energyRadiusPen, Pen destroyRadiusPen, PaintEventArgs e)
        {
            foreach (var star in stars)
            {
                int diametr = 2 * star.EnergyRadius + 1;
                int startX = star.Position.X - star.EnergyRadius;
                int startY = star.Position.Y;
                int endX = startX + diametr;
                for (int i = 0; i <= star.EnergyRadius; i++)
                {
                    for (int j = startX; j < endX; j++)
                    {
                        PaintSquare(rectangles[startY + i][j], e, energyRadiusPen.Brush);
                        PaintSquare(rectangles[startY - i][j], e, energyRadiusPen.Brush);
                    }
                    startX++;
                    endX--;
                }

                diametr = 2 * star.DestroyRadius + 1;
                startX = star.Position.X - star.DestroyRadius;
                startY = star.Position.Y;
                endX = startX + diametr;

                for (int i = 0; i <= star.DestroyRadius; i++)
                {
                    for (int j = startX; j < endX; j++)
                    {
                        PaintSquare(rectangles[startY + i][j], e, destroyRadiusPen.Brush);
                        PaintSquare(rectangles[startY - i][j], e, destroyRadiusPen.Brush);
                    }
                    startX++;
                    endX--;
                }

                PaintSquare(rectangles[star.Position.Y][star.Position.X], e, starPen.Brush);
            }
        }

        void RenderPlanets(Pen pen, PaintEventArgs e)
        {
            foreach (var planet in planets)
            {
                PaintSquare(rectangles[planet.Position.Y][planet.Position.X], e, pen.Brush);
            }
        }

        void RenderStations(Pen pen, PaintEventArgs e)
        {
            foreach (var station in stations)
            {
                PaintSquare(rectangles[station.Position.Y][station.Position.X], e, pen.Brush);
            }
        }

        void RenderMarker(Pen pen, PaintEventArgs e)
        {
            PaintFrame(rectangles[rowNumber][colNumber], e, pen.Brush);
        }

        void DrawGrid(PaintEventArgs e, Pen pen)
        {
            for (int i = 0; i < CELLS_NUM; i++)
            {
                e.Graphics.DrawRectangles(pen, rectangles[i]);
            }
        }

        void InitCells()
        {
            rectangles = new Rectangle[CELLS_NUM][];
            for (int i = 0; i < CELLS_NUM; i++)
            {
                rectangles[i] = new Rectangle[CELLS_NUM];
                for (int j = 0; j < CELLS_NUM; j++)
                {
                    rectangles[i][j] = new Rectangle(j * cellSize, i * cellSize, cellSize, cellSize);
                }
            }
        }

        void MakeTurn()
        {

        }

        void MovePlayer()
        {
            //Point newCoords = new Point();
            if (coordsToMove.X > player.Position.X)
            {
                tempX = player.Position.X + 1;
            }
            else if (coordsToMove.X < player.Position.X)
            {
                tempX = player.Position.X - 1;
            }
            else
            {
                tempX = player.Position.X;
            }

            if (coordsToMove.Y > player.Position.Y)
            {
                tempY = player.Position.Y + 1;
            }
            else if (coordsToMove.Y < player.Position.Y)
            {
                tempY = player.Position.Y - 1;
            }
            else
            {
                tempY = player.Position.Y;
            }

            player.Move(tempX, tempY);
        }

        public GameForm()
        {

            InitializeComponent();
            rand = new Random();

            starsCount = rand.Next(1, 5);
            planetCount = rand.Next(1, 6);
            stationsCount = rand.Next(1, 3);


            stars = new Star[starsCount];
            planets = new Planet[planetCount];
            stations = new Station[stationsCount];

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Point(rand.Next(CELLS_NUM), rand.Next(CELLS_NUM)), rand.Next(1, 3), rand.Next(1, 2), 20);
            }

            for (int i = 0; i < planets.Length; i++)
            {
                planets[i] = new Planet(new Point(rand.Next(CELLS_NUM), rand.Next(CELLS_NUM)));
            }

            for (int i = 0; i < stations.Length; i++)
            {
                stations[i] = new Station(new Point(rand.Next(CELLS_NUM), rand.Next(CELLS_NUM)));
            }


            player = new Player(new Point(2, 4));

            markerPen = new Pen(Brushes.Red);
            playerPen = new Pen(Brushes.Black);
            gridPed = new Pen(Brushes.Black);
            starPen = new Pen(Brushes.Yellow);
            starEnergyRadiusPen = new Pen(Brushes.LightYellow);
            starDestroyRadiusPen = new Pen(Brushes.Red);
            planetPen = new Pen(Brushes.LawnGreen);
            stationPen = new Pen(Brushes.BlueViolet);

        }

        void PaintSquare(Rectangle rect, PaintEventArgs e, Brush brush)
        {
            e.Graphics.FillRectangle(brush, rect);
        }

        void PaintFrame(Rectangle rect, PaintEventArgs e, Brush brush)
        {
            e.Graphics.DrawRectangle(new Pen(brush), rect);
            // e.Graphics.FillRectangle(brush, rect);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            cellSize = (panel1.Height < panel1.Width ? panel1.Height : panel1.Width) / CELLS_NUM;



            InitCells();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e, gridPed);
            RenderStars(starPen, starEnergyRadiusPen, starDestroyRadiusPen, e);
            RenderPlanets(planetPen, e);
            RenderStations(stationPen, e);

            if (refrashState == RefrashStates.PlaceMarker || refrashState == RefrashStates.Turn)
                RenderMarker(markerPen, e);

            if (refrashState == RefrashStates.Turn)
            {
                MovePlayer();
                refrashState = RefrashStates.None;
            }

            RenderPlayer(playerPen, e);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < cellSize * CELLS_NUM && e.Y < cellSize * CELLS_NUM)
            {
                colNumber = e.X / cellSize;
                rowNumber = e.Y / cellSize;
                coordsToMove = new Point(colNumber, rowNumber);
                refrashState = RefrashStates.PlaceMarker;
                this.panel1.Invalidate();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {

        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            refrashState = RefrashStates.Turn;
            panel1.Invalidate();
        }
    }
}

