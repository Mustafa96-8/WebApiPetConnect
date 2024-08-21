namespace WebApp.API.Domain
{
    public class MainPhoto
    {
        public MainPhoto(string path)
        {
            Path = path;
        }
        public string Path { get; private set; }

    }
