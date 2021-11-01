using Core.Entities;

namespace Entities.DTOs
{
    public class FileDto : IDto
    {
        public string FileExtension { get; set; }
        public string FileContent { get; set; }
    }
}
