using ASPCoreWithAngular.Interfaces;
using ASPCoreWithAngular.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.DataAccess
{
    public class PersonalDataAccessLayer : IPersonal
    {
        private string connectionString;
        public PersonalDataAccessLayer(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        //To View all employees details
        public IEnumerable<Personal> GetAllPersonal()
        {
            try
            {
                List<Personal> lstemployee = new List<Personal>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllPersonal", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Personal personal = new Personal();

                        personal.IdPersonal = Convert.ToInt32(rdr["IdPersonal"]);
                        personal.ApPaterno = rdr["ApPaterno"].ToString();
                        personal.ApMaterno = rdr["ApMaterno"].ToString();
                        personal.Nombre1 = rdr["Nombre1"].ToString();
                        personal.Nombre2 = rdr["Nombre2"].ToString();
                        personal.NombreCompleto = rdr["NombreCompleto"].ToString();
                        personal.FchNac = rdr["FchNac"].ToString(); ;
                        personal.FchIngreso = rdr["FchIngreso"].ToString(); ;

                        lstemployee.Add(personal);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record 
        public int AddPersonal(Personal personal)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddPersonal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPersonal", personal.IdPersonal);
                    cmd.Parameters.AddWithValue("@ApPaterno", personal.ApPaterno);
                    cmd.Parameters.AddWithValue("@ApMaterno", personal.ApMaterno);
                    cmd.Parameters.AddWithValue("@FchIngreso", personal.FchIngreso);
                    cmd.Parameters.AddWithValue("@FchNac", personal.FchNac);
                    cmd.Parameters.AddWithValue("@Nombre1", personal.Nombre1);
                    cmd.Parameters.AddWithValue("@Nombre2", personal.Nombre2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee
        public int UpdatePersonal(Personal personal)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spActualizarPersonal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPersonal", personal.IdPersonal);
                    cmd.Parameters.AddWithValue("@ApPaterno", personal.ApPaterno);
                    cmd.Parameters.AddWithValue("@ApMaterno", personal.ApMaterno);
                    cmd.Parameters.AddWithValue("@Nombre1", personal.Nombre1);
                    cmd.Parameters.AddWithValue("@Nombre2", personal.Nombre2);
                    cmd.Parameters.AddWithValue("@FchNac", personal.FchNac);
                    cmd.Parameters.AddWithValue("@FchIngreso", personal.FchIngreso);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee
        public Personal GetPersonalData(int id)
        {
            try
            {
                Personal personal = new Personal();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM PERSONAL WHERE IdPersonal= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        personal.IdPersonal = Convert.ToInt32(rdr["IdPersonal"]);
                        personal.ApPaterno = rdr["ApPaterno"].ToString();
                        personal.ApMaterno = rdr["ApMaterno"].ToString();
                        personal.Nombre1 = rdr["Nombre1"].ToString();
                        personal.Nombre2 = rdr["Nombre2"].ToString();
                        personal.FchNac = rdr["FchNac"].ToString(); ;
                        personal.FchIngreso = rdr["FchIngreso"].ToString(); ;

                    }
                }
                return personal;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular employee
        public int DeletePersonal(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spBorrarPersonal", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPersonal", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //    public List<City> GetCities()
        //    {
        //        try
        //        {
        //            List<City> lstCity = new List<City>();

        //            using (SqlConnection con = new SqlConnection(connectionString))
        //            {
        //                SqlCommand cmd = new SqlCommand("spGetCityList", con);
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                con.Open();
        //                SqlDataReader rdr = cmd.ExecuteReader();

        //                while (rdr.Read())
        //                {
        //                    City city = new City();

        //                    city.CityId= Convert.ToInt32(rdr["CityID"]);
        //                    city.CityName = rdr["CityName"].ToString();
        //                    lstCity.Add(city);
        //                }
        //                con.Close();
        //            }
        //            return lstCity;
        //        }
        //        catch
        //        {
        //            throw;
        //        }
        //    }
    }
}
