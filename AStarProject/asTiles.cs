using System;
using System.Drawing;
using System.Windows.Forms;

namespace AStarProject
{
    public class asTile : Panel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Walkable { get { return !(_Type == TileType.NonWalkable); } }

        private TileType _Type = TileType.Normal;

        public TileType Type { get { return _Type; } set { _Type = value; SetTileColor(); } }


        public asTile ParentTile { get; set; }

        private Label _DebugLabel;

        private Color _originalColor;

        /// <summary>
        /// Distance from start
        /// </summary>
        public int gCost { get; set; }
        /// <summary>
        /// (Heuristic) Distance from end node
        /// </summary>
        public int hCost { get; set; }
        /// <summary>
        /// full cost (Gcost + Hcost)
        /// </summary>
        public int fCost { get { return (gCost + hCost); } }

        public asTile(int x, int y, int size, TileType type) : this() {
            // set basic parameters
            X = x; Y = y; Size = new Size(size, size); Type = type;
            
            // set print location
            Location = new Point(X * Size.Width, Y * Size.Height);

            #if DEBUG
            _DebugLabel = new Label();
            _DebugLabel.Text = $"{X}, {Y}";
            _DebugLabel.Font = new Font(FontFamily.GenericSansSerif, 6.0f);
            //_DebugLabel.MouseEnter += Tile_MouseEnter;
            //_DebugLabel.MouseLeave += Tile_MouseLeave;
            Controls.Add(_DebugLabel);
            #endif
        }

        public asTile() {
            //MouseEnter += Tile_MouseEnter;
            //MouseLeave += Tile_MouseLeave;
            //MouseClick += Tile_MouseClick;
            //MouseMove += Tile_MouseClick;
        }

        private void SetTileColor() {
            switch (_Type) {
                case TileType.Normal:
                    BackColor = _originalColor = Color.FromArgb(230, 230, 230);
                    break;
                case TileType.NonWalkable:
                    BackColor = _originalColor = Color.Black;
                    break;
                case TileType.Start:
                    BackColor = _originalColor = Color.Blue;
                    break;
                case TileType.Target:
                    BackColor = _originalColor = Color.Red;
                    break;
                case TileType.Path:
                    BackColor = _originalColor = Color.SteelBlue;
                    break;
                case TileType.Closed:
                    BackColor = _originalColor = Color.Orange;
                    break;
                case TileType.Open:
                    BackColor = _originalColor = Color.LightGreen;
                    break;
            }
        }

        private void Tile_MouseLeave(object sender, EventArgs e) {
            BackColor = _originalColor;
        }

        private void Tile_MouseEnter(object sender, EventArgs e) {
            BackColor = Color.GreenYellow;
        }

        private void Tile_MouseClick(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) { 
                this.Type = asGrid.SelectType;
            } else if (e.Button == MouseButtons.Right) {
                this.Type = TileType.Normal;
            }
        }

        public override string ToString() {
            string walkString = Walkable ? "Walkable" : "Not-Walkable";
            return $"({X}, {Y}) {walkString} g:{gCost} h:{hCost} f:{fCost} ";
        }

        protected override void WndProc(ref Message m) {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST) {
                m.Result = (IntPtr)HTTRANSPARENT;
            } else {
                base.WndProc(ref m);
            }
        }

        public void ResetColor() { this.BackColor = _originalColor; } 
    }

    public enum TileType
    {
        Normal,
        NonWalkable,
        Start,
        Target,
        Path,
        Closed,
        Open
    }
}