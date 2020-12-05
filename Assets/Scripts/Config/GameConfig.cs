namespace Config
{
    public static class GameConfig
    {
        public const int POOL_INITIAL_COUNT = 50;


        #region Physics Settings

        public const int COLLECTABLE_LAYER = 8;
        public const int DEFAULT_LAYER = 0;

        public const float FORCE_TO_HOLE = 50f;

        #endregion

        #region Hole Settings

        public const float HoleSpeedZ = .3f;
        public const float HoleSpeedX = .2f;

        #endregion

    }
}
