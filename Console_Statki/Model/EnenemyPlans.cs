using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Statki.Model;

namespace Console_Statki.Model
{
    class EnenemyPlans
    {
        public static int Point { get; set; }
        //public static int[] State { get; set; }
        public  Coordinate[] State { get; set; }
        public static int[,] Matrix { get; set; }
        public static int[] RestPoints { get; set; }
        public static Coordinate coordinate { get; set; }
        public static int Available { get; set; }
        public static int Queue { get; set; }

        public EnenemyPlans()
        {
            RestPoints = new int[100];
            Available = 100;
            Queue = 0;
            for (int i = 0; i < Available; i++)
            {
                RestPoints[i] = i;
            }

        }

        public void RemovePoint(int param)
        {
            for (int i = 0; i <= param; i++)
            {
                if (param>=0 && param<=99)
                if (RestPoints[i] == param)
                {
                    for (int j = i; j < Available - 1; j++)
                    {
                        RestPoints[j] = RestPoints[j + 1];
                    }
                    Available--;
                    break;
                }
            }

        }

        public Coordinate Shoot(bool result,PlayerMatrix pM) // ta pizda na granicy x0 lub x9 
        
        {
            Available = 0;
            for (int i = 0; i < 10;i++ )
            {
                for(int j=0;j<10;j++)
                {
                    if (pM.playerMatrix[i, j] != 123 && pM.playerMatrix[i, j] != 999 && pM.playerMatrix[i, j] != 321/* && pM.playerMatrix[i, j] != 9 && pM.playerMatrix[i, j] != 18*/)
                    {
                        RestPoints[Available++] = i * 10 + j; 
                    }
                }
            }
                if (!result)
                {
                    if (Queue == 0) //nie trafił i nie był w sekwencji
                    {
                        Random r = new Random();
                        int random = r.Next(0, Available);
                        coordinate = new Coordinate(RestPoints[random]);
                        RemovePoint(RestPoints[random]);
                        return coordinate;
                    }
                    else // nie trafił ale był w sekwencji
                    {
                        coordinate = State[Matrix[0, Point]];

                        if (coordinate.X > 9 || coordinate.X < 0 || coordinate.Y > 9 || coordinate.Y < 0)
                        {
                            while (coordinate.X > 9 || coordinate.X < 0 || coordinate.Y > 9 || coordinate.Y < 0)
                            {

                                Point = Matrix[0, Point];
                                coordinate = State[Matrix[0, Point]];


                            }
                            //   coordinate = CheckisFree(coordinate, 0);
                        }
                        else
                        {
                            Point = Matrix[0, Point];
                            ///coordinate = CheckisFree(coordinate, 0);
                        }

                        RemovePoint(State[Point].X * 10 + State[Point].Y);
                        Queue++;
                        return coordinate;
                    }
                }
                else
                {
                    if (Queue == 0)
                    {
                        Coordinate point = FirstHit(coordinate);
                        Queue++;
                        coordinate = point;
                        if (coordinate.X > 9 || coordinate.X < 0 || coordinate.Y > 9 || coordinate.Y < 0)
                        {
                            while (coordinate.X > 9 || coordinate.X < 0 || coordinate.Y > 9 || coordinate.Y < 0)
                            {
                                coordinate = State[Matrix[0, Point]];
                                Point = Matrix[0, Point];
                            }
                            //coordinate = CheckisFree(coordinate, 0);
                        }
                    }
                    else
                    {
                        Queue++;
                        coordinate = State[Matrix[1, Point]];
                        if (coordinate.X > 9 || coordinate.X < 0 || coordinate.Y > 9 || coordinate.Y < 0)
                        {
                            while (coordinate.X > 9 || coordinate.X < 0 || coordinate.Y > 9 || coordinate.Y < 0)
                            {
                                coordinate = State[Matrix[0, Point]];
                                Point = Matrix[0, Point];


                            }
                            // coordinate = CheckisFree(coordinate, 0);

                        }
                        else
                        {
                            Point = Matrix[1, Point];
                            // coordinate = CheckisFree(coordinate, 1);
                        }


                    }


                    RemovePoint(State[Point].X * 10 + State[Point].Y);
                    return coordinate;

                }
        }

        public Coordinate FirstHit(Coordinate coordinate)
        {
            int point = coordinate.X * 10 + coordinate.Y;

            State = new Coordinate[12];
            Matrix = new int[2, 11];
            /*  State[0] = point - 10;
              State[1] = point - 1;
              State[2] = point + 1;
              State[3] = point + 10;
              State[4] = point - 20;
              State[5] = point - 30;
              State[6] = point - 2;
              State[7] = point - 3;
              State[8] = point + 2;
              State[9] = point + 3;
              State[10] = point + 20;
              State[11] = point + 30;*/
            for (int i = 0; i < 12; i++ )
            State[i] = new Coordinate();

            State[0].X = point / 10 - 1;
            State[0].Y = point % 10;
            State[1].X = point / 10;
            State[1].Y = point % 10 - 1;
            State[2].X = point / 10;
            State[2].Y = point % 10 + 1;
            State[3].X = point / 10 + 1;
            State[3].Y = point % 10;
            State[4].X = point / 10 - 2;
            State[4].Y = point % 10;
            State[5].X = point / 10 - 3;
            State[5].Y = point % 10;
            State[6].Y = point % 10 - 2;
            State[6].X = point / 10;
            State[7].Y = point % 10 - 3;
            State[7].X = point / 10;
            State[8].Y = point % 10 + 2;
            State[8].X = point / 10;
            State[9].Y = point % 10 + 3;
            State[9].X = point / 10;
            State[10].X = point / 10 + 2;
            State[10].Y = point % 10;
            State[11].X = point / 10 + 3;
            State[11].Y = point % 10;

            Matrix[0, 0] = 1;
            Matrix[0, 1] = 2;
            Matrix[0, 2] = 3;
            Matrix[0, 4] = 3;
            Matrix[0, 5] = 3;
            Matrix[0, 6] = 2;
            Matrix[0, 7] = 2;
 
            Matrix[1, 0] = 4;
            Matrix[1, 1] = 6;
            Matrix[1, 2] = 8;
            Matrix[1, 3] = 10;
            Matrix[1, 4] = 5;
            Matrix[1, 6] = 7;
            Matrix[1, 8] = 9;
            Matrix[1, 10] = 11;

            Point = 0;

            return State[Point];
        }

        public void IsDefeat(bool result, PlayerMatrix pM, int lenght, int truex, int truey, int rotate)
        {
            
            if (result == true)
            {
                Queue = 0;
            
            }
        }

        //public Coordinate CheckisFree(Coordinate coordinate, int result)
        
        //{
        //    int i = 0;
        //    while (i == 0)
        //    {
        //        for (int g = 0; g < 100; g++)
        //        {
        //            if (State[Point].X * 10 + State[Point].Y == RestPoints[g])
        //            {
        //                i = 1;
        //                Point = Matrix[result, Point];
        //                break;
        //            }

        //        }
        //        if (i == 0)
        //        {
        //            coordinate = State[Matrix[0, Point]];
        //            Point = Matrix[0, Point];
        //            if (coordinate.X > 9 || coordinate.X < 0 || coordinate.Y > 9 || coordinate.Y < 0)
        //                while (coordinate.X > 9 || coordinate.X < 0 || coordinate.Y > 9 || coordinate.Y < 0)
        //                {
        //                    coordinate = State[Matrix[0, Point]];
        //                    Point = Matrix[0, Point];


        //                }

        //        }
        //    }
        //    RemovePoint(State[Point].X * 10 + State[Point].Y);
        //    return coordinate;
        //} //do zrobienia żeby gracz nie miał forów
    }
}
