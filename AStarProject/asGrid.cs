using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarProject
{
    public class asGrid : UserControl
    {
        public static TileType SelectType = TileType.Normal;

        private const double STARTENDTHRESHOLD = 0.5;

        //private List<asTiles> _Tiles = new List<asTiles>();
        private asTile[,] _Tiles;

        private List<asTile> _TilesCollection = new List<asTile>();

        public int Rows { get; set; } = 10;
        public int Colums { get; set; } = 10;

        public Size AreaSize = new Size(200, 200);

        public int Seed { get; set; } = 4217;//421337;

        public int TileSize { get { return (Math.Min(this.Size.Width, this.Size.Height) / Math.Max(Rows, Colums)); } }

        public asGrid() {
            Load += AsGrid_Load;
            _Tiles = new asTile[Colums, Rows];
            this.MouseMove += Grid_MouseMove;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e) {
            var tileX = e.X / TileSize;
            var tileY = e.Y / TileSize;

            Console.WriteLine($"Mouse at: {e.X}, {e.Y} --> {tileX}, {tileY}");

            _TilesCollection.FindAll(q => q.BackColor == Color.LimeGreen).ForEach(n => n.ResetColor());

            var tile = SearchTile(tileX, tileY);
            if (tile == null) return;
            tile.BackColor = Color.LimeGreen;

            if (e.Button == MouseButtons.Left) {
                tile.Type = asGrid.SelectType;
            } else if (e.Button == MouseButtons.Right) {
                tile.Type = TileType.Normal;
            }

        }

        public asGrid(int colums, int rows, int seed = 4217) : this() {
            Colums = colums;
            Rows = rows;
            _Tiles = new asTile[colums, rows];
            Seed = seed;
        }

        private void AsGrid_Load(object sender, EventArgs e) {
            InitTiles();
        }

        public void InitTiles() {
            Controls.Clear();
            _TilesCollection.Clear();

            for (int x = 0; x < Colums; x++) {
                for (int y = 0; y < Rows; y++) {
                    /*InitGrid();*/
                    var tile = new asTile(x, y, TileSize, TileType.Normal);
                    _TilesCollection.Add(tile);
                    Controls.Add(tile); 
                }
            }
        }

        public void Generate() {
            
            this.Reset();

            Random rand = new Random(Seed);

            for (int x = 0; x < Colums; x++) {
                for (int y = 0; y < Rows; y++) {
                    var randValue = rand.Next(0, 100);
                    var type = randValue > 30 ? TileType.Normal : TileType.NonWalkable;
                    //Console.WriteLine($"{randValue} - {walkable}");
                    var tile = _TilesCollection.Find(q => q.X == x && q.Y == y);
                    tile.Type = type;
                    //_Tiles[x, y] = tile;
                    //_TilesCollection.Add(tile);
                    //Controls.Add(tile);
                }
            }

            var walkableTiles = _TilesCollection.Where(q => q.Walkable).ToList();


            var startTile = walkableTiles[rand.Next(0, walkableTiles.Count - 1)];
            SetStartTile(startTile);

            var endTile = walkableTiles[rand.Next(0, walkableTiles.Count - 1)];
            var maxDiagnal = (Calc.GetDistance(_TilesCollection.First(), _TilesCollection.Last()));
            while (Calc.GetDistance(startTile, endTile) <= (maxDiagnal * STARTENDTHRESHOLD)) {
                endTile = walkableTiles[rand.Next(0, walkableTiles.Count - 1)];
            }
            SetEndTile(endTile);

            //foreach (var tile in walkableTiles.Where(q => q.Type == TileType.Normal && Calc.DistanceBetween(startTile, q) <= (maxDiagnal * STARTENDTHRESHOLD))) {
            //    tile.BackColor = Color.FromArgb(255,210,210);
            //}
        }

        public void ClearPath() {
            _TilesCollection.FindAll(q => q.Type == TileType.Path || q.Type == TileType.Closed || q.Type == TileType.Open).ForEach(q => q.Type = TileType.Normal);
        }

        public void Reset() {
            _TilesCollection.ForEach(q => q.Type = TileType.Normal);
        }

        public List<asTile> GetAdjecentTiles(asTile tile, bool allowDiagonal = true) {
            var tiles = _TilesCollection.FindAll(q =>
                (q.X >= (tile.X - 1) && q.X <= (tile.X + 1)) &&
                (q.Y >= (tile.Y - 1) && q.Y <= (tile.Y + 1))
            ).FindAll(q => !(q.X == tile.X && q.Y == tile.Y));

            if (!allowDiagonal) { tiles.RemoveAll(q => tile.X != q.X && tile.Y != q.Y); }

            return tiles;
        }

        public void FindPath(bool allowDiagonal, bool instant) {
            asPathFinder.FindPath(_TilesCollection.Find(q => q.Type == TileType.Start), _TilesCollection.Find(q => q.Type == TileType.Target), this, allowDiagonal, instant);
        }

        public void SetStartTile(int x, int y) {
            var tile = SearchTile(x, y);
            if (tile == null || !tile.Walkable) { Console.WriteLine($"No Walkable tile found ({x}, {y})");  return; }
            SetStartTile(tile);
        }
        public void SetStartTile(asTile tile) {
            tile.BackColor = Color.Blue;
            tile.Type = TileType.Start;
        }

        public void SetEndTile(int x, int y) {
            var tile = SearchTile(x, y);
            if (tile == null || !tile.Walkable) { Console.WriteLine($"No Walkable tile found ({x}, {y})"); return; }
            SetEndTile(tile);
        }
        public void SetEndTile(asTile tile) {
            tile.BackColor = Color.Red;
            tile.Type = TileType.Target;
        }

        public asTile SearchTile(int x, int y) { return _TilesCollection.Find(f => f.X == x && f.Y == y); }
    }
}
