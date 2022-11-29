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
using SpaceGame.Game.Objects;
using SpaceGame.Game.Utils;

namespace SpaceGame
{
    partial class GameForm : Form
    {
        int CELLS_NUM;
        int starsCount;
        int planetCount;
        int stationsCount;

        Player player;
        Pen playerPen;
        Pen gridPed;
        Pen starPen;
        Pen starEnergyRadiusPen;
        Pen starDestroyRadiusPen;
        Pen markerPen;
        Pen planetPen;
        Pen stationPen;
        Pen oilPen;


        Render render;
        Generation generation;

        Random rand;

        Star[] stars;
        Planet[] planets;
        Station[] stations;
        Oil[] oils;

        Point coordsToMove;
        Point oldCoordsToMove;
        Point playerPlanetCoords;

        RefrashStates refrashState;

        Label[] fuelLabels;

        int planetIndex = -1;

        bool isOnPlanet = false;



        void Refuil()
        {
            foreach (var station in stations)
            {
                if (player.Position == station.Position)
                    player.refuelEngine(typeof(NuclearEngine), 1);
            }

            foreach (var star in stars)
            {
                if (Math.Abs(player.Position.X - star.Position.X) <= star.EnergyRadius
                     && Math.Abs(player.Position.Y - star.Position.Y) <= star.EnergyRadius)
                    player.refuelEngine(typeof(SolarEngine), star.Power);
            }

        }


        bool CheckDectroying(Player player, Star[] stars)
        {
            foreach (var star in stars)
            {
                int r2 = (int)Math.Pow(player.Position.X - star.Position.X, 2) + (int)Math.Pow(player.Position.Y - star.Position.Y, 2);
                int r1 = (int)Math.Pow(star.DestroyRadius, 2);

                if (r2 <= r1)
                {
                    if (r2 <= (int)Math.Pow(1 + star.DestroyRadius - (int)Math.Abs(player.Position.X - star.Position.X), 2) ||
                                        r2 <= (int)Math.Pow(1 + star.DestroyRadius - (int)Math.Abs(player.Position.Y - star.Position.Y), 2))
                        return true;
                }
            }
            return false;
        }

        bool CheckPlanet()
        {
            for (int i = 0; i < planets.Length; i++)
            {
                if (player.Position == planets[i].Position)
                {
                    planetIndex = i;
                    return true;
                }
            }
            return false;
        }

        public GameForm(Player player, int cellsNum)
        {
            InitializeComponent();
            this.player = player;
            this.CELLS_NUM = cellsNum;

            generation = new Generation();
            rand = new Random();

            starsCount = rand.Next(1, CELLS_NUM/10);
            planetCount = rand.Next(1, CELLS_NUM/10);
            stationsCount = rand.Next(1, CELLS_NUM/20);

            planets = new Planet[planetCount];
            stations = new Station[stationsCount];


            bool wrongGeneration = false;
            int counts = 0;
            do
            {

                if (counts > 5) {
                    rand = new Random();
                    counts = 0;
                }

                wrongGeneration = false;
                stars = generation.GenerateStars(rand, starsCount, CELLS_NUM);
                stations = generation.GenerateStations(rand, planetCount, CELLS_NUM);
                planets = generation.GeneratePlanets(rand, planetCount, CELLS_NUM);

                foreach (var star in stars)
                {

                    if (Math.Abs(star.Position.X - player.Position.X) <= star.DestroyRadius + 2 ||
                            Math.Abs(star.Position.Y - player.Position.Y) <= star.DestroyRadius + 2)
                        wrongGeneration = true;

                    foreach (var planet in planets)
                    {
                        if (Math.Abs(star.Position.X - planet.Position.X) <= star.DestroyRadius + 2 ||
                            Math.Abs(star.Position.Y - planet.Position.Y) <= star.DestroyRadius + 2)
                            wrongGeneration = true;
                    }
                    foreach (var station in stations)
                    {
                        if (Math.Abs(star.Position.X - station.Position.X) <= star.DestroyRadius + 2 ||
                            Math.Abs(star.Position.Y - station.Position.Y) <= star.DestroyRadius + 2)
                            wrongGeneration = true;
                    }
                }


                foreach (var planet in planets)
                {
                    foreach (var station in stations)
                    {
                        if (Math.Abs(planet.Position.X - station.Position.X) <= 2 ||
                           Math.Abs(planet.Position.Y - station.Position.Y) <= 2)
                            wrongGeneration = true;
                    }
                }

                //for (int i = 0; i < stars.Length; i++)
                //{
                //    for (int j = i; j < stars.Length - 1; j++)
                //    {
                //        int radius = stars[i].DestroyRadius > stars[j].DestroyRadius ? stars[i].DestroyRadius : stars[j].DestroyRadius;
                //        if (Math.Abs(stars[i].Position.X - stars[j].Position.X) <= radius + 2 ||
                //           Math.Abs(stars[i].Position.Y - stars[j].Position.Y) <= radius + 2)
                //            wrongGeneration = true;
                //    }
                //}

            } while (wrongGeneration);




            markerPen = new Pen(Brushes.Red);
            playerPen = new Pen(Brushes.Black);
            gridPed = new Pen(Brushes.Black);
            starPen = new Pen(Brushes.Yellow);
            starEnergyRadiusPen = new Pen(Brushes.LightYellow);
            starDestroyRadiusPen = new Pen(Brushes.Red);
            planetPen = new Pen(Brushes.LawnGreen);
            stationPen = new Pen(Brushes.BlueViolet);
            oilPen = new Pen(Brushes.DarkGray);

            fuelLabel.Text = player.Fuel.ToString();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            render = new Render(generation.GenerateCells(CELLS_NUM, panel1.Height), CELLS_NUM);

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
                else if (player.GetEngines()[i].GetType() == typeof(SolarEngine))
                {
                    labels[i].Text = "Звёздный";
                }
            }

        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            render.RenderGrid(e, gridPed);
            render.RenderStars(stars, starPen, starEnergyRadiusPen, starDestroyRadiusPen, e);
            render.RenderPlanets(planets, planetPen, e);
            render.RenderStations(stations, stationPen, e);


            if (refrashState == RefrashStates.PlaceMarker || refrashState == RefrashStates.Turn)
                render.RenderMarker(coordsToMove, markerPen, e);

            if (refrashState == RefrashStates.Turn)
            {
                player.Move(coordsToMove);
                if (CheckDectroying(player, stars))
                {
                    Application.Exit();
                }
                if (CheckPlanet())
                {
                    planetButton.Visible = true;
                }
                else planetButton.Visible = false;
                refrashState = RefrashStates.None;
            }

            for (int i = 0; i < player.EnginesCount; i++)
            {
                fuelLabels[i].Text = player.GetEngines()[i].Fuel.ToString();
            }

            fuelLabel.Text = player.Fuel.ToString();

            render.RenderPlayer(player, playerPen, e);

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < generation.CellSize * CELLS_NUM && e.Y < generation.CellSize * CELLS_NUM)
            {

                coordsToMove = new Point(e.X / generation.CellSize, e.Y / generation.CellSize);

                refrashState = RefrashStates.PlaceMarker;

                oldCoordsToMove = coordsToMove;
                this.panel1.Invalidate();
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            if (coordsToMove != player.Position)
                refrashState = RefrashStates.Turn;
            Refuil();

            if (isOnPlanet)
            {
                foreach (var oil in planets[planetIndex].Oils)
                {
                    if (player.Position == oil.Position && !oil.IsEmpty)
                    {
                        foreach (var engine in player.GetEngines())
                        {
                            oil.DrawOil();
                            if (engine.GetType() == typeof(OilEngine) && engine.Fuel < engine.MaxCapacity)
                            {

                                player.refuelEngine(typeof(OilEngine), 1);
                            }
                            else
                            {
                                player.AddFuel();
                            }
                        }

                    }
                }
            }

            panel1.Invalidate();
        }

        private void planetButton_Click(object sender, EventArgs e)
        {
            if (!isOnPlanet)
            {
                if (planetIndex != -1)
                {
                    panel1.Paint -= panel1_Paint;
                    panel1.Paint += panel1_PaintPlanet;
                    isOnPlanet = true;
                    planetButton.Text = "Улететь с планеты";
                    playerPlanetCoords = planets[planetIndex].Position;
                    oils = planets[planetIndex].Oils;
                    panel1.Invalidate();
                }
            }
            else
            {
                panel1.Paint -= panel1_PaintPlanet;
                panel1.Paint += panel1_Paint;

                planetButton.Text = "Сесть на планету";
                isOnPlanet = false;
                player.Teleport(playerPlanetCoords);
                panel1.Invalidate();
            }
        }

        private void panel1_PaintPlanet(object sender, PaintEventArgs e)
        {
            render.RenderGrid(e, gridPed);
            render.RenderOil(oils, oilPen, e);

            if (refrashState == RefrashStates.PlaceMarker || refrashState == RefrashStates.Turn)
                render.RenderMarker(coordsToMove, markerPen, e);

            if (refrashState == RefrashStates.Turn)
            {
                player.Move(coordsToMove);
                refrashState = RefrashStates.None;
            }


            for (int i = 0; i < player.EnginesCount; i++)
            {
                fuelLabels[i].Text = player.GetEngines()[i].Fuel.ToString();
            }

            fuelLabel.Text = player.Fuel.ToString();

            render.RenderPlayer(player, playerPen, e);

        }
    }
}

