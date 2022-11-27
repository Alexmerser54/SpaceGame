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
    class Render
    {
        Rectangle[][] rectangles;
        int cellCount;

        public Render(Rectangle[][] rectangles, int cellCount)
        {
            this.rectangles = rectangles;
            this.cellCount = cellCount;
        }

        void PaintSquare(Rectangle rect, PaintEventArgs e, Brush brush)
        {
            e.Graphics.FillRectangle(brush, rect);
        }

        void PaintFrame(Rectangle rect, PaintEventArgs e, Pen pen)
        {
            e.Graphics.DrawRectangle(pen, rect);
        }

        public void RenderObject(GameObject gameObject, Pen pen, PaintEventArgs e)
        {
            PaintSquare(rectangles[gameObject.Position.X][gameObject.Position.Y], e, pen.Brush);
        }

        public void RenderObjects(GameObject[] gameObjects, Pen pen, PaintEventArgs e)
        {
            foreach (var gameObject in gameObjects)
            {
                RenderObject(gameObject, pen, e);
            }
        }

        public void RenderPlayer(Player player, Pen pen, PaintEventArgs e)
        {
            RenderObject(player, pen, e);
        }

        public void RenderOil(Oil[] oils, Pen pen, PaintEventArgs e)
        {
            foreach (var oil in oils)
            {
                if (!oil.IsEmpty)
                    RenderObject(oil, pen, e);
            }

        }

        public void RenderPlanets(Planet[] planets, Pen pen, PaintEventArgs e)
        {
            RenderObjects(planets, pen, e);
        }

        public void RenderStations(Station[] stations, Pen pen, PaintEventArgs e)
        {
            RenderObjects(stations, pen, e);
        }

        public void RenderStars(Star[] stars, Pen starPen, Pen energyRadiusPen, Pen destroyRadiusPen, PaintEventArgs e)
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

                startX = star.Position.X - star.Size;
                startY = star.Position.Y;
                endX = startX + 2 * star.Size + 1;

                for (int i = 0; i <= star.Size; i++)
                {
                    for (int j = startX; j < endX; j++)
                    {
                        PaintSquare(rectangles[j][startY + i], e, starPen.Brush);
                        PaintSquare(rectangles[j][startY - i], e, starPen.Brush);
                    }
                    startX++;
                    endX--;
                }

                //for (int i = -star.Size; i < -star.Size; i++)
                //{
                //    for (int j = -star.Size; j < -star.Size; j++)
                //    {
                //        PaintSquare(rectangles[j][i], e, destroyRadiusPen.Brush);
                //    }
                //}

                //RenderObject(star, starPen, e);
                //PaintSquare(rectangles[star.Position.X][star.Position.Y], e, starPen.Brush);
            }
        }


        void RenderOils(Planet planet, Pen pen, PaintEventArgs e)
        {

            foreach (var oil in planet.Oils)
            {
                if (!oil.IsEmpty)
                    PaintSquare(rectangles[oil.Position.X][oil.Position.Y], e, pen.Brush);
            }
        }

        //void RenderStations(Pen pen, PaintEventArgs e)
        //{
        //    foreach (var station in stations)
        //    {
        //        PaintSquare(rectangles[station.Position.X][station.Position.Y], e, pen.Brush);
        //    }
        //}

        public void RenderMarker(Point pos, Pen pen, PaintEventArgs e)
        {
            PaintFrame(rectangles[pos.X][pos.Y], e, pen);
        }

        public void RenderGrid(PaintEventArgs e, Pen pen)
        {
            for (int i = 0; i < cellCount; i++)
            {
                e.Graphics.DrawRectangles(pen, rectangles[i]);
            }
        }
    }
}