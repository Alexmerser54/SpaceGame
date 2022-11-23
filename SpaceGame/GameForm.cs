﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceGame.Game;
using System.Windows.Forms;
using SpaceGame.Game.Objects;

namespace SpaceGame
{
    partial class GameForm : Form
    {
        const int CELLS_NUM = 40;
        int cellSize;
        int starsCount;
        int planetCount;
        int stationsCount;
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
        Point oldCoordsToMove;

        RefrashStates refrashState;
        Rectangle[][] rectangles;

        Label[] fuelLabels;

        void RenderPlayer(Pen pen, PaintEventArgs e)
        {
            PaintSquare(rectangles[player.Position.X][player.Position.Y], e, pen.Brush);
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
                        PaintSquare(rectangles[j][startY + i], e, energyRadiusPen.Brush);
                        PaintSquare(rectangles[j][startY - i], e, energyRadiusPen.Brush);
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
                        PaintSquare(rectangles[j][startY + i], e, destroyRadiusPen.Brush);
                        PaintSquare(rectangles[j][startY - i], e, destroyRadiusPen.Brush);
                    }
                    startX++;
                    endX--;
                }

                PaintSquare(rectangles[star.Position.X][star.Position.Y], e, starPen.Brush);
            }
        }

        void RenderPlanets(Pen pen, PaintEventArgs e)
        {
            foreach (var planet in planets)
            {
                PaintSquare(rectangles[planet.Position.X][planet.Position.Y], e, pen.Brush);
            }
        }

        void RenderStations(Pen pen, PaintEventArgs e)
        {
            foreach (var station in stations)
            {
                PaintSquare(rectangles[station.Position.X][station.Position.Y], e, pen.Brush);
            }
        }

        void RenderMarker(Pen pen, PaintEventArgs e)
        {
            PaintFrame(rectangles[coordsToMove.X][coordsToMove.Y], e, pen.Brush);
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
                    rectangles[i][j] = new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize);
                }
            }
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
            //player.;
            player.Move(tempX, tempY);
        }


        void Refuil()
        {
            foreach (var station in stations)
            {
                if (player.Position == station.Position)
                {
                    player.refuelEngine(typeof(NuclearEngine));
                }
            }
        }

        bool CheckDectroying(Player player, Star[] stars)
        {
            foreach (var star in stars)
            {
                if (Math.Abs(player.Position.X - star.Position.X) <= star.DestroyRadius
                     && Math.Abs(player.Position.Y - star.Position.Y) <= star.DestroyRadius)
                    return true;
            }
            return false;
        }

        public GameForm(Player player)
        {

            InitializeComponent();
            this.player = player;

            rand = new Random();

            starsCount = rand.Next(1, 5);
            planetCount = rand.Next(1, 6);
            stationsCount = rand.Next(1, 3);


            stars = new Star[starsCount];
            planets = new Planet[planetCount];
            stations = new Station[stationsCount];

            for (int i = 0; i < stars.Length; i++)
            {
                int energyRadius = rand.Next(1, 3);
                stars[i] = new Star(new Point(rand.Next(energyRadius, CELLS_NUM - energyRadius), rand.Next(energyRadius, CELLS_NUM - energyRadius)), energyRadius, rand.Next(1, energyRadius), 20);
            }

            for (int i = 0; i < planets.Length; i++)
            {
                planets[i] = new Planet(new Point(rand.Next(CELLS_NUM), rand.Next(CELLS_NUM)));
            }

            for (int i = 0; i < stations.Length; i++)
            {
                stations[i] = new Station(new Point(rand.Next(CELLS_NUM), rand.Next(CELLS_NUM)));
            }


            //player = new Player(new Point(2, 4), CELLS_NUM*2);

            markerPen = new Pen(Brushes.Red);
            playerPen = new Pen(Brushes.Black);
            gridPed = new Pen(Brushes.Black);
            starPen = new Pen(Brushes.Yellow);
            starEnergyRadiusPen = new Pen(Brushes.LightYellow);
            starDestroyRadiusPen = new Pen(Brushes.Red);
            planetPen = new Pen(Brushes.LawnGreen);
            stationPen = new Pen(Brushes.BlueViolet);

            fuelLabel.Text = player.Fuel.ToString();

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

            Label[] labels = { engine1Label, engine2Label, engine3Label };
            fuelLabels = new Label[3] { engine1FuelLabel, engine2FuelLabel, engine3FuelLabel };

            for (int i = 0; i < player.EnginesCount; i++)
            {
                labels[i].Visible = true;
                fuelLabels[i].Visible = true;
                if (player.GetEngines()[i].GetType() == typeof(OilEngine))
                {
                    labels[i].Text = "Нефтяной";
                }
                else if (player.GetEngines()[i].GetType() == typeof(NuclearEngine))
                {
                    labels[i].Text = "Ядерный";
                }
            }

            //engine1Label.Text = player.GetEngines()[0].

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
                if (CheckDectroying(player, stars))
                {
                    Application.Exit();
                }
                refrashState = RefrashStates.None;
            }

            RenderPlayer(playerPen, e);


            for (int i = 0; i < player.EnginesCount; i++)
            {
                fuelLabels[i].Text = player.GetEngines()[i].Fuel.ToString();
            }

            fuelLabel.Text = player.Fuel.ToString();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < cellSize * CELLS_NUM && e.Y < cellSize * CELLS_NUM)
            {

                coordsToMove = new Point(e.X / cellSize, e.Y / cellSize);

                refrashState = RefrashStates.PlaceMarker;

                oldCoordsToMove = coordsToMove;
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
            if (player.Fuel > 0 && coordsToMove != player.Position)
                refrashState = RefrashStates.Turn;
            Refuil();

            panel1.Invalidate();
        }
    }
}

