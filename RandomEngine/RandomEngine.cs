﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkingEngine
{
    /////////////////////////////////////////
    //  思考エンジンのサンプル
    //////////////////////////////////////////

    /// <summary>
    /// 乱数にしたがって次の手を決定する
    /// </summary>
    public class RandomThinking : ThinkingEngineBase.IThinkingEngine
    {
        /// <summary>
        /// 思考時間の上限を設定する
        /// </summary>
        /// <param name="milliSecond"></param>
        public void SetTimeLimit(int milliSecond)
        {
            //今は実装しない
        }
        //オセロの局面
        Reversi.Core.ReversiBoard board;
        //先手または後手
        Reversi.Core.StoneType player;
        //合法手のリスト
        List<Reversi.Core.ReversiMove> legalMoves = new List<Reversi.Core.ReversiMove>();

        /// <summary>
        /// 盤の情報をもとに思考し、次の手を返す
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public Reversi.Core.ReversiMove Think(Reversi.Core.ReversiBoard board, Reversi.Core.StoneType player)
        {
            this.board = board;
            this.player = player;
            legalMoves = board.SearchLegalMoves(player); //合法手
            if (legalMoves.Count ==0)
            {
                throw new InvalidOperationException("合法手がありません");
            }
            else
            {
                //乱数を生成して次の手を決定
                var random = new Random().Next(legalMoves.Count);
                return legalMoves[random];
            }
        }
        
    }
}
