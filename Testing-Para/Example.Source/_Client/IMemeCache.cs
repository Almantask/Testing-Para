namespace Example.Source._Client
{
    public interface IMemeCache
    {
        void Add(string meme);
        string GetRandom();
    }
}