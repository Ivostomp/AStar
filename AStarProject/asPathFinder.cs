using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Drawing;

namespace AStarProject
{
    public class asPathFinder
    {
        public static int TimerInterval = 1;

        public static void FindPath(asTile start, asTile target, asGrid grid, bool allowDiagonal = true, bool instant = false) {

            grid.ClearPath();

            List<asTile> openTiles = new List<asTile>();
            List<asTile> closedTiles = new List<asTile>();
            openTiles.Add(start);

            if (!instant) {
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = TimerInterval;
                timer.Tick += (s, e) => {
                    //while (openTiles.Count > 0) {

                    if (openTiles.Count == 0) { timer.Stop(); return; }

                    var currentTile = openTiles.Where(q => q.fCost == openTiles.Min(t => t.fCost)).OrderBy(o => o.hCost).First();
                    openTiles.Remove(currentTile); closedTiles.Add(currentTile);

                    if (currentTile != start && currentTile != target) { currentTile.Type = TileType.Closed; }

                    //openTiles.Where(q => q.Type != TileType.Normal).ToList().ForEach(n => n.Type = TileType.Open);
                    //closedTiles.Where(q => q.Type == TileType.Normal).ToList().ForEach(n => n.Type = TileType.Closed);

                    if (currentTile == target) {
                        timer.Stop(); RetracePath(start, target); return;
                    }

                    foreach (var adjecentTile in grid.GetAdjecentTiles(currentTile, allowDiagonal)) {
                        if (!adjecentTile.Walkable || closedTiles.Contains(adjecentTile)) continue;


                        int newMovementCostToAdjecent = currentTile.gCost + Calc.GetDistance(currentTile, adjecentTile, allowDiagonal);
                        if (newMovementCostToAdjecent < adjecentTile.gCost || !openTiles.Contains(adjecentTile)) {
                            adjecentTile.gCost = newMovementCostToAdjecent;
                            adjecentTile.hCost = Calc.GetDistance(adjecentTile, target);
                            adjecentTile.ParentTile = currentTile;

                            if (!openTiles.Contains(adjecentTile)) {
                                if (adjecentTile != start && adjecentTile != target) { adjecentTile.Type = TileType.Open; }
                                openTiles.Add(adjecentTile);
                            }

                        }
                    }
                };
                timer.Start();
            } else {
                while(openTiles.Count > 0) { 
                    //if (openTiles.Count == 0) { return; }

                    var currentTile = openTiles.Where(q => q.fCost == openTiles.Min(t => t.fCost)).OrderBy(o => o.hCost).First();
                    openTiles.Remove(currentTile); closedTiles.Add(currentTile);

                    if (currentTile != start && currentTile != target) { currentTile.Type = TileType.Closed; }

                    //openTiles.Where(q => q.Type != TileType.Normal).ToList().ForEach(n => n.Type = TileType.Open);
                    //closedTiles.Where(q => q.Type == TileType.Normal).ToList().ForEach(n => n.Type = TileType.Closed);

                    if (currentTile == target) {
                        RetracePath(start, target); return;
                    }

                    foreach (var adjecentTile in grid.GetAdjecentTiles(currentTile, allowDiagonal)) {
                        if (!adjecentTile.Walkable || closedTiles.Contains(adjecentTile)) continue;


                        int newMovementCostToAdjecent = currentTile.gCost + Calc.GetDistance(currentTile, adjecentTile, allowDiagonal);
                        if (newMovementCostToAdjecent < adjecentTile.gCost || !openTiles.Contains(adjecentTile)) {
                            adjecentTile.gCost = newMovementCostToAdjecent;
                            adjecentTile.hCost = Calc.GetDistance(adjecentTile, target);
                            adjecentTile.ParentTile = currentTile;

                            if (!openTiles.Contains(adjecentTile)) {
                                if (adjecentTile != start && adjecentTile != target) { adjecentTile.Type = TileType.Open; }
                                openTiles.Add(adjecentTile);
                            }

                        }
                    }
                }
            }
        }

        private static void RetracePath(asTile start, asTile target) {
            var path = new List<asTile>();

            asTile current = target;

            while (current != start) {
                path.Add(current);
                current = current.ParentTile;
            }

            path.Reverse();

            foreach (var p in path) {
                if (p.Type == TileType.Start || p.Type == TileType.Target) { continue; }
                p.Type = TileType.Path;
                Console.WriteLine(p.ToString());
            }

            return;
        }
    }
}