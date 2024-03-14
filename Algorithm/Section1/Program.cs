namespace Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board2 board = new Board2();
            board.Initialize();


            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;
            const char CIRCLE = '\u25cf';
            int lastTick = 0;
            while(true)
            {
                #region 프레임 관리
                // FPS 프레임(60프레임 OK, 30프레임 이하 NO)

                int currenTick = System.Environment.TickCount; // 현재 시간, 시스템이 시작된 이후의 경과된 m/s 
                // int elapsedTick = currenTick - lastTick; // 경과한 시간 = 현재 시간 - 지난 시간

                // 만약에 경과한 시간이 1 * 1000/30초보다 작다면 (밀리 새컨드 단위라서 * 1000)
                if (currenTick - lastTick < WAIT_TICK) continue;

                lastTick = currenTick;
                #endregion

                // 입력

                // 로직

                // 렌더링
                Console.SetCursorPosition(0,0);
                for(int i = 0; i<25; i++)
                {
                    for(int j =0; j<25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }
                    Console.WriteLine();
                }
            }        
        }
    }
}
