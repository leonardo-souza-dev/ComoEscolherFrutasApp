using System.Threading.Tasks;

namespace Como.Data
{
    public interface IPicture
    {
        void SavePictureToDisk(string filename, byte[] imageData);
    }
}
