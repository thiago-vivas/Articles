using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._5.D.Problem
{
    public class BusinessLayer
    {
        public void AddItem(int itemId)
        {
            RepositoryLayer repositoryLayer = new RepositoryLayer();
            if (!string.IsNullOrEmpty(repositoryLayer.GetItem(itemId)))
                repositoryLayer.Update();
            else
                repositoryLayer.Create();
        }
    }
    public class RepositoryLayer
    {
        public void Create()
        {
            //save data into the Database
        }
        public void Delete()
        {
            //delete data from the Database
        }
        public void Update()
        {
            //update data in the Database
        }
        public string GetItem(int itemId)
        {
            //get item from the Database
            return "item";
        }
    }
}
