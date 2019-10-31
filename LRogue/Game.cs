using System;

namespace LRogue
{
    internal class Game
    {
        private Map map;
        private Hero hero;
        private bool gameInProgress;

        public Game()
        {

        }

        internal void Run()
        {
            Initialize();
            Play();
        }

        private void Play()
        {

            do
            {
                Draw();

            }

            //draw map
            //get command
            //execute action
            //draw map
            //Enemy actions
            //draw map
            while (gameInProgress) ;
        }

        private void Draw()
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            //TODO: Read from config later
            map = new Map(width: 10, height: 10);
            hero = new Hero();
        }
    }
}