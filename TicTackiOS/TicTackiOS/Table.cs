using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TicTackiOS
{
    enum ValeCell : byte
    {
        Empty,
        PlayerX,
        PlayerO
    }
    class Table
    {
        public ValeCell[] m_Values;
        
        bool m_TurnPlayerX;
       
        public bool GameOver { get; set; }

        public ValeCell m_Winner;

        public Table(ValeCell[] values, bool turnForPlayerX)
        {
            m_TurnPlayerX = turnForPlayerX;
            m_Values = values;
            ScoreGame();

        }
        public void ScoreGame()
        {
            int[,] PlayerWins = {
                             { 0, 1, 2 },
                             { 3, 4, 5 },
                             { 6, 7, 8 },
                             { 0, 3, 6 },
                             { 1, 4, 7 },
                             { 2, 5, 8 },
                             { 0, 4, 8 },
                             { 2, 4, 6 }
            };
            int countX = 0;
            int countO = 0;
            for (int i = PlayerWins.GetLowerBound(0); i <= PlayerWins.GetUpperBound(0); i++)
            {
                var one = m_Values[PlayerWins[i, 0]];
                var two = m_Values[PlayerWins[i, 1]];
                var three = m_Values[PlayerWins[i, 2]];
                var row = new ValeCell[] { one, two, three };
                countX = row.Count(x => x == ValeCell.PlayerX);
                countO = row.Count(y => y == ValeCell.PlayerO);
                if (countO == 3 || countX == 3)
                {
                    GameOver = true;
                     break;
                }          
            }
            m_Winner = countX == 3 ? ValeCell.PlayerX : countO == 3 ? ValeCell.PlayerO : ValeCell.Empty;
        }
                   
        public bool GameEnd()
        {
            if (GameOver)
                return true;

            foreach (ValeCell v in m_Values)
            {
                if (v == ValeCell.Empty)
                    return false;
            }
            return true;
        }           
        public Table GetNewBoard(int indexMove)
        {
            
            ValeCell[] NewValues = (ValeCell[])m_Values.Clone();
           
            if (m_Values[indexMove] != ValeCell.Empty)
                 throw new Exception(string.Format("Position [{0}] taken by {1}", indexMove, m_Values[indexMove]));
                

            NewValues[indexMove] = m_TurnPlayerX ? ValeCell.PlayerX : ValeCell.PlayerO;
            return new Table(NewValues, !m_TurnPlayerX);
        }
    }
    
    class Counter
    {
        public Table CurrentBoard { get; set; }

        public Counter()
        {
            ValeCell[] values = Enumerable.Repeat(ValeCell.Empty, 9).ToArray();
            CurrentBoard = new Table(values, true);
        }
        public void MakeMoveUser(int pos)
        {
            if (CurrentBoard.GameEnd())
                return;
            try
            {
    
                CurrentBoard = CurrentBoard.GetNewBoard(pos);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
