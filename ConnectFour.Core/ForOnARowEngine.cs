using System;
using System.Collections.Generic;

namespace ForOnARow.core
{
    public class ForOnARowEngine
    {
        public char?[] Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Turn { get; set; }

        public ForOnARowEngine()
        {
            Player1 = new Player('X');
            Player2 = new Player('O');
            Board = new char?[42];
            Turn = new Random().Next(1, 3);
        }

        public bool Validate(int rowNumber)
        {
            int position = GetPosition(rowNumber);
            AddMove(position);
            bool gameDone = CalculateGameDone();
            SwitchTurn();
            return gameDone;
        }

        private bool CalculateGameDone()
        {
            bool won = false;
            int counter = 0;

            for (int i = 0; i < Board.Length; i++)
            {
                if (Board[i].HasValue)
                {
                    if (won) continue;
                    for (int j = 0; j < 8; j++)
                    {
                        if (counter < 4)
                        {
                            switch (j)
                            {
                                case 0:
                                    counter = CalculateSameInARow(i, Direction.RIGHT, 1);
                                    break;
                                case 1:
                                    counter = CalculateSameInARow(i, Direction.BOTTOM_RIGHT, 1);
                                    break;
                                case 2:
                                    counter = CalculateSameInARow(i, Direction.BOTTOM, 1);
                                    break;
                                case 3:
                                    counter = CalculateSameInARow(i, Direction.BOTTOM_LEFT, 1);
                                    break;
                                case 4:
                                    counter = CalculateSameInARow(i, Direction.LEFT, 1);
                                    break;
                                case 5:
                                    counter = CalculateSameInARow(i, Direction.TOP_LEFT, 1);
                                    break;
                                case 6:
                                    counter = CalculateSameInARow(i, Direction.TOP, 1);
                                    break;
                                case 7:
                                    counter = CalculateSameInARow(i, Direction.TOP_RIGHT, 1);
                                    break;
                            }
                        }
                        else
                        {
                            won = true;
                        }
                    }
                }
            }

            return won;
        }

        private int CalculateSameInARow(int position, Direction direction, int counter)
        {
            var result = counter;

            var left = position - 1;
            var topLeft = position + 6;
            var top = position + 7;
            var topRight = position + 8;
            var right = position + 1;
            var bottomRight = position - 6;
            var bottom = position - 7;
            var bottomLeft = position - 8;

            switch (direction)
            {
                case Direction.RIGHT:
                    if (right <= 41 && right != 35 && right != 28 && right != 21 && right != 14 && right != 7)
                    {
                        if (Board[position] == Board[right])
                        {
                            result = CalculateSameInARow(right, Direction.RIGHT, result + 1);
                        }
                    }

                    break;
                case Direction.BOTTOM_RIGHT:
                    if (right <= 41 && right != 35 && right != 28 && right != 21 && right != 14 && right != 7)
                    {
                        if (bottomRight >= 0)
                        {
                            if (Board[position] == Board[bottomRight])
                            {
                                result = CalculateSameInARow(bottomRight, Direction.BOTTOM_RIGHT, result + 1);
                            }
                        }
                    }

                    break;
                case Direction.BOTTOM:
                    if (bottom >= 0)
                    {
                        if (Board[position] == Board[bottom])
                        {
                            result = CalculateSameInARow(bottom, Direction.BOTTOM, result + 1);
                        }
                    }

                    break;
                case Direction.BOTTOM_LEFT:
                    if (left >= 0 && left != 6 && left != 13 && left != 20 && left != 27 && left != 34)
                    {
                        if (bottom >= 0)
                        {
                            if (Board[position] == Board[bottomLeft])
                            {
                                result = CalculateSameInARow(bottomLeft, Direction.BOTTOM_LEFT, result + 1);
                            }
                        }
                    }

                    break;
                case Direction.LEFT:
                    if (left >= 0 && left != 6 && left != 13 && left != 20 && left != 27 && left != 34)
                    {
                        if (Board[position] == Board[left])
                        {
                            result = CalculateSameInARow(left, Direction.LEFT, result + 1);
                        }
                    }

                    break;
                case Direction.TOP_LEFT:
                    if (left >= 0 && left != 6 && left != 13 && left != 20 && left != 27 && left != 34)
                    {
                        if (top <= 41)
                        {
                            if (Board[position] == Board[topLeft])
                            {
                                result = CalculateSameInARow(topLeft, Direction.TOP_LEFT, result + 1);
                            }
                        }
                    }

                    break;
                case Direction.TOP:
                    if (top <= 41)
                    {
                        if (Board[position] == Board[top])
                        {
                            result = CalculateSameInARow(top, Direction.TOP, result + 1);
                        }
                    }

                    break;
                case Direction.TOP_RIGHT:
                    if (right <= 41 && right != 35 && right != 28 && right != 21 && right != 14 && right != 7)
                    {
                        if (top <= 41)
                        {
                            if (Board[position] == Board[topRight])
                            {
                                result = CalculateSameInARow(topRight, Direction.TOP_RIGHT, result + 1);
                            }
                        }
                    }
                    break;
            }
            return result;
        }

        private int GetPosition(int rowNumber)
        {
            var result = 0;
            for (int i = 0; i < 6; i++)
            {
                if (Board[rowNumber - 1 + (7 * i)].HasValue) continue;
                result = rowNumber - 1 + (7 * i);
                break;
            }

            return result;
        }

        public void AddMove(int position)
        {
            Board[position] = GetPlayerOnTurn().Symbol;
        }

        public Player GetPlayerOnTurn()
        {
            Player player;
            switch (Turn)
            {
                case 1:
                {
                    player = Player1;
                    break;
                }
                case 2:
                {
                    player = Player2;
                    break;
                }
                default:
                    player = Player1;
                    break;
            }

            return player;
        }

        public void SwitchTurn()
        {
            if (Turn == 1) Turn++;
            else Turn--;
        }
    }
}