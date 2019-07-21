using Gestor.Domain.Repositories;
using System;

namespace Gestor.Infrastructure.FileSystem.Repositories
{
    internal class ImageRepository : IImageRepository
    {
        public void Upload<T>(Guid id, string imageBase64) where T : class
        {
            //TODO: implementar
        }

        public byte[] Get<T>(Guid id) where T : class
        {
            //TODO: implementar

            return null;
        }

        public bool Has<T>(Guid id) where T : class
        {
            //TODO: implementar

            return false;
        }
    }
}