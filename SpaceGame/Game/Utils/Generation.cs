using SpaceGame.Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceGame.Game.Utils
{
    class Generation
    {
        int cellSize;

        public Rectangle[][] GenerateCells(int CELLS_NUM, int sizeOfField )
        {
            cellSize = sizeOfField / CELLS_NUM;
            Rectangle[][] rectangles = new Rectangle[CELLS_NUM][];
            for (int i = 0; i < CELLS_NUM; i++)
            {
                rectangles[i] = new Rectangle[CELLS_NUM];
                for (int j = 0; j < CELLS_NUM; j++)
                {
                    rectangles[i][j] = new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize);
                }
            }
            return rectangles;
        }

        public int CellSize => cellSize; 

        public Star[] GenerateStars(Random rand, int count, int CELLS_NUM)
        {
            Star[] stars = new Star[count];
            for (int i = 0; i < count; i++)
            {
                int energyRadius = rand.Next(1, 3);
                stars[i] = new Star(new Point(rand.Next(energyRadius, CELLS_NUM - energyRadius), rand.Next(energyRadius, CELLS_NUM - energyRadius)), energyRadius, rand.Next(1, energyRadius), 20);
            }
            return stars;
        }

        public Planet[] GeneratePlanets(Random rand, int count, int CELLS_NUM)
        {
            Oil[] oils;
            Planet[] planets = new Planet[count];
            for (int i = 0; i < count; i++)
            {
                oils = GenerateOils(rand, rand.Next(1, 7), CELLS_NUM);
                planets[i] = new Planet(new Point(rand.Next(CELLS_NUM), rand.Next(CELLS_NUM)), oils);
            }
            return planets;
        }

        public Station[] GenerateStations(Random rand, int count, int CELLS_NUM)
        {
            Station[] stations = new Station[count];
            for (int i = 0; i < count; i++)
            {
                stations[i] = new Station(new Point(rand.Next(CELLS_NUM), rand.Next(CELLS_NUM)));
            }
            return stations;
        }

        public Oil[] GenerateOils(Random rand, int count, int CELLS_NUM)
        {
            Oil[] oils = new Oil[count];
            for (int i = 0; i < count; i++)
            {
                oils[i] = new Oil(rand.Next(1, 5), new Point(rand.Next(CELLS_NUM), rand.Next(CELLS_NUM)));
            }
            return oils;
        }
    }
}
