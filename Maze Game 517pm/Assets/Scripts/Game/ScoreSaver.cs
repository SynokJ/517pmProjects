public static class ScoreSaver
{

    private static int _scoreTarget;
    private static int _scoreCurrent;



    public static void InitScoreTarget(int targetNum) => _scoreTarget = targetNum;
    public static bool IsTargetReached() => _scoreCurrent >= _scoreTarget;
    public static void AddScore() => _scoreCurrent++;
}
