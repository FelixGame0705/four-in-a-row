using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AI 
{
   
    static int MIN = -1000;
    static int MAX = 1000;
    public class Move
    {
        public int row, column;
    }
    static int Evaluate(int[,] board)
    {
        for(int row= 0; row < GameBoard.Instance.row; row++)
        {
            for(int column= 0; column < GameBoard.Instance.column; column++) {

                if (column <= GameBoard.Instance.column - 4)
                {

                    if (board[column, row] == 1 && board[column + 1, row] == 1 && board[column + 2, row] == 1 && board[column + 3, row] == 1)
                    {

                        return 10;
                    }
                    else if (board[column, row] == 2 && board[column + 1, row] == 2 && board[column + 2, row] == 2 && board[column + 3, row] == 2)
                    {
                        return -10;
                    }
                }
                if (row <= GameBoard.Instance.row - 4)
                {
                    if (board[column, row] == 1 && board[column, row + 1] == 1 && board[column, row + 2] == 1 && board[column, row + 3] == 1)
                    {

                        return 10;
                    }
                    else if (board[column, row] == 2 && board[column, row + 1] == 2 && board[column, row + 2] == 2 && board[column, row + 3] == 2)
                    {

                        return -10;
                    }
                }
                if (column > 4 && row <= GameBoard.Instance.row - 4)
                {
                    if (board[column, row] == 1 && board[column - 1, row + 1] == 1 && board[column - 2, row + 2] == 1 && board[column - 3, row + 3] == 1)
                    {
                        return 10;
                    }
                    else if (board[column, row] == 2 && board[column - 1, row + 1] == 2 && board[column - 2, row + 2] == 2 && board[column - 3, row + 3] == 2)
                    {
                        return -10;
                    }
                }
                if (column <= GameBoard.Instance.column - 4 && row <= GameBoard.Instance.row - 4)
                {
                    if (board[column, row] == 1 && board[column + 1, row + 1] == 1 && board[column + 2, row + 2] == 1 && board[column + 3, row + 3] == 1)
                    {
                        return 10;
                    }
                    else if (board[column, row] == 2 && board[column + 1, row + 1] == 2 && board[column + 2, row + 2] == 2 && board[column + 3, row + 3] == 2)
                    {
                        return -10;
                    }
                }
            }
        }
                
        return 0;
        
    }
    


    public static bool isArgee(int[,] board, int column, int row)
    {
       // Debug.Log(column + "  " + row);
        if (row == 0 && board[column, row] == 0) return true;
        else if (row > 0 && board[column, row] == 0)
        {
            if (board[column, row - 1] != 0)
            {

                return true;
            }
        }
        
        return false;
    }
    static int miniMax(int[,] board, int depth, bool isMax, int alpha, int beta,int breakDepth)
    {
        int score = Evaluate(board);
        if (score == 10) return score - depth;
        if (score == -10) return score + depth;
        if (depth == breakDepth) return score;

        if (isMax)
        {
            
            int best = MIN;

            for (int row = 0; row < GameBoard.Instance.row; row++)
            {
                for (int column = 0; column < GameBoard.Instance.column; column++)
                {
                    if (isArgee(board, column, row))
                    {
                        
                        board[column, row] = 1;

                        best = Mathf.Max(best, miniMax(board, depth + 1, !isMax, alpha, beta,breakDepth));
                        alpha = Mathf.Max(beta, best);
                        board[column, row] = 0;
                        if (beta <= alpha) break;

                    }
                }
            }
            return best;
        }
        else
        {
            
            int best = MAX;
            for (int row = 0; row < GameBoard.Instance.row; row++)
            {
                for (int column = 0; column < GameBoard.Instance.column; column++)
                {
                    if (isArgee(board, column, row))
                    {
                        
                        board[column, row] = 2;

                        best = Mathf.Min(best, miniMax(board, depth + 1, !isMax, alpha, beta,breakDepth));
                        board[column, row] = 0;
                        beta = Mathf.Min(beta, best);
                        if (beta <= alpha) break;
                    }
                }
            }
            return best;
        }
        
    }

    public static Move bestMove(int[,] board,int breakDepth)
    {
        
        Move bestMove = new Move();
        int bestVal = MIN;
        bestMove.row = -1;
        bestMove.column = -1;
       
        for (int i = 0; i < GameBoard.Instance.row; i++)
        {
            for (int j = 0; j < GameBoard.Instance.column; j++)
            {
               
                if (isArgee(board, j, i) == true)
                {
                   
                    board[j, i] = 1;//đánh đầu tiên
                    int moveVal = miniMax(board, 0, false, MIN, MAX,breakDepth);
                    board[j, i] = 0;
                    if (moveVal > bestVal)
                    {
                        bestMove.row = i;
                        bestMove.column = j;
                        bestVal = moveVal;
                    }
                }
            }
        }
        return bestMove;
    }
   
}
