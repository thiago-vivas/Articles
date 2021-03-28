using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._5.D
{
    public class BusinessLayer
    {
        private readonly IRepositoryLayer repositoryLayer;

        public BusinessLayer(IRepositoryLayer repositoryLayer)
        {
            this.repositoryLayer = repositoryLayer;
        }
        public void AddItem(int itemId)
        {
            if (!string.IsNullOrEmpty(repositoryLayer.GetItem(itemId)))
                repositoryLayer.Update();
            else
                repositoryLayer.Create();
        }
    }
    public interface IRepositoryLayer
    {
        void Create();

        void Delete();

        void Update();

        string GetItem(int itemId);
    }
}
