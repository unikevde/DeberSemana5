using DeberSemana5.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeberSemana5
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        //Mensaje a mostrar
        public string StatusMessage {  get; set; }
        // TODO:Add variable for the SQLite connection
        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();

        }
        public PersonRepository(string dbPath1)
        { dbPath = dbPath1; }

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                //Validar que se ingrese el nombre
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");
                Persona person = new() { Name = nombre };
                result = conn.insert(person);
                StatusMessage = string.Format("{0} record(s) added(Nombre:{1}", result, nombre);
                
            }
            catch (Exception ex) 
            {
                StatusMessage=string.Format("Falied to add {0}.Error:{1}",nombre,ex.Message);

            }
        }
        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex) 
            {
                StatusMessage = string.Format("Falied to retrieve data.{0}", ex.Message);

            }
            return new List<Persona>();

        }
    }
}
