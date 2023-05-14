using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.DBInterface;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.Domain.DataBase
{
    public class FileDataBase<T> : IDatabase<T> where T : BaseEntity
    {
        private string _folderPath;
        private string _filePath;
        private int _id;
        public FileDataBase()
        {
            _folderPath = @"..\..\..\Database";
            _filePath = _folderPath + $@"\{typeof(T).Name}s.json";

            if (File.Exists(_filePath))
            {
                List<T> values = ReadFromFile();
                if (values.Any())
                {
                    _id = values.Last().Id;
                }
                else
                {
                    _id = 0;
                }
            }
            else
            {
                _id = 0;
            }

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
                WriteToFile(new List<T>());
            }
        }

        private List<T> ReadFromFile()
        {
            string content = "";
            using (StreamReader sr = new StreamReader(_filePath))
            {
                content = sr.ReadToEnd();
            }

            List<T> result = JsonConvert.DeserializeObject<List<T>>(content);

            return result;
        }

        private List<User> ReadUsersFromFile()
        {
            string content = "";
            using (StreamReader sr = new StreamReader(_filePath))
            {
                content = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<User>>(content);
        }

        private void WriteToFile(List<T> values)
        {
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                string content = JsonConvert.SerializeObject(values);

                sw.WriteLine(content);
            }

        }
        public int Add(T entity)
        {

            entity.Id = _id++;
            List<T> values = ReadFromFile();
            values.Add(entity);

            WriteToFile(values);
            _id++;
            return _id;
        }

        public List<T> GetAll()
        {
            return ReadFromFile();
        }

        public T GetById(int id)
        {
            List<T> values = ReadFromFile();
            return values.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveById(int id)
        {
            List<T> values = ReadFromFile();
            T entityForRemove = values.FirstOrDefault(x => x.Id == id);
            if (entityForRemove == null)
            {
                throw new Exception($"Entity with id {id} does not exist!");
            }

            values.Remove(entityForRemove);
            WriteToFile(values);
        }

        public void Update(T entity)
        {
            List<T> values = ReadFromFile();
            T entityForUpdate = values.FirstOrDefault(x => x.Id == entity.Id);
            if (entityForUpdate == null)
            {
                throw new Exception($"Entity with id {entity.Id} was not found");
            }

            int index = values.IndexOf(entityForUpdate);
            values[index] = entity;

            WriteToFile(values);
        }

        public User GetByUsername(string username)
        {
            List<User> users = ReadUsersFromFile();
            User user = users.FirstOrDefault(x => x.Username == username);
            return user;           
        }
    }
}