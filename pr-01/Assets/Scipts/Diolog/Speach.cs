public class Speach
{

    private string _initPhrase;
    private string[] _speach;

    public Speach(string initPhrase, string[] speach)
    {
        _initPhrase = initPhrase;
        _speach = speach;
    }

    public string GetInitPhrase() => _initPhrase;

    /// TODO
    /// Devide a speach into independent phrases
    //public string NextPhrase() => 

    public bool TryGetSpeachByIndex(int index, out string res)
    {
        res = _speach[index];
        return index < _speach.Length;
    }
}
