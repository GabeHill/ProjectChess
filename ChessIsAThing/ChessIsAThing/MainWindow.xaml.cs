using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessIsAThing {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private bool dragging;

        private Point[][] points = new Point[][]{
            new Point[8],
            new Point[8],
            new Point[8],
            new Point[8],
            new Point[8],
            new Point[8],
            new Point[8],
            new Point[8]
        };

        public MainWindow() {
            InitializeComponent();

            //Add colored rectangles to grid to create board
            for(int i = 0; i<grdMain.RowDefinitions.Count-1; i++) {
                for(int j = 0; j<grdMain.ColumnDefinitions.Count-1; j++) {

                    Rectangle r = new Rectangle();
                    if(i%2==0) {
                        switch(j) {
                            case 1:
                            case 3:
                            case 5:
                            case 7:
                                r.Fill=new SolidColorBrush(Colors.Black);
                                break;
                            default:
                                r.Fill=new SolidColorBrush(Colors.White);
                                break;
                        }
                    } else if(j%2==0) {
                        r.Fill=new SolidColorBrush(Colors.Black);
                    } else {
                        r.Fill=new SolidColorBrush(Colors.White);
                    }
                    
                    grdMain.Children.Add(r);
                    Grid.SetColumn(r, j);
                    Grid.SetRow(r, i);

                    setBoard();

                    points[i][j]=new Point(i,j);
                }
            }
            
        }

        private void setBoard() {


            //r.MouseLeftButtonDown+=rectMouseButtonDown;
            //r.MouseLeftButtonUp+=rectMouseButtonUp;
            //r.MouseMove+=rectMouseMove;
        }

        private void cnvSnapToGrid(Rectangle r) {
            int xPos = (int)(Canvas.GetTop(r)/100);
            int yPos = (int)(Canvas.GetLeft(r)/100);

            Canvas.SetTop(r,xPos*100);
            Canvas.SetLeft(r, yPos*100);
        }

        private void rectMouseMove(object sender,MouseEventArgs e) {
            if(!dragging) return;

            var mousePos = e.GetPosition(grdMain);

            double left = mousePos.X-(((Rectangle)sender).ActualWidth/2);
            double top = mousePos.Y-(((Rectangle)sender).ActualHeight/2);
            Canvas.SetLeft(((Rectangle)sender), left);
            Canvas.SetTop(((Rectangle)sender), top);
        }

        private void rectMouseButtonDown(object sender, MouseButtonEventArgs e) {
            dragging=true;
            ((Rectangle)sender).CaptureMouse();
        }

        private void rectMouseButtonUp(object sender, MouseButtonEventArgs e) {
            dragging=false;
            ((Rectangle)sender).ReleaseMouseCapture();

// TODO make snap to grid of stuff yeah idk

        }

    }
}

